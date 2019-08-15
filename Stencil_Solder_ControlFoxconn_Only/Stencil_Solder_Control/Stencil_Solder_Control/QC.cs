using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stencil_Solder_Control
{
    public partial class QC : Form
    {
        public sqlClass conn{get;set;}
        public bool updateDone { get; set; }
        public QC(sqlClass conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void QC_Load(object sender, EventArgs e)
        {
            updateDone = false;
            txtuser.Focus();
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if(txtpass.Text==""||txtuser.Text==""||rtbconfirm.Text=="")
            {
                MessageBox.Show("all information can not be empty!!!");
                    return;
            }
            try
            {
               if(conn.GetDataMySQL("select * from QC_USER where USER='" + txtuser.Text.Trim() + "' and PASS='" + txtpass.Text.Trim() + "'").Rows.Count!=0)
                {
                    MessageBox.Show("Update success!!");
                    this.updateDone = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("this account is invalid!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("this account is invalid!");
                return;
            }
        }

        private void txtuser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtpass.Focus();
            }
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                rtbconfirm.Focus();
            }
        }
    }
}
