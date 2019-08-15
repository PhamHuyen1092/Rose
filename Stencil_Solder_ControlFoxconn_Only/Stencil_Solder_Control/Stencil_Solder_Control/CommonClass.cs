using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Stencil_Solder_Control
{
    public enum SatationStatus { NG = 0, OK };
    //
    public enum TableGetData { NULL_TABLE = 0, PANEL_SHEET = 1, PWB_PCS };
    /// <summary>
    /// lop thao tac voi SQL
    /// </summary>
    public class sqlClass
    {
        MySqlCommand Acomman;
        MySqlConnection Aconnection;
        string IPserver = "";
        string DatabaseName = "";
        string User = "";
        string PassWord = "";

        public sqlClass(string IPserver, string DatabaseName, string User, string PassWord)
        {
            this.IPserver = IPserver;
            this.DatabaseName = DatabaseName;
            this.User = User;
            this.PassWord = PassWord;
        }
        
        public DataTable GetDataMySql_Notcloseconnection(string comman)
        {
            DataTable dt = new DataTable();            
            dt = GetDataTableMySQL(comman);
           
            return dt;
        }
        public DataTable GetDataMySQL(string Comman)
        {
            DataTable dt = new DataTable();
            if (openConnect(IPserver, DatabaseName, User, PassWord))
            {
                dt = GetDataTableMySQL(Comman);
                closeConnect();
            }
            else
            {
                return null;
            }
            return dt;
            //

        }
        public string GetVender_PartText(string PART_ID)
        {
            DataTable dt = new DataTable();
            if (openConnect(IPserver, DatabaseName, User, PassWord))
            {
                dt = GetDataTableMySQL("Select * from PART_PART_DID where PDID='"+PART_ID+"'");
                closeConnect();
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["VENDER_PART_NUMBER"].ToString();
                }
            }            
            
            return null;
        }
        public bool InsertDataMySQL(string Comman)
        {
            if (openConnect(IPserver, DatabaseName, User, PassWord))
            {
                if (ExecuteMySQL(Comman))
                {
                    closeConnect();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        // Save picture
        //public void InsertPictureToMySQL(string IPserver, string DatabaseName, string User, string PassWord, string TableName, string ColumsName, Byte[] DataPicture)
        //{
        //    string MyConString = "SERVER = " + IPserver + ";" + "DATABASE = " + DatabaseName + ";" + "UID = " + User + ";" + "PASSWORD = " + PassWord;
        //    string Comman = "INSERT INTO " + TableName + " (" + ColumsName + ") VALUES (?image);";
        //    //create command and assign the query and connection from the constructor
        //    MySqlConnection connection = new MySqlConnection(MyConString);
        //    //----------------
        //    connection.Open();
        //    var data = DataPicture;
        //    using (var cmd = new MySqlCommand(Comman, connection))
        //    {
        //        cmd.Parameters.Add("?image", data);
        //        cmd.ExecuteNonQuery();
        //    }
        //    connection.Close();
        //}
        ////
        //// Save picture
        //public void UpdatePictureToMySQL(string IPserver, string DatabaseName, string User, string PassWord, string TableName, string ColumsName, string ColumsAddr, string RowAddr, Byte[] DataPicture)
        //{
        //    string MyConString = "SERVER = " + IPserver + ";" + "DATABASE = " + DatabaseName + ";" + "UID = " + User + ";" + "PASSWORD = " + PassWord;
        //    string Comman = "UPDATE " + TableName + " SET `" + ColumsName + "`=?image WHERE `" + ColumsAddr + "`='" + RowAddr + "';";
        //    //
        //    //create command and assign the query and connection from the constructor
        //    MySqlConnection connection = new MySqlConnection(MyConString);
        //    //----------------
        //    connection.Open();
        //    var data = DataPicture;
        //    using (var cmd = new MySqlCommand(Comman, connection))
        //    {
        //        cmd.Parameters.Add("?image", data);
        //        cmd.ExecuteNonQuery();
        //    }
        //    connection.Close();
        //}
        ////
        public byte[] RetrieveImage(string IPserver, string DatabaseName, string User, string PassWord, string Comman)
        {
            byte[] imageData = null;
            string MyConString = "SERVER = " + IPserver + ";" + "DATABASE = " + DatabaseName + ";" + "UID = " + User + ";" + "PASSWORD = " + PassWord;
            MySqlConnection connection = new MySqlConnection(MyConString);
            connection.Open();
            //
            MySqlCommand cmd = new MySqlCommand(Comman, connection);
            MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            reader.Read();
            long bytesize = reader.GetBytes(0, 0, null, 0, 0);
            imageData = new byte[bytesize];
            long bytesread = 0;
            int curpos = 0;
            int chunkSize = 1;
            while (bytesread < bytesize)
            {
                bytesread += reader.GetBytes(0, curpos, imageData, curpos, chunkSize);
                curpos += chunkSize;
            }
            connection.Close();
            return imageData;
        }
        //
        // tao database
        public void CreateDatabase(string IPserver, string User, string PassWord, string Comman)
        {
            string MyConString = "SERVER = " + IPserver + ";" + "UID = " + User + ";" + "PASSWORD = " + PassWord;
            //create command and assign the query and connection from the constructor
            MySqlConnection connection = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand(Comman, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //====================================================================
        //public bool openConnect()
        //{
        //    return openConnect(IPserver, DatabaseName, User, PassWord);
        //}
        //
        public ConnectionState getconnectionState()
        {
            return Aconnection.State;
        }
        private bool openConnect(string IPserver, string DatabaseName, string User, string PassWord)
        {
            try
            {
                string MyConString = "SERVER = " + IPserver + ";" + "DATABASE = " + DatabaseName + ";" + "UID = " + User + ";" + "PASSWORD = " + PassWord + ";charset=utf8;SslMode=none;";
                Aconnection = new MySqlConnection(MyConString);
                Acomman = new MySqlCommand();
                Acomman = Aconnection.CreateCommand();
                Aconnection.Open();
                return true;
            }
            catch (Exception Ex)
            {
                string Exm = Ex.Message;
                return false;
            }
        }
        public bool openConnectNew(string IPserver, string DatabaseName, string User, string PassWord)
        {
            try
            {
                string MyConString = "SERVER = " + IPserver + ";" + "DATABASE = " + DatabaseName + ";" + "UID = " + User + ";" + "PASSWORD = " + PassWord + ";charset=utf8;SslMode=none;convert zero datetime=True;";
                Aconnection = new MySqlConnection(MyConString);
                Acomman = new MySqlCommand();
                Acomman = Aconnection.CreateCommand();
                Aconnection.Open();
                return true;
            }
            catch (Exception Ex)
            {
                string Exm = Ex.Message;
                return false;
            }
        }
        //
        public bool closeConnect()
        {
            try
            {
                Aconnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //
        private DataTable GetDataTableMySQL(string Comman1)
        {
            DataTable dt = new DataTable();
            //
            //MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            //dataAdapter.SelectCommand = new MySqlCommand(select_cmd, conn);
            //DataTable table = new DataTable();
            //dataAdapter.Fill(table);
            //
            Acomman.CommandType = CommandType.Text;// vua them
            Acomman.CommandText = Comman1;
            Acomman.Connection = Aconnection; // vua them
            // =========================================
            try
            {
                MySqlDataAdapter readerAdapter = new MySqlDataAdapter(Acomman);
                readerAdapter.Fill(dt); // DO DU LIEU VAO TABLE
                return dt;
            }
            catch (Exception ex)
            {
                string Emess = ex.Message;
                return null;
            }
        }
        //
        private bool ExecuteMySQL(string Comman)
        {
            Acomman.CommandType = CommandType.Text;// vua them
            Acomman.CommandText = Comman;
            Acomman.Connection = Aconnection; // vua them
            // =========================================
            MySqlTransaction transaction;
            transaction = Aconnection.BeginTransaction();// bat dau qua trinh transaction
            Acomman.Transaction = transaction;
            //===================================
            try
            {
                Acomman.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                string data = ex.Message;
                return false;
            }
        }

    }
    //
    //
    //******************************************************************************************************************************************************/
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "192.168.1.254";
            database = "SPARE_PART";
            uid = "admin";
            password = "tsadmin";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        // MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Execute command
                cmd.ExecuteNonQuery();
                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "D:\\" + year + "-" + month + "-" + day + "-" + hour + "-" + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"E:\MySQL Workbench 6.0.8 CE\mysqldump.exe";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                //MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                // MessageBox.Show("Error , unable to Restore!");
            }
        }
    }
    /// <summary>
    /// thong tin ve part phu kien
    /// </summary>
    public class ComponentPart_t
    {
        public string ComponentID = "";
        public string PartNumber = "";
        public List<string> ListPartNumber = new List<string>();
        public string PartName = "";
        public int TargetQty = 0;
        public int ActualQty = 0;
        public ComponentPart_t(string PartNumber, string PartName, string ComponentID, int TargetQty, int ActualQty, List<string> ListPartNumber)
        {
            this.PartNumber = PartNumber;
            this.PartName = PartName;
            this.ComponentID = ComponentID;
            this.TargetQty = TargetQty;
            this.ActualQty = ActualQty;
            this.ListPartNumber = ListPartNumber;
        }
        // This is the serialization constructor.
        // Satisfies rule: ImplementSerializationConstructors.
        /**
         * public RequestTypeTrans RequestType = RequestTypeTrans.Check;
        public CheckType WhatCheck = CheckType.NON;
         * */
        protected ComponentPart_t(SerializationInfo info, StreamingContext context)
        {
            ComponentID = (string)info.GetValue("ComponentID", typeof(string));
            PartNumber = (string)info.GetValue("PartNumber", typeof(string));
            PartName = (string)info.GetValue("PartName", typeof(string));
            ListPartNumber = (List<string>)info.GetValue("ListPartNumber", typeof(List<string>));
            //
            TargetQty = (int)info.GetValue("TargetQty", typeof(int));
            ActualQty = (int)info.GetValue("ActualQty", typeof(int));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ComponentID", ComponentID, ComponentID.GetType());
            info.AddValue("PartNumber", PartNumber, PartNumber.GetType());
            info.AddValue("PartName", PartName, PartName.GetType());
            info.AddValue("TargetQty", TargetQty, TargetQty.GetType());
            info.AddValue("ActualQty", ActualQty, ActualQty.GetType());
            info.AddValue("ListPartNumber", ListPartNumber, ListPartNumber.GetType());
        }
        /// <summary>
        /// Xoa cac thong tin part da ban va thiet lap lai ban dau
        /// </summary>
        public void Reset()
        {
            ActualQty = 0;
        }
        /// <summary>
        /// Kiem tra xem da ban du so luong chua
        /// </summary>
        /// <returns></returns>
        public bool IsComplete()
        {
            if (ActualQty == TargetQty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //
    }

    public class Station_t
    {
        /// <summary>
        /// Ma nhan dang cong doan
        /// </summary>
        public string idStation = "";
        /// <summary>
        /// tên cong đoạn
        /// </summary>
        public string nameStation = "";
        /// <summary>
        /// Địa chỉ của công đoạn
        /// </summary>
        public string ipStation = "";
        /// <summary>
        /// thời gian mà sản phầm được đọc tại công đoạn
        /// </summary>
        public DateTime StationTime = DateTime.MinValue;
        /// <summary>
        /// Tên line sản xuất
        /// </summary>
        public string LineName = "";
        /// <summary>
        /// Ten nguoi thao tac voi ban mach
        /// </summary>
        public string UserID = "";
        /// <summary>
        /// trang thai cua san pham, bang PASS la pass, bang cac gia tri khac thi tuong ung voi ma loi
        /// </summary>
        public string ProductStatus = "UNKOWN";

        public Station_t()
        {
            ipStation = "";
            nameStation = "";
            idStation = "";
            StationTime = DateTime.MinValue;
            LineName = "";
            UserID = "";
            ProductStatus = "UNKOWN";
        }
        public Station_t(string idStation, string nameStation, string ipStation, DateTime StationTime, string LineName, string UserID, string ProductStatus)
        {
            this.idStation = idStation;
            this.nameStation = nameStation;
            this.ipStation = ipStation;
            this.StationTime = StationTime;
            this.LineName = LineName;
            this.UserID = UserID;
            this.ProductStatus = ProductStatus;
        }
    }
    //
    public enum SatationPost { FIRST = 1, MIDDLE, LAST, TO_CUSTOMER };
    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Millisecond;
    };
    //
    /// <summary>
    /// chua cac thong tin them can dung cho cac muc dich luu tru thong tin phat sinh
    /// </summary>
    public class OtherInformation
    {
        /// <summary>
        /// Ten cua du lieu can luu
        /// </summary>
        public string NameInfor = "";
        /// <summary>
        /// Noi dung cua du lieu
        /// </summary>
        public string DataContent = "";
        public OtherInformation()
        {
            DataContent = "";
            NameInfor = "";
        }
        public OtherInformation(string NameInfor, string DataContent)
        {
            this.DataContent = DataContent;
            this.NameInfor = NameInfor;
        }
    }
    /// <summary>
    /// Chua thong tin ve cai dat tren may, luu lai seting ra ngoai
    /// </summary>
    public class SettingClass_t
    {
        public string StationID = "";
        public string StationName = "";
        public string LineName = "";
        /// <summary>
        /// so luong ban mach tren mot sheet
        /// </summary>
        public int NumberCavity = 1;
        public string ServerIP = "";
        public int SertverPort = 1701;
        public string dbConnectString = "";
        public string ModelName = "";
        /// <summary>
        /// BANG TRUE neu yeu cau nhap tat ca thong tin
        /// </summary>
        public bool inputFullInfor = true;
        /// <summary>
        /// Nếu sử dụng 1 tem cho cả sheet bản mạch và nhập các thông tin con lấy thông tin tử id sheet
        /// </summary>
        public bool UsePanelID = false;
        public bool UsePanelPCBID = true;
        /// <summary>
        /// phan biet la cong doan dau, cuoi, hay o giua, dung de xac dinh thoi gian nhap san pham vao va ket thuc. 
        /// cong doan đầu = 1, các công đoạn giữa = 2, công đoạn cuối = 3, Xuat hang di khac hang = 4
        /// </summary>
        public SatationPost STPosition = SatationPost.FIRST;
        /// <summary>
        /// Che do hoat dong, 
        /// = 1 : chi nhap panel id
        /// = 2 : chi nhap PWB ID
        /// = 3 : nhap PWB ID, lay thong tin tu panel id
        /// </summary>
        public int OPerationMode = 0;
        /// <summary>
        /// Cong ket noi den thiet bi ngoai vi com port
        /// </summary>
        public string COM_PORT = "COM3";
        public int BaudRate = 115200;
        /// <summary>
        /// Có kiểm tra số serial xem có tồn tại trên hệ thống hay không.
        /// </summary>
        public bool CheckLableSerial = false;
        /// <summary>
        /// có kiểm tra thời gian hết hạn hay không?
        /// </summary>
        public bool CheckTimeExpiry = false;
        /// <summary>
        /// nếu có kiểm tra thời gian hết hạn thì bao nhiêu phút.
        /// </summary>
        public int TimeExpiry_by_minute = 0;
        /// <summary>
        /// Do dai chuoi SERIAL PCB
        /// </summary>
        public int SerialPCBLen = 0;
        /// <summary>
        /// Ky tu fix PCB Serial
        /// </summary>
        public string FixCharPCBserial = "";
        /// <summary>
        /// Do dai chuoi PCB Panel
        /// </summary>
        public int PanelLen = 0;
        /// <summary>
        /// Ky tu fix panel serial
        /// </summary>
        public string FixCharPanel = "";
        /// <summary>
        /// Co can xac nhan lai so serial them 1 lan nua khong, neu co ti bang true
        /// </summary>
        public bool ConfirmSerial = false;
        /// <summary>
        /// truyen thong tin so serial ra cong com
        /// </summary>
        public bool SendSerialToComPort = false;
        /// <summary>
        /// Vi trí bắt đầu của số serial bản mạch
        /// </summary>
        public int SerialPCBStartPositon = 0;
        /// <summary>
        /// Độ dài của số serial bản mạch cần nhập vào
        /// </summary>
        public int SerialPCBInputLength = 0;
        /// <summary>
        /// Neu bang true thì tiến hành in nhãn hàng ra ngoài
        /// </summary>
        public bool PrintLable = false;
        /// <summary>
        /// Tên máy in sẽ sử dụng để in
        /// </summary>
        public string PrinterName = "";
        /// <summary>
        /// Dường dẫn chứa file để in
        /// </summary>
        public string TemparatePrintPath = "";
        //
        public SettingClass_t()
        {
            StationID = "";
            StationName = "";
            LineName = "";
            NumberCavity = 1;
            ServerIP = "";
            SertverPort = 1701;
            dbConnectString = "";
            ModelName = "";
            inputFullInfor = true;
            UsePanelID = false;
            UsePanelPCBID = true;
            STPosition = SatationPost.FIRST;
            OPerationMode = 0;
            COM_PORT = "COM3";
            BaudRate = 115200;
            SerialPCBLen = 0;
            FixCharPCBserial = "";
            PanelLen = 0;
            FixCharPanel = "";
            ConfirmSerial = false;
            SendSerialToComPort = false;
            SerialPCBStartPositon = 0;
            SerialPCBInputLength = 0;
        }
    }
    /// <summary>
    /// Class mota chuong trinh sẽ down load tu mang ve
    /// </summary>
    public class programName_t
    {
        public string ProgramName = "";
        public string PathFileRun = "";
        public string DownLoadUri = "";
        public string DownLoadFileName = "";
        public string Version = "";
        public programName_t(string ProgramName, string PathFileRun, string DownLoadUri, string Version, string DownLoadFileName)
        {
            this.ProgramName = ProgramName;
            this.PathFileRun = PathFileRun;
            this.DownLoadUri = DownLoadUri;
            this.Version = Version;
            this.DownLoadFileName = DownLoadFileName;
        }
    }
    /// <summary>
    /// Chua thong tin ve sua chua
    /// </summary>
    public class Repair_t
    {
        public string ngCode = "";
        public string NgContent = "";
        public string RepairContent = "";
        public string RepairBy = "";
        public string Position = "";
        public string PartReplace = "";
        public DateTime NGtime = DateTime.MinValue;
        public DateTime RepairTime = DateTime.MinValue;
        public Repair_t()
        {
            ngCode = "";
            NgContent = "";
            RepairContent = "";
            RepairBy = "";
            NGtime = DateTime.MinValue;
            RepairTime = DateTime.MinValue;
        }
        public Repair_t(string ngCode, string ngContent, DateTime NGtime)
        {
            this.ngCode = ngCode;
            this.NgContent = ngContent;
            //
            RepairContent = "";
            RepairBy = "";
            this.NGtime = NGtime;
            RepairTime = DateTime.MinValue;
        }
    }
    /// <summary>
    /// Chua thong tin tong hop ve san pham
    /// </summary>
    public class Production_t
    {
        public string ProductionID = "";
        public string PanelID = "";
        public string Model = "";
        public string LotNo = "";
        public string OrderNo = "";
        public int CycleTime = 0;
        public List<Station_t> StationInfor = new List<Station_t>();
        public List<Repair_t> RepairContent = new List<Repair_t>();
        public string Note = "";
        public DateTime StartTime = DateTime.MinValue;
        public DateTime FinshTime = DateTime.MinValue;
        public string ProState = "";
        public Production_t()
        {
            ProductionID = "";
            PanelID = "";
            Model = "";
            LotNo = "";
            OrderNo = "";
            CycleTime = 0;
            StationInfor = new List<Station_t>();
            RepairContent = new List<Repair_t>();
            Note = "";
            StartTime = DateTime.MinValue;
            FinshTime = DateTime.MinValue;
            ProState = "";
        }
        public Production_t(Production_t proInfor)
        {
            ProductionID = proInfor.ProductionID;
            PanelID = proInfor.PanelID;
            Model = proInfor.Model;
            LotNo = proInfor.LotNo;
            OrderNo = proInfor.OrderNo;
            CycleTime = proInfor.CycleTime;
            StationInfor = new List<Station_t>(proInfor.StationInfor);
            RepairContent = new List<Repair_t>(proInfor.RepairContent);
            Note = proInfor.Note;
            StartTime = proInfor.StartTime;
            FinshTime = proInfor.FinshTime;
            ProState = proInfor.ProState;
        }
    }
    //
    public class FunctionClass
    {
        /// <summary>
        /// Xoa ca folder
        /// </summary>
        /// <param name="strFolderName"></param>
        public void DeleteFolder(string strFolderName)
        {
            DirectoryInfo ThuMucNguonDir = new DirectoryInfo(strFolderName);
            if (Directory.Exists(strFolderName))
            {
                try
                {
                    EmptyFolder(ThuMucNguonDir);
                    Directory.Delete(strFolderName);
                }
                catch { }
            }
        }
        //
        //====================================================================
        public void EmptyFolder(DirectoryInfo directoryInfo)
        {
            try
            {
                foreach (FileInfo file in directoryInfo.GetFiles())
                {

                    file.Delete();
                }
                foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
                {
                    EmptyFolder(subfolder);
                }
            }
            catch { }
        }
        //
        public void CopyDirectory(DirectoryInfo ThuMucNguon, DirectoryInfo ThucMucDich)
        {
            try
            {
                if (!ThucMucDich.Exists)
                {
                    ThucMucDich.Create();
                }
                FileInfo[] files = ThuMucNguon.GetFiles();
                foreach (FileInfo file in files)
                {
                    if ((File.Exists(System.IO.Path.Combine(ThucMucDich.FullName, file.Name))) == false)
                    {
                        file.CopyTo(Path.Combine(ThucMucDich.FullName, file.Name));
                    }
                }
                //Xử lý thư mục con
                DirectoryInfo[] dirs = ThuMucNguon.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    string ThucMucDichDir = Path.Combine(ThucMucDich.FullName, dir.Name);
                    CopyDirectory(dir, new DirectoryInfo(ThucMucDichDir));
                }

            }
            catch { }
        }
        //=================================================================================
        public void RenameFolder(string strOldFolderName, string strNewFolderName)
        {
            try
            {
                Directory.Move(strOldFolderName, strNewFolderName);
            }
            catch { }
        }
        /// <summary>
        /// Tao một folder mới
        /// </summary>
        /// <param name="path"></param>
        public void createFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        /// <summary>
        /// Sao chép file
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFIle"></param>
        /// <returns></returns>
        public Boolean coppyfile(string sourceFile, string destinationFIle)
        {
            Boolean valuess = false;
            if (System.IO.File.Exists(sourceFile))
            {
                File.Delete(destinationFIle);
                File.Copy(sourceFile, destinationFIle);
                valuess = true;
            }
            else
            {
                valuess = false;
            }
            return valuess;
        }

        /// <summary>
        /// Doc file text
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadTextFile(string path)
        {
            String line = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        //
        public void writeDatatext(string Path, string Data)
        {
            StreamWriter wr = new StreamWriter(Path);
            wr.WriteLine(Data);
            wr.Close();
        }
        //
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return ("No network adapters with an IPv4 address in the system!");
        }
        public string GetLocalMACAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    return macAddresses;
                }
            }
            return ("No network adapters with an IPv4 address in the system!");
        }
    }
    /// <summary>
    /// Class connect with serial port
    /// </summary>
    public class RS232Class
    {
        // cai dat cong Com
        public bool setting(string portname, Int32 baudrate, ref SerialPort serialPort1)
        {
            serialPort1.PortName = portname;
            serialPort1.BaudRate = baudrate;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;
            serialPort1.ParityReplace = 63;
            serialPort1.DataBits = 8;
            serialPort1.ReadBufferSize = 4096;
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    serialPort1.Open();
                }
                else
                {
                    serialPort1.Open();
                }
                return true;
            }
            catch { }
            return false;
        }
        //============================================
        public String Receive(SerialPort ComPort)
        {
            String ReceiveData = "";
            ReceiveData = ComPort.ReadExisting();
            return ReceiveData;
        }
        //=============================================
        public void Send(SerialPort ComPort, String data)
        {
            ComPort.Write(data);//
        }
        //====================================================
        public void writeByte(byte b, SerialPort serialPort1)
        {
            byte[] buffer = new byte[1];
            buffer[0] = b;
            try
            {
                serialPort1.Write(buffer, 0, 1);// GHI MOT BYTE DU LIEU RA CONG COM
            }
            catch { }
        }
        //=======================================================
        /// <summary>
        /// get all serial port in computer
        /// </summary>
        /// <returns></returns>
        public string[] getport()
        {
            return SerialPort.GetPortNames();
        }
        public void disconnect(SerialPort serialport)
        {
            serialport.Close();
        }
    }
    // chứa thông tin về 1 kich thuoc, thong so linh kien
    public class ChildPartInfor_t
    {
        /// <summary>
        /// The body size
        /// </summary>
        public string BodySize = "1608";
        public double Value = 0;
        public double MinValue = 0;
        public double MaxValue = 0;
        public double Cost = 0;
        public int MOQ = 0;
        public double Weight = 0;
        public ChildPartInfor_t()
        {
            BodySize = "1608";
            Value = 0;
            MinValue = 0;
            MaxValue = 0;
            Cost = 0;
            MOQ = 0;
            Weight = 0;
        }
    }
    //
    public class Condition_t
    {
        /// <summary>
        /// Thời gian cho phép bảo quản, tính theo ngày
        /// </summary>
        public int ExpireDate = 0;
        /// <summary>
        /// Thời gian tối đa được phép mở bao gói
        /// </summary>
        public int OpenPackingExpire = 0;
        public double MinTemperature = 0;
        public double MaxTemperature = 0;
        public double MinHumidity = 0;
        public double MaxHumidity = 0;
        /// <summary>
        /// cấp độ bảo quản độ ẩm
        /// </summary>
        public int HumidityLevel = 6;
        /// <summary>
        /// có cần thiết phải đo LCR hay không. nếu không = false, nếu có = true
        /// </summary>
        public bool NeedLCR = false;
        public Condition_t()
        {
            ExpireDate = 0;
            OpenPackingExpire = 0;
            MinTemperature = 0;
            MaxTemperature = 0;
            MinHumidity = 0;
            MaxHumidity = 0;
            NeedLCR = false;
            HumidityLevel = 6;
        }
    }
    /// <summary>
    /// Chua thong tin ve dia chi cua 1 linh kien
    /// </summary>
    public class PartAddresss_t
    {
        public List<Local_> Address;
        public PartAddresss_t()
        {
            Address = new List<Local_>();
        }
        public string[] ToAddressArray(int index)
        {
            if (Address == null || Address.Count < index)
            {
                return null;
            }
            return new string[] { Address[index].LocalID, Address[index].LocalName };
        }
    }
    /// <summary>
    /// thong tin vi tri linh kien
    /// </summary>
    public class Local_
    {
        public string LocalID = "";
        public string LocalName = "";
        public Local_()
        {
            LocalID = "";
            LocalName = "";
        }
        //
        public Local_(string LocalID, string LocalName)
        {
            this.LocalID = LocalID;
            this.LocalName = LocalName;
        }
    }
    /// <summary>
    /// Thông tin nhà sản xuất linh kiện
    /// </summary>
    public class Vender_t
    {
        public string VenderType = "";
        public string VenderName = "";
        public int LeadTime = 0;
        public int MinPacking = 1;
        public Vender_t()
        {
            VenderName = "";
            VenderType = "";
            LeadTime = 0;
            MinPacking = 1;
        }
        //
        public Vender_t(string VenderType, string VenderName, int LeadTime, int MinPacking)
        {
            this.VenderName = VenderName;
            this.VenderType = VenderType;
            this.LeadTime = LeadTime;
            this.MinPacking = MinPacking;
        }
        public string[] ToArray()
        {
            return new string[] { VenderType, VenderName, LeadTime.ToString() };
        }
    }
    public class PartMaster_
    {
        public int TableID = 0;
        public string VenderPartNumber = "";
        public string InternalPartNumber = "";
        public string CustomerPartNumber = "";
        public string PartName = "";
        public List<Vender_t> Vender = new List<Vender_t>();
        public string Description = "";
        /// <summary>
        /// Loai linh kien la gi? Chia lam 3 loai. Tu dien, Dien tro, Loai khac
        /// </summary>
        public int PartType = 0;
        public ChildPartInfor_t PartInfor = new ChildPartInfor_t();
        public int PackitType = 0;
        public Condition_t ConditionStore = new Condition_t();
        public Image Picture = null;
        public string Note = "";
        public PartAddresss_t Address = new PartAddresss_t();
        public PartMaster_()
        {
            TableID = 0;
            VenderPartNumber = "";
            InternalPartNumber = "";
            CustomerPartNumber = "";
            PartName = "";
            Vender = new List<Vender_t>();
            Description = "";
            PartType = 0;
            PartInfor = new ChildPartInfor_t();
            PackitType = 0;
            ConditionStore = new Condition_t();
            Picture = null;
            Note = "";
            Address = new PartAddresss_t();
        }
    }
    //
    public class BOMitem_t
    {
        /// <summary>
        /// Chua thong tin so thu tự của item trong Bom
        /// </summary>
        public int Item_No = 0;
        /// <summary>
        /// Chua danh sách các linh kiện được phép sử dụng
        /// </summary>
        public List<string> ListPartUsing = new List<string>();
        /// <summary>
        /// Chứa danh sách các mã thông tin nhà cung cấp được phép sử dụng.
        /// </summary>
        public List<string> ListVenTypederUsing = new List<string>();
        /// <summary>
        /// Vị trí của linh kiện trên bản mạch
        /// </summary>
        public string Location = "";
        /// <summary>
        /// Số lượng linh kiện cần dùng
        /// </summary>
        public int Quantity = 0;
        /// <summary>
        /// Thông tin thêm cho người sử dụng
        /// </summary>
        public string Note = "";
        /// <summary>
        /// Ma linh kien su dung chinh
        /// </summary>
        public string MainPartNumber = "";
        public BOMitem_t()
        {
            Item_No = 0;
            ListPartUsing = new List<string>();
            ListVenTypederUsing = new List<string>();
            Location = "";
            Quantity = 0;
            Note = "";
            MainPartNumber = "";
        }
        public string[] toStringArray()
        {
            string PartListUsing = "";
            string VenderUsing = "";
            if (ListPartUsing.Count > 0)
            {
                foreach (string Part in ListPartUsing)
                {
                    PartListUsing += (Part + " ,");
                }
            }
            //
            if (ListVenTypederUsing.Count > 0)
            {
                foreach (string Vender in ListVenTypederUsing)
                {
                    VenderUsing += (Vender + " ,");
                }
            }
            //
            VenderUsing = VenderUsing.TrimEnd(',');
            PartListUsing = PartListUsing.TrimEnd(',');
            return (new string[] { Item_No.ToString(), PartListUsing, VenderUsing, Location, Quantity.ToString(), Note });
        }

    }
    //
    public class Model_t
    {
        public string ModelID = "";
        public string ModelName = "";
        public Model_t()
        {
            ModelID = "";
            ModelName = "";
        }
        public Model_t(string ModelID, string ModelName)
        {
            this.ModelID = ModelID;
            this.ModelName = ModelName;
        }
    }
    //
    public class BOM_DATA_t
    {
        /// <summary>
        /// Chua thong tin ve ID cua toàn bộ BOM
        /// </summary>
        public string BOM_ID = "";
        /// <summary>
        /// Ten Model Su dung
        /// </summary>
        public Model_t Model = new Model_t();
        /// <summary>
        /// Nội dung các item trong bom
        /// </summary>
        public List<BOMitem_t> BOMitem = new List<BOMitem_t>();
        /// <summary>
        /// Nguoi tao BOM
        /// </summary>
        public User_data_t IssueBy = new User_data_t();
        /// <summary>
        /// NGAY THANG TAO BOM
        /// </summary>
        public DateTime TimeIssue = DateTime.Now;
        /// <summary>
        /// NGUOI KIEM TRA BOM
        /// </summary>
        public User_data_t CheckBy = new User_data_t();
        /// <summary>
        /// Thoi gian Check BOM
        /// </summary>
        public DateTime TimeICheck = DateTime.Now;
        /// <summary>
        /// NGUOI PHE DUYET BOM
        /// </summary>
        public User_data_t ApproverBy = new User_data_t();
        /// <summary>
        /// tHOI GIAN PHE DUYET
        /// </summary>
        public DateTime TimeAppover = DateTime.Now;
        /// <summary>
        /// Thoi gian thay doi cuoi cung
        /// </summary>
        public DateTime LastTimeUpdate = DateTime.Now;
        /// <summary>
        /// Phien ban cua BOM
        /// </summary>
        public int Version = 1;
        public BOM_DATA_t()
        {
            BOM_ID = "";
            Model = new Model_t();
            BOMitem = new List<BOMitem_t>();
            //
            IssueBy = new User_data_t();
            TimeIssue = DateTime.Now;
            CheckBy = new User_data_t();
            TimeICheck = DateTime.Now;
            ApproverBy = new User_data_t();
            TimeAppover = DateTime.Now;
            LastTimeUpdate = DateTime.Now;
            Version = 1;
        }
        public void Clear()
        {
            BOM_ID = "";
            BOMitem.Clear();
            Model.ModelID = "";
            Model.ModelName = "";
            //
            IssueBy = new User_data_t();
            TimeIssue = DateTime.Now;
            CheckBy = new User_data_t();
            TimeICheck = DateTime.Now;
            ApproverBy = new User_data_t();
            TimeAppover = DateTime.Now;
            LastTimeUpdate = DateTime.Now;
            Version = 1;
        }
    }
    //
    /// <summary>
    /// Chua thong tin cua 1 item report
    /// </summary>
    public class ReportItem_t
    {
        /// <summary>
        /// Chua thong tin so thu tự của item trong Bom
        /// </summary>
        public int Item_No = 0;
        /// <summary>
        /// Chua danh sách các linh kiện được phép sử dụng
        /// </summary>
        public List<PartMaster_> ListPartUsing = new List<PartMaster_>();
        /// <summary>
        /// Chứa danh sách các mã thông tin nhà cung cấp được phép sử dụng.
        /// </summary>
        public List<Vender_t> ListVenTypederUsing = new List<Vender_t>();
        /// <summary>
        /// Vị trí của linh kiện trên bản mạch
        /// </summary>
        public string Location = "";
        /// <summary>
        /// Số lượng linh kiện cần dùng
        /// </summary>
        public int Quantity = 0;
        /// <summary>
        /// Thông tin thêm cho người sử dụng
        /// </summary>
        public string Note = "";
        //
        public ReportItem_t()
        {
            Item_No = 0;
            ListPartUsing = new List<PartMaster_>();
            ListVenTypederUsing = new List<Vender_t>();
            Location = "";
            Quantity = 0;
            Note = "";
        }
    }
    /// <summary>
    /// Chua thong tin cua BOM Report
    /// </summary>
    public class REPORT_DATA_t
    {
        /// <summary>
        /// Chua thong tin ve ID cua toàn bộ BOM
        /// </summary>
        public string BOM_ID = "";
        /// <summary>
        /// Ten Model Su dung
        /// </summary>
        public Model_t Model = new Model_t();
        /// <summary>
        /// Nội dung các item trong bom
        /// </summary>
        public List<ReportItem_t> ReportData = new List<ReportItem_t>();
        //
        /// <summary>
        /// Nguoi tao BOM
        /// </summary>
        public User_data_t IssueBy = new User_data_t();
        /// <summary>
        /// NGAY THANG TAO BOM
        /// </summary>
        public DateTime TimeIssue = DateTime.Now;
        /// <summary>
        /// NGUOI KIEM TRA BOM
        /// </summary>
        public User_data_t CheckBy = new User_data_t();
        /// <summary>
        /// Thoi gian Check BOM
        /// </summary>
        public DateTime TimeICheck = DateTime.Now;
        /// <summary>
        /// NGUOI PHE DUYET BOM
        /// </summary>
        public User_data_t ApproverBy = new User_data_t();
        /// <summary>
        /// tHOI GIAN PHE DUYET
        /// </summary>
        public DateTime TimeAppover = DateTime.Now;
        /// <summary>
        /// Thoi gian thay doi cuoi cung
        /// </summary>
        public DateTime LastTimeUpdate = DateTime.Now;
        public REPORT_DATA_t()
        {
            BOM_ID = "";
            Model = new Model_t();
            ReportData = new List<ReportItem_t>();
        }
        public void Clear()
        {
            BOM_ID = "";
            ReportData.Clear();
            Model.ModelID = "";
            Model.ModelName = "";
            //
            IssueBy = new User_data_t();
            TimeIssue = DateTime.Now;
            CheckBy = new User_data_t();
            TimeICheck = DateTime.Now;
            ApproverBy = new User_data_t();
            TimeAppover = DateTime.Now;
            LastTimeUpdate = DateTime.Now;
        }
    }
    //
    public class User_data_t
    {
        /// <summary>
        /// ma dinh danh nguoi dung
        /// </summary>
        public string UserID = "";
        /// <summary>
        /// ten nguoi dung
        /// </summary>
        public string UserName = "";
        /// <summary>
        /// phan quyen cho user level nao
        /// </summary>
        public int Authority = 3;
        public User_data_t()
        {
            UserID = "";
            UserName = "";
            Authority = 3;
        }
        public User_data_t(string UserID, string UserName, int Authority)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Authority = Authority;
        }
        //
        public void Clear()
        {
            UserID = "";
            UserName = "";
            Authority = 3;
        }
    }
    /// <summary>
    /// Moi khi check mot doi tuong ok thi tich vao true
    /// </summary>
    public class RegisterStep_t
    {
        public bool CheckDID = false;
        public bool CheckPartNumber = false;
        public RegisterStep_t()
        {
            CheckDID = false;
            CheckPartNumber = false;
        }
        //
        public void Clear()
        {
            CheckDID = false;
            CheckPartNumber = false;
        }
    }
    //
    public class RemainPartData_t
    {
        public List<RemainPartItem_t> RemainData = new List<RemainPartItem_t>();
        public string StoreID = "";
        public RemainPartData_t()
        {
            RemainData = new List<RemainPartItem_t>();
            StoreID = "";
        }
    }
    public class RemainPartItem_t
    {
        public string PartNumber = "";
        public int TotalDID = 0;
        public int TotalQty = 0;
        public string Address1 = "";
        public string Address2 = "";
        //
        public RemainPartItem_t(string PartNumber, int TotalDID, int TotalQty)
        {
            this.PartNumber = PartNumber;
            this.TotalDID = TotalDID;
            this.TotalQty = TotalQty;
            Address1 = "";
            Address2 = "";
        }
        public string[] ToStringArray()
        {
            string temp = "";
            if (Address1.Length > 5)
            {
                PartAddresss_t AddressAuto = new PartAddresss_t();
                AddressAuto = (PartAddresss_t)ConverStringToObj(Address1, AddressAuto.GetType());
                foreach (Local_ loc in AddressAuto.Address)
                {
                    temp += (loc.LocalID + "; ");
                }
                //
                temp = temp.TrimEnd(' ');
                temp = temp.TrimEnd(';');
            }
            return new string[] { this.PartNumber, this.TotalDID.ToString(), this.TotalQty.ToString(), temp, Address2 };
        }
        private object ConverStringToObj(string DataIn, Type objectType)
        {
            try
            {
                if (DataIn[0] == '[')
                {
                    JArray jar = JArray.Parse(DataIn);
                    return jar.ToObject(objectType);
                }
                else
                {
                    JObject job = JObject.Parse(DataIn);
                    return job.ToObject(objectType);
                }
            }
            catch
            {
                return new PartAddresss_t();
            }
        }
    }
    //
    public class ShippingPlanItem_t
    {
        public string ID_Model = "";
        public DateTime DateShipping = DateTime.MinValue;
        public UInt32 PlanSipping = 0;
        public UInt32 ActualShipping = 0;
        public string Note = "";
        public bool AlreadyMake = false;
        //
        public ShippingPlanItem_t(string ID_Model, DateTime DateShipping, UInt32 PlanSipping, UInt32 ActualShipping, string Note, bool AlreadyMake)
        {
            this.ID_Model = ID_Model;
            this.DateShipping = DateShipping;
            this.PlanSipping = PlanSipping;
            this.ActualShipping = ActualShipping;
            this.AlreadyMake = AlreadyMake;
        }
    }
    //
    public class ShippingData_t
    {
        public List<ShippingPlanItem_t> ShippingData = new List<ShippingPlanItem_t>();
        public ShippingData_t()
        {
            ShippingData = new List<ShippingPlanItem_t>();
        }
    }
    //
    public class ChildPartPlanItem_t
    {
        public string VenderPartNo = "";
        public DateTime DatePlan = DateTime.MinValue;
        public int InputPlan = 0;
        public int OutputPlan = 0;
        public int RemainPlan = 0;
        public int MinDayStock = 0;
        public int MaxDayStock = 0;
        /// <summary>
        /// so luong ton kho nho nhat
        /// </summary>
        public int MinStock = 0;
        /// <summary>
        /// So luong ton kho lon nhar
        /// </summary>
        public int MaxStock = 0;
        /// <summary>
        /// so luong dong goi nho nhat can phai mua
        /// </summary>
        public int MinPacking = 0;
        /// <summary>
        /// Gia tri dieu chinh so luong bang tay
        /// </summary>
        public int AdjustValue = 0;
        public ChildPartPlanItem_t(string VenderPartNo, DateTime DatePlan, int InputPlan, int OutputPlan, int RemainPlan, int MinDayStock, int MaxDayStock, int MinStock, int MaxStock, int MinPacking, int AdjustValue)
        {
            this.VenderPartNo = VenderPartNo;
            this.DatePlan = DatePlan;
            this.InputPlan = InputPlan;
            this.OutputPlan = OutputPlan;
            this.RemainPlan = RemainPlan;
            this.MinDayStock = MinDayStock;
            this.MaxDayStock = MaxDayStock;
            this.MinStock = MinStock;
            this.MaxStock = MaxStock;
            this.MinPacking = MinPacking;
            this.AdjustValue = AdjustValue;
        }
    }
    //
    public class PartPlanOrderInfor_t
    {
        public List<ChildPartPlanItem_t> ChildPartInfor = new List<ChildPartPlanItem_t>();
        public DateTime MinDate = DateTime.MinValue;
        public int LastRemain = 0;
        //
        public PartPlanOrderInfor_t(List<ChildPartPlanItem_t> ChildPartInfor, DateTime MinDate, int LastRemain)
        {
            this.ChildPartInfor = ChildPartInfor;
            this.MinDate = MinDate;
            this.LastRemain = LastRemain;
        }
    }
    //
    // =======================================================================================================
    public class POitem_t
    {
        public Int64 itemID = 0;
        public string PONo = "";
        public string VenderPartNo = "";
        public string Description = "";
        /// <summary>
        /// chua thong tin nha cung cap sẽ mua hang
        /// </summary>
        public Supplyer_t SupplyerInfor = new Supplyer_t();
        /// <summary>
        /// chua toan bo thong tin cac nha cung cap co the mua hang
        /// </summary>
        public PurchaseInfor_t SupplierCanBuy = new PurchaseInfor_t();
        //
        public string SupplyerName = "";
        public Vender_t MakerInfor = new Vender_t();
        //
        public DateTime POdate = DateTime.MinValue;
        public DateTime CaculateDate = DateTime.MinValue;
        public DateTime ReceiveDate = DateTime.MinValue;
        public int ActualReceive = 0;
        public int TargetOrder = 0;
        public int ActualOrder = 0;
        public bool AlreadyPO = false;
        public bool AlreadyReceive = false;
        public string IssueBy = "";
        public int LeadTime = 0;
        public POitem_t(Int64 itemID, string PONo, string VenderPartNo,string SupplyerID, string SupplyerName, DateTime POdate, DateTime CaculateDate, DateTime ReceiveDate, int ActualReceive, int TargetOrder, int ActualOrder, bool AlreadyPO, bool AlreadyReceive, string IssueBy, int LeadTime, Supplyer_t SupplyerInfor, string Description, PurchaseInfor_t SupplierCanBuy, Vender_t MakerInfor)
        {
            this.itemID = itemID;
            this.PONo = PONo;
            this.VenderPartNo = VenderPartNo;
            this.SupplyerName = SupplyerName;
            this.POdate = POdate;
            this.CaculateDate = CaculateDate;
            this.ReceiveDate = ReceiveDate;
            this.ActualReceive = ActualReceive;
            this.TargetOrder = TargetOrder;
            this.ActualOrder = ActualOrder;
            this.AlreadyPO = AlreadyPO;
            this.AlreadyReceive = AlreadyReceive;
            this.IssueBy = IssueBy;
            this.LeadTime = LeadTime;
            this.SupplyerInfor = SupplyerInfor;
            this.Description = Description;
            this.SupplierCanBuy = SupplierCanBuy;
            this.MakerInfor = MakerInfor;
        }
        //
        public POitem_t(POitem_t POinfor)
        {
            this.itemID = POinfor.itemID;
            this.PONo = POinfor.PONo;
            this.VenderPartNo = POinfor.VenderPartNo;
            this.SupplyerName = POinfor.SupplyerName;
            this.POdate = POinfor.POdate;
            this.CaculateDate = POinfor.CaculateDate;
            this.ReceiveDate = POinfor.ReceiveDate;
            this.ActualReceive = POinfor.ActualReceive;
            this.TargetOrder = POinfor.TargetOrder;
            this.ActualOrder = POinfor.ActualOrder;
            this.AlreadyPO = POinfor.AlreadyPO;
            this.AlreadyReceive = POinfor.AlreadyReceive;
            this.IssueBy = POinfor.IssueBy;
            this.LeadTime = POinfor.LeadTime;
            this.Description = POinfor.Description;
            this.SupplyerInfor = new Supplyer_t(POinfor.SupplyerInfor);
            SupplierCanBuy = new PurchaseInfor_t();
            this.MakerInfor = new Vender_t(POinfor.MakerInfor.VenderType, POinfor.MakerInfor.VenderName, 30, 1);
        }
    }
    //
    public class POInformation_t
    {
        public List<POitem_t> POinfor = new List<POitem_t>();
        public POInformation_t()
        {
            POinfor = new List<POitem_t>();
        }
        public List<POitem_t> GetSortPO()
        {
            List<POitem_t> SortedList = POinfor.OrderBy(po => po.PONo).ToList();
            return SortedList;
        }
    }
    //
    public class Supplyer_t
    {
        public string Supplrer_ID = "";
        public string Supplyer_Name = "";
        public List<string> Supplyer_Addresss = new List<string>();
        public List<string> Supplyer_PIC = new List<string>();
        public List<string> Supplyer_Phne = new List<string>();
        public List<string> Supplyer_Email = new List<string>();
        //
        public List<string> Goods = new List<string>();
        // THONG TIN CHO MUAHANG
        /// <summary>
        /// Gia Thanh
        /// </summary>
        public double Cost = 0;
        /// <summary>
        /// Don vi tinh gia, là cuộn, chiếc, hay gam
        /// </summary>
        public string PartUnit = "";
        /// <summary>
        /// Don vi tien te
        /// </summary>
        public string CurrencyUnit = "USD";
        /// <summary>
        /// thoi gian giao hang
        /// </summary>
        public int LeadTime = 0;
        /// <summary>
        /// Thoi gian di duong
        /// </summary>
        public int GRDate = 0;
        /// <summary>
        /// Minimun order quantity
        /// </summary>
        public int MOQ = 0;
        /// <summary>
        /// Nguồn gốc, xuất xứ
        /// </summary>
        public string COCQ = "";


        public Supplyer_t()
        {
            Supplrer_ID = "";
            Supplyer_Name = "";
            Supplyer_Addresss = new List<string>();
            Supplyer_PIC = new List<string>();
            Supplyer_Phne = new List<string>();
            Supplyer_Email = new List<string>();
            //
            Goods = new List<string>();
            //
            Cost = 0;
            PartUnit = "";
            CurrencyUnit = "USD";
            LeadTime = 0;
            GRDate = 0;
            MOQ = 0;
            COCQ = "";
        }
        public Supplyer_t(Supplyer_t Suppler)
        {
            Supplrer_ID = Suppler.Supplrer_ID;
            Supplyer_Name = Suppler.Supplyer_Name;
            Supplyer_Addresss = new List<string>(Suppler.Supplyer_Addresss);
            Supplyer_PIC = new List<string>(Suppler.Supplyer_PIC);
            Supplyer_Phne = new List<string>(Suppler.Supplyer_Phne);
            Supplyer_Email = new List<string>(Suppler.Supplyer_Email);
            //
            Goods = new List<string>(Suppler.Goods);
            //
            Cost = Suppler.Cost;
            PartUnit = Suppler.PartUnit;
            CurrencyUnit = Suppler.CurrencyUnit;
            LeadTime = Suppler.LeadTime;
            GRDate = Suppler.GRDate;
            MOQ = Suppler.MOQ;
            COCQ = Suppler.COCQ;
        }
    }
    /// <summary>
    /// Chua cac thong tin can thiet ve mua hang
    /// </summary>
    public class PurchaseInfor_t
    {
        public string VenderPartNo = "";
        public List<Supplyer_t> SupplrerInfor = new List<Supplyer_t>();
        public PurchaseInfor_t()
        {
            SupplrerInfor = new List<Supplyer_t>();
            VenderPartNo = "";
        }
    }
    //
    public class PrintData_t
    {
        public string ObjectName = "";
        public string ObjectData = "";
        public PrintData_t(string ObjectName, string ObjectData)
        {
            this.ObjectName = ObjectName;
            this.ObjectData = ObjectData;
        }
    }
}
