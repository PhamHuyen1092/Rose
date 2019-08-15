using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Excel;

namespace Stencil_Solder_Control
{
    public partial class Setting : Form
    {
        sqlClass sqlconnect;
        public List<string> model;
        public List<string> customer;
        public Setting(sqlClass sqlconnect,List<string>model, List<string>customer)
        {
            this.sqlconnect = sqlconnect;
            InitializeComponent();
            this.model = model;
            this.customer = customer;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            cbtype.SelectedIndex = 0;
            for (int i = 0; i < this.model.Count; i++)
            {
                cbmodelName.Items.Add(model[i]);
            }
            for (int i = 0; i < this.customer.Count; i++)
            {
                cbCustomer.Items.Add(customer[i]);
            }
            cbmodelName.SelectedIndex = 0;
            cbCustomer.SelectedIndex = 0;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if(cbCustomer.Text=="")
            {
                if(cbtype.Text== "Stencil")
                {
                    dataGridView1.DataSource = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.STENCIL_RULE;");
                }else
                {
                    dataGridView1.DataSource = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.SOLDER_RULE;");
                }
                
            }else
            {
                if (cbtype.Text == "Stencil")
                {
                    dataGridView1.DataSource = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.STENCIL_RULE where CUSTOMER='"+cbCustomer.Text+"';");
                    txtwashing.Text = dataGridView1.Rows[0].Cells["TIME_USE"].Value.ToString();
                }
                else
                {
                    dataGridView1.DataSource = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.SOLDER_RULE where CUSTOMER='" + cbCustomer.Text + "';");
                    txtspin.Text= dataGridView1.Rows[0].Cells["TIME_SPIN"].Value.ToString(); 
                    txtthaw.Text= dataGridView1.Rows[0].Cells["TIME_THAW"].Value.ToString();
                    txtturnaround.Text= dataGridView1.Rows[0].Cells["TIME_TUNRBACK"].Value.ToString();
                }
            }
        }
        public bool checkvalid(string[] list)
        {
            foreach (var item in list)
            {
                
                if(item.Trim().Length<1|| item.Trim() == "0")
                {
                    MessageBox.Show("Kiểm tra các giá trị đầu vào không đúng định dạng");
                    return false;
                }
                try
                {
                    int.Parse(item);
                }
                catch (Exception)
                {
                    MessageBox.Show("Kiểm tra các giá trị đầu vào không đúng định dạng");
                    return false;
                    
                }
            }
            return true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtpartInter.Text==""||txtpartNumber.Text=="")
            {
                MessageBox.Show("Kiểm tra các giá trị đầu vào không đúng định dạng");
                return;
            }
            if(txtpartInter.Text.Length!=10)
            {
                MessageBox.Show("Mã nội bộ phải có độ dài 10 ký tự!");
                return;
            }
            DataTable getused = sqlconnect.GetDataMySQL("select PART_INTER FROM PRODUCTION_TRACER.STENCIL_SOLDER_NEW where PART_INTER='" + txtpartInter.Text + "' and MODEL='" + cbmodelName.Text + "' and STATE<>2 and STATE<>6 and CHECK=1;");
            try
            {
                if (getused != null || getused.Rows.Count != 0)
                {
                    MessageBox.Show("Loại này đang được sử dụng , không được sửa, thông báo với IT!");
                    return;
                }
            }catch
            {

            }
            if (checkboxbcontrol.Checked)
            {
                if(cbtype.Text== "Stencil")
                {
                    string[] list = { txtwashing.Text };
                    if(!checkvalid(list))
                    {
                        return;
                    }
                    
                    if(!sqlconnect.InsertDataMySQL("insert into STENCIL_RULE (CUSTOMER,TIME_USE,STENCIL_RULE.CHECK,PART_INTER,PART_NUMBER,MODEL) values('" + cbCustomer.Text+"',"+txtwashing.Text+ ",1,'"+txtpartInter.Text+ "','" + txtpartNumber.Text + "','" + cbmodelName.Text + "') on duplicate key update TIME_USE=" + txtwashing.Text + ", STENCIL_RULE.CHECK=1, MODEL='"+cbmodelName.Text+ "',PART_NUMBER='"+txtpartNumber.Text+ "',CUSTOMER='"+cbCustomer.Text+"';"))
                    {
                        MessageBox.Show("Kiểm tra các giá trị đầu vào không đúng định dạng");
                        return ;
                    }
                }
                else
                {
                    string[] list = { txtspin.Text,txtthaw.Text,txtturnaround.Text,txtturnaround.Text,txtoutside.Text };
                    if (!checkvalid(list))
                    {
                        return;
                    }
                    if(!sqlconnect.InsertDataMySQL("insert into SOLDER_RULE (PART_INTER,PART_NUMBER,MODEL,CUSTOMER,TIME_THAW,TIME_SPIN,TIME_TUNRBACK,TIME_OUTSIDE,SOLDER_RULE.CHECK) values ('" + txtpartInter.Text + "','" + txtpartNumber.Text + "','" + cbmodelName.Text + "','" + cbCustomer.Text + "',"+txtthaw.Text+","+txtspin.Text+","+txtturnaround.Text+ "," + txtoutside.Text + ",1) on duplicate key update TIME_THAW=" + txtthaw.Text+",TIME_SPIN="+txtspin.Text+",TIME_TUNRBACK="+txtturnaround.Text+ ",TIME_OUTSIDE="+txtoutside.Text+ ", SOLDER_RULE.CHECK=1 , MODEL='" + cbmodelName.Text + "',PART_NUMBER='" + txtpartNumber.Text + "',CUSTOMER='" + cbCustomer.Text + "';"))
                    {
                        MessageBox.Show("Kiểm tra các giá trị đầu vào không đúng định dạng");
                        return;
                    }
                }
            }else
            {
                if (cbtype.Text == "Stencil")
                {

                    if(!sqlconnect.InsertDataMySQL("insert into STENCIL_RULE (CUSTOMER,TIME_USE,STENCIL_RULE.CHECK,PART_INTER,PART_NUMBER,MODEL) values('" + cbCustomer.Text + "',0,0,'" + txtpartInter.Text + "','" + txtpartNumber.Text + "','" + cbmodelName.Text + "') on duplicate key update TIME_USE=0, STENCIL_RULE.CHECK=0;"))
                    {
                        MessageBox.Show("Kiểm tra các giá trị đầu vào không đúng định dạng");
                        return;
                    }
                }
                else
                {
                    if(!sqlconnect.InsertDataMySQL("insert into SOLDER_RULE (PART_INTER,PART_NUMBER,MODEL,CUSTOMER,TIME_THAW,TIME_SPIN,TIME_TUNRBACK,TIME_OUTSIDE,SOLDER_RULE.CHECK) values ('" + txtpartInter.Text + "','" + txtpartNumber.Text + "','" + cbmodelName.Text + "','" + cbCustomer.Text + "',0,0,0,0,0) on duplicate key update TIME_THAW=0,TIME_SPIN=0,TIME_TUNRBACK=0,SOLDER_RULE.CHECK=0,TIME_OUTSIDE=0;"))
                    {
                        MessageBox.Show("Kiểm tra các giá trị đầu vào không đúng định dạng");
                        return;
                    }
                }
            }
            btnsearch_Click(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
                try
                {
                    DataTable getused = sqlconnect.GetDataMySQL("select PART_INTER FROM PRODUCTION_TRACER.STENCIL_SOLDER_NEW where PART_INTER='" + txtpartInter.Text + "' and MODEL='" + cbmodelName.Text + "'and STATE<>6 and STATE<>2;");
                    try
                    {
                        if (getused != null && getused.Rows.Count != 0)
                        {
                            MessageBox.Show("Loại này đang được sử dụng , không được xóa!");
                            return;
                        }
                    }
                    catch
                    { }
                    if (cbtype.Text == "Solder Paste")
                    {

                        sqlconnect.InsertDataMySQL("delete from SOLDER_RULE where PART_INTER='" + txtpartInter.Text + "'and MODEL='" + cbmodelName.Text + "';");
                        dataGridView1.DataSource = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.SOLDER_RULE;");
                    }
                    else
                    {
                        sqlconnect.InsertDataMySQL("delete from STENCIL_RULE where PART_INTER='" + txtpartInter.Text + "'and MODEL='" + cbmodelName.Text + "';");
                        dataGridView1.DataSource = sqlconnect.GetDataMySQL("SELECT * FROM PRODUCTION_TRACER.STENCIL_RULE;");
                    }

                    MessageBox.Show("DONE!");

                }
                catch (Exception)
                {

                    MessageBox.Show("FAIL");
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
                    for (int i = 0; i < dtSource.Columns.Count; i++)
                    {
                        try
                        {
                            if (row.Cells[0].Value.ToString().Length < 1)
                            {
                                break;
                            }
                        }
                        catch
                        {
                            break;
                        }
                        drNewRow[i] = row.Cells[i].Value;
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
        private void btnexport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Lấy dữ liêu muốn lưu trước!");
                return;
            }
            DataTable dt = GetDataGridViewAsDataTable(dataGridView1);
            savetoCSV(dt);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string part_inter = "", part_number = "", model = "", customer = "", type="", check = "", timespin = "", timethaw = "", timeturnback = "", timeoutside = "", time_use = "";
            try
            {
                part_inter= dataGridView1.Rows[e.RowIndex].Cells["PART_INTER"].Value.ToString();
                part_number= dataGridView1.Rows[e.RowIndex].Cells["PART_NUMBER"].Value.ToString();
                model= dataGridView1.Rows[e.RowIndex].Cells["MODEL"].Value.ToString();
                check= dataGridView1.Rows[e.RowIndex].Cells["CHECK"].Value.ToString();
                customer = dataGridView1.Rows[e.RowIndex].Cells["CUSTOMER"].Value.ToString();
                time_use = dataGridView1.Rows[e.RowIndex].Cells["TIME_USE"].Value.ToString();

                type = "Stencil";
            }
            catch
            {
                timeoutside= dataGridView1.Rows[e.RowIndex].Cells["TIME_OUTSIDE"].Value.ToString();
                timespin= dataGridView1.Rows[e.RowIndex].Cells["TIME_SPIN"].Value.ToString();
                timeturnback= dataGridView1.Rows[e.RowIndex].Cells["TIME_TUNRBACK"].Value.ToString();
                timethaw = dataGridView1.Rows[e.RowIndex].Cells["TIME_THAW"].Value.ToString();
                type = "Solder Paste";
            }
            if(type== "Solder Paste")
            {
                cbtype.SelectedIndex = 0;
            }
            else
            {
                cbtype.SelectedIndex = 1;
            }
            if(check=="1")
            {
                checkboxbcontrol.Checked = true;
            }
            else
            {
                checkboxbcontrol.Checked = false;
            }
            cbCustomer.Text = customer;cbmodelName.Text = model;txtpartInter.Text = part_inter;txtpartNumber.Text = part_number;
            txtthaw.Text = timethaw;txtturnaround.Text = timeturnback;txtspin.Text = timespin;txtwashing.Text = timethaw;txtoutside.Text = timeoutside;
        }

        private void button1_Click(object sender, EventArgs e)
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
                    dataGridView1.DataSource = dt;
                    //6. Free resources (IExcelDataReader is IDisposable)
                    excelReader.Close();
                    // save to DB
                    string SQLcmd = "";
                    string TotalSQLcmd = "";
                    string Vender_ID = "";
                    string Customer_ID = "";
                    try
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Vender_ID = dt.Rows[i][0].ToString();
                            Customer_ID = dt.Rows[i][1].ToString();
                            if(cbtype.Text== "Solder Paste")
                            {
                                SQLcmd = "insert into SOLDER_RULE (PART_INTER,PART_NUMBER,MODEL,CUSTOMER,TIME_THAW,TIME_SPIN,TIME_TUNRBACK,TIME_OUTSIDE,SOLDER_RULE.CHECK) values ('" + dt.Rows[i]["PART_INTER"].ToString() + "','" + dt.Rows[i]["PART_NUMBER"].ToString() + "','" + dt.Rows[i]["MODEL"].ToString() + "','" + dt.Rows[i]["CUSTOMER"].ToString() + "'," + dt.Rows[i]["TIME_THAW"].ToString() + "," + dt.Rows[i]["TIME_SPIN"].ToString() + "," + dt.Rows[i]["TIME_TUNRBACK"].ToString() + "," + dt.Rows[i]["TIME_OUTSIDE"].ToString() + "," + dt.Rows[i]["CHECK"].ToString()+" ) on duplicate key update TIME_THAW=" + dt.Rows[i]["TIME_THAW"].ToString() + ",TIME_SPIN=" + dt.Rows[i]["TIME_SPIN"].ToString() + ",TIME_TUNRBACK=" + dt.Rows[i]["TIME_TUNRBACK"].ToString() + ",TIME_OUTSIDE=" + dt.Rows[i]["TIME_OUTSIDE"].ToString() + ", SOLDER_RULE.CHECK="+ dt.Rows[i]["CHECK"].ToString() +" , MODEL='" + dt.Rows[i]["MODEL"].ToString() + "',PART_NUMBER='" + dt.Rows[i]["PART_NUMBER"].ToString() + "',CUSTOMER='" + dt.Rows[i]["CUSTOMER"].ToString() + "';";
                            }
                            else
                            {
                                SQLcmd = "insert into STENCIL_RULE (CUSTOMER,TIME_USE,STENCIL_RULE.CHECK,PART_INTER,PART_NUMBER,MODEL) values('" + dt.Rows[i]["CUSTOMER"].ToString() + "'," + dt.Rows[i]["TIME_USE"].ToString() + ","+ dt.Rows[i]["CHECK"].ToString() + ",'" + dt.Rows[i]["PART_INTER"].ToString() + "','" + dt.Rows[i]["PART_NUMBER"].ToString() + "','" + dt.Rows[i]["MODEL"].ToString() + "') on duplicate key update TIME_USE=" + dt.Rows[i]["TIME_USE"].ToString() + ", STENCIL_RULE.CHECK="+ dt.Rows[i]["CHECK"].ToString() + ", MODEL='" + dt.Rows[i]["MODEL"].ToString() + "',PART_NUMBER='" + dt.Rows[i]["PART_NUMBER"].ToString() + "',CUSTOMER='" + dt.Rows[i]["CUSTOMER"].ToString() + "';";
                            }
                            //
                            
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnaddmodel_Click(object sender, EventArgs e)
        {
            addItem add = new addItem(sqlconnect, "PART_MODEL_CONTROL");
            add.ShowDialog();
        }

        private void btnaddcus_Click(object sender, EventArgs e)
        {
            addItem add = new addItem(sqlconnect, "DEFINE_CUSTOMER");
            add.ShowDialog();
        }
    }
}
