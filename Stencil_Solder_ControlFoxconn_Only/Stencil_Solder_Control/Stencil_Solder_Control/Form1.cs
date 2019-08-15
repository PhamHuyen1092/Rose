using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Net;
using Tarczynski.NtpDateTime;
using System.Threading;
using Microsoft.Office.Interop;
using Excel;

namespace Stencil_Solder_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string server_ip = "172.16.10.3";
        string server_port = "3306";
        sqlClass sqlconnect;
        JObject Json_read;
        bool login = false;
        bool checkrunning = false;
        int gbindex = 1;
        int counttimeThaw = 1;
        int timeSpin = 240;
        int authority;
        int timewash = 14400;
        int timThawing;
        int lengtbarcode;
        int counttmstatus = 0;
        int countinThreadShow = 0;
        int MaxTimeDelayWashingStencil;
        List<NewTimmer> listTimeer;
        List<int> countListTimemrShow;
        List<TimeSpan> timespanShow;
        bool showInfoRealtime = true;
        int panel1_width = 874;
        int panel1_height =205;
        string user = "";
        DataTable fromExcel;
        updateHistory history;
        string pretext = "GP";
        TimeSpan timeSpan;
        GroupBox[] listGP = new GroupBox[8];
        /// <summary>
        /// 1 gblogin
        /// 2 gbputin
        /// 3 gbputout
        /// 4 gbSpin
        /// 5 gbputinSMT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        Thread thawSolder;
        Thread washStencil;
        Thread showAllinfo;
        


        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty( txtpass.Text)||string.IsNullOrEmpty( txtuser.Text))
            {
                MessageBox.Show("user name and password can not be empty!");
                return;
            }
            else
            {
                sqlconnect = new sqlClass(server_ip, "TRACKING_SYSTEM", "admin", "ManuAdmin$123");
                DataTable dt = sqlconnect.GetDataMySQL("select * from USER_CONTROL where USER_ID='" + txtuser.Text.Trim() + "'");
                
                try
                {
                    if(dt.Rows[0]["USER_PASSWORD"].ToString().Trim()==txtpass.Text.Trim())
                    {
                        login = true;
                        gbLogIn.Text = "Welcome";
                        gbLogIn.ForeColor = Color.Blue;
                        pnwelcome.Visible = true;
                        lbwelcome.Text = "welcome: "+dt.Rows[0]["USER_NAME"];
                        user = txtuser.Text.Trim();
                        authority =Convert.ToInt16(  dt.Rows[0]["AUTHORITY"].ToString());
                        tmlocalTIme.Start();
                        //tmtimeLeft.Start();
                        //gbLogIn.Visible = false;
                        sqlconnect = new sqlClass(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");
                        tmstatus.Start();
                        return;
                    }
                }
                catch
                {

                }

                login = false;
                gbLogIn.Text = "Login Fail";
                gbLogIn.ForeColor = Color.Red;
                txtpass.Text = "";
                
                return;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
            if (!File.Exists(".\\Setting.js"))
            {
                MessageBox.Show(" Check file setting.js not exits!");
                Application.Exit();
            }
            Json_read = JObject.Parse(File.ReadAllText(".\\Setting.js"));
            server_ip = (string)Json_read["ServerIP"];
            server_port = (string)Json_read["ServerPort"];
            timeSpin = (int)Json_read["TimeSpin"];
            timewash = (int)Json_read["TimeWashSpencil"];
            timThawing = (int)Json_read["TimeThaw"];
            pretext = (string)Json_read["pretext"];
            MaxTimeDelayWashingStencil = (int)Json_read["MaxTimeDelayWashingStencil"];
            //lengtbarcode = (int)Json_read["LenghtBarcode"];
            listGP[1] = gbLogIn;
            listGP[2] = gbPutin;
            listGP[3] = gbPutout;
            listGP[4] = gbSpinSolder;
            listGP[5] = gbPutinSMT;
            listGP[6] = gbsticklable;
            listGP[7] = gbCheckinfo;
            //
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //history = new updateHistory() { action = 2, time = DateTime.Now.FromNtp().ToString("yyyy-MM-dd hh:mm:ss") };
            //string aa = Newtonsoft.Json.JsonConvert.SerializeObject(history);
            ////string a=DateTime.Now.FromNtp().ToString();
            //System.Net.Sockets.TcpClient t = new System.Net.Sockets.TcpClient("172.16.10.3", 13);
            //System.IO.StreamReader rd = new System.IO.StreamReader(t.GetStream());
            //a = rd.ReadToEnd();
            // timeSpan = TimeSpan.FromSeconds(62);
            //string a = "Wait:" + timeSpan.ToString("hh':'mm':'ss");

            //dtgridShowinfo.Visible = true;
            ////panel1.Visible = false;
            //showAllinfo = new Thread(updategrivewInfo);
            //showAllinfo.IsBackground = true;
            //showAllinfo.Start();
            //updateHistory history = new updateHistory() { action = 1,time = "aaa"    };
            //string aa=Newtonsoft.Json.JsonConvert.SerializeObject(history);
            //sqlClass sqlconnect = new sqlClass(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");
            //DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE='123456789016'");
            //string history = dt.Rows[0]["HISTORY"].ToString();
            //string aa = history.Substring(0, history.Length - 1);
            //updateHistory k = new updateHistory() { action = 2, time = DateTime.Now.FromNtp().ToString("yyyy-MM-dd hh:mm:ss"), historyuser = "123" };
            //history = history.Substring(0, history.Length - 1) +","+ Newtonsoft.Json.JsonConvert.SerializeObject(k) + "]";
            //JArray b =(JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(history);
            ////ListHistory a=Newtonsoft.Json.JsonConvert.DeserializeObject("[{"action":2,"historyuser":"MV0001179","time":"2019 - 07 - 06 09:24:14"},{"action":3,"historyuser":"MV0001179","time":"2019 - 07 - 08 09:23:03"},{"action":1,"historyuser":"MV0001179","time":"2019 - 07 - 08 09:23:32"},{"action":1,"historyuser":"MV0001179","time":"2019 - 07 - 08 09:44:38"},{"action":4,"historyuser":"MV0001179","time":"2019 - 07 - 08 10:29:42"},{"action":5,"historyuser":"MV0001179","time":"2019 - 07 - 08 10:32:21"}]")
            //JArray a =  (JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(dt.Rows[0]["HISTORY"].ToString());
            //foreach(JObject tem in b)
            //{
            //    if(tem["action"].ToString()=="2")
            //    {
            //        MessageBox.Show("found");
            //    }
            //}

            //StreamWriter a = new StreamWriter(".\\debug.txt");
            //a.Write(aa);
            //a.Close();

            panel1.Width = panel1_width;
            panel1.Height = panel1_height;
        }


        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpass.Text = "";
            txtuser.Focus();
            dtgridShowinfo.Visible = false;
            gbCheckinfo.Visible = false;
            panel1.Width = panel1_width;
            panel1.Height = panel1_height;
            panel1.Visible = true;
            gbLogIn.Visible = true;
            gbLogIn.BringToFront();
            gbLogIn.Text = "Login";
            gbLogIn.ForeColor = Color.Black;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblocaltime.Text= "Local Time:"+ DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }
        public string getnewhistory(object history, string barcode)
        {
            //DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE='" + barcode + "'");
            //string newHistory =dt.Rows[0]["HISTORY"].ToString();
            //newHistory = newHistory.Substring(0, newHistory.Length - 1) + "," + Newtonsoft.Json.JsonConvert.SerializeObject(history) + "]";
            //return newHistory;

            DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE='" + barcode + "'");
            return dt.Rows[0]["HISTORY"].ToString() + "," + Newtonsoft.Json.JsonConvert.SerializeObject(history);
        }
      
        private void tmServerTime_Tick(object sender, EventArgs e)
        {
            //lbservertime.Text="Server Time:"+ DateTime.Now.FromNtp().ToString("yyyy/MM/dd hh: mm:ss");
            //if (gbindex == 5)
            //{
            //    //if (counttimeThaw < 1)
            //    //{
            //    //    txtputinSMTconfirm.Enabled = true;
            //    //    gbPutinSMTstatus.Text = "This Stencil is up to date, please take it out to washing!!!";
            //    //    txtputinSMTconfirm.Enabled = true;
            //    //    Form2 show= new Form2();
            //    //    show.Show();
            //    //    this.Invoke((MethodInvoker)delegate { tmtimeLeft.Stop(); });
            //    //}
            //    //else
            //    //{
            //    //    counttimeThaw--;
            //    //    timeSpan = TimeSpan.FromSeconds(counttimeThaw);
            //    //    lbputinsmtTimeleft.Text = "Time Left:" + timeSpan.ToString("hh':'mm':'ss");
                   
            //    //}
                
            //}
            //else if(gbindex==4)
            //{
            //    if (counttimeThaw < 1)
            //    {
            //        history = new updateHistory() { action = 4, time = DateTime.Now.FromNtp().ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };                    
            //        if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=4, TIME_END_USE=now(),HISTORY='" + getnewhistory(history, txtspinserial.Text.Trim()) + "' where BARCODE='" + txtspinserial.Text.Trim() + "'"))
            //        {

            //            lbspinstatus.Text = "FAIL";
            //            lbspinstatus.ForeColor = Color.Red;
            //            return;
            //        }
            //        else
            //        {

            //            rbspinNote.Text = "Spin done, Please take out Solder !!!";
            //            txtspinserial.Text = "";
            //            txtspinserial.Focus();
            //            lbspinstatus.Text = "PASS";
            //            lbspinstatus.ForeColor = Color.Green;
                        
            //        }
            //        this.Invoke((MethodInvoker)delegate { tmtimeLeft.Stop(); });
            //        gbindex = 4;
            //        counttmstatus = 0;
            //        //txtspinconfirm.Text = "";
            //        checkrunning = false;
            //        txtspinconfirm.Enabled = false;
            //       // txtspinserial.Text = "";
                    
            //        //txtspinconfirm.Enabled = true;
            //        //this.Invoke((MethodInvoker)delegate { tmtimeLeft.Stop(); });
            //    }
            //    else
            //    {
            //        counttimeThaw--;
            //        // DateTime.Parse()
            //        timeSpan = TimeSpan.FromSeconds(counttimeThaw);
            //        lbspinTimeLeft.Text = "Wait:" +timeSpan.ToString("hh':'mm':'ss");
            //    }
            //}
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnlogin_Click(sender,e);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtpass.Text = "";
            txtuser.Text = "";
            user = "";
            login = false;
            gbLogIn.ForeColor = Color.Black;
            gbLogIn.Visible = true;
            gbLogIn.BringToFront();
            gbLogIn.Text = "Login";
            panel1.Visible = true;
            dtgridCheckInfo.Visible = false;
            dtgridShowinfo.Visible = false;
        }

        private void putInStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbbputinsearch.SelectedIndex = 0;
            if(authority!=5&&authority!=0)
            {
                MessageBox.Show("chức năng này chỉ dùng cho bộ phận Kho!");
                    return;
            }
            dataGridView1.Visible = false;
            dtgridputinstore.Visible = true;
            loadForm(gbPutin);
            txtputinSMTserial.Focus();
        }

        private void txtputinSerial_KeyDown(object sender, KeyEventArgs e)
        {
            rbputinNote.Text = "";
            dtgridputinstore.Visible = true;
            dataGridView1.Visible = false;
            DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
            if (e.KeyCode==Keys.Enter)
            {
                //if(txtputinSerial.Text.Trim().Length!=lengtbarcode)
                //{
                //    lbputinstatus.Text = "FAIL";
                //    lbputinstatus.ForeColor = Color.Red;
                //    rbputinNote.Text = "This barcode is wrong format!!!";
                //    return;
                //}
                history = new updateHistory() { action = 2, time =servernow.ToString("yyyy-MM-dd hh:mm:ss") , historyuser = this.user};
                DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE='" + txtputinSerial.Text + "' ");
                if(dt.Rows.Count==0)
                {
                    if (sqlconnect.InsertDataMySQL("insert into STENCIL_SOLDER_CONTROL (BARCODE,DATE_STORE,STATE,HISTORY) values('" + txtputinSerial.Text.Trim() + "',curdate(),2,'" + Newtonsoft.Json.JsonConvert.SerializeObject(history) + "')"))
                    {
                        txtputinSerial.Text = "";
                        txtputinSerial.Focus();
                        lbputinstatus.Text = "PASS";
                        lbputinstatus.ForeColor = Color.Green;
                        try
                        {
                            dtgridputinstore.Rows.Clear();
                            DataTable dt_ = sqlconnect.GetDataMySQL("select BARCODE,DATE_STORE,STATE,ADRESS from STENCIL_SOLDER_CONTROL ORDER BY ID DESC LIMIT 0,10");
                            for (int i = 0; i < dt_.Rows.Count; i++)
                            {
                                dtgridputinstore.Rows.Add("False", dt_.Rows[i]["BARCODE"].ToString(), dt_.Rows[i]["DATE_STORE"].ToString(), dt_.Rows[i]["STATE"].ToString(), dt_.Rows[i]["ADRESS"].ToString());
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        lbputinstatus.Text = "FAIL";
                        lbputinstatus.ForeColor = Color.Red;
                    }

                }else
                {
                    if (sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=2, ADRESS='STORE', HISTORY='" + getnewhistory(history,txtputinSerial.Text)+ "' where BARCODE='" + txtputinSerial.Text + "'"))
                    {

                        txtputinSerial.Text = "";
                        txtputinSerial.Focus();
                        lbputinstatus.Text = "PASS";
                        lbputinstatus.ForeColor = Color.Green;
                        try
                        {
                            dtgridputinstore.Rows.Clear();
                            DataTable dt_ = sqlconnect.GetDataMySQL("select BARCODE,DATE_STORE,STATE,ADRESS from STENCIL_SOLDER_CONTROL ORDER BY ID DESC LIMIT 0,10");
                            for (int i = 0; i < dt_.Rows.Count; i++)
                            {
                                dtgridputinstore.Rows.Add("False", dt_.Rows[i]["BARCODE"].ToString(), dt_.Rows[i]["DATE_STORE"].ToString(), dt_.Rows[i]["STATE"].ToString(), dt_.Rows[i]["ADRESS"].ToString());
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        lbputinstatus.Text = "FAIL";
                        lbputinstatus.ForeColor = Color.Red;
                    }

                }

                #region old
                //if (sqlconnect.InsertDataMySQL("insert into STENCIL_SOLDER_CONTROL (BARCODE,DATE_STORE,STATE,HISTORY) values('" + txtputinSerial.Text.Trim()+ "',curdate(),2,'["+ Newtonsoft.Json.JsonConvert.SerializeObject(history)+"]')")|| sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=2, LINE='null', HISTORY=concat(HISTORY,',"+ Newtonsoft.Json.JsonConvert.SerializeObject(history)+"') where BARCODE='" + txtputinSerial.Text + "'"))
                //{

                //    txtputinSerial.Text = "";
                //    txtputinSerial.Focus();
                //    lbputinstatus.Text = "PASS";
                //    lbputinstatus.ForeColor = Color.Green;

                //}
                //else
                //{
                //    if (sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where STATE=2 and BARCODE='" + txtputinSerial.Text.Trim() + "'").Rows.Count != 0)
                //    {
                //        rbputinNote.Text = "This barcode already in store!!!";
                //    }
                //    lbputinstatus.Text = "FAIL";
                //    lbputinstatus.ForeColor = Color.Red;

                //}
                #endregion
                counttmstatus = 0;
                gbindex = 2;
            }
        }

        private void tmstatus_Tick(object sender, EventArgs e)
        {
            counttmstatus++;
            switch (gbindex)
            {
                case 2:
                    
                    if (counttmstatus == 3)
                    {
                        lbputinstatus.Text = "WAITE";
                        lbputinstatus.ForeColor = Color.Black;
                    }
                    
                    break;
                case 3:
                    
                    if (counttmstatus == 3)
                    {
                        lbPutoutstatus.Text = "WAITE";
                        lbPutoutstatus.ForeColor = Color.Black;
                    }
                    break;
                    
                case 4:
                   
                    if (counttmstatus == 3)
                    {
                        lbspinstatus.Text = "WAITE";
                        lbspinstatus.ForeColor = Color.Black;
                    }

                    break;
                case 6:
                        if (counttmstatus == 3)
                    {
                        lbstickstatus.Text = "WAITE";
                        lbstickstatus.ForeColor = Color.Black;
                    }

                    break;
                case 5:
                    if(counttmstatus==3)
                    {
                        lbputinSMTstatus.Text = "WAITE";
                        lbputinSMTstatus.ForeColor = Color.Black;
                    }
                    break;



            }
        }

        private void txtputoutserial_KeyDown(object sender, KeyEventArgs e)
        {
            rtputoutNote.Text = "";
            DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
            if (e.KeyCode == Keys.Enter)
            {
                history = new updateHistory() { action = 3, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };
                //check barcode have in store or not
                if (sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where STATE=2 and BARCODE='" + txtputoutserial.Text.Trim() + "'").Rows.Count == 0)
                {
                    rtputoutNote.Text = "This Barcode not exist on Store!!!";
                    lbPutoutstatus.Text = "FAIL";
                    lbPutoutstatus.ForeColor = Color.Red;
                    gbindex = 3;
                    counttmstatus = 0;
                    return;
                }
                //this case for Stencil dont need control FIFO
                if (!txtputoutserial.Text.Contains(pretext))
                {
                    if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=3, TIME_START_USE=now(),HISTORY='"+getnewhistory(history, txtputoutserial.Text.Trim()) +"' where BARCODE='" + txtputoutserial.Text.Trim() + "'"))
                    {

                        lbPutoutstatus.Text = "FAIL";
                        lbPutoutstatus.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtputoutserial.Text = "";
                        txtputoutserial.Focus();
                        lbPutoutstatus.Text = "PASS";
                        lbPutoutstatus.ForeColor = Color.Green;
                    }
                    gbindex = 3;
                    counttmstatus = 0;
                    return;
                }
                //this case for Solder paste need to be control by FIFO
                DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where STATE=2 and BARCODE like'"+pretext+ "%' and DATE_STORE <= (select MIN(DATE_STORE) from STENCIL_SOLDER_CONTROL where STATE=2)");                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(dt.Rows[i]["BARCODE"].ToString()==txtputoutserial.Text.Trim())
                    {
                        if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=3, TIME_START_USE=now(),HISTORY=concat(HISTORY,'," + Newtonsoft.Json.JsonConvert.SerializeObject(history) + "') where BARCODE='" + txtputoutserial.Text.Trim() + "'"))
                        {
                            
                            lbPutoutstatus.Text = "FAIL";
                            lbPutoutstatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            txtputoutserial.Text = "";
                            txtputoutserial.Focus();
                            lbPutoutstatus.Text = "PASS";
                            lbPutoutstatus.ForeColor = Color.Green;
                        }
                        gbindex = 3;
                        counttmstatus = 0;
                        return;
                    }
                }
                
                //if dont feed FIFO
                {
                    rtputoutNote.Text = "This is not correct item should be used\r\n breaking FIFO control!!!";
                    lbPutoutstatus.Text = "FAIL";
                    lbPutoutstatus.ForeColor = Color.Red;
                }
                gbindex = 3;
                counttmstatus = 0;
            }
        }

        private void putOutStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authority != 5 && authority != 0)
            {
                MessageBox.Show("chức năng này chỉ dùng cho bộ phận Kho!");
                    return;
            }
            loadForm(gbPutout);
            txtputoutserial.Focus();
        }

        private void spinSolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            loadForm(gbSpinSolder);
            //txtspinconfirm.Enabled = false;
            txtspinconfirm.Text = "";
            txtspinserial.Text = "";
            rbspinNote.Text = "";
            txtspinserial.Focus();
        }
        void loadForm(GroupBox temp )
        {
            if (!login)
            {
                MessageBox.Show("Please login first!");
                return;
            }
           // dtgridCheckInfo.Visible = false;
            dtgridShowinfo.Visible = false;
            panel1.Width = panel1_width;
            panel1.Height = panel1_height;
            foreach (GroupBox item in listGP)
            {
                try
                {
                    if (item.Name == temp.Name)
                    {
                        panel1.Visible = true;
                        item.Visible = true;



                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
                catch { }
            }
        }
        private void putInSMTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(gbPutinSMT);
            //txtputinSMTconfirm.Enabled = false;
            lbputinsmtTimeleft.Text = "Time left";
            txtputinSMTserial.Focus();
            //cbputinSMTLine.DisplayMember = "SMT01";
            //cbputinSMTLine.SelectedIndex = 0;
        }
        void funthreadThawSolder()
        {
            this.Invoke((MethodInvoker)delegate
            {
                rbspinNote.Text = "";
            });            
            DataTable dt = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where (STATE=8 or STATE=1)and BARCODE='" + txtspinserial.Text.Trim() + "'");
            gbindex = 4;
            if (dt.Rows.Count==0)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    rbspinNote.Text = "This Barcode is invalid for this station!!!";
                    lbspinstatus.Text = "FAIL";
                    lbspinstatus.ForeColor = Color.Red;
                    
                    counttmstatus = 0;
                    return;
                });
                
            }
            else
            {
                string state = dt.Rows[0]["STATE"].ToString();
                DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                TimeSpan count = servernow - Convert.ToDateTime(dt.Rows[0]["TIME_START_USE"]);
                if (state.Contains("8"))
                {
                    if (count.TotalSeconds < timThawing)
                    {
                        int wait = (timThawing) - Convert.ToInt16(count.TotalSeconds);
                        this.Invoke((MethodInvoker)delegate
                        {
                            rbspinNote.Text = "This Solder paste need to thaw  atleast " + timThawing + " seconds!!!\r\n Need wait about " + wait + " seconds to finish";
                            lbspinstatus.Text = "FAIL";
                            lbspinstatus.ForeColor = Color.Red;
                            gbindex = 4;
                            counttmstatus = 0;
                        });

                    }
                    else
                    {
                        history = new updateHistory() { action = 1, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };
                        if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=1, TIME_START_USE=now(),HISTORY='"+getnewhistory(history, txtspinserial.Text.Trim()) + "' where BARCODE='" + txtspinserial.Text.Trim() + "'"))
                        {

                            lbspinstatus.Text = "FAIL";
                            lbspinstatus.ForeColor = Color.Red;
                            return;
                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            lbspinstatus.Text = "ON GOING";
                            counttimeThaw = timeSpin;
                            timeSpan = TimeSpan.FromSeconds(counttimeThaw);
                            Thread temp = new Thread(() => coundown(false));
                            temp.IsBackground = true;
                            temp.Start();
                            //tmtimeLeft.Start();
                        });

                    }
                } else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lbspinstatus.Text = "ON GOING";
                        checkrunning = true;
                        counttimeThaw = timeSpin;
                        timeSpan = TimeSpan.FromSeconds(counttimeThaw);
                        Thread temp = new Thread(() => coundown(false));
                        temp.IsBackground = true;
                        temp.Start();
                        // tmtimeLeft.Start();
                    });
                }
            }
        }
        private void txtspinserial_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {

                rbspinNote.Text = "";
                txtspinconfirm.Text = "";
                if(!txtspinserial.Text.Contains(pretext))
                {
                    lbspinstatus.Text = "FAIL";
                    lbspinstatus.ForeColor = Color.Red;
                    rbspinNote.Text = "This function only use for Solder paste!!!";
                    return;
                }
                try
                {
                    if (thawSolder.IsAlive||checkrunning==true)
                    {
                        return;
                    }
                   
                }
                catch
                {

                }
                //txtspinconfirm.Enabled = false;
                thawSolder = new Thread(funthreadThawSolder);
                thawSolder.IsBackground = true;
                thawSolder.Start();

            }
        }

        private void txtspinserial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtspinconfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtspinconfirm.Text.Contains(pretext))
                {
                    lbspinstatus.Text = "FAIL";
                    lbspinstatus.ForeColor = Color.Red;
                    rbspinNote.Text = "This function only use for Solder paste!!!";
                    return;
                }
                history = new updateHistory() { action = 8, time = DateTime.Now.FromNtp().ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };
                if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=8, TIME_START_USE=now(),HISTORY='" + getnewhistory(history, txtspinserial.Text.Trim()) + "' where BARCODE='" + txtspinconfirm.Text.Trim() + "'"))
                {

                    lbspinstatus.Text = "FAIL";
                    lbspinstatus.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    txtspinserial.Text = "";
                    txtspinserial.Focus();
                    lbspinstatus.Text = "PASS";
                    lbspinstatus.ForeColor = Color.Green;
                }

                gbindex = 4;
                counttmstatus = 0;
                txtspinconfirm.Text = "";
                //checkrunning = false;
                //txtspinconfirm.Enabled = false;
                txtspinserial.Text = "";
                rbspinNote.Text = "";
            }
        }
       void coundown(bool temp)
        {
            while (counttimeThaw >= 0)
            {
                if (temp)
                {

                    if (counttimeThaw == 1)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            txtputinSMTconfirm.Enabled = true;
                            gbPutinSMTstatus.Text = "This Stencil is up to date, please take it out to washing!!!";
                            txtputinSMTconfirm.Enabled = true;
                            Form2 show = new Form2();
                            show.Show();

                        });
                        counttimeThaw--;
                        //this.Invoke((MethodInvoker)delegate { tmtimeLeft.Stop(); });
                    }
                    else
                    {
                        counttimeThaw--;
                        timeSpan = TimeSpan.FromSeconds(counttimeThaw);
                        this.Invoke((MethodInvoker)delegate
                        {
                            lbputinsmtTimeleft.Text = "Time Left:" + timeSpan.ToString("hh':'mm':'ss");
                        });
                    }

                }
                else
                {
                    if (counttimeThaw < 1)
                    {
                        DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                        history = new updateHistory() { action = 4, time =servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };
                        if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=4, TIME_END_USE=now(),HISTORY='" + getnewhistory(history, txtspinserial.Text.Trim()) + "' where BARCODE='" + txtspinserial.Text.Trim() + "'"))
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                lbspinstatus.Text = "FAIL";
                                lbspinstatus.ForeColor = Color.Red;
                            });
                            return;
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                rbspinNote.Text = "Spin done, Please take out Solder !!!";
                                txtspinserial.Text = "";
                                txtspinserial.Focus();
                                lbspinstatus.Text = "PASS";
                                lbspinstatus.ForeColor = Color.Green;
                            });
                        }

                        gbindex = 4;
                        counttmstatus = 0;
                        //txtspinconfirm.Text = "";
                        checkrunning = false;
                        //this.Invoke((MethodInvoker)delegate { txtspinconfirm.Enabled = false; });
                        return;
                        // txtspinserial.Text = "";

                        //txtspinconfirm.Enabled = true;
                        //this.Invoke((MethodInvoker)delegate { tmtimeLeft.Stop(); });
                    }
                    else
                    {
                        counttimeThaw--;
                        // DateTime.Parse()
                        timeSpan = TimeSpan.FromSeconds(counttimeThaw);
                        this.Invoke((MethodInvoker)delegate { lbspinTimeLeft.Text = "Wait:" + timeSpan.ToString("hh':'mm':'ss"); });
                    }
                }
                Thread.Sleep(1000);
            }
                
            
        }
        private void txtputinSMTserial_KeyDown(object sender, KeyEventArgs e)
        {
            gbPutinSMTstatus.Text = "";
            if (e.KeyCode==Keys.Enter)
            {
                gbindex = 5;
                //tmstatus.Start();
                if(!txtputinSMTserial.Text.Contains(pretext))// for stencil only
                {
                    try
                    {
                        #region oldcode
                        //this case for stencil already take out for using 
                        //DataTable dt = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where (STATE=5 or STATE=3) and BARCODE='" + txtputinSMTserial.Text.Trim() + "'");
                        //if (dt.Rows.Count == 0)
                        //{
                        //    //
                        //    lbputinSMTstatus.Text = "FAIL";
                        //    lbputinSMTstatus.ForeColor = Color.Red;
                        //    gbPutinSMTstatus.Text = "This Barcode is invalid!!!";
                        //    return;
                        //}else if(dt.Rows[0]["STATE"].ToString().Contains("5"))
                        //{ 
                        //    //
                        //    txtputinSMTserial.Text = "";
                        //    txtputinSMTserial.Focus();
                        //    lbputinSMTstatus.Text = "RUNNING";
                        //    lbputinSMTstatus.ForeColor = Color.Green;
                        //    counttmstatus = 4;
                        //    //tmstatus.Stop();
                        //    //gbindex = 5;
                        //    TimeSpan count = DateTime.Now.FromNtp() - Convert.ToDateTime(dt.Rows[0]["TIME_START_USE"]);
                        //    counttimeThaw = timewash-(int) count.TotalSeconds;
                        //    tmtimeLeft.Start();
                        //}                        
                        //else //this case for stencil already take out off store, start using in line STATE=3
                        //{
                        //    history = new updateHistory() { action = 5, time = DateTime.Now.FromNtp().ToString("yyyy-MM-dd hh:mm:ss"), historyuser=this.user,address=Environment.MachineName };
                        //    if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=5, ADRESS ='"+Environment.MachineName+"',TIME_START_USE=now(),HISTORY='"+getnewhistory(history, txtputinSMTserial.Text.Trim()) +"' where BARCODE='" + txtputinSMTserial.Text.Trim() + "'"))
                        //    {

                        //        lbputinSMTstatus.Text = "FAIL";
                        //        lbputinSMTstatus.ForeColor = Color.Red;
                        //    }
                        //    else
                        //    {
                        //        txtputinSMTserial.Text = "";
                        //        txtputinSMTserial.Focus();
                        //        lbputinSMTstatus.Text = "RUNNING";
                        //        lbputinSMTstatus.ForeColor = Color.Green;
                        //        counttmstatus = 4;
                        //        //tmstatus.Stop();
                        //        //gbindex = 5;
                        //        counttimeThaw = timewash;
                        //        tmtimeLeft.Start();
                        //    }

                        //}
                        #endregion

                        DataTable dt = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where (STATE=3 or STATE=6) and BARCODE='" + txtputinSMTserial.Text.Trim() + "'");
                        if (dt.Rows.Count == 0)
                        {
                            //
                            lbputinSMTstatus.Text = "FAIL";
                            lbputinSMTstatus.ForeColor = Color.Red;
                            gbPutinSMTstatus.Text = "This Barcode is invalid!!!";
                            return;
                        }                        
                        else //this case for stencil already take out off store, start using in line STATE=3
                        {
                            DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                            history = new updateHistory() { action = 5, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user, address = Environment.MachineName };
                            if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=5, ADRESS ='" + Environment.MachineName + "',TIME_START_USE=now(),HISTORY='" + getnewhistory(history, txtputinSMTserial.Text.Trim()) + "' where BARCODE='" + txtputinSMTserial.Text.Trim() + "'"))
                            {

                                lbputinSMTstatus.Text = "FAIL";
                                lbputinSMTstatus.ForeColor = Color.Red;
                            }
                            else
                            {
                                txtputinSMTserial.Text = "";
                                txtputinSMTserial.Focus();
                                lbputinSMTstatus.Text = "RUNNING";
                                lbputinSMTstatus.ForeColor = Color.Green;
                                counttmstatus = 4;
                                //tmstatus.Stop();
                                //gbindex = 5;
                                counttimeThaw = timewash;
                                Thread temp = new Thread(()=>coundown(true));
                                temp.IsBackground = true;
                                temp.Start();
                                //tmtimeLeft.Start();
                            }

                        }
                    }
                    catch
                    {

                    }
                    
                    
                }else// for solder paste only
                {
                    
                     
                    //// this case for solder paste not yet spined done
                    DataTable dt = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where (STATE=4 or STATE=5) and BARCODE='" + txtputinSMTserial.Text.Trim() + "'");
                    
                    if (dt.Rows.Count == 0)
                    {
                        gbPutinSMTstatus.Text = "This barcode is invalid!!!";
                        lbputinSMTstatus.Text = "FAIL";
                        lbputinSMTstatus.ForeColor = Color.Red;
                    }
                    else 
                    {
                        //this case for solder paste spined done, start to use online
                        dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE='" + txtputinSMTserial.Text.Trim() + "'");
                        JArray allhistory = (JArray)(Newtonsoft.Json.JsonConvert.DeserializeObject("["+dt.Rows[0]["HISTORY"].ToString()+"]"));
                        string dateputout = "";
                        foreach (var item in allhistory)
                        {
                            if (item["action"].ToString() == "5")
                            {
                                dateputout = item["time"].ToString();
                                break;
                            }
                        }
                        DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                        if (dateputout != "")
                        {
                            
                            TimeSpan temp = servernow - Convert.ToDateTime(dateputout);
                            if (temp.TotalHours >= 24)
                            {
                                lbputinSMTstatus.Text = "FAIL";
                                lbputinSMTstatus.ForeColor = Color.Red;
                                gbPutinSMTstatus.Text = "This solder paste has a circle live more than 1 day\r\n can not use anymore!!!";
                            }
                        }
                        else
                        {
                            history = new updateHistory() { action = 5, time = servernow.ToString(), historyuser = this.user, address = Environment.MachineName };
                            if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=5, ADRESS ='" + Environment.MachineName + "',TIME_START_USE=now(),HISTORY='" + getnewhistory(history, txtputinSMTserial.Text.Trim()) + "' where BARCODE='" + txtputinSMTserial.Text.Trim() + "'"))
                            {

                                lbputinSMTstatus.Text = "FAIL";
                                lbputinSMTstatus.ForeColor = Color.Red;
                            }
                            else
                            {
                                txtputinSMTserial.Text = "";
                                txtputinSMTserial.Focus();
                                lbputinSMTstatus.Text = "PASS";
                                lbputinSMTstatus.ForeColor = Color.Green;
                                //tmstatus.Stop();
                            }
                        }
                        
                    }
                }
                
            }
            
        }

        private void txtputinSMTconfirm_KeyDown(object sender, KeyEventArgs e)
        {
            DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
            if (e.KeyCode == Keys.Enter)
            {
                //for stencil
                tmtimeLeft.Stop();

                counttmstatus = 0;

                DataTable dt = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where STATE=5  and BARCODE='" + txtputinSMTconfirm.Text.Trim() + "'");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("this barcode is invalid!!");
                    return;
                }
                
                TimeSpan count =servernow - Convert.ToDateTime(dt.Rows[0]["TIME_START_USE"]);
                if ((!txtputinSMTconfirm.Text.Contains(pretext)) && (count.TotalSeconds > (timewash + MaxTimeDelayWashingStencil)))
                {
                    
                MessageBox.Show("This stencil is out off time for using >" + MaxTimeDelayWashingStencil + " seconds, Please call QC to confirm!!!","Note",MessageBoxButtons.OK);
                QC loginQC = new QC(sqlconnect);
                loginQC.ShowDialog();
                if (loginQC.updateDone)
                {
                    history = new updateHistory() { action = 6, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user, reason = gbPutinSMTstatus.Text };
                    if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=6, TIME_END_USE=now(),HISTORY='" + getnewhistory(history, txtputinSMTconfirm.Text.Trim()) + "' where BARCODE='" + txtputinSMTconfirm.Text.Trim() + "'"))
                    {

                        lbputinSMTstatus.Text = "FAIL";
                        lbputinSMTstatus.ForeColor = Color.Red;
                        return;
                    }
                    else
                    {
                        txtputinSMTserial.Text = "";
                        txtputinSMTserial.Focus();
                        txtputinSMTconfirm.Text = "";
                        //txtputinSMTconfirm.Enabled = false;
                        lbputinSMTstatus.Text = "PASS";
                        lbputinSMTstatus.ForeColor = Color.Green;
                        checkrunning = false;
                        return;
                    }
                }
                else
                {
                    //MessageBox.Show("This stencil is out off time for using >" + MaxTimeDelayWashingStencil + " seconds, Please call QC to confirm!!!");
                    return;
                }
            }
            //}

            else
            {

                history = new updateHistory() { action = 6, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user, address = Environment.MachineName };

                if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=6, TIME_END_USE=now(),HISTORY='" + getnewhistory(history, txtputinSMTconfirm.Text.Trim()) + "' where BARCODE='" + txtputinSMTconfirm.Text.Trim() + "'"))
                {

                    lbputinSMTstatus.Text = "FAIL";
                    lbputinSMTstatus.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    txtputinSMTserial.Text = "";
                    txtputinSMTserial.Focus();
                    txtputinSMTconfirm.Text = "";
                    //txtputinSMTconfirm.Enabled = false;
                    lbputinSMTstatus.Text = "PASS";
                    lbputinSMTstatus.ForeColor = Color.Green;
                    checkrunning = false;
                }
                    counttimeThaw = -1;
                    lbputinsmtTimeleft.Text = "Time left: 00:00:00";
            }
                
                //tmtimeLeft.Stop();
            }
        }
        //public delegate void EventHandlerNew(object sender, EventArgs e,int row);
        void timemerShowStick(object sender,EventArgs e, int row)
        {
            countListTimemrShow[row]--;
            if(countListTimemrShow[row]<1)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    listTimeer[row].Stop();
                    return;
                });
            }
            timespanShow[row] = TimeSpan.FromSeconds(countListTimemrShow[row]);
            this.Invoke((MethodInvoker)delegate
            {
                
                dtgridShowinfo[row,4].Value=timespanShow[row].ToString("hh ':' MM ':' ss");
            });
        }
        void installnewRow(TimeSpan count)
        {
            NewTimmer temp = new NewTimmer();
            temp.Interval = 1000;
            temp.Enabled = true;
            temp.Stop();
            temp.TickNew += timemerShowStick;
            
            int countime = (int)count.TotalSeconds;
            listTimeer.Add(temp);
            countListTimemrShow.Add(countime);
            timespanShow.Add(new TimeSpan());

            listTimeer.Last().Start();
        }
        void updategrivewInfo()
        {
            try
            {
                server_ip = "172.16.10.3";
                sqlClass getdata = new sqlClass(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");
                getdata.openConnectNew(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");  
                          
                while (getdata.getconnectionState()==ConnectionState.Open)
                {
                    if(countinThreadShow%60==0)
                    {
                        countinThreadShow = 1;
                        DataTable dt = getdata.GetDataMySql_Notcloseconnection("(select * from STENCIL_SOLDER_CONTROL where BARCODE NOT like '"+pretext+ "%' and STATE=5 )union (select * from STENCIL_SOLDER_CONTROL where BARCODE like '" + pretext+ "%' and (STATE=1 or STATE=3))");
                        if(dt.Rows.Count==0)
                        {
                            
                            countinThreadShow++;
                            continue;
                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            try
                            {
                                dtgridShowinfo.Rows.Clear();
                                listTimeer.Clear();
                                countListTimemrShow.Clear();
                                timespanShow.Clear();
                            }
                            catch { }
                            listTimeer = new List<NewTimmer>();
                            countListTimemrShow = new List<int>();
                            timespanShow = new List<TimeSpan>();
                        });
                        int currentRow = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                            TimeSpan count = servernow - Convert.ToDateTime(dt.Rows[i]["TIME_START_USE"]);
                            //for stencil
                            if (!dt.Rows[i]["BARCODE"].ToString().Contains(pretext))
                            {           
                                if(count.TotalSeconds>=(timewash- 1200))
                                {
                                    //installnewRow(count);
                                    this.Invoke((MethodInvoker)delegate {
                                        
                                        dtgridShowinfo.Rows.Add("Stencil", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["ADRESS"], "Time to washing!", "00:00:00", "Hurry Up!!!");
                                        //currentRow = dtgridShowinfo.Rows.Count - 1;
                                        //dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Red;
                                    });
                                }else
                                {
                                    this.Invoke((MethodInvoker)delegate { dtgridShowinfo.Rows.Add("Stencil", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["ADRESS"], "online", count.ToString("hh':'mm':'ss"), "using!!!");
                                        //currentRow = dtgridShowinfo.Rows.Count-1 ;  dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Yellow;
                                    });
                                }
                            }else //for solder paste
                            {
                                if(dt.Rows[i]["STATE"].ToString().Contains("3"))//thawing
                                {
                                    
                                     if(count.TotalSeconds >= (timThawing))
                                    {
                                        this.Invoke((MethodInvoker)delegate { dtgridShowinfo.Rows.Add("Solder Paste", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["Adress"], "Thawed done", "00:00:00", "Realdy to use!!!");
                                            //currentRow = dtgridShowinfo.Rows.Count-1; dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Green;
                                        });
                                    } else if (count.TotalSeconds >= (timThawing - 300))
                                    {
                                        //installnewRow(count);
                                        this.Invoke((MethodInvoker)delegate { dtgridShowinfo.Rows.Add("Solder Paste", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["Adress"], "Thawing", count.ToString("hh':'mm':'ss"), "Almost Ready!!!");
                                            //currentRow = dtgridShowinfo.Rows.Count-1; dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Yellow;
                                        });
                                    }
                                }
                                else if(dt.Rows[i]["STATE"].ToString().Contains("1"))
                                {
                                    if (count.TotalSeconds>(timeSpin))
                                    {
                                        //installnewRow(count);
                                        this.Invoke((MethodInvoker)delegate { dtgridShowinfo.Rows.Add("Solder Paste", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["Adress"], "Spined done", "00:00:00", "Realdy to use!!!");
                                            //currentRow = dtgridShowinfo.Rows.Count-1 ; dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Green;
                                        });
                                    }
                                    else
                                    {
                                        this.Invoke((MethodInvoker)delegate { dtgridShowinfo.Rows.Add("Solder Paste", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["Adress"], "Spinning", count.ToString("hh':'mm':'ss"), "Almost Ready!!!");
                                            //currentRow = dtgridShowinfo.Rows.Count-1; dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Yellow;
                                        });
                                    }
                                }
                            }
                        }
                        //request and update status
                    }else
                    {
                        //increase counting
                        Thread.Sleep(1000);
                        countinThreadShow++;
                    }
                }
                MessageBox.Show("Please check the connection to database server!!!");
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        private void showInfoRealTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showInfoRealtime)
            {
                dtgridShowinfo.Visible=true;
                panel1.Visible = false;
                gbCheckinfo.Visible = false;
                showAllinfo = new Thread(updategrivewInfo);
                showAllinfo.IsBackground = true;
                showAllinfo.Start();
                showInfoRealtime = false;
            }
            else
            {
                try
                {


                }
                catch
                {

                }
                dtgridShowinfo.Visible = false;
                panel1.Visible = true;
                showInfoRealtime = true;
            }
        }

        private void stickLableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(gbsticklable);
            rbstickNote.Text = "";
            txtstickserial.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            rbstickNote.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                if (!sqlconnect.InsertDataMySQL("update PCB_TRACER set TIME_STICK_LABLE=now() where PWB_SHEET_SERIAL='" + txtstickserial.Text.Trim() + "' and TIME_STICK_LABLE is NULL"))
                {                    
                    lbstickstatus.Text = "FAIL";
                    lbstickstatus.ForeColor = Color.Red;


                }
                else
                {
                    txtstickserial.Text = "";
                    txtstickserial.Focus();
                    lbstickstatus.Text = "PASS";
                    lbstickstatus.ForeColor = Color.Green;
                }
                counttmstatus = 0;
                gbindex = 6;
            }
        }

        private void checkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showInfoRealtime)
            {
                showInfoRealtime = false;
                cbgrcheckinfolooktype.SelectedIndex = 0;
                txtcheckinfoSerial.Text = "";
                loadForm(gbCheckinfo);
                panel1.Visible = false;
                dtgridShowinfo.Visible = false;
                txtcheckinfoSerial.Focus();
            }
            else
            {
                showInfoRealtime = true;
                gbCheckinfo.Visible = false;
            }

                
        }

        private void cbgrcheckinfolooktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cbgrcheckinfolooktype.SelectedIndex==0)
            {
                txtcheckinfoSerial.Enabled = true;
                txtcheckinfoSerial.Focus();
                return;
            }else if(cbgrcheckinfolooktype.SelectedIndex == 1)
            {
                //online
                DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where STATE=5 and BARCODE NOT like '"+pretext+"%'");
                dtgridCheckInfo.DataSource = dt;
            }
            else
            {
                //offline
                DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where STATE<>5 and BARCODE NOT like '" + pretext + "%'");
                dtgridCheckInfo.DataSource = dt;
            }
            //DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where STATE<>5 and BARCODE not like '%" + pretext + "'");
            dtgridstate.DataSource = sqlconnect.GetDataMySQL("select * from STATE_DEFINE"); 
        }

        private void txtcheckinfoSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                //if(txtcheckinfoSerial.Text.Trim().Length!=lengtbarcode)
                //{
                //    MessageBox.Show("Wrong barcode fomart!!!");
                //    return;
                //}
                DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE ='"+txtcheckinfoSerial.Text.Trim()+"'");
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("this barcode not exist!!!");
                    return;
                }
                dtgridCheckInfo.DataSource = dt;
                dtgridstate.DataSource = sqlconnect.GetDataMySQL("select * from STATE_DEFINE");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog temp = new SaveFileDialog();
            temp.Filter = "CSV Files | *.csv";
            temp.DefaultExt = "csv";
            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbooks book = app.Workbooks;
            //book.OpenDatabase
            if (temp.ShowDialog() == DialogResult.OK)
            {
                dtgridCheckInfo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                dtgridCheckInfo.RowHeadersVisible = false;  // the row headers column is copied too if visible
                dtgridCheckInfo.SelectAll();                // only the selected cells are used (the Windows Clipboard is not used)

                DataObject dataObject = dtgridCheckInfo.GetClipboardContent();      // 4 Data Formats: Text,Csv,HTML Format,UnicodeText
                
                File.WriteAllText(temp.FileName, dataObject.GetData("Csv") as string);

            }
        }

        private void btntk_Click(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnloaddata_Click(object sender, EventArgs e)
        {

        }

        private void btnimporttoDB_Click(object sender, EventArgs e)
        {

        }

        private void btnloaddata_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excell files (*.xls, *.xlsx) | *.xls; *.xlsx";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string FilePath = openFile.FileName;
                    FileStream stream = File.Open(FilePath, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader;
                    //
                    string[] FileType = FilePath.Split('.');
                    if (FileType[FileType.Length - 1].ToUpper() == "XLS")
                    {
                        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (FileType[FileType.Length - 1].ToUpper() == "XLSX")
                    {
                        //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        MessageBox.Show("Wrong excell Fomat");
                        return;
                    }
                    //3. DataSet - The result of each spreadsheet will be created in the result.Tables
                    //4. DataSet - Create column names from first row
                    excelReader.IsFirstRowAsColumnNames = true;
                    DataSet result = excelReader.AsDataSet();
                    DataTable dt = result.Tables[0];
                    //5. Data Reader methods
                    //while (excelReader.Read())
                    //{
                    //    //excelReader.GetInt32(0);
                    //}
                    dataGridView1.Visible = true;
                    dtgridputinstore.Visible = false;
                    dataGridView1.DataSource = dt;
                    fromExcel = dt;
                    //6. Free resources (IExcelDataReader is IDisposable)
                    excelReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnimporttoDB_Click_1(object sender, EventArgs e)
        {
            if (fromExcel != null&&dataGridView1.Visible==true)
            {
                string SQLcmd = "";
                string TotalSQLcmd = "";
                string Vender_ID = "";
                string Customer_ID = "";
                string Customer_Name = "";
                try
                {
                    for (int i = 0; i < fromExcel.Rows.Count; i++)
                    {
                        Vender_ID = fromExcel.Rows[i][0].ToString();
                        Customer_ID = fromExcel.Rows[i][1].ToString();
                        //
                        SQLcmd = @"INSERT INTO STENCIL_SOLDER_CONTROL (`BARCODE`, `DATE_STORE`, `STATE`)values('" + fromExcel.Rows[i][0] + "','" + fromExcel.Rows[i][1] + "',2) ;";
                        //
                        TotalSQLcmd += SQLcmd;
                        SQLcmd = "";
                    }
                    //
                    if (sqlconnect.InsertDataMySQL(TotalSQLcmd))
                    {
                        MessageBox.Show("Import data complete");
                    }
                    else
                    {
                        MessageBox.Show("Import data Fail");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("Please load excell file first");
            }
            dataGridView1.Visible = false;
            dtgridputinstore.Visible = true;
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            dtgridputinstore.Visible = true;
            dataGridView1.Visible = false;
            for (int i = 0; i < dtgridputinstore.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgridputinstore.Rows[i].Cells["select"].Value) == true)
                {
                    DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL  where BARCODE='" + dtgridputinstore.Rows[i].Cells["sn"].Value.ToString() + "' ");
                    if(dt.Rows[0]["TIME_START_USE"].ToString().Length!=0)
                    {
                        MessageBox.Show("Không được Xóa !!!");
                        return;
                    }
                    sqlconnect.InsertDataMySQL("delete from STENCIL_SOLDER_CONTROL where BARCODE ='" + dtgridputinstore.Rows[i].Cells["sn"].Value.ToString() + "'");

                }
            }
            dtgridputinstore.Rows.Clear();
            DataTable dt_ = sqlconnect.GetDataMySQL("select BARCODE,DATE_STORE,STATE,ADRESS from STENCIL_SOLDER_CONTROL ORDER BY ID DESC LIMIT 0,10");
            for (int i = 0; i < dt_.Rows.Count; i++)
            {
                dtgridputinstore.Rows.Add("False", dt_.Rows[i]["BARCODE"].ToString(), dt_.Rows[i]["DATE_STORE"].ToString(), dt_.Rows[i]["STATE"].ToString(), dt_.Rows[i]["ADRESS"].ToString());
            }
        }

        private void btntk_Click_1(object sender, EventArgs e)
        {
            dtgridputinstore.Visible = true;
            dataGridView1.Visible = false;
            dtgridputinstore.Rows.Clear();
            DataTable dt_ = sqlconnect.GetDataMySQL("select BARCODE,DATE_STORE,STATE,ADRESS from STENCIL_SOLDER_CONTROL  where BARCODE='"+textBox1.Text.Trim()+"'");
            for (int j = 0; j < dt_.Rows.Count; j++)
            {
                dtgridputinstore.Rows.Add("False", dt_.Rows[j]["BARCODE"].ToString(), dt_.Rows[j]["DATE_STORE"].ToString(), dt_.Rows[j]["STATE"].ToString(), dt_.Rows[j]["ADRESS"].ToString());
            }
        }

        private void cbbputinsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbputinsearch.SelectedIndex;
            DataTable dt_;
            switch (i)
            {
                case 0:
                    textBox1.Focus();
                    break;
                case 1:
                    dtgridputinstore.Rows.Clear();
                    dt_ = sqlconnect.GetDataMySQL("select BARCODE,DATE_STORE,STATE,ADRESS from STENCIL_SOLDER_CONTROL where STATE=2 ORDER BY ID ");
                    if (dt_ == null || dt_.Rows.Count == 0)
                    {
                        txtCount.Text = "0";
                        return;
                    }
                    for (int j = 0; j < dt_.Rows.Count; j++)
                    {
                        dtgridputinstore.Rows.Add("False", dt_.Rows[j]["BARCODE"].ToString(), dt_.Rows[j]["DATE_STORE"].ToString(), dt_.Rows[j]["STATE"].ToString(), dt_.Rows[j]["ADRESS"].ToString());
                    }
                    txtCount.Text = dt_.Rows.Count.ToString();
                    break;
                case 2:
                    dtgridputinstore.Rows.Clear();
                    dt_ = sqlconnect.GetDataMySQL("select BARCODE,DATE_STORE,STATE,ADRESS from STENCIL_SOLDER_CONTROL where STATE<>2 ORDER BY ID ");
                    if (dt_ == null || dt_.Rows.Count == 0)
                    {
                        txtCount.Text = "0";
                        return;
                    }
                    for (int j = 0; j < dt_.Rows.Count; j++)
                    {
                        dtgridputinstore.Rows.Add("False", dt_.Rows[j]["BARCODE"].ToString(), dt_.Rows[j]["DATE_STORE"].ToString(), dt_.Rows[j]["STATE"].ToString(), dt_.Rows[j]["ADRESS"].ToString());
                    }
                    txtCount.Text = dt_.Rows.Count.ToString();
                    break;

            }

        }
        public bool savetoCSV(DataTable dt)
        {
            SaveFileDialog SV = new SaveFileDialog();
            SV.Filter = "CSV files (*.csv)|*.csv";
            if (SV.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string DesFile = SV.FileName.ToString();
                    int run = 0;
                    int run2 = 0;
                    int numberRows = dt.Rows.Count;
                    int columsNumber = dt.Columns.Count;
                    StreamWriter wr = new StreamWriter(DesFile);
                    //
                    string DataPrint = "";
                    for (run2 = 0; run2 < columsNumber; run2++)
                    {
                        DataPrint += dt.Columns[run2].ColumnName.ToString() + ",";

                    }
                    wr.WriteLine(DataPrint);
                    wr.WriteLine(",,,,,,,,,");
                    wr.WriteLine(",,,,,,,,,");
                    for (run = 0; run < numberRows; run++)
                    {
                        for (int i = 0; i < columsNumber; i++)
                        {
                            wr.Write (dt.Rows[run][i].ToString().Trim()+",");
                        }
                        wr.WriteLine();
                    }
                    wr.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return true;
        }

        private DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
        {
            try
            {
                if (_DataGridView.ColumnCount == 0) return null;
                DataTable dtSource = new DataTable();
                //////create columns
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null) dtSource.Columns.Add(col.Name, typeof(string));
                    else dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                ///////insert row data
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch
            {
                return null;
            }
        }
        private void btnsaveCSV_Click(object sender, EventArgs e)
        {
            if(dtgridputinstore.Rows.Count==0)
            {
                MessageBox.Show("Lấy dữ liêu muốn lưu trước!");
                return;
            }
            DataTable dt =GetDataGridViewAsDataTable(dtgridputinstore);
            savetoCSV(dt);
        }

        private void dtgridShowinfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            string a = dtgridShowinfo.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (a == "Realdy to use!!!")
            {
                dtgridShowinfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
            }
            else if (a == "Almost Ready!!!" || a == "using!!!")
            {
                dtgridShowinfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
            }
            else if (a == "Hurry Up!!!")
            {
                dtgridShowinfo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }

        }

        private void txtspinconfirm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
