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
//Stencil_Solder_Control
namespace Stencil_Solder_Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string server_ip = "172.16.10.3";
        sqlClass sqlconnect;
        JObject Json_read;
        bool login = false;
        int gbindex = 1;
        int counttimeThaw = 1;
        // fro solder paste+ stencil
        int timeSpin;
        int datewarning;
        int timeturnback;
        int timewash;
        int timThawing;
        int time_outside;
        int MaxTimeDelayWashingStencil;
        //
        string part_inter = "";
        String type;
        string check;
        string model;
        string barcode;
        //
        //
        int authority;
        int counttmstatus = 0;
        int countinThreadShow = 0;
        string password;
        List<NewTimmer> listTimeer;
        List<int> countListTimemrShow;
        List<TimeSpan> timespanShow;
       
        
        string user = "";
        DataTable fromExcel;
        updateHistory history;
        TimeSpan timeSpan;
        GroupBox[] listGP = new GroupBox[10];
        public List<string> modelList;
        public List<string> customerList;
        Thread spinsolder;
        Thread showAllinfo;



        private void btnlogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtpass.Text) || string.IsNullOrEmpty(txtuser.Text))
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
                    if (dt.Rows[0]["USER_PASSWORD"].ToString().Trim() == txtpass.Text.Trim())
                    {
                        login = true;
                        password = txtpass.Text.Trim();
                        gbLogIn.Text = "Welcome";
                        gbLogIn.ForeColor = Color.Blue;
                        pnwelcome.Visible = true;
                        lbwelcome.Text = "welcome: " + dt.Rows[0]["USER_NAME"];
                        user = txtuser.Text.Trim();
                        authority = Convert.ToInt16(dt.Rows[0]["AUTHORITY"].ToString());
                        tmlocalTIme.Start();
                        if(authority==5||authority==6||authority==10)
                        {
                            tableLayoutPanel3.Enabled = false;
                        }
                        //tmtimeLeft.Start();
                        //gbLogIn.Visible = false;

                        DataTable modelName = sqlconnect.GetDataMySQL("SELECT ID_MODEL FROM TRACKING_SYSTEM.PART_MODEL_CONTROL;");
                        modelList = new List<string>();
                        for (int i = 0; i < modelName.Rows.Count; i++)
                        {
                            modelList.Add(modelName.Rows[i]["ID_MODEL"].ToString());
                            cbputoutmodel.Items.Add(modelName.Rows[i]["ID_MODEL"].ToString());
                            cbputinSMTmodel.Items.Add(modelName.Rows[i]["ID_MODEL"].ToString());
                        }
                        customerList = new List<string>();
                        DataTable customer = sqlconnect.GetDataMySQL("SELECT CUSTOMER_NAME FROM TRACKING_SYSTEM.DEFINE_CUSTOMER;");
                        
                        for (int i = 0; i < customer.Rows.Count; i++)
                        {
                            customerList.Add(customer.Rows[i]["CUSTOMER_NAME"].ToString());
                            //cbputinpartnumber.Items.Add(customer.Rows[i]["CUSTOMER_NAME"].ToString());
                        }

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
            datewarning = (int)Json_read["Datewarning"];
            MaxTimeDelayWashingStencil = (int)Json_read["MaxTimeDelayWashingStencil"];
            //lengtbarcode = (int)Json_read["LenghtBarcode"];
            listGP[1] = gbLogIn;
            listGP[2] = gbPutin;
            listGP[3] = gbPutout;
            listGP[4] = gbSpinSolder;
            listGP[5] = gbPutinSMT;
            listGP[6] = gbsticklable;
            listGP[7] = gbCheckinfo;
            listGP[8] = grbPutoutSMT;
            listGP[9] = CallSolderPaste;
            //

        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            gbLogIn.Visible = true;
        }


        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpass.Text = "";
            txtuser.Focus();
            gbLogIn.BringToFront();
            gbLogIn.Text = "Login";
            gbLogIn.ForeColor = Color.Black;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblocaltime.Text = "Local Time:" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }
        public string getnewhistory(object history, string barcode)
        {
            DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE='" + barcode + "'");
            return dt.Rows[0]["HISTORY"].ToString() + "," + Newtonsoft.Json.JsonConvert.SerializeObject(history);
        }

      

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlogin_Click(sender, e);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtpass.Text = "";
            txtuser.Text = "";
            user = "";
            login = true;
            gbLogIn.ForeColor = Color.Black;
            gbLogIn.Visible = true;
            gbLogIn.BringToFront();
            gbLogIn.Text = "Login";
        }

        private void putInStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(gbPutin);
            if (authority != 5 && authority != 0&& authority!=7)
            {
                MessageBox.Show("chức năng này chỉ dùng cho bộ phận Kho!");
                return;
            }
            if(authority == 7)
            {
                btnxoa.Enabled = false;
            }
            else
            {
                btnxoa.Enabled = true;
            }
            dtgridputinstore.BringToFront();
            txtputinSMTserial.Clear();
            txtputinSMTserial.Focus();
        }

        private void txtputinSerial_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    dtgridputinstore.BringToFront();
                    gbindex = 2;
                    rbputinNote.Text = "";
                    string check = "ERROR";
                    string part_number, model, customer, expiryDate;
                    string barcode = txtputinSerial.Text.Trim();
                    string part_inter = barcode.Substring(0, 10);
                    DataTable dtGetdefine;
                    string type = "Solder Paste";
                    if (barcode.Length == 14)
                    {
                        type = "Stencil";
                    }
                    if (type == "Solder Paste")
                    {
                        dtGetdefine = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.SOLDER_RULE where PART_INTER='" + part_inter + "';");
                    }
                    else
                    {
                        dtGetdefine = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.STENCIL_RULE where PART_INTER='" + part_inter + "';");
                    }


                    if (dtGetdefine == null || dtGetdefine.Rows.Count == 0)
                    {
                        MessageBox.Show("Mã NỘI BỘ này không tồn tại");
                        return;
                    }

                    part_number = dtGetdefine.Rows[0]["PART_NUMBER"].ToString();
                   // model = dtGetdefine.Rows[0]["MODEL"].ToString();
                    customer = dtGetdefine.Rows[0]["CUSTOMER"].ToString();
                    check = dtGetdefine.Rows[0]["CHECK"].ToString();
                    expiryDate = dtpexpirydate.Value.ToString("yyyy-MM-dd");
                    if (cbexpridate.Checked)
                    {
                        DataTable maxdate = sqlconnect.GetDataMySQL("select MAX(DATE_STORE) from STENCIL_SOLDER_NEW where  PART_INTER='" + part_inter + "';");
                        if (maxdate == null || maxdate.Rows.Count == 0)
                        {

                        }
                        else
                        {
                            try
                            {
                                DateTime temp = Convert.ToDateTime(maxdate.Rows[0][0].ToString());
                                if (temp > dtpexpirydate.Value)
                                {
                                    DialogResult dlgresult = MessageBox.Show("Kem hàn này nhập có hạn sử dụng ít hơn kem hàn còn tồn trong kho!\r\n Nếu là kem hàn được mua hãy nhấn Cancel và báo Kế hoạch để kiểm tra lại!\r\n Nếu do bên khách hàng cấp và bạn không quan tâm,hãy nhấn OK có thể bỏ check trong checkbox check expiry date phía trên!", "Thông báo!!!", MessageBoxButtons.OKCancel);
                                    if (dlgresult == DialogResult.Cancel)
                                    {
                                        lbputinstatus.Text = "FAIL";
                                        lbputinstatus.ForeColor = Color.Red;
                                        return;
                                    }
                                }
                            }
                            catch { }
                            
                        }
                    }

                    DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                    if (dtpexpirydate.Value.Date < servernow.Date)
                    {

                        MessageBox.Show("Kem hàn quá hạn sử dụng!");
                        lbputinstatus.Text = "FAIL";
                        lbputinstatus.ForeColor = Color.Red;
                        return;
                    }else if(servernow.Subtract(dtpexpirydate.Value).TotalDays < datewarning)
                    {
                        //MessageBox.Show("Kem hàn nhập có số ngày sử dụng được <!"+datewarning);
                        DialogResult dlgresult = MessageBox.Show("Kem hàn nhập có số ngày sử dụng được <!" + datewarning, "Thông báo!!!", MessageBoxButtons.OKCancel);
                        if (dlgresult == DialogResult.Cancel)
                        {
                            lbputinstatus.Text = "FAIL";
                            lbputinstatus.ForeColor = Color.Red;
                            return;
                        }
                        //lbputinstatus.Text = "FAIL";
                        //lbputinstatus.ForeColor = Color.Red;
                        //return;
                    }
                    
                    if (e.KeyCode == Keys.Enter)
                    {
                        history = new updateHistory() { action = 2, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };
                        DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE='" + barcode + "' AND TYPE='" + type + "'");
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            if (sqlconnect.InsertDataMySQL("insert into STENCIL_SOLDER_CONTROL (BARCODE,PART_INTER,PART_NUMBER,CUSTOMER,DATE_STORE,STATE,HISTORY,TYPE,STENCIL_SOLDER_NEW.CHECK,EXPIRY_DATE,ADRESS) values('" + barcode + "','" + part_inter + "','" + part_number + "','" + customer + "',curdate(),2,'" + Newtonsoft.Json.JsonConvert.SerializeObject(history) + "','" + type + "'," + check + ",'" + expiryDate + "','STORE')"))
                            {
                                txtputinSerial.Text = "";
                                lbputinstatus.Text = "PASS";
                                lbputinstatus.ForeColor = Color.Green;
                                txtputinSerial.Focus();
                                try
                                {
                                    dtgridputinstore.Rows.Clear();
                                    refreshfrmPutin();
                                }
                                catch { }
                            }
                            else
                            {
                                lbputinstatus.Text = "FAIL";
                                lbputinstatus.ForeColor = Color.Red;
                            }

                        }
                        else
                        {
                            if (dt.Rows[0]["STATE"].ToString() == "2")
                            {
                                lbputinstatus.Text = "FAIL";
                                lbputinstatus.ForeColor = Color.Red;
                                rbputinNote.Text = "This barcode already was put in store!";

                            }
                            else if (sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=2, ADRESS='STORE', HISTORY='" + getnewhistory(history, barcode) + "' where BARCODE='" + barcode + "'"))
                            {

                                txtputinSerial.Text = ""; txtputinSerial.Focus();
                                lbputinstatus.Text = "PASS";
                                lbputinstatus.ForeColor = Color.Green;
                                try
                                {
                                    dtgridputinstore.Rows.Clear();
                                    refreshfrmPutin();
                                }
                                catch { }
                            }
                            else
                            {
                                lbputinstatus.Text = "FAIL";
                                lbputinstatus.ForeColor = Color.Red;
                            }

                        }
                        counttmstatus = 0;

                    }
                }
                catch { MessageBox.Show("kiểm tra định dạng barcode!"); }
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
                    if (counttmstatus == 3)
                    {
                        lbputinSMTstatus.Text = "WAITE";
                        lbputinSMTstatus.ForeColor = Color.Black;
                    }
                    break;
                case 7:
                    if (counttmstatus == 3)
                    {
                        lbputoutSMTstatus.Text = "WAITE";
                        lbputoutSMTstatus.ForeColor = Color.Black;
                    }
                    break;



            }
        }

        private void txtputoutserial_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                gbindex = 3;
                rtputoutNote.Text = "";
                try
                {
                    DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];

                    history = new updateHistory() { action = 3, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };
                    //check barcode have in store or not
                    DataTable dt_instore = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where STATE=2 and BARCODE='" + txtputoutserial.Text.Trim() + "'");

                    if (dt_instore == null || dt_instore.Rows.Count == 0)
                    {
                        rtputoutNote.Text = "This Barcode not exist on Store!!!";
                        lbPutoutstatus.Text = "FAIL";
                        lbPutoutstatus.ForeColor = Color.Red;
                        counttmstatus = 0;
                        return;
                    }
                    part_inter = dt_instore.Rows[0]["PART_INTER"].ToString();
                    type = dt_instore.Rows[0]["TYPE"].ToString();
                    barcode = txtputoutserial.Text.Trim();

                    //this case for Stencil dont need control FIFO
                    if (!type.Contains("Solder Paste"))
                    {
                        DataTable checkdetail = sqlconnect.GetDataMySQL("SELECT * FROM STENCIL_RULE where INSTR(MODEL,'" + cbputoutmodel.Text + "')>0 AND PART_INTER='" + part_inter + "';");
                        if (checkdetail == null || checkdetail.Rows.Count == 0)
                        {
                            rtputoutNote.Text = "model name is invalid!!!";
                            lbPutoutstatus.Text = "FAIL";
                            lbPutoutstatus.ForeColor = Color.Red;
                            counttmstatus = 0;
                            return;
                        }
                        check = checkdetail.Rows[0]["CHECK"].ToString();
                        timewash = int.Parse(checkdetail.Rows[0]["TIME_USE"].ToString());
                        model = checkdetail.Rows[0]["MODEL"].ToString();
                        if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=3, TIME_START_USE=now(),`CHECK`=" + check + ",TIME_USE=" + timewash + ",HISTORY='" + getnewhistory(history, txtputoutserial.Text.Trim()) + "',MODEL='" + model + "' where BARCODE='" + txtputoutserial.Text.Trim() + "'"))
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
                            showavailableRequest(ref dtgputoutRequesting);
                        }

                        counttmstatus = 0;
                        return;
                    }
                    else
                    {
                        //this case for Solder paste need to be control by FIFO                 
                        DataTable checkdetail = sqlconnect.GetDataMySQL("Select * from SOLDER_RULE where PART_INTER='" + part_inter + "' and  INSTR(MODEL,'" + cbputoutmodel.Text + "')>0");

                        check = checkdetail.Rows[0]["CHECK"].ToString();
                        if (checkdetail == null || checkdetail.Rows.Count == 0)
                        {
                            rtputoutNote.Text = "model name is invalid!!!";
                            lbPutoutstatus.Text = "FAIL";
                            lbPutoutstatus.ForeColor = Color.Red;
                            counttmstatus = 0;
                            return;
                        }
                        time_outside = int.Parse(checkdetail.Rows[0]["TIME_OUTSIDE"].ToString());
                        timeturnback = int.Parse(checkdetail.Rows[0]["TIME_TUNRBACK"].ToString());
                        //TIME_TUNRBACK
                        timeSpin = int.Parse(checkdetail.Rows[0]["TIME_SPIN"].ToString());
                        timThawing = int.Parse(checkdetail.Rows[0]["TIME_THAW"].ToString());
                        model = checkdetail.Rows[0]["MODEL"].ToString();
                        DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where STATE=2 and TYPE='Solder Paste' and PART_INTER='" + part_inter + "' AND DATE_STORE <= (select MIN(DATE_STORE) from STENCIL_SOLDER_CONTROL where STATE=2 AND TYPE='Solder Paste' and PART_INTER='" + part_inter + "')");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["BARCODE"].ToString() == txtputoutserial.Text.Trim())
                            {
                                //check expirydate
                                DateTime expirydate = Convert.ToDateTime(sqlconnect.GetDataMySQL("SELECT EXPIRY_DATE FROM PRODUCTION_TRACER.STENCIL_SOLDER_NEW where BARCODE='" + barcode + "';").Rows[0][0].ToString());

                                if (expirydate.Date < servernow.Date)
                                {
                                    MessageBox.Show("Kem hàn quá hạn sử dụng");
                                    lbPutoutstatus.Text = "FAIL";
                                    lbPutoutstatus.ForeColor = Color.Red;
                                    return;
                                }
                                if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=3,TIME_THAW=" + timThawing + ",TIME_SPIN=" + timeSpin + ",TIME_TUNRBACK=" + timeturnback + ",TIME_OUTSIDE=" + time_outside + ", TIME_START_USE=now(),HISTORY='" + getnewhistory(history, txtputoutserial.Text.Trim()) + "',MODEL='" + model + "' where BARCODE='" + txtputoutserial.Text.Trim() + "'"))
                                {

                                    lbPutoutstatus.Text = "FAIL";
                                    lbPutoutstatus.ForeColor = Color.Red;
                                }
                                else
                                {
                                    sqlconnect.InsertDataMySQL("update LINE_CURRENT_REQUEST set STATE=2 , TIME_SUPPLY=now() where PART_INTER='" + part_inter + "' and MODEL='" + cbputoutmodel.Text + "' and STATE=1;");
                                    
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
                    }
                    gbindex = 3;
                    counttmstatus = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    lbPutoutstatus.Text = "FAIL";
                    lbPutoutstatus.ForeColor = Color.Red;
                    gbindex = 3;
                    counttmstatus = 0;
                }
            }
        }

        private void putOutStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(gbPutout);
            if (authority != 5 && authority != 0)
            {
                MessageBox.Show("chức năng này chỉ dùng cho bộ phận Kho!");
                return;
            }
            
            showavailableRequest(ref dtgputoutRequesting);
            txtputoutserial.Focus();
            cbputoutmodel.SelectedIndex = 0;
        }
        public bool checkSanxuat()
        {
            if (authority == 5 || authority == 10 || authority == 7)
            {
                MessageBox.Show("chức năng này chỉ dùng cho bộ phận Sản Xuất!");
                return false;
            }
            return true;
        }
        private void spinSolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkSanxuat())
                return;
            loadForm(gbSpinSolder);
            try
            {
                if (spinsolder.IsAlive)
                {
                    return;
                }
                else
                {
                    txtspinserial.Text = "";
                    rbspinNote.Text = "";
                    lbspecspin.Text = "Spec :";
                    txtspinserial.Focus();
                }
            }
            catch
            {
                txtspinserial.Text = "";
                rbspinNote.Text = "";
                txtspinserial.Focus();
            }
        }
        void loadForm(GroupBox temp)
        {
            if (!login)
            {
                MessageBox.Show("Please login first!");
                return;
            }
            // dtgridCheckInfo.Visible = false;
            dtgridShowinfo.Visible = false;
            gbCheckinfo.Visible = false;
            tmupdaterequest.Enabled = false;
            panel1.Visible = true;
            foreach (GroupBox item in listGP)
            {
                try
                {
                    if (item.Name == temp.Name)
                    {                       
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
            if (!checkSanxuat())
                return;
            lbputinsmtTimeleft.Text = "Time left";
        }
       
        public int getsolderDetail(ref int timethaw, ref int timespine, ref int timeturnback, string customerID)
        {
            try
            {
                DataTable getcustomer = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.SOLDER_RULE where INSTR(MODEL,'" + customerID + "')>0;");
                if (getcustomer.Rows.Count == 0)
                {
                    return 0;
                }
                if (getcustomer.Rows[0]["CHECK"].ToString().Contains("1"))
                {
                    timethaw = int.Parse(getcustomer.Rows[0]["TIME_THAW"].ToString());
                    timeSpin = int.Parse(getcustomer.Rows[0]["TIME_SPIN"].ToString());
                    timeturnback = int.Parse(getcustomer.Rows[0]["TIME_TUNRBACK"].ToString());
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return 0;
            }

        }
        public int getStencilDetail(string customerID, ref int timeuse)
        {
            try
            {
                DataTable getcustomer = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.STENCIL_RULE where  where INSTR(MODEL,'" + customerID + "')>0;");
                if (getcustomer.Rows.Count == 0)
                {
                    return 0;
                }
                if (getcustomer.Rows[0]["CHECK"].ToString().Contains("1"))
                {
                    timeuse = int.Parse(getcustomer.Rows[0]["TIME_USE"].ToString());
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return 0;
            }

        }
        private void txtspinserial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                barcode = txtspinserial.Text.Trim();
                rbspinNote.Text = "";
                DataTable dt = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where( STATE=3 or STATE=1 )and TYPE='Solder Paste' and BARCODE='" + barcode + "' ");
                gbindex = 4;
                if (dt == null || dt.Rows.Count == 0)
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
                    if (dt.Rows[0]["CHECK"].ToString().Contains("0"))
                    {
                        txtspinserial.Text = "";
                        txtspinserial.Focus();
                        lbspinstatus.Text = "PASS";
                        lbspinstatus.ForeColor = Color.Green;
                        counttmstatus = 0;
                        return;

                    }
                    DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                    TimeSpan count = servernow - Convert.ToDateTime(dt.Rows[0]["TIME_START_USE"]);
                    timThawing = int.Parse(dt.Rows[0]["TIME_THAW"].ToString());
                    timeSpin = int.Parse(dt.Rows[0]["TIME_SPIN"].ToString());
                    lbspecspin.Text = "Spec to Spin (s) =" + timeSpin;
                    if (dt.Rows[0]["STATE"].ToString() == "1")
                    {
                        if (timeSpin - Convert.ToInt16(count.TotalSeconds) > 0)
                        {
                            timeSpin = timeSpin - Convert.ToInt16(count.TotalSeconds);
                        }
                        else
                        {
                            timeSpin = 2;
                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            lbspinstatus.Text = "ON GOING";
                            counttimeThaw = timeSpin;
                            timeSpan = TimeSpan.FromSeconds(counttimeThaw);
                            spinsolder = new Thread(() => coundown(false));
                            txtspinserial.Enabled = false;
                            spinsolder.IsBackground = true;
                            spinsolder.Start();
                            //tmtimeLeft.Start();
                        });

                    }
                    else
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
                            return;
                        }
                        else
                        {
                            history = new updateHistory() { action = 1, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };
                            if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=1, TIME_START_USE=now(),HISTORY='" + getnewhistory(history, txtspinserial.Text.Trim()) + "' where BARCODE='" + txtspinserial.Text.Trim() + "';"))
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
                                spinsolder = new Thread(() => coundown(false));
                                spinsolder.IsBackground = true;
                                spinsolder.Start();
                                //tmtimeLeft.Start();
                            });

                        }
                    }
                }


            }
        }

        private void txtspinserial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtspinconfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtspinserial.Focus();
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
                            //txtputinSMTmodel.Enabled = true;
                            gbPutinSMTstatus.Text = "This Stencil is up to date, please take it out to washing!!!";
                            //txtputinSMTmodel.Enabled = true;
                            counttimeThaw--;
                            Form2 show = new Form2();
                            show.Show();
                            lbputinSMTstatus.Text = "WAIT";
                            lbputinsmtTimeleft.Text = "Time Left:";
                            return;

                        });

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
                        history = new updateHistory() { action = 4, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user };
                        if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=4, TIME_END_USE=now(),HISTORY='" + getnewhistory(history, txtspinserial.Text.Trim()) + "' where BARCODE='" + txtspinserial.Text.Trim() + "'"))
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                lbspinstatus.Text = "FAIL";
                                lbspinstatus.ForeColor = Color.Red;
                            });
                            counttmstatus = 4;
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                rbspinNote.Text = "Spin done, Please take out Solder !!!";
                                txtspinserial.Text = "";
                                txtspinserial.Focus();
                                lbspinstatus.Text = "PASS";
                                txtspinserial.Enabled = true;
                                lbspinstatus.ForeColor = Color.Green;

                                counttmstatus = 0;
                            });
                        }

                        gbindex = 4;
                        return;
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
        {//

            gbPutinSMTstatus.Text = "";
            if (e.KeyCode == Keys.Enter)
            {
                gbindex = 5;
                //tmstatus.Start();
                DataTable dt = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where  BARCODE='" + txtputinSMTserial.Text + "'and INSTR(MODEL,'" + cbputinSMTmodel.Text + "')>0");
                if (dt == null || dt.Rows.Count == 0)
                {
                    //
                    lbputinSMTstatus.Text = "FAIL";
                    lbputinSMTstatus.ForeColor = Color.Red;
                    gbPutinSMTstatus.Text = "This Barcode is invalid!!!";
                    counttmstatus = 0;
                    return;
                }
                string type = dt.Rows[0]["TYPE"].ToString();
                if (!type.Contains("Solder Paste"))// for stencil only
                {
                    try
                    {

                        if (!dt.Rows[0]["STATE"].ToString().Contains("3") && !dt.Rows[0]["STATE"].ToString().Contains("6")) //this case for stencil already take out off store, start using in line STATE=3
                        {
                            lbputinSMTstatus.Text = "FAIL";
                            lbputinSMTstatus.ForeColor = Color.Red;
                            gbPutinSMTstatus.Text = "This Barcode is invalid!!!";

                        }
                        //
                        DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                        history = new updateHistory() { action = 5, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user, address = Environment.MachineName };
                        if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=5, ADRESS ='" + Environment.MachineName + "',TIME_START_USE=now(),HISTORY='" + getnewhistory(history, txtputinSMTserial.Text) + "' where BARCODE='" + txtputinSMTserial.Text + "'"))
                        {

                            lbputinSMTstatus.Text = "FAIL";
                            lbputinSMTstatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            txtputinSMTserial.Text = "";
                            txtputinSMTserial.Focus();

                            if (dt.Rows[0]["CHECK"].ToString().Contains("1"))
                            {
                                lbputinSMTstatus.Text = "RUNNING";
                                lbputinSMTstatus.ForeColor = Color.Green;
                                counttmstatus = 4;
                                timewash = int.Parse(dt.Rows[0]["TIME_USE"].ToString());
                                counttimeThaw = timewash;
                                Thread temp = new Thread(() => coundown(true));
                                temp.IsBackground = true;
                                temp.Start();
                                return;
                            }
                            else
                            {
                                lbputinSMTstatus.Text = "PASS";
                                lbputinSMTstatus.ForeColor = Color.Green;
                                counttmstatus = 0;
                            }
                            //tmtimeLeft.Start();
                        }


                        counttmstatus = 0;
                        return;
                    }
                    catch
                    {
                        lbputinSMTstatus.Text = "FAIL";
                        lbputinSMTstatus.ForeColor = Color.Red;
                        gbPutinSMTstatus.Text = "This Barcode is invalid!!!";
                        counttmstatus = 0;
                        return;
                    }


                }
                else// for solder paste only
                {


                    if (!dt.Rows[0]["STATE"].ToString().Contains("4") && !dt.Rows[0]["STATE"].ToString().Contains("5"))
                    {
                        lbputinSMTstatus.Text = "FAIL";
                        lbputinSMTstatus.ForeColor = Color.Red;
                        gbPutinSMTstatus.Text = "This Barcode is invalid!!!";
                        counttmstatus = 0;
                        return;
                    }

                    JArray allhistory = (JArray)(Newtonsoft.Json.JsonConvert.DeserializeObject("[" + dt.Rows[0]["HISTORY"].ToString() + "]"));
                    timeturnback = int.Parse(dt.Rows[0]["TIME_TUNRBACK"].ToString());
                    time_outside = int.Parse(dt.Rows[0]["TIME_OUTSIDE"].ToString());
                    string datestartopen = "";
                    string timeoutside = "";
                    foreach (var item in allhistory)
                    {
                        if (item["action"].ToString() == "5")
                        {
                            datestartopen = item["time"].ToString();
                            break;
                        }
                    }
                    foreach (var item in allhistory)
                    {
                        if (item["action"].ToString() == "3")
                        {
                            timeoutside = item["time"].ToString();

                        }
                    }
                    DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                    DateTime expirydate = Convert.ToDateTime(sqlconnect.GetDataMySQL("SELECT EXPIRY_DATE FROM PRODUCTION_TRACER.STENCIL_SOLDER_NEW where BARCODE='" + txtputinSMTserial.Text + "';").Rows[0][0].ToString());

                    if (expirydate.Date < servernow.Date)
                    {
                        MessageBox.Show("Kem hàn quá hạn sử dụng");
                        lbputinSMTstatus.Text = "FAIL";
                        lbputinSMTstatus.ForeColor = Color.Red;
                        return;
                    }
                    if (datestartopen != "" && dt.Rows[0]["CHECK"].ToString().Contains("1"))
                    {

                        TimeSpan temp = servernow - Convert.ToDateTime(datestartopen);
                        if (temp.TotalHours >= timeturnback)
                        {
                            lbputinSMTstatus.Text = "FAIL";
                            lbputinSMTstatus.ForeColor = Color.Red;
                            gbPutinSMTstatus.Text = "This solder paste has a circle living out off time\r\n can not use anymore!!!";
                            counttmstatus = 0;
                            return;
                        }
                    }
                    if (timeoutside != "" && dt.Rows[0]["CHECK"].ToString().Contains("1"))
                    {
                        TimeSpan temp = servernow - Convert.ToDateTime(timeoutside);
                        if (temp.TotalHours >= time_outside)
                        {
                            lbputinSMTstatus.Text = "FAIL";
                            lbputinSMTstatus.ForeColor = Color.Red;
                            gbPutinSMTstatus.Text = "This solder paste was put out more time than spec!!!";
                            counttmstatus = 0;
                            return;
                        }
                    }
                    //DOING
                    history = new updateHistory() { action = 5, time = servernow.ToString(), historyuser = this.user, address = Environment.MachineName };
                    if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=5, ADRESS ='" + Environment.MachineName + "',TIME_START_USE=now(),HISTORY='" + getnewhistory(history, txtputinSMTserial.Text) + "' where BARCODE='" + txtputinSMTserial.Text + "'"))
                    {

                        lbputinSMTstatus.Text = "FAIL";
                        lbputinSMTstatus.ForeColor = Color.Red;
                        counttmstatus = 0;
                        return;
                    }
                    else
                    {
                        txtputinSMTserial.Text = "";
                        txtputinSMTserial.Focus();
                        lbputinSMTstatus.Text = "PASS";
                        lbputinSMTstatus.ForeColor = Color.Green;
                        counttmstatus = 0;
                        return;
                        //tmstatus.Stop();
                    }


                }



            }

        }
        
        private void txtputinSMTconfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtputinSMTserial.Focus();
            }

        }
        //public delegate void EventHandlerNew(object sender, EventArgs e,int row);
        void timemerShowStick(object sender, EventArgs e, int row)
        {
            countListTimemrShow[row]--;
            if (countListTimemrShow[row] < 1)
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

                dtgridShowinfo[row, 4].Value = timespanShow[row].ToString("hh ':' MM ':' ss");
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
                //server_ip = "172.16.10.3";
                sqlClass getdata = new sqlClass(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");
                getdata.openConnectNew(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");
                luonchay:
                while (true)
                {
                    try
                    {
                        if (getdata.getconnectionState() == ConnectionState.Open)
                        {
                            if (countinThreadShow % 30 == 0)
                            {
                                countinThreadShow = 1;
                                DataTable dt = getdata.GetDataMySql_Notcloseconnection("(select * from STENCIL_SOLDER_CONTROL where TYPE='Stencil'  and STENCIL_SOLDER_NEW.CHECK=1 and STATE=5 )union (select * from STENCIL_SOLDER_CONTROL where TYPE='Solder Paste'  and STENCIL_SOLDER_NEW.CHECK=1  and (STATE=1 or STATE=3))");
                                if (dt == null || dt.Rows.Count == 0)
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
                                    if (!dt.Rows[i]["TYPE"].ToString().Contains("Solder Paste"))
                                    {
                                        timewash = int.Parse(dt.Rows[i]["TIME_USE"].ToString());
                                        if (count.TotalSeconds >= (timewash - 1200))
                                        {
                                            //installnewRow(count);
                                            this.Invoke((MethodInvoker)delegate
                                            {

                                                dtgridShowinfo.Rows.Add("Stencil", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["CUSTOMER"].ToString(), dt.Rows[i]["ADRESS"], "Time to washing!", "00:00:00", "Hurry Up!!!");
                                                currentRow = dtgridShowinfo.Rows.Count - 1;
                                                dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Red;
                                            });
                                        }
                                        else
                                        {
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                dtgridShowinfo.Rows.Add("Stencil", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["MODEL"].ToString(), dt.Rows[i]["ADRESS"], "online", count.ToString("hh':'mm':'ss"), "using!!!");
                                                currentRow = dtgridShowinfo.Rows.Count - 1; dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Yellow;
                                            });
                                        }
                                    }
                                    else //for solder paste
                                    {
                                        timThawing = int.Parse(dt.Rows[i]["TIME_THAW"].ToString());
                                        timeSpin = int.Parse(dt.Rows[i]["TIME_SPIN"].ToString());
                                        timeturnback = int.Parse(dt.Rows[i]["TIME_TUNRBACK"].ToString());
                                        if (dt.Rows[i]["STATE"].ToString().Contains("3"))//thawing
                                        {

                                            if (count.TotalSeconds >= (timThawing))
                                            {
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    dtgridShowinfo.Rows.Add("Solder Paste", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["MODEL"].ToString(), dt.Rows[i]["Adress"], "Thawed done", "00:00:00", "Realdy to use!!!");
                                                    //currentRow = dtgridShowinfo.Rows.Count-1; dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Green;
                                                });
                                            }
                                            else if (count.TotalSeconds >= (timThawing - 300))
                                            {
                                                //installnewRow(count);
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    dtgridShowinfo.Rows.Add("Solder Paste", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["MODEL"].ToString(), dt.Rows[i]["Adress"], "Thawing", count.ToString("hh':'mm':'ss"), "Almost Ready!!!");
                                                    //currentRow = dtgridShowinfo.Rows.Count-1; dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Yellow;
                                                });
                                            }
                                        }
                                        else if (dt.Rows[i]["STATE"].ToString().Contains("1"))
                                        {
                                            if (count.TotalSeconds > (timeSpin))
                                            {
                                                //installnewRow(count);
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    dtgridShowinfo.Rows.Add("Solder Paste", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["CUSTOMER"].ToString(), dt.Rows[i]["Adress"], "Spined done", "00:00:00", "Realdy to use!!!");

                                                });
                                            }
                                            else
                                            {
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    dtgridShowinfo.Rows.Add("Solder Paste", dt.Rows[i]["BARCODE"].ToString(), dt.Rows[i]["CUSTOMER"].ToString(), dt.Rows[i]["Adress"], "Spinning", count.ToString("hh':'mm':'ss"), "Almost Ready!!!");
                                                    //currentRow = dtgridShowinfo.Rows.Count-1; dtgridShowinfo.Rows[currentRow].DefaultCellStyle.ForeColor = Color.Yellow;
                                                });
                                            }
                                        }
                                    }
                                }
                                //request and update status
                            }
                            else
                            {
                                //increase counting
                                Thread.Sleep(1000);
                                countinThreadShow++;
                            }
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            getdata.openConnectNew(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");
                            //getdata = new sqlClass(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");
                        }

                    }
                    catch
                    {
                        Thread.Sleep(1000);

                        getdata.openConnectNew(server_ip, "PRODUCTION_TRACER", "admin", "ManuAdmin$123");
                        goto luonchay;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        private void showInfoRealTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!login)
            {
                MessageBox.Show("Please login first!");
                return;
            }
            dtgridShowinfo.Visible = true;
            panel1.Visible = false;
            gbCheckinfo.Visible = false;
            try
            {
                if (showAllinfo.IsAlive)
                    return;
            }catch
            {

            }
            showAllinfo = new Thread(updategrivewInfo);
            showAllinfo.IsBackground = true;
            showAllinfo.Start();
            
        }

        private void stickLableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(gbsticklable);
            rbstickNote.Text = "";
            txtstickserial.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt_ = sqlconnect.GetDataMySQL("select BARCODE,DATE_STORE,STATE,ADRESS from STENCIL_SOLDER_CONTROL  where BARCODE='" + textBox1.Text + "'");
                if (dt_ == null || dt_.Rows.Count == 0)
                { MessageBox.Show("Không tìm thấy"); return; }
                dataGridView1.DataSource = dt_;
                dataGridView1.BringToFront();
            }
        }

        private void checkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!login)
            {
                MessageBox.Show("Please login first!");
                return;
            }
            gbCheckinfo.Visible = true;
            cbgrcheckinfolooktype.SelectedIndex = 0;
            txtcheckinfoSerial.Clear();
            panel1.Visible = false;
            dtgridShowinfo.Visible = false;
            txtcheckinfoSerial.Focus();
               
            

        }

        private void cbgrcheckinfolooktype_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbgrcheckinfolooktype.SelectedIndex == 0)
            {
                txtcheckinfoSerial.Clear();
                txtcheckinfoSerial.Focus();
                return;
            }else
            {
                txtgbcheckinfoPartnumber.Clear();
                txtgbcheckinfoPartnumber.Focus();
            }
            
            //DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where STATE<>5 and BARCODE not like '%" + pretext + "'");
            
        }

        private void txtcheckinfoSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where BARCODE ='" + txtcheckinfoSerial.Text.Trim() + "'");
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("this barcode not exist!!!");
                    return;
                }
                dtgridCheckInfo.DataSource = dt;
                
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
            if (fromExcel != null && dataGridView1.Visible == true)
            {
                string SQLcmd = "";
                string TotalSQLcmd = "";
                string Vender_ID = "";
                string Customer_ID = "";
                try
                {
                    for (int i = 0; i < fromExcel.Rows.Count; i++)
                    {
                        Vender_ID = fromExcel.Rows[i][0].ToString();
                        Customer_ID = fromExcel.Rows[i][1].ToString();
                        //
                        SQLcmd = @"INSERT INTO STENCIL_SOLDER_CONTROL (`BARCODE`,`CUSTOMER`,`TYPE`, `DATE_STORE`, `STATE`)values('" + fromExcel.Rows[i][0] + "','" + fromExcel.Rows[i][1] + "','" + fromExcel.Rows[i][2] + "','" + fromExcel.Rows[i][3] + "',2) ;";
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
            dataGridView1.BringToFront();
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            
            for (int i = 0; i < dtgridputinstore.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgridputinstore.Rows[i].Cells["select"].Value) == true)
                {
                    DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL  where BARCODE='" + dtgridputinstore.Rows[i].Cells["sn"].Value.ToString() + "'");
                    if (dt.Rows[0]["TIME_START_USE"].ToString().Length != 0)
                    {
                        MessageBox.Show("Không được Xóa !!!");
                        return;
                    }
                    sqlconnect.InsertDataMySQL("delete from STENCIL_SOLDER_CONTROL where BARCODE ='" + dtgridputinstore.Rows[i].Cells["sn"].Value.ToString() + "' ");

                }
            }
            dtgridputinstore.Rows.Clear();
            refreshfrmPutin();
        }

       

        private void cbbputinsearch_SelectedIndexChanged(object sender, EventArgs e)
        {


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
                            wr.Write(dt.Rows[run][i].ToString().Trim() + ",");
                        }
                        wr.WriteLine();
                    }
                    wr.Close();
                }
                catch (Exception ex)
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
            if (dtgridputinstore.Rows.Count == 0)
            {
                MessageBox.Show("Lấy dữ liêu muốn lưu trước!");
                return;
            }
            DataTable dt = GetDataGridViewAsDataTable(dtgridputinstore);
            savetoCSV(dt);
        }
        public void refreshfrmPutin()
        {
            DataTable dt_ = sqlconnect.GetDataMySQL("select BARCODE,CUSTOMER,TYPE,DATE_STORE,STATE,ADRESS from STENCIL_SOLDER_CONTROL ORDER BY ID DESC LIMIT 0,10");
            for (int i = 0; i < dt_.Rows.Count; i++)
            {
                dtgridputinstore.Rows.Add("False", dt_.Rows[i]["BARCODE"].ToString(), dt_.Rows[i]["CUSTOMER"].ToString(), dt_.Rows[i]["TYPE"].ToString(), dt_.Rows[i]["DATE_STORE"].ToString(), dt_.Rows[i]["STATE"].ToString(), dt_.Rows[i]["ADRESS"].ToString());
            }
        }
        private void txtputincustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtputinSerial.Text = "";
                txtputinSerial.Focus();
            }
        }

        private void txtputoutcustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtputoutserial.Focus();
            }
        }

        private void txtputoutSMTcustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtputoutSMTserial.Focus();
            }
        }

        private void txtputoutSMTserial_KeyDown(object sender, KeyEventArgs e)
        {
            DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
            if (e.KeyCode == Keys.Enter)
            {
                //for stencil
                tmtimeLeft.Stop();
                gbindex = 7;


                DataTable dt = sqlconnect.GetDataMySQL("Select * from STENCIL_SOLDER_CONTROL where STATE=5  and BARCODE='" + txtputoutSMTserial.Text.Trim() + "' ");
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("this barcode is invalid!!");
                    return;
                }

                TimeSpan count = servernow - Convert.ToDateTime(dt.Rows[0]["TIME_START_USE"]);
                if (!dt.Rows[0]["TYPE"].ToString().Contains("Solder Paste") && dt.Rows[0]["CHECK"].ToString().Contains("1"))
                {

                    timewash = int.Parse(dt.Rows[0]["TIME_USE"].ToString());

                    if (count.TotalSeconds > (timewash + MaxTimeDelayWashingStencil))
                    {

                        MessageBox.Show("This stencil is out off time for using >" + MaxTimeDelayWashingStencil + " seconds, Please call QC to confirm!!!", "Note", MessageBoxButtons.OK);
                        QC loginQC = new QC(sqlconnect);
                        loginQC.ShowDialog();
                        if (!loginQC.updateDone)
                        {
                            return;
                        }

                    }
                }


                history = new updateHistory() { action = 6, time = servernow.ToString("yyyy-MM-dd hh:mm:ss"), historyuser = this.user, address = Environment.MachineName };

                if (!sqlconnect.InsertDataMySQL("update STENCIL_SOLDER_CONTROL set STATE=6, TIME_END_USE=now(),HISTORY='" + getnewhistory(history, txtputoutSMTserial.Text.Trim()) + "' where BARCODE='" + txtputoutSMTserial.Text.Trim() + "'"))
                {

                    lbputoutSMTstatus.Text = "FAIL";
                    lbputoutSMTstatus.ForeColor = Color.Red;

                }
                else
                {
                    txtputoutSMTserial.Text = "";
                    //txtputinSMTconfirm.Enabled = false;
                    lbputoutSMTstatus.Text = "PASS";
                    lbputoutSMTstatus.ForeColor = Color.Green;
                    counttimeThaw = -1;
                }
                counttmstatus = 0;



                //tmtimeLeft.Stop();
            }

        }

        private void putOutSMTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(grbPutoutSMT);
            if (!checkSanxuat())
                return;
            txtputoutSMTserial.Clear();
            txtputoutSMTserial.Focus();
        }

        

       

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangPass a = new ChangPass(password, user, server_ip);
            a.ShowDialog();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authority != 10 && authority != 0)
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này!");
                return;
            }
            Setting a = new Setting(sqlconnect, modelList, customerList);
            a.ShowDialog();
        }

        private void dtgridShowinfo_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void dtgridShowinfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            string a = dtgridShowinfo.Rows[e.RowIndex].Cells[6].Value.ToString();
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

        private void cbputoutmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable checkdetail = sqlconnect.GetDataMySQL("Select PART_INTER from SOLDER_RULE where INSTR(MODEL,'" + cbputoutmodel.Text + "')>0");
            if (checkdetail == null || checkdetail.Rows.Count == 0)
            {
                MessageBox.Show("Model này không có mã kem hàn nào phù hợp!");
                return;
            }
            List<DataTable> alltable = new List<DataTable>();
            try
            {
                for (int i = 0; i < checkdetail.Rows.Count; i++)
                {
                    DataTable temp = sqlconnect.GetDataMySQL("SELECT BARCODE,PART_INTER,CUSTOMER,DATE_STORE,EXPIRY_DATE FROM STENCIL_SOLDER_NEW where STATE=2 AND TYPE='Solder Paste' and PART_INTER='" + checkdetail.Rows[i][0].ToString() + "' AND DATE_STORE <= (select MIN(DATE_STORE) from STENCIL_SOLDER_NEW where STATE=2 AND TYPE='Solder Paste' and PART_INTER='" + checkdetail.Rows[i][0].ToString() + "');");
                    if (temp == null || temp.Rows.Count == 0)
                    {
                        continue;
                    }
                    alltable.Add(temp);
                }
                for (int i = 1; i < alltable.Count; i++)
                {
                    for (int j = 0; j < alltable[i].Rows.Count; j++)
                    {
                        DataRow row;
                        this.Invoke((MethodInvoker)delegate
                        {
                            row = alltable[i].Rows[j];
                        });
                    }
                }
                dtgputoutsearchDeal.DataSource = alltable[0];
            }
            catch (Exception ex) { /*MessageBox.Show(ex.ToString()); */}

        }
        private bool CheckAlreadyRequest(string PartNumber, string model)
        {
            string SQLcmd = "SELECT * FROM LINE_CURRENT_REQUEST WHERE PART_INTER = '" + PartNumber + "' AND MODEL='" + model + "'  AND STATE=1;";
            DataTable dt = sqlconnect.GetDataMySQL(SQLcmd);
            //
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btncall_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.SOLDER_RULE where PART_INTER='" + txtpartnumber.Text + "' and INSTR(MODEL,'" + txtmodel.Text + "')>0;");
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Model or PartNumber is invalided!");
                    return;
                }
                else
                {
                    if (CheckAlreadyRequest(txtpartnumber.Text, txtmodel.Text.ToUpper()))
                    {
                        MessageBox.Show("Already request, please check again");
                        return;
                    }
                    try
                    {
                        int.Parse(txtcountCall.Text);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Nhập lại số lượng yêu cầu!");
                        return;
                    }

                    string temp = "INSERT INTO `LINE_CURRENT_REQUEST` (`PART_INTER`, `REQUEST_QTY`, `TIME_REQUEST`,`USER`,`MODEL`,STATE) VALUES ('" + txtpartnumber.Text + "', '" + txtcountCall.Text + "', NOW(),'"+user+"', '" + txtmodel.Text.Trim() + "',1);";
                    try
                    {
                        sqlconnect.InsertDataMySQL(temp);
                        MessageBox.Show("Issue request Sucess");
                        showavailableRequest(ref dtgrequest);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //
                    txtmodel.Clear();
                    txtpartnumber.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            return;


        }
        public void showresponsedRequest(ref DataGridView dt)
        {
            try
            {
                dt.DataSource = sqlconnect.GetDataMySQL("select * from LINE_CURRENT_REQUEST where date(TIME_REQUEST)= current_date() and STATE=2;");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        public void showavailableRequest(ref DataGridView dtg)
        {
            try
            {
                dtg.DataSource = sqlconnect.GetDataMySQL("select * from LINE_CURRENT_REQUEST where date(TIME_REQUEST)= current_date() and STATE=1;");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = sqlconnect.GetDataMySQL("SELECT * FROM LINE_CURRENT_REQUEST where PART_INTER='" + txtpartnumber.Text + "' and MODEL='" + txtmodel.Text.ToUpper() + "' and STATE=1;");
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("this request is not available!");
                    return;
                }
                string temp = "delete from LINE_CURRENT_REQUEST where PART_INTER='" + txtpartnumber.Text+"' and MODEL='"+txtmodel.Text+"' and STATE=1;";
                try
                {
                    sqlconnect.InsertDataMySQL(temp);
                    MessageBox.Show("DELETE request Sucess");
                    showavailableRequest(ref dtgrequest);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            return;
        }

      

        

        private void tmupdaterequest_Tick(object sender, EventArgs e)
        {
            showavailableRequest(ref dtgrequest);
            showresponsedRequest(ref dtgresponse);
        }

        

        private void callSolderPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(CallSolderPaste);
            if (!checkSanxuat())
                return;
            tmupdaterequest.Enabled = true;
            txtpartnumber.Clear();
            txtcountCall.Clear();
            txtmodel.Clear();
            
        }

        private void txtgbcheckinfoPartnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (cbgrcheckinfolooktype.SelectedIndex == 1)
                {
                    //online
                    DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where STATE=5 and TYPE='Stencil' and PART_INTER='" + txtgbcheckinfoPartnumber.Text + "'");
                    dtgridCheckInfo.DataSource = dt;
                }
                else
                {
                    //offline
                    DataTable dt = sqlconnect.GetDataMySQL("select * from STENCIL_SOLDER_CONTROL where STATE<>5 and TYPE='Stencil' and PART_INTER='" + txtgbcheckinfoPartnumber.Text + "'");
                    dtgridCheckInfo.DataSource = dt;
                }
            }
        }

        private void txtserchputinpartnb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                
                DataTable dt_ = sqlconnect.GetDataMySQL("select BARCODE,PART_INTER,PART_NUMBER,DATE_STORE,EXPIRY_DATE,STATE,ADRESS,CUSTOMER from STENCIL_SOLDER_CONTROL where STATE=2 and TYPE ='Solder Paste' and PART_INTER='" + txtserchputinpartnb.Text + "' ORDER BY EXPIRY_DATE ");
                if (dt_ == null || dt_.Rows.Count == 0)
                {
                    txtcount.Text = "0";
                    return;
                }
                dataGridView1.DataSource = dt_;
                dataGridView1.BringToFront();
                txtcount.Text = dt_.Rows.Count.ToString();
                DateTime servernow = (DateTime)sqlconnect.GetDataMySQL("select current_timestamp();").Rows[0][0];
                DateTime temp;
                for (int i = 0; i < dt_.Rows.Count; i++)
                {
                    temp = Convert.ToDateTime(dataGridView1.Rows[i].Cells["EXPIRY_DATE"].Value.ToString());
                    if (servernow.Date.Subtract(temp.Date).TotalDays<datewarning)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void txtstickserial_KeyDown(object sender, KeyEventArgs e)
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

       
    }
    
}
