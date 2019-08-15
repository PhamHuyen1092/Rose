namespace Stencil_Solder_Control
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stickLableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putInStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putOutStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spinSolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putInSMTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putOutSMTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callSolderPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoRealTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbPutin = new System.Windows.Forms.GroupBox();
            this.cbexpridate = new System.Windows.Forms.CheckBox();
            this.dtpexpirydate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnimporttoDB = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnloaddata = new System.Windows.Forms.Button();
            this.btnsaveCSV = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtcount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtserchputinpartnb = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.rbputinNote = new System.Windows.Forms.RichTextBox();
            this.lbputinstatus = new System.Windows.Forms.Label();
            this.txtputinSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtgridputinstore = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.where = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPutout = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dtgputoutRequesting = new System.Windows.Forms.DataGridView();
            this.Suggestions = new System.Windows.Forms.Label();
            this.dtgputoutsearchDeal = new System.Windows.Forms.DataGridView();
            this.cbputoutmodel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtputoutNote = new System.Windows.Forms.RichTextBox();
            this.lbPutoutstatus = new System.Windows.Forms.Label();
            this.txtputoutserial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbPutinSMT = new System.Windows.Forms.GroupBox();
            this.cbputinSMTmodel = new System.Windows.Forms.ComboBox();
            this.lbputinsmtTimeleft = new System.Windows.Forms.Label();
            this.lbputinSMTconfirm = new System.Windows.Forms.Label();
            this.gbPutinSMTstatus = new System.Windows.Forms.RichTextBox();
            this.lbputinSMTstatus = new System.Windows.Forms.Label();
            this.txtputinSMTserial = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbSpinSolder = new System.Windows.Forms.GroupBox();
            this.lbspecspin = new System.Windows.Forms.Label();
            this.lbspinTimeLeft = new System.Windows.Forms.Label();
            this.rbspinNote = new System.Windows.Forms.RichTextBox();
            this.lbspinstatus = new System.Windows.Forms.Label();
            this.txtspinserial = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbLogIn = new System.Windows.Forms.GroupBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tmlocalTIme = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbsticklable = new System.Windows.Forms.GroupBox();
            this.rbstickNote = new System.Windows.Forms.RichTextBox();
            this.lbstickstatus = new System.Windows.Forms.Label();
            this.txtstickserial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbPutoutSMT = new System.Windows.Forms.GroupBox();
            this.rtbputoutSMT = new System.Windows.Forms.RichTextBox();
            this.lbputoutSMTstatus = new System.Windows.Forms.Label();
            this.txtputoutSMTserial = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.CallSolderPaste = new System.Windows.Forms.GroupBox();
            this.dtgresponse = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dtgrequest = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtpartnumber = new System.Windows.Forms.TextBox();
            this.txtmodel = new System.Windows.Forms.TextBox();
            this.btncall = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtcountCall = new System.Windows.Forms.TextBox();
            this.pnwelcome = new System.Windows.Forms.Panel();
            this.lblocaltime = new System.Windows.Forms.Label();
            this.lbwelcome = new System.Windows.Forms.Label();
            this.tmtimeLeft = new System.Windows.Forms.Timer(this.components);
            this.tmstatus = new System.Windows.Forms.Timer(this.components);
            this.dtgridShowinfo = new System.Windows.Forms.DataGridView();
            this.type__ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BARCODE__ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER__ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADRESS__ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS__ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME__ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTE__ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCheckinfo = new System.Windows.Forms.GroupBox();
            this.txtgbcheckinfoPartnumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.dtgridstate = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbgrcheckinfolooktype = new System.Windows.Forms.ComboBox();
            this.txtcheckinfoSerial = new System.Windows.Forms.TextBox();
            this.lbserial = new System.Windows.Forms.Label();
            this.dtgridCheckInfo = new System.Windows.Forms.DataGridView();
            this.tmupdaterequest = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.gbPutin.SuspendLayout();
            this.info.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridputinstore)).BeginInit();
            this.gbPutout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgputoutRequesting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgputoutsearchDeal)).BeginInit();
            this.gbPutinSMT.SuspendLayout();
            this.gbSpinSolder.SuspendLayout();
            this.gbLogIn.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbsticklable.SuspendLayout();
            this.grbPutoutSMT.SuspendLayout();
            this.CallSolderPaste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgresponse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrequest)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnwelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridShowinfo)).BeginInit();
            this.gbCheckinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridstate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridCheckInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.functionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1071, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.logInToolStripMenuItem.Text = "Log In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stickLableToolStripMenuItem,
            this.putInStoreToolStripMenuItem,
            this.putOutStoreToolStripMenuItem,
            this.spinSolderToolStripMenuItem,
            this.putInSMTToolStripMenuItem,
            this.putOutSMTToolStripMenuItem,
            this.callSolderPasteToolStripMenuItem,
            this.showInfoRealTimeToolStripMenuItem,
            this.checkingToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.functionToolStripMenuItem.Text = "Function";
            // 
            // stickLableToolStripMenuItem
            // 
            this.stickLableToolStripMenuItem.Name = "stickLableToolStripMenuItem";
            this.stickLableToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.stickLableToolStripMenuItem.Text = "Stick Lable";
            this.stickLableToolStripMenuItem.Click += new System.EventHandler(this.stickLableToolStripMenuItem_Click);
            // 
            // putInStoreToolStripMenuItem
            // 
            this.putInStoreToolStripMenuItem.Name = "putInStoreToolStripMenuItem";
            this.putInStoreToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.putInStoreToolStripMenuItem.Text = "Put In Store";
            this.putInStoreToolStripMenuItem.Click += new System.EventHandler(this.putInStoreToolStripMenuItem_Click);
            // 
            // putOutStoreToolStripMenuItem
            // 
            this.putOutStoreToolStripMenuItem.Name = "putOutStoreToolStripMenuItem";
            this.putOutStoreToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.putOutStoreToolStripMenuItem.Text = "Put Out Store";
            this.putOutStoreToolStripMenuItem.Click += new System.EventHandler(this.putOutStoreToolStripMenuItem_Click);
            // 
            // spinSolderToolStripMenuItem
            // 
            this.spinSolderToolStripMenuItem.Name = "spinSolderToolStripMenuItem";
            this.spinSolderToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.spinSolderToolStripMenuItem.Text = "Spin Solder";
            this.spinSolderToolStripMenuItem.Click += new System.EventHandler(this.spinSolderToolStripMenuItem_Click);
            // 
            // putInSMTToolStripMenuItem
            // 
            this.putInSMTToolStripMenuItem.Name = "putInSMTToolStripMenuItem";
            this.putInSMTToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.putInSMTToolStripMenuItem.Text = "Put In SMT";
            this.putInSMTToolStripMenuItem.Click += new System.EventHandler(this.putInSMTToolStripMenuItem_Click);
            // 
            // putOutSMTToolStripMenuItem
            // 
            this.putOutSMTToolStripMenuItem.Name = "putOutSMTToolStripMenuItem";
            this.putOutSMTToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.putOutSMTToolStripMenuItem.Text = "Put Out SMT";
            this.putOutSMTToolStripMenuItem.Click += new System.EventHandler(this.putOutSMTToolStripMenuItem_Click);
            // 
            // callSolderPasteToolStripMenuItem
            // 
            this.callSolderPasteToolStripMenuItem.Name = "callSolderPasteToolStripMenuItem";
            this.callSolderPasteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.callSolderPasteToolStripMenuItem.Text = "Call Solder Paste";
            this.callSolderPasteToolStripMenuItem.Click += new System.EventHandler(this.callSolderPasteToolStripMenuItem_Click);
            // 
            // showInfoRealTimeToolStripMenuItem
            // 
            this.showInfoRealTimeToolStripMenuItem.Name = "showInfoRealTimeToolStripMenuItem";
            this.showInfoRealTimeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showInfoRealTimeToolStripMenuItem.Text = "Info Real Time";
            this.showInfoRealTimeToolStripMenuItem.Click += new System.EventHandler(this.showInfoRealTimeToolStripMenuItem_Click);
            // 
            // checkingToolStripMenuItem
            // 
            this.checkingToolStripMenuItem.Name = "checkingToolStripMenuItem";
            this.checkingToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.checkingToolStripMenuItem.Text = "Checking";
            this.checkingToolStripMenuItem.Click += new System.EventHandler(this.checkingToolStripMenuItem_Click);
            // 
            // gbPutin
            // 
            this.gbPutin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPutin.Controls.Add(this.cbexpridate);
            this.gbPutin.Controls.Add(this.dtpexpirydate);
            this.gbPutin.Controls.Add(this.label6);
            this.gbPutin.Controls.Add(this.info);
            this.gbPutin.Controls.Add(this.rbputinNote);
            this.gbPutin.Controls.Add(this.lbputinstatus);
            this.gbPutin.Controls.Add(this.txtputinSerial);
            this.gbPutin.Controls.Add(this.label2);
            this.gbPutin.Controls.Add(this.dataGridView1);
            this.gbPutin.Controls.Add(this.dtgridputinstore);
            this.gbPutin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPutin.Location = new System.Drawing.Point(16, 30);
            this.gbPutin.Name = "gbPutin";
            this.gbPutin.Size = new System.Drawing.Size(1038, 450);
            this.gbPutin.TabIndex = 1;
            this.gbPutin.TabStop = false;
            this.gbPutin.Text = "PutIn";
            this.gbPutin.Visible = false;
            // 
            // cbexpridate
            // 
            this.cbexpridate.AutoSize = true;
            this.cbexpridate.Checked = true;
            this.cbexpridate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbexpridate.Location = new System.Drawing.Point(891, 127);
            this.cbexpridate.Name = "cbexpridate";
            this.cbexpridate.Size = new System.Drawing.Size(132, 20);
            this.cbexpridate.TabIndex = 23;
            this.cbexpridate.Text = "check expiry date";
            this.cbexpridate.UseVisualStyleBackColor = true;
            // 
            // dtpexpirydate
            // 
            this.dtpexpirydate.CustomFormat = "yyyy-MM-dd";
            this.dtpexpirydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpexpirydate.Location = new System.Drawing.Point(122, 43);
            this.dtpexpirydate.Name = "dtpexpirydate";
            this.dtpexpirydate.Size = new System.Drawing.Size(151, 22);
            this.dtpexpirydate.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Expiry date";
            // 
            // info
            // 
            this.info.Controls.Add(this.tableLayoutPanel1);
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(10, 159);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(284, 277);
            this.info.TabIndex = 19;
            this.info.TabStop = false;
            this.info.Text = "Checking";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.28044F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.71956F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnimporttoDB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnxoa, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnloaddata, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnsaveCSV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtserchputinpartnb, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label22, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(271, 250);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Looking By";
            // 
            // btnimporttoDB
            // 
            this.btnimporttoDB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnimporttoDB.Enabled = false;
            this.btnimporttoDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimporttoDB.Location = new System.Drawing.Point(122, 3);
            this.btnimporttoDB.Name = "btnimporttoDB";
            this.btnimporttoDB.Size = new System.Drawing.Size(93, 33);
            this.btnimporttoDB.TabIndex = 45;
            this.btnimporttoDB.Text = "Import to DB";
            this.btnimporttoDB.UseVisualStyleBackColor = true;
            this.btnimporttoDB.Click += new System.EventHandler(this.btnimporttoDB_Click_1);
            // 
            // btnxoa
            // 
            this.btnxoa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Location = new System.Drawing.Point(122, 42);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(93, 32);
            this.btnxoa.TabIndex = 44;
            this.btnxoa.Text = "Clear";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click_1);
            // 
            // btnloaddata
            // 
            this.btnloaddata.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnloaddata.Enabled = false;
            this.btnloaddata.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloaddata.Location = new System.Drawing.Point(3, 4);
            this.btnloaddata.Name = "btnloaddata";
            this.btnloaddata.Size = new System.Drawing.Size(92, 31);
            this.btnloaddata.TabIndex = 46;
            this.btnloaddata.Text = "Load Excel";
            this.btnloaddata.UseVisualStyleBackColor = true;
            this.btnloaddata.Click += new System.EventHandler(this.btnloaddata_Click_1);
            // 
            // btnsaveCSV
            // 
            this.btnsaveCSV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnsaveCSV.Enabled = false;
            this.btnsaveCSV.Location = new System.Drawing.Point(3, 43);
            this.btnsaveCSV.Name = "btnsaveCSV";
            this.btnsaveCSV.Size = new System.Drawing.Size(92, 30);
            this.btnsaveCSV.TabIndex = 50;
            this.btnsaveCSV.Text = "Save to csv";
            this.btnsaveCSV.UseVisualStyleBackColor = true;
            this.btnsaveCSV.Click += new System.EventHandler(this.btnsaveCSV_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.txtcount, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(122, 198);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(130, 28);
            this.tableLayoutPanel2.TabIndex = 54;
            // 
            // txtcount
            // 
            this.txtcount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtcount.Location = new System.Drawing.Point(55, 3);
            this.txtcount.Name = "txtcount";
            this.txtcount.Size = new System.Drawing.Size(72, 22);
            this.txtcount.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 16);
            this.label12.TabIndex = 52;
            this.label12.Text = "Count";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 16);
            this.label17.TabIndex = 55;
            this.label17.Text = "PartNumber";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(122, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 22);
            this.textBox1.TabIndex = 49;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // txtserchputinpartnb
            // 
            this.txtserchputinpartnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserchputinpartnb.Location = new System.Drawing.Point(122, 120);
            this.txtserchputinpartnb.Name = "txtserchputinpartnb";
            this.txtserchputinpartnb.Size = new System.Drawing.Size(146, 22);
            this.txtserchputinpartnb.TabIndex = 56;
            this.txtserchputinpartnb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtserchputinpartnb_KeyDown);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 167);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 16);
            this.label22.TabIndex = 57;
            this.label22.Text = "Serial";
            // 
            // rbputinNote
            // 
            this.rbputinNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbputinNote.Location = new System.Drawing.Point(599, 31);
            this.rbputinNote.Name = "rbputinNote";
            this.rbputinNote.Size = new System.Drawing.Size(436, 88);
            this.rbputinNote.TabIndex = 7;
            this.rbputinNote.Text = "";
            // 
            // lbputinstatus
            // 
            this.lbputinstatus.AutoSize = true;
            this.lbputinstatus.BackColor = System.Drawing.Color.Yellow;
            this.lbputinstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbputinstatus.Location = new System.Drawing.Point(439, 47);
            this.lbputinstatus.Name = "lbputinstatus";
            this.lbputinstatus.Size = new System.Drawing.Size(119, 37);
            this.lbputinstatus.TabIndex = 6;
            this.lbputinstatus.Text = "WAITE";
            // 
            // txtputinSerial
            // 
            this.txtputinSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtputinSerial.Location = new System.Drawing.Point(124, 88);
            this.txtputinSerial.Name = "txtputinSerial";
            this.txtputinSerial.Size = new System.Drawing.Size(151, 22);
            this.txtputinSerial.TabIndex = 3;
            this.txtputinSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtputinSerial_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Serial";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(303, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(735, 267);
            this.dataGridView1.TabIndex = 20;
            // 
            // dtgridputinstore
            // 
            this.dtgridputinstore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgridputinstore.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgridputinstore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridputinstore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.sn,
            this.customer_,
            this.type_,
            this.date,
            this.state,
            this.where});
            this.dtgridputinstore.Location = new System.Drawing.Point(300, 169);
            this.dtgridputinstore.Name = "dtgridputinstore";
            this.dtgridputinstore.Size = new System.Drawing.Size(742, 267);
            this.dtgridputinstore.TabIndex = 15;
            // 
            // select
            // 
            this.select.HeaderText = "select";
            this.select.Name = "select";
            this.select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.select.Width = 60;
            // 
            // sn
            // 
            this.sn.HeaderText = "Serial";
            this.sn.Name = "sn";
            this.sn.Width = 120;
            // 
            // customer_
            // 
            this.customer_.HeaderText = "Customer";
            this.customer_.Name = "customer_";
            // 
            // type_
            // 
            this.type_.HeaderText = "Type";
            this.type_.Name = "type_";
            // 
            // date
            // 
            this.date.HeaderText = "Date input";
            this.date.Name = "date";
            this.date.Width = 170;
            // 
            // state
            // 
            this.state.HeaderText = "state";
            this.state.Name = "state";
            this.state.Width = 50;
            // 
            // where
            // 
            this.where.HeaderText = "Adress";
            this.where.Name = "where";
            // 
            // gbPutout
            // 
            this.gbPutout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPutout.Controls.Add(this.label21);
            this.gbPutout.Controls.Add(this.dtgputoutRequesting);
            this.gbPutout.Controls.Add(this.Suggestions);
            this.gbPutout.Controls.Add(this.dtgputoutsearchDeal);
            this.gbPutout.Controls.Add(this.cbputoutmodel);
            this.gbPutout.Controls.Add(this.label5);
            this.gbPutout.Controls.Add(this.rtputoutNote);
            this.gbPutout.Controls.Add(this.lbPutoutstatus);
            this.gbPutout.Controls.Add(this.txtputoutserial);
            this.gbPutout.Controls.Add(this.label8);
            this.gbPutout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPutout.Location = new System.Drawing.Point(12, 17);
            this.gbPutout.Name = "gbPutout";
            this.gbPutout.Size = new System.Drawing.Size(905, 463);
            this.gbPutout.TabIndex = 9;
            this.gbPutout.TabStop = false;
            this.gbPutout.Text = "PutOut";
            this.gbPutout.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(21, 302);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 16);
            this.label21.TabIndex = 13;
            this.label21.Text = "Requesting";
            // 
            // dtgputoutRequesting
            // 
            this.dtgputoutRequesting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgputoutRequesting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgputoutRequesting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgputoutRequesting.Location = new System.Drawing.Point(16, 321);
            this.dtgputoutRequesting.Name = "dtgputoutRequesting";
            this.dtgputoutRequesting.Size = new System.Drawing.Size(877, 136);
            this.dtgputoutRequesting.TabIndex = 12;
            // 
            // Suggestions
            // 
            this.Suggestions.AutoSize = true;
            this.Suggestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Suggestions.Location = new System.Drawing.Point(20, 133);
            this.Suggestions.Name = "Suggestions";
            this.Suggestions.Size = new System.Drawing.Size(83, 16);
            this.Suggestions.TabIndex = 11;
            this.Suggestions.Text = "Suggestions";
            // 
            // dtgputoutsearchDeal
            // 
            this.dtgputoutsearchDeal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgputoutsearchDeal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgputoutsearchDeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgputoutsearchDeal.Location = new System.Drawing.Point(14, 152);
            this.dtgputoutsearchDeal.Name = "dtgputoutsearchDeal";
            this.dtgputoutsearchDeal.Size = new System.Drawing.Size(879, 146);
            this.dtgputoutsearchDeal.TabIndex = 10;
            // 
            // cbputoutmodel
            // 
            this.cbputoutmodel.FormattingEnabled = true;
            this.cbputoutmodel.Location = new System.Drawing.Point(108, 32);
            this.cbputoutmodel.Name = "cbputoutmodel";
            this.cbputoutmodel.Size = new System.Drawing.Size(263, 24);
            this.cbputoutmodel.TabIndex = 9;
            this.cbputoutmodel.SelectedIndexChanged += new System.EventHandler(this.cbputoutmodel_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Model";
            // 
            // rtputoutNote
            // 
            this.rtputoutNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtputoutNote.Location = new System.Drawing.Point(544, 16);
            this.rtputoutNote.Name = "rtputoutNote";
            this.rtputoutNote.Size = new System.Drawing.Size(349, 115);
            this.rtputoutNote.TabIndex = 7;
            this.rtputoutNote.Text = "";
            // 
            // lbPutoutstatus
            // 
            this.lbPutoutstatus.AutoSize = true;
            this.lbPutoutstatus.BackColor = System.Drawing.Color.Yellow;
            this.lbPutoutstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPutoutstatus.Location = new System.Drawing.Point(404, 31);
            this.lbPutoutstatus.Name = "lbPutoutstatus";
            this.lbPutoutstatus.Size = new System.Drawing.Size(119, 37);
            this.lbPutoutstatus.TabIndex = 6;
            this.lbPutoutstatus.Text = "WAITE";
            // 
            // txtputoutserial
            // 
            this.txtputoutserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtputoutserial.Location = new System.Drawing.Point(107, 78);
            this.txtputoutserial.Name = "txtputoutserial";
            this.txtputoutserial.Size = new System.Drawing.Size(160, 22);
            this.txtputoutserial.TabIndex = 3;
            this.txtputoutserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtputoutserial_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Serial";
            // 
            // gbPutinSMT
            // 
            this.gbPutinSMT.Controls.Add(this.cbputinSMTmodel);
            this.gbPutinSMT.Controls.Add(this.lbputinsmtTimeleft);
            this.gbPutinSMT.Controls.Add(this.lbputinSMTconfirm);
            this.gbPutinSMT.Controls.Add(this.gbPutinSMTstatus);
            this.gbPutinSMT.Controls.Add(this.lbputinSMTstatus);
            this.gbPutinSMT.Controls.Add(this.txtputinSMTserial);
            this.gbPutinSMT.Controls.Add(this.label11);
            this.gbPutinSMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPutinSMT.Location = new System.Drawing.Point(4, 38);
            this.gbPutinSMT.Name = "gbPutinSMT";
            this.gbPutinSMT.Size = new System.Drawing.Size(842, 145);
            this.gbPutinSMT.TabIndex = 10;
            this.gbPutinSMT.TabStop = false;
            this.gbPutinSMT.Text = "Put In SMT";
            this.gbPutinSMT.Visible = false;
            // 
            // cbputinSMTmodel
            // 
            this.cbputinSMTmodel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbputinSMTmodel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbputinSMTmodel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbputinSMTmodel.FormattingEnabled = true;
            this.cbputinSMTmodel.Location = new System.Drawing.Point(71, 41);
            this.cbputinSMTmodel.Name = "cbputinSMTmodel";
            this.cbputinSMTmodel.Size = new System.Drawing.Size(194, 24);
            this.cbputinSMTmodel.TabIndex = 11;
            // 
            // lbputinsmtTimeleft
            // 
            this.lbputinsmtTimeleft.AutoSize = true;
            this.lbputinsmtTimeleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbputinsmtTimeleft.Location = new System.Drawing.Point(311, 102);
            this.lbputinsmtTimeleft.Name = "lbputinsmtTimeleft";
            this.lbputinsmtTimeleft.Size = new System.Drawing.Size(69, 20);
            this.lbputinsmtTimeleft.TabIndex = 10;
            this.lbputinsmtTimeleft.Text = "Time left";
            // 
            // lbputinSMTconfirm
            // 
            this.lbputinSMTconfirm.AutoSize = true;
            this.lbputinSMTconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbputinSMTconfirm.Location = new System.Drawing.Point(14, 43);
            this.lbputinSMTconfirm.Name = "lbputinSMTconfirm";
            this.lbputinSMTconfirm.Size = new System.Drawing.Size(52, 20);
            this.lbputinSMTconfirm.TabIndex = 8;
            this.lbputinSMTconfirm.Text = "Model";
            // 
            // gbPutinSMTstatus
            // 
            this.gbPutinSMTstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPutinSMTstatus.Location = new System.Drawing.Point(456, 17);
            this.gbPutinSMTstatus.Name = "gbPutinSMTstatus";
            this.gbPutinSMTstatus.Size = new System.Drawing.Size(380, 122);
            this.gbPutinSMTstatus.TabIndex = 7;
            this.gbPutinSMTstatus.Text = "";
            // 
            // lbputinSMTstatus
            // 
            this.lbputinSMTstatus.AutoSize = true;
            this.lbputinSMTstatus.BackColor = System.Drawing.Color.Yellow;
            this.lbputinSMTstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbputinSMTstatus.Location = new System.Drawing.Point(291, 25);
            this.lbputinSMTstatus.Name = "lbputinSMTstatus";
            this.lbputinSMTstatus.Size = new System.Drawing.Size(88, 29);
            this.lbputinSMTstatus.TabIndex = 6;
            this.lbputinSMTstatus.Text = "WAITE";
            // 
            // txtputinSMTserial
            // 
            this.txtputinSMTserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtputinSMTserial.Location = new System.Drawing.Point(71, 95);
            this.txtputinSMTserial.Name = "txtputinSMTserial";
            this.txtputinSMTserial.Size = new System.Drawing.Size(143, 22);
            this.txtputinSMTserial.TabIndex = 3;
            this.txtputinSMTserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtputinSMTserial_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Serial";
            // 
            // gbSpinSolder
            // 
            this.gbSpinSolder.Controls.Add(this.lbspecspin);
            this.gbSpinSolder.Controls.Add(this.lbspinTimeLeft);
            this.gbSpinSolder.Controls.Add(this.rbspinNote);
            this.gbSpinSolder.Controls.Add(this.lbspinstatus);
            this.gbSpinSolder.Controls.Add(this.txtspinserial);
            this.gbSpinSolder.Controls.Add(this.label10);
            this.gbSpinSolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSpinSolder.Location = new System.Drawing.Point(12, 21);
            this.gbSpinSolder.Name = "gbSpinSolder";
            this.gbSpinSolder.Size = new System.Drawing.Size(842, 142);
            this.gbSpinSolder.TabIndex = 10;
            this.gbSpinSolder.TabStop = false;
            this.gbSpinSolder.Text = "Spin Solder";
            this.gbSpinSolder.Visible = false;
            // 
            // lbspecspin
            // 
            this.lbspecspin.AutoSize = true;
            this.lbspecspin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbspecspin.Location = new System.Drawing.Point(33, 112);
            this.lbspecspin.Name = "lbspecspin";
            this.lbspecspin.Size = new System.Drawing.Size(54, 20);
            this.lbspecspin.TabIndex = 9;
            this.lbspecspin.Text = "Spec: ";
            // 
            // lbspinTimeLeft
            // 
            this.lbspinTimeLeft.AutoSize = true;
            this.lbspinTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbspinTimeLeft.Location = new System.Drawing.Point(326, 104);
            this.lbspinTimeLeft.Name = "lbspinTimeLeft";
            this.lbspinTimeLeft.Size = new System.Drawing.Size(70, 20);
            this.lbspinTimeLeft.TabIndex = 8;
            this.lbspinTimeLeft.Text = "Tim Left:";
            // 
            // rbspinNote
            // 
            this.rbspinNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbspinNote.Location = new System.Drawing.Point(506, 22);
            this.rbspinNote.Name = "rbspinNote";
            this.rbspinNote.Size = new System.Drawing.Size(328, 115);
            this.rbspinNote.TabIndex = 7;
            this.rbspinNote.Text = "";
            // 
            // lbspinstatus
            // 
            this.lbspinstatus.AutoSize = true;
            this.lbspinstatus.BackColor = System.Drawing.Color.Yellow;
            this.lbspinstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbspinstatus.Location = new System.Drawing.Point(301, 28);
            this.lbspinstatus.Name = "lbspinstatus";
            this.lbspinstatus.Size = new System.Drawing.Size(100, 31);
            this.lbspinstatus.TabIndex = 6;
            this.lbspinstatus.Text = "WAITE";
            // 
            // txtspinserial
            // 
            this.txtspinserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtspinserial.Location = new System.Drawing.Point(99, 33);
            this.txtspinserial.Name = "txtspinserial";
            this.txtspinserial.Size = new System.Drawing.Size(168, 26);
            this.txtspinserial.TabIndex = 3;
            this.txtspinserial.TextChanged += new System.EventHandler(this.txtspinserial_TextChanged);
            this.txtspinserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtspinserial_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Serial";
            // 
            // gbLogIn
            // 
            this.gbLogIn.Controls.Add(this.btnlogin);
            this.gbLogIn.Controls.Add(this.txtpass);
            this.gbLogIn.Controls.Add(this.label9);
            this.gbLogIn.Controls.Add(this.txtuser);
            this.gbLogIn.Controls.Add(this.label13);
            this.gbLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLogIn.Location = new System.Drawing.Point(12, 13);
            this.gbLogIn.Name = "gbLogIn";
            this.gbLogIn.Size = new System.Drawing.Size(842, 145);
            this.gbLogIn.TabIndex = 11;
            this.gbLogIn.TabStop = false;
            this.gbLogIn.Text = "Log In";
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(307, 82);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(75, 29);
            this.btnlogin.TabIndex = 10;
            this.btnlogin.Text = "Log In";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtpass
            // 
            this.txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpass.Location = new System.Drawing.Point(110, 88);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(152, 26);
            this.txtpass.TabIndex = 9;
            this.txtpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpass_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Pass Word";
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.Location = new System.Drawing.Point(110, 44);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(152, 26);
            this.txtuser.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "User Name";
            // 
            // tmlocalTIme
            // 
            this.tmlocalTIme.Interval = 1000;
            this.tmlocalTIme.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.CallSolderPaste);
            this.panel1.Controls.Add(this.gbPutout);
            this.panel1.Controls.Add(this.gbPutin);
            this.panel1.Controls.Add(this.gbsticklable);
            this.panel1.Controls.Add(this.gbSpinSolder);
            this.panel1.Controls.Add(this.grbPutoutSMT);
            this.panel1.Controls.Add(this.gbPutinSMT);
            this.panel1.Controls.Add(this.gbLogIn);
            this.panel1.Location = new System.Drawing.Point(0, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1063, 483);
            this.panel1.TabIndex = 12;
            // 
            // gbsticklable
            // 
            this.gbsticklable.Controls.Add(this.rbstickNote);
            this.gbsticklable.Controls.Add(this.lbstickstatus);
            this.gbsticklable.Controls.Add(this.txtstickserial);
            this.gbsticklable.Controls.Add(this.label1);
            this.gbsticklable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbsticklable.Location = new System.Drawing.Point(10, 17);
            this.gbsticklable.Name = "gbsticklable";
            this.gbsticklable.Size = new System.Drawing.Size(848, 166);
            this.gbsticklable.TabIndex = 11;
            this.gbsticklable.TabStop = false;
            this.gbsticklable.Text = "Stick Label";
            this.gbsticklable.Visible = false;
            // 
            // rbstickNote
            // 
            this.rbstickNote.Location = new System.Drawing.Point(499, 22);
            this.rbstickNote.Name = "rbstickNote";
            this.rbstickNote.Size = new System.Drawing.Size(331, 133);
            this.rbstickNote.TabIndex = 3;
            this.rbstickNote.Text = "";
            // 
            // lbstickstatus
            // 
            this.lbstickstatus.AutoSize = true;
            this.lbstickstatus.BackColor = System.Drawing.Color.Yellow;
            this.lbstickstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstickstatus.Location = new System.Drawing.Point(361, 55);
            this.lbstickstatus.Name = "lbstickstatus";
            this.lbstickstatus.Size = new System.Drawing.Size(106, 33);
            this.lbstickstatus.TabIndex = 2;
            this.lbstickstatus.Text = "WAITE";
            // 
            // txtstickserial
            // 
            this.txtstickserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstickserial.Location = new System.Drawing.Point(125, 60);
            this.txtstickserial.Name = "txtstickserial";
            this.txtstickserial.Size = new System.Drawing.Size(166, 26);
            this.txtstickserial.TabIndex = 1;
            this.txtstickserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtstickserial_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial";
            // 
            // grbPutoutSMT
            // 
            this.grbPutoutSMT.Controls.Add(this.rtbputoutSMT);
            this.grbPutoutSMT.Controls.Add(this.lbputoutSMTstatus);
            this.grbPutoutSMT.Controls.Add(this.txtputoutSMTserial);
            this.grbPutoutSMT.Controls.Add(this.label18);
            this.grbPutoutSMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPutoutSMT.Location = new System.Drawing.Point(6, 32);
            this.grbPutoutSMT.Name = "grbPutoutSMT";
            this.grbPutoutSMT.Size = new System.Drawing.Size(842, 145);
            this.grbPutoutSMT.TabIndex = 11;
            this.grbPutoutSMT.TabStop = false;
            this.grbPutoutSMT.Text = "Put Out SMT";
            this.grbPutoutSMT.Visible = false;
            // 
            // rtbputoutSMT
            // 
            this.rtbputoutSMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbputoutSMT.Location = new System.Drawing.Point(456, 17);
            this.rtbputoutSMT.Name = "rtbputoutSMT";
            this.rtbputoutSMT.Size = new System.Drawing.Size(380, 122);
            this.rtbputoutSMT.TabIndex = 7;
            this.rtbputoutSMT.Text = "";
            // 
            // lbputoutSMTstatus
            // 
            this.lbputoutSMTstatus.AutoSize = true;
            this.lbputoutSMTstatus.BackColor = System.Drawing.Color.Yellow;
            this.lbputoutSMTstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbputoutSMTstatus.Location = new System.Drawing.Point(291, 25);
            this.lbputoutSMTstatus.Name = "lbputoutSMTstatus";
            this.lbputoutSMTstatus.Size = new System.Drawing.Size(88, 29);
            this.lbputoutSMTstatus.TabIndex = 6;
            this.lbputoutSMTstatus.Text = "WAITE";
            // 
            // txtputoutSMTserial
            // 
            this.txtputoutSMTserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtputoutSMTserial.Location = new System.Drawing.Point(69, 33);
            this.txtputoutSMTserial.Name = "txtputoutSMTserial";
            this.txtputoutSMTserial.Size = new System.Drawing.Size(192, 22);
            this.txtputoutSMTserial.TabIndex = 3;
            this.txtputoutSMTserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtputoutSMTserial_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(18, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "Serial";
            // 
            // CallSolderPaste
            // 
            this.CallSolderPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CallSolderPaste.Controls.Add(this.dtgresponse);
            this.CallSolderPaste.Controls.Add(this.label20);
            this.CallSolderPaste.Controls.Add(this.label19);
            this.CallSolderPaste.Controls.Add(this.dtgrequest);
            this.CallSolderPaste.Controls.Add(this.tableLayoutPanel3);
            this.CallSolderPaste.Location = new System.Drawing.Point(10, 3);
            this.CallSolderPaste.Name = "CallSolderPaste";
            this.CallSolderPaste.Size = new System.Drawing.Size(1048, 462);
            this.CallSolderPaste.TabIndex = 12;
            this.CallSolderPaste.TabStop = false;
            this.CallSolderPaste.Text = "Call Solder Paste";
            this.CallSolderPaste.Visible = false;
            // 
            // dtgresponse
            // 
            this.dtgresponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgresponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgresponse.Location = new System.Drawing.Point(8, 284);
            this.dtgresponse.Name = "dtgresponse";
            this.dtgresponse.Size = new System.Drawing.Size(1030, 172);
            this.dtgresponse.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 268);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Request was responsed";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Request";
            // 
            // dtgrequest
            // 
            this.dtgrequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrequest.Location = new System.Drawing.Point(8, 104);
            this.dtgrequest.Name = "dtgrequest";
            this.dtgrequest.Size = new System.Drawing.Size(1030, 156);
            this.dtgrequest.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.53846F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.46154F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtpartnumber, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtmodel, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btncall, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.btncancel, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.label16, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtcountCall, 5, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(21, 24);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(994, 44);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Part Number";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(254, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Model";
            // 
            // txtpartnumber
            // 
            this.txtpartnumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtpartnumber.Location = new System.Drawing.Point(82, 12);
            this.txtpartnumber.Name = "txtpartnumber";
            this.txtpartnumber.Size = new System.Drawing.Size(159, 20);
            this.txtpartnumber.TabIndex = 2;
            // 
            // txtmodel
            // 
            this.txtmodel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtmodel.Location = new System.Drawing.Point(304, 12);
            this.txtmodel.Name = "txtmodel";
            this.txtmodel.Size = new System.Drawing.Size(132, 20);
            this.txtmodel.TabIndex = 3;
            // 
            // btncall
            // 
            this.btncall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btncall.Location = new System.Drawing.Point(813, 10);
            this.btncall.Name = "btncall";
            this.btncall.Size = new System.Drawing.Size(58, 23);
            this.btncall.TabIndex = 4;
            this.btncall.Text = "Call";
            this.btncall.UseVisualStyleBackColor = true;
            this.btncall.Click += new System.EventHandler(this.btncall_Click);
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btncancel.Location = new System.Drawing.Point(906, 10);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 5;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(466, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Count";
            // 
            // txtcountCall
            // 
            this.txtcountCall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtcountCall.Location = new System.Drawing.Point(541, 12);
            this.txtcountCall.Name = "txtcountCall";
            this.txtcountCall.Size = new System.Drawing.Size(100, 20);
            this.txtcountCall.TabIndex = 7;
            // 
            // pnwelcome
            // 
            this.pnwelcome.AutoSize = true;
            this.pnwelcome.Controls.Add(this.lblocaltime);
            this.pnwelcome.Controls.Add(this.lbwelcome);
            this.pnwelcome.Location = new System.Drawing.Point(158, 0);
            this.pnwelcome.Name = "pnwelcome";
            this.pnwelcome.Size = new System.Drawing.Size(913, 37);
            this.pnwelcome.TabIndex = 13;
            // 
            // lblocaltime
            // 
            this.lblocaltime.AutoSize = true;
            this.lblocaltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblocaltime.Location = new System.Drawing.Point(461, 9);
            this.lblocaltime.Name = "lblocaltime";
            this.lblocaltime.Size = new System.Drawing.Size(93, 20);
            this.lblocaltime.TabIndex = 1;
            this.lblocaltime.Text = "Local Time: ";
            // 
            // lbwelcome
            // 
            this.lbwelcome.AutoSize = true;
            this.lbwelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwelcome.Location = new System.Drawing.Point(150, 9);
            this.lbwelcome.Name = "lbwelcome";
            this.lbwelcome.Size = new System.Drawing.Size(83, 20);
            this.lbwelcome.TabIndex = 0;
            this.lbwelcome.Text = "Welcome: ";
            // 
            // tmtimeLeft
            // 
            this.tmtimeLeft.Interval = 1000;
            // 
            // tmstatus
            // 
            this.tmstatus.Interval = 1000;
            this.tmstatus.Tick += new System.EventHandler(this.tmstatus_Tick);
            // 
            // dtgridShowinfo
            // 
            this.dtgridShowinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgridShowinfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgridShowinfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgridShowinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridShowinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type__,
            this.BARCODE__,
            this.CUSTOMER__,
            this.ADRESS__,
            this.STATUS__,
            this.TIME__,
            this.NOTE__});
            this.dtgridShowinfo.EnableHeadersVisualStyles = false;
            this.dtgridShowinfo.Location = new System.Drawing.Point(8, 43);
            this.dtgridShowinfo.Name = "dtgridShowinfo";
            this.dtgridShowinfo.Size = new System.Drawing.Size(1054, 490);
            this.dtgridShowinfo.TabIndex = 14;
            this.dtgridShowinfo.Visible = false;
            this.dtgridShowinfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtgridShowinfo_RowsAdded);
            this.dtgridShowinfo.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.dtgridShowinfo_ControlAdded);
            // 
            // type__
            // 
            this.type__.HeaderText = "TYPE";
            this.type__.Name = "type__";
            // 
            // BARCODE__
            // 
            this.BARCODE__.HeaderText = "BARCODE";
            this.BARCODE__.Name = "BARCODE__";
            // 
            // CUSTOMER__
            // 
            this.CUSTOMER__.HeaderText = "CUSTOMER";
            this.CUSTOMER__.Name = "CUSTOMER__";
            // 
            // ADRESS__
            // 
            this.ADRESS__.HeaderText = "ADRESS";
            this.ADRESS__.Name = "ADRESS__";
            // 
            // STATUS__
            // 
            this.STATUS__.HeaderText = "STATUS";
            this.STATUS__.Name = "STATUS__";
            // 
            // TIME__
            // 
            this.TIME__.HeaderText = "TIME LEFT";
            this.TIME__.Name = "TIME__";
            // 
            // NOTE__
            // 
            this.NOTE__.HeaderText = "NOTE";
            this.NOTE__.Name = "NOTE__";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            // 
            // Adress
            // 
            this.Adress.HeaderText = "Adress";
            this.Adress.Name = "Adress";
            this.Adress.Width = 150;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.Width = 150;
            // 
            // TimeLeft
            // 
            this.TimeLeft.HeaderText = "Time Left";
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.Width = 150;
            // 
            // Note
            // 
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            this.Note.Width = 200;
            // 
            // gbCheckinfo
            // 
            this.gbCheckinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCheckinfo.Controls.Add(this.txtgbcheckinfoPartnumber);
            this.gbCheckinfo.Controls.Add(this.label15);
            this.gbCheckinfo.Controls.Add(this.btnExport);
            this.gbCheckinfo.Controls.Add(this.dtgridstate);
            this.gbCheckinfo.Controls.Add(this.label3);
            this.gbCheckinfo.Controls.Add(this.cbgrcheckinfolooktype);
            this.gbCheckinfo.Controls.Add(this.txtcheckinfoSerial);
            this.gbCheckinfo.Controls.Add(this.lbserial);
            this.gbCheckinfo.Controls.Add(this.dtgridCheckInfo);
            this.gbCheckinfo.Location = new System.Drawing.Point(8, 43);
            this.gbCheckinfo.Name = "gbCheckinfo";
            this.gbCheckinfo.Size = new System.Drawing.Size(1051, 472);
            this.gbCheckinfo.TabIndex = 15;
            this.gbCheckinfo.TabStop = false;
            this.gbCheckinfo.Text = "Info";
            this.gbCheckinfo.Visible = false;
            // 
            // txtgbcheckinfoPartnumber
            // 
            this.txtgbcheckinfoPartnumber.Location = new System.Drawing.Point(389, 42);
            this.txtgbcheckinfoPartnumber.Name = "txtgbcheckinfoPartnumber";
            this.txtgbcheckinfoPartnumber.Size = new System.Drawing.Size(131, 20);
            this.txtgbcheckinfoPartnumber.TabIndex = 8;
            this.txtgbcheckinfoPartnumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtgbcheckinfoPartnumber_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(285, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 20);
            this.label15.TabIndex = 7;
            this.label15.Text = "Part Number";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(445, 90);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dtgridstate
            // 
            this.dtgridstate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgridstate.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgridstate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridstate.EnableHeadersVisualStyles = false;
            this.dtgridstate.Location = new System.Drawing.Point(541, 10);
            this.dtgridstate.Name = "dtgridstate";
            this.dtgridstate.Size = new System.Drawing.Size(327, 124);
            this.dtgridstate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Looking By";
            // 
            // cbgrcheckinfolooktype
            // 
            this.cbgrcheckinfolooktype.AutoCompleteCustomSource.AddRange(new string[] {
            "By Serial",
            "Stencil online",
            "Stencil offline"});
            this.cbgrcheckinfolooktype.FormattingEnabled = true;
            this.cbgrcheckinfolooktype.Items.AddRange(new object[] {
            "By Serial",
            "Stencil online",
            "Stencil offline"});
            this.cbgrcheckinfolooktype.Location = new System.Drawing.Point(135, 44);
            this.cbgrcheckinfolooktype.Name = "cbgrcheckinfolooktype";
            this.cbgrcheckinfolooktype.Size = new System.Drawing.Size(129, 21);
            this.cbgrcheckinfolooktype.TabIndex = 3;
            this.cbgrcheckinfolooktype.SelectedIndexChanged += new System.EventHandler(this.cbgrcheckinfolooktype_SelectedIndexChanged);
            // 
            // txtcheckinfoSerial
            // 
            this.txtcheckinfoSerial.Location = new System.Drawing.Point(133, 84);
            this.txtcheckinfoSerial.Name = "txtcheckinfoSerial";
            this.txtcheckinfoSerial.Size = new System.Drawing.Size(131, 20);
            this.txtcheckinfoSerial.TabIndex = 2;
            this.txtcheckinfoSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcheckinfoSerial_KeyDown);
            // 
            // lbserial
            // 
            this.lbserial.AutoSize = true;
            this.lbserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbserial.Location = new System.Drawing.Point(31, 90);
            this.lbserial.Name = "lbserial";
            this.lbserial.Size = new System.Drawing.Size(49, 20);
            this.lbserial.TabIndex = 1;
            this.lbserial.Text = "Serial";
            // 
            // dtgridCheckInfo
            // 
            this.dtgridCheckInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgridCheckInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgridCheckInfo.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgridCheckInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgridCheckInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridCheckInfo.EnableHeadersVisualStyles = false;
            this.dtgridCheckInfo.GridColor = System.Drawing.SystemColors.Control;
            this.dtgridCheckInfo.Location = new System.Drawing.Point(6, 140);
            this.dtgridCheckInfo.Name = "dtgridCheckInfo";
            this.dtgridCheckInfo.Size = new System.Drawing.Size(1039, 329);
            this.dtgridCheckInfo.TabIndex = 0;
            // 
            // tmupdaterequest
            // 
            this.tmupdaterequest.Interval = 5000;
            this.tmupdaterequest.Tick += new System.EventHandler(this.tmupdaterequest_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1071, 545);
            this.Controls.Add(this.pnwelcome);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbCheckinfo);
            this.Controls.Add(this.dtgridShowinfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbPutin.ResumeLayout(false);
            this.gbPutin.PerformLayout();
            this.info.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridputinstore)).EndInit();
            this.gbPutout.ResumeLayout(false);
            this.gbPutout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgputoutRequesting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgputoutsearchDeal)).EndInit();
            this.gbPutinSMT.ResumeLayout(false);
            this.gbPutinSMT.PerformLayout();
            this.gbSpinSolder.ResumeLayout(false);
            this.gbSpinSolder.PerformLayout();
            this.gbLogIn.ResumeLayout(false);
            this.gbLogIn.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbsticklable.ResumeLayout(false);
            this.gbsticklable.PerformLayout();
            this.grbPutoutSMT.ResumeLayout(false);
            this.grbPutoutSMT.PerformLayout();
            this.CallSolderPaste.ResumeLayout(false);
            this.CallSolderPaste.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgresponse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrequest)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.pnwelcome.ResumeLayout(false);
            this.pnwelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridShowinfo)).EndInit();
            this.gbCheckinfo.ResumeLayout(false);
            this.gbCheckinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridstate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridCheckInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putInStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putOutStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spinSolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putInSMTToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbPutin;
        private System.Windows.Forms.Label lbputinstatus;
        private System.Windows.Forms.GroupBox gbPutout;
        private System.Windows.Forms.GroupBox gbSpinSolder;
        private System.Windows.Forms.Label lbspinTimeLeft;
        private System.Windows.Forms.RichTextBox rbspinNote;
        private System.Windows.Forms.Label lbspinstatus;
        private System.Windows.Forms.TextBox txtspinserial;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtputoutNote;
        private System.Windows.Forms.Label lbPutoutstatus;
        private System.Windows.Forms.TextBox txtputoutserial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer tmlocalTIme;
        private System.Windows.Forms.GroupBox gbPutinSMT;
        private System.Windows.Forms.RichTextBox gbPutinSMTstatus;
        private System.Windows.Forms.Label lbputinSMTstatus;
        private System.Windows.Forms.TextBox txtputinSMTserial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbLogIn;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnwelcome;
        private System.Windows.Forms.Label lblocaltime;
        private System.Windows.Forms.Label lbwelcome;
        private System.Windows.Forms.Timer tmtimeLeft;
        private System.Windows.Forms.Timer tmstatus;
        private System.Windows.Forms.RichTextBox rbputinNote;
        private System.Windows.Forms.Label lbputinsmtTimeleft;
        private System.Windows.Forms.Label lbputinSMTconfirm;
        private System.Windows.Forms.ToolStripMenuItem showInfoRealTimeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgridShowinfo;
        private System.Windows.Forms.ToolStripMenuItem stickLableToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbsticklable;
        private System.Windows.Forms.RichTextBox rbstickNote;
        private System.Windows.Forms.Label lbstickstatus;
        private System.Windows.Forms.TextBox txtstickserial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem checkingToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbCheckinfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbgrcheckinfolooktype;
        private System.Windows.Forms.TextBox txtcheckinfoSerial;
        private System.Windows.Forms.Label lbserial;
        private System.Windows.Forms.DataGridView dtgridCheckInfo;
        private System.Windows.Forms.DataGridView dtgridstate;
        private System.Windows.Forms.DataGridView dtgridputinstore;
        private System.Windows.Forms.GroupBox info;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtputinSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnimporttoDB;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnloaddata;
        private System.Windows.Forms.Button btnsaveCSV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn where;
        private System.Windows.Forms.ToolStripMenuItem putOutSMTToolStripMenuItem;
        private System.Windows.Forms.GroupBox grbPutoutSMT;
        private System.Windows.Forms.RichTextBox rtbputoutSMT;
        private System.Windows.Forms.Label lbputoutSMTstatus;
        private System.Windows.Forms.TextBox txtputoutSMTserial;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        //private System.Windows.Forms.DataGridViewTextBoxColumn customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtcount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbputoutmodel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn type__;
        private System.Windows.Forms.DataGridViewTextBoxColumn BARCODE__;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER__;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADRESS__;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS__;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME__;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTE__;
        private System.Windows.Forms.ComboBox cbputinSMTmodel;
        private System.Windows.Forms.DataGridView dtgputoutsearchDeal;
        private System.Windows.Forms.Label lbspecspin;
        private System.Windows.Forms.DateTimePicker dtpexpirydate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbexpridate;
        private System.Windows.Forms.TextBox txtserchputinpartnb;
        private System.Windows.Forms.ToolStripMenuItem callSolderPasteToolStripMenuItem;
        private System.Windows.Forms.GroupBox CallSolderPaste;
        private System.Windows.Forms.DataGridView dtgrequest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtpartnumber;
        private System.Windows.Forms.TextBox txtmodel;
        private System.Windows.Forms.Button btncall;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtcountCall;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dtgresponse;
        private System.Windows.Forms.Timer tmupdaterequest;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dtgputoutRequesting;
        private System.Windows.Forms.Label Suggestions;
        private System.Windows.Forms.TextBox txtgbcheckinfoPartnumber;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label22;
    }
}

