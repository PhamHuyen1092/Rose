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
    public partial class addItem : Form
    {
        sqlClass sqlconnect;
        string table;
        public addItem(sqlClass sqlconnect,string table)
        {
            this.sqlconnect = sqlconnect;
            this.table = table;
            InitializeComponent();
        }

        private void addItem_Load(object sender, EventArgs e)
        {
            
            sqlconnect = new sqlClass(sqlconnect.IPserver, "TRACKING_SYSTEM", "admin", "ManuAdmin$123"); ;
        }
        public void refresh()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (table == "DEFINE_CUSTOMER")
                {
                    if (!sqlconnect.InsertDataMySQL("insert into DEFINE_CUSTOMER (CUSTOMER_NAME,CUSTOMER_ID) values('" + textBox2.Text + "','" + textBox1.Text + "');"))
                    {
                        MessageBox.Show("FAIL!");
                        return;
                    }
                    MessageBox.Show("DONE!");
                    refresh();
                    return;
                }
                else
                {
                    if (!sqlconnect.InsertDataMySQL("insert into PART_MODEL_CONTROL (MODEL_NAME,ID_MODEL) values('" + textBox2.Text + "','" + textBox1.Text + "');"))
                    {
                        MessageBox.Show("FAIL!");
                        return;
                    }
                    MessageBox.Show("DONE!");
                    refresh();
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("FAIL!");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (table == "DEFINE_CUSTOMER")
                {
                    if (!sqlconnect.InsertDataMySQL("delete from DEFINE_CUSTOMER where CUSTOMER_NAME='" + textBox2.Text + "';"))
                    {
                        MessageBox.Show("FAIL!");
                        return;
                    }
                    MessageBox.Show("DONE!");
                    refresh();
                    return;
                }
                else
                {
                    if (!sqlconnect.InsertDataMySQL("delete from PART_MODEL_CONTROL where ID_MODEL='" + textBox1.Text + "';"))
                    {
                        MessageBox.Show("FAIL!");
                        return;
                    }
                    MessageBox.Show("DONE!");
                    refresh();
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("FAIL!");
                return;
            }
        }
    }
}
