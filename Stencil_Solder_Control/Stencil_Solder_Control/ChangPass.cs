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
    public partial class ChangPass : Form
    {
        string serverip;
        public string oldpass;
        string user;
        sqlClass sqlconnect;
        public ChangPass(string oldpass,string user, string serverip)
        {
            this.user = user;
            this.oldpass = oldpass;
            this.serverip = serverip;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtconfirm.Text==""||txtnewpass.Text==""||txtoldpass.Text=="")
            {
                MessageBox.Show("Không được bỏ trống !!!");
                return;
            }
            if(txtnewpass.Text!=txtconfirm.Text)
            {
                MessageBox.Show("Password mới không được xác nhận thành công !!!");
                return;
            }
            if (txtoldpass.Text != oldpass)
            {
                MessageBox.Show("Password không đúng");
                return;
            }
            try
            {
                sqlconnect.InsertDataMySQL("update TRACKING_SYSTEM.USER_CONTROL set USER_PASSWORD='" + txtconfirm.Text + "' where USER_ID='" + user + "';");
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("FAIL");
                return;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangPass_Load(object sender, EventArgs e)
        {
            sqlconnect= new sqlClass(serverip, "TRACKING_SYSTEM", "admin", "ManuAdmin$123");
        }
    }
}
