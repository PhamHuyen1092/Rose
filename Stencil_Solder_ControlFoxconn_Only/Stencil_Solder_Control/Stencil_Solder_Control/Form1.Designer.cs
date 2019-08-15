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
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putInStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putOutStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spinSolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putInSMTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stickLableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoRealTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbPutin = new System.Windows.Forms.GroupBox();
            this.info = new System.Windows.Forms.GroupBox();
            this.btnsaveCSV = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbbputinsearch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnloaddata = new System.Windows.Forms.Button();
            this.btnimporttoDB = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btntk = new System.Windows.Forms.Button();
            this.dtgridputinstore = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.where = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbputinNote = new System.Windows.Forms.RichTextBox();
            this.lbputinstatus = new System.Windows.Forms.Label();
            this.txtputinSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbPutout = new System.Windows.Forms.GroupBox();
            this.rtputoutNote = new System.Windows.Forms.RichTextBox();
            this.lbPutoutstatus = new System.Windows.Forms.Label();
            this.txtputoutserial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbPutinSMT = new System.Windows.Forms.GroupBox();
            this.lbputinsmtTimeleft = new System.Windows.Forms.Label();
            this.txtputinSMTconfirm = new System.Windows.Forms.TextBox();
            this.lbputinSMTconfirm = new System.Windows.Forms.Label();
            this.gbPutinSMTstatus = new System.Windows.Forms.RichTextBox();
            this.lbputinSMTstatus = new System.Windows.Forms.Label();
            this.txtputinSMTserial = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbSpinSolder = new System.Windows.Forms.GroupBox();
            this.txtspinconfirm = new System.Windows.Forms.TextBox();
            this.lbspinTimeLeft = new System.Windows.Forms.Label();
            this.rbspinNote = new System.Windows.Forms.RichTextBox();
            this.lbspinstatus = new System.Windows.Forms.Label();
            this.txtspinserial = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.pnwelcome = new System.Windows.Forms.Panel();
            this.lblocaltime = new System.Windows.Forms.Label();
            this.lbwelcome = new System.Windows.Forms.Label();
            this.tmtimeLeft = new System.Windows.Forms.Timer(this.components);
            this.tmstatus = new System.Windows.Forms.Timer(this.components);
            this.dtgridShowinfo = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCheckinfo = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.dtgridstate = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbgrcheckinfolooktype = new System.Windows.Forms.ComboBox();
            this.txtcheckinfoSerial = new System.Windows.Forms.TextBox();
            this.lbserial = new System.Windows.Forms.Label();
            this.dtgridCheckInfo = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.gbPutin.SuspendLayout();
            this.info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridputinstore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbPutout.SuspendLayout();
            this.gbPutinSMT.SuspendLayout();
            this.gbSpinSolder.SuspendLayout();
            this.gbLogIn.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbsticklable.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.logInToolStripMenuItem.Text = "Log In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.putInStoreToolStripMenuItem,
            this.putOutStoreToolStripMenuItem,
            this.spinSolderToolStripMenuItem,
            this.putInSMTToolStripMenuItem,
            this.stickLableToolStripMenuItem,
            this.showInfoRealTimeToolStripMenuItem,
            this.checkingToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.functionToolStripMenuItem.Text = "Function";
            // 
            // putInStoreToolStripMenuItem
            // 
            this.putInStoreToolStripMenuItem.Name = "putInStoreToolStripMenuItem";
            this.putInStoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.putInStoreToolStripMenuItem.Text = "Put In Store";
            this.putInStoreToolStripMenuItem.Click += new System.EventHandler(this.putInStoreToolStripMenuItem_Click);
            // 
            // putOutStoreToolStripMenuItem
            // 
            this.putOutStoreToolStripMenuItem.Name = "putOutStoreToolStripMenuItem";
            this.putOutStoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.putOutStoreToolStripMenuItem.Text = "Put Out Store";
            this.putOutStoreToolStripMenuItem.Click += new System.EventHandler(this.putOutStoreToolStripMenuItem_Click);
            // 
            // spinSolderToolStripMenuItem
            // 
            this.spinSolderToolStripMenuItem.Name = "spinSolderToolStripMenuItem";
            this.spinSolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.spinSolderToolStripMenuItem.Text = "Spin Solder";
            this.spinSolderToolStripMenuItem.Click += new System.EventHandler(this.spinSolderToolStripMenuItem_Click);
            // 
            // putInSMTToolStripMenuItem
            // 
            this.putInSMTToolStripMenuItem.Name = "putInSMTToolStripMenuItem";
            this.putInSMTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.putInSMTToolStripMenuItem.Text = "Put In SMT";
            this.putInSMTToolStripMenuItem.Click += new System.EventHandler(this.putInSMTToolStripMenuItem_Click);
            // 
            // stickLableToolStripMenuItem
            // 
            this.stickLableToolStripMenuItem.Name = "stickLableToolStripMenuItem";
            this.stickLableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stickLableToolStripMenuItem.Text = "Stick Lable";
            this.stickLableToolStripMenuItem.Click += new System.EventHandler(this.stickLableToolStripMenuItem_Click);
            // 
            // showInfoRealTimeToolStripMenuItem
            // 
            this.showInfoRealTimeToolStripMenuItem.Name = "showInfoRealTimeToolStripMenuItem";
            this.showInfoRealTimeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showInfoRealTimeToolStripMenuItem.Text = "Info Real Time";
            this.showInfoRealTimeToolStripMenuItem.Click += new System.EventHandler(this.showInfoRealTimeToolStripMenuItem_Click);
            // 
            // checkingToolStripMenuItem
            // 
            this.checkingToolStripMenuItem.Name = "checkingToolStripMenuItem";
            this.checkingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checkingToolStripMenuItem.Text = "Checking";
            this.checkingToolStripMenuItem.Click += new System.EventHandler(this.checkingToolStripMenuItem_Click);
            // 
            // gbPutin
            // 
            this.gbPutin.Controls.Add(this.info);
            this.gbPutin.Controls.Add(this.dtgridputinstore);
            this.gbPutin.Controls.Add(this.rbputinNote);
            this.gbPutin.Controls.Add(this.lbputinstatus);
            this.gbPutin.Controls.Add(this.txtputinSerial);
            this.gbPutin.Controls.Add(this.label2);
            this.gbPutin.Controls.Add(this.dataGridView1);
            this.gbPutin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPutin.Location = new System.Drawing.Point(16, 30);
            this.gbPutin.Name = "gbPutin";
            this.gbPutin.Size = new System.Drawing.Size(842, 450);
            this.gbPutin.TabIndex = 1;
            this.gbPutin.TabStop = false;
            this.gbPutin.Text = "PutIn";
            this.gbPutin.Visible = false;
            // 
            // info
            // 
            this.info.Controls.Add(this.txtCount);
            this.info.Controls.Add(this.label5);
            this.info.Controls.Add(this.btnsaveCSV);
            this.info.Controls.Add(this.textBox1);
            this.info.Controls.Add(this.cbbputinsearch);
            this.info.Controls.Add(this.label4);
            this.info.Controls.Add(this.btnloaddata);
            this.info.Controls.Add(this.btnimporttoDB);
            this.info.Controls.Add(this.btnxoa);
            this.info.Controls.Add(this.btntk);
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(10, 159);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(284, 277);
            this.info.TabIndex = 19;
            this.info.TabStop = false;
            this.info.Text = "Info";
            // 
            // btnsaveCSV
            // 
            this.btnsaveCSV.Location = new System.Drawing.Point(127, 77);
            this.btnsaveCSV.Name = "btnsaveCSV";
            this.btnsaveCSV.Size = new System.Drawing.Size(97, 30);
            this.btnsaveCSV.TabIndex = 26;
            this.btnsaveCSV.Text = "Save to csv";
            this.btnsaveCSV.UseVisualStyleBackColor = true;
            this.btnsaveCSV.Click += new System.EventHandler(this.btnsaveCSV_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(127, 224);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 25;
            // 
            // cbbputinsearch
            // 
            this.cbbputinsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbputinsearch.FormattingEnabled = true;
            this.cbbputinsearch.Items.AddRange(new object[] {
            "Serial",
            "In store",
            "Out store"});
            this.cbbputinsearch.Location = new System.Drawing.Point(119, 130);
            this.cbbputinsearch.Name = "cbbputinsearch";
            this.cbbputinsearch.Size = new System.Drawing.Size(121, 24);
            this.cbbputinsearch.TabIndex = 24;
            this.cbbputinsearch.SelectedIndexChanged += new System.EventHandler(this.cbbputinsearch_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Looking By";
            // 
            // btnloaddata
            // 
            this.btnloaddata.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloaddata.Location = new System.Drawing.Point(15, 21);
            this.btnloaddata.Name = "btnloaddata";
            this.btnloaddata.Size = new System.Drawing.Size(88, 30);
            this.btnloaddata.TabIndex = 22;
            this.btnloaddata.Text = "Load Excel";
            this.btnloaddata.UseVisualStyleBackColor = true;
            this.btnloaddata.Click += new System.EventHandler(this.btnloaddata_Click_1);
            // 
            // btnimporttoDB
            // 
            this.btnimporttoDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimporttoDB.Location = new System.Drawing.Point(127, 21);
            this.btnimporttoDB.Name = "btnimporttoDB";
            this.btnimporttoDB.Size = new System.Drawing.Size(98, 30);
            this.btnimporttoDB.TabIndex = 21;
            this.btnimporttoDB.Text = "Import to DB";
            this.btnimporttoDB.UseVisualStyleBackColor = true;
            this.btnimporttoDB.Click += new System.EventHandler(this.btnimporttoDB_Click_1);
            // 
            // btnxoa
            // 
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Location = new System.Drawing.Point(13, 77);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(90, 30);
            this.btnxoa.TabIndex = 20;
            this.btnxoa.Text = "Clear";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click_1);
            // 
            // btntk
            // 
            this.btntk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntk.Location = new System.Drawing.Point(18, 218);
            this.btntk.Name = "btntk";
            this.btntk.Size = new System.Drawing.Size(85, 35);
            this.btntk.TabIndex = 19;
            this.btntk.Text = "Search";
            this.btntk.UseVisualStyleBackColor = true;
            this.btntk.Click += new System.EventHandler(this.btntk_Click_1);
            // 
            // dtgridputinstore
            // 
            this.dtgridputinstore.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgridputinstore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridputinstore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.sn,
            this.date,
            this.state,
            this.where});
            this.dtgridputinstore.Location = new System.Drawing.Point(300, 169);
            this.dtgridputinstore.Name = "dtgridputinstore";
            this.dtgridputinstore.Size = new System.Drawing.Size(536, 267);
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
            // rbputinNote
            // 
            this.rbputinNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbputinNote.Location = new System.Drawing.Point(483, 22);
            this.rbputinNote.Name = "rbputinNote";
            this.rbputinNote.Size = new System.Drawing.Size(349, 111);
            this.rbputinNote.TabIndex = 7;
            this.rbputinNote.Text = "";
            // 
            // lbputinstatus
            // 
            this.lbputinstatus.AutoSize = true;
            this.lbputinstatus.BackColor = System.Drawing.Color.Yellow;
            this.lbputinstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbputinstatus.Location = new System.Drawing.Point(319, 26);
            this.lbputinstatus.Name = "lbputinstatus";
            this.lbputinstatus.Size = new System.Drawing.Size(119, 37);
            this.lbputinstatus.TabIndex = 6;
            this.lbputinstatus.Text = "WAITE";
            // 
            // txtputinSerial
            // 
            this.txtputinSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtputinSerial.Location = new System.Drawing.Point(119, 37);
            this.txtputinSerial.Name = "txtputinSerial";
            this.txtputinSerial.Size = new System.Drawing.Size(168, 26);
            this.txtputinSerial.TabIndex = 3;
            this.txtputinSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtputinSerial_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Serial";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(483, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(353, 267);
            this.dataGridView1.TabIndex = 20;
            // 
            // gbPutout
            // 
            this.gbPutout.Controls.Add(this.rtputoutNote);
            this.gbPutout.Controls.Add(this.lbPutoutstatus);
            this.gbPutout.Controls.Add(this.txtputoutserial);
            this.gbPutout.Controls.Add(this.label8);
            this.gbPutout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPutout.Location = new System.Drawing.Point(12, 17);
            this.gbPutout.Name = "gbPutout";
            this.gbPutout.Size = new System.Drawing.Size(842, 142);
            this.gbPutout.TabIndex = 9;
            this.gbPutout.TabStop = false;
            this.gbPutout.Text = "PutOut";
            this.gbPutout.Visible = false;
            // 
            // rtputoutNote
            // 
            this.rtputoutNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtputoutNote.Location = new System.Drawing.Point(487, 21);
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
            this.lbPutoutstatus.Location = new System.Drawing.Point(310, 23);
            this.lbPutoutstatus.Name = "lbPutoutstatus";
            this.lbPutoutstatus.Size = new System.Drawing.Size(119, 37);
            this.lbPutoutstatus.TabIndex = 6;
            this.lbPutoutstatus.Text = "WAITE";
            // 
            // txtputoutserial
            // 
            this.txtputoutserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtputoutserial.Location = new System.Drawing.Point(94, 40);
            this.txtputoutserial.Name = "txtputoutserial";
            this.txtputoutserial.Size = new System.Drawing.Size(160, 26);
            this.txtputoutserial.TabIndex = 3;
            this.txtputoutserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtputoutserial_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Serial";
            // 
            // gbPutinSMT
            // 
            this.gbPutinSMT.Controls.Add(this.lbputinsmtTimeleft);
            this.gbPutinSMT.Controls.Add(this.txtputinSMTconfirm);
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
            this.gbPutinSMT.Text = "Put In/Out SMT";
            this.gbPutinSMT.Visible = false;
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
            // txtputinSMTconfirm
            // 
            this.txtputinSMTconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtputinSMTconfirm.Location = new System.Drawing.Point(109, 99);
            this.txtputinSMTconfirm.Name = "txtputinSMTconfirm";
            this.txtputinSMTconfirm.Size = new System.Drawing.Size(151, 26);
            this.txtputinSMTconfirm.TabIndex = 9;
            this.txtputinSMTconfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtputinSMTconfirm_KeyDown);
            // 
            // lbputinSMTconfirm
            // 
            this.lbputinSMTconfirm.AutoSize = true;
            this.lbputinSMTconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbputinSMTconfirm.Location = new System.Drawing.Point(8, 102);
            this.lbputinSMTconfirm.Name = "lbputinSMTconfirm";
            this.lbputinSMTconfirm.Size = new System.Drawing.Size(104, 20);
            this.lbputinSMTconfirm.TabIndex = 8;
            this.lbputinSMTconfirm.Text = "Serial Put out";
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
            this.txtputinSMTserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtputinSMTserial.Location = new System.Drawing.Point(109, 40);
            this.txtputinSMTserial.Name = "txtputinSMTserial";
            this.txtputinSMTserial.Size = new System.Drawing.Size(153, 26);
            this.txtputinSMTserial.TabIndex = 3;
            this.txtputinSMTserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtputinSMTserial_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Serial Put in";
            // 
            // gbSpinSolder
            // 
            this.gbSpinSolder.Controls.Add(this.txtspinconfirm);
            this.gbSpinSolder.Controls.Add(this.lbspinTimeLeft);
            this.gbSpinSolder.Controls.Add(this.rbspinNote);
            this.gbSpinSolder.Controls.Add(this.lbspinstatus);
            this.gbSpinSolder.Controls.Add(this.txtspinserial);
            this.gbSpinSolder.Controls.Add(this.label10);
            this.gbSpinSolder.Controls.Add(this.label7);
            this.gbSpinSolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSpinSolder.Location = new System.Drawing.Point(12, 21);
            this.gbSpinSolder.Name = "gbSpinSolder";
            this.gbSpinSolder.Size = new System.Drawing.Size(842, 142);
            this.gbSpinSolder.TabIndex = 10;
            this.gbSpinSolder.TabStop = false;
            this.gbSpinSolder.Text = "Spin Solder";
            this.gbSpinSolder.Visible = false;
            // 
            // txtspinconfirm
            // 
            this.txtspinconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtspinconfirm.Location = new System.Drawing.Point(115, 44);
            this.txtspinconfirm.Name = "txtspinconfirm";
            this.txtspinconfirm.Size = new System.Drawing.Size(139, 26);
            this.txtspinconfirm.TabIndex = 10;
            this.txtspinconfirm.TextChanged += new System.EventHandler(this.txtspinconfirm_TextChanged);
            this.txtspinconfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtspinconfirm_KeyDown);
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
            this.txtspinserial.Location = new System.Drawing.Point(115, 98);
            this.txtspinserial.Name = "txtspinserial";
            this.txtspinserial.Size = new System.Drawing.Size(141, 26);
            this.txtspinserial.TabIndex = 3;
            this.txtspinserial.TextChanged += new System.EventHandler(this.txtspinserial_TextChanged);
            this.txtspinserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtspinserial_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Start Spining";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Start Thawing";
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
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.gbSpinSolder);
            this.panel1.Controls.Add(this.gbPutinSMT);
            this.panel1.Controls.Add(this.gbPutin);
            this.panel1.Controls.Add(this.gbPutout);
            this.panel1.Controls.Add(this.gbLogIn);
            this.panel1.Controls.Add(this.gbsticklable);
            this.panel1.Location = new System.Drawing.Point(8, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 483);
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
            this.txtstickserial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
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
            // pnwelcome
            // 
            this.pnwelcome.AutoSize = true;
            this.pnwelcome.Controls.Add(this.lblocaltime);
            this.pnwelcome.Controls.Add(this.lbwelcome);
            this.pnwelcome.Location = new System.Drawing.Point(158, 0);
            this.pnwelcome.Name = "pnwelcome";
            this.pnwelcome.Size = new System.Drawing.Size(724, 37);
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
            this.tmtimeLeft.Tick += new System.EventHandler(this.tmServerTime_Tick);
            // 
            // tmstatus
            // 
            this.tmstatus.Interval = 1000;
            this.tmstatus.Tick += new System.EventHandler(this.tmstatus_Tick);
            // 
            // dtgridShowinfo
            // 
            this.dtgridShowinfo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgridShowinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridShowinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Barcode,
            this.Adress,
            this.Action,
            this.TimeLeft,
            this.Note});
            this.dtgridShowinfo.EnableHeadersVisualStyles = false;
            this.dtgridShowinfo.Location = new System.Drawing.Point(8, 43);
            this.dtgridShowinfo.Name = "dtgridShowinfo";
            this.dtgridShowinfo.Size = new System.Drawing.Size(874, 490);
            this.dtgridShowinfo.TabIndex = 14;
            this.dtgridShowinfo.Visible = false;
            this.dtgridShowinfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtgridShowinfo_RowsAdded);
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
            this.gbCheckinfo.Controls.Add(this.btnExport);
            this.gbCheckinfo.Controls.Add(this.dtgridstate);
            this.gbCheckinfo.Controls.Add(this.label3);
            this.gbCheckinfo.Controls.Add(this.cbgrcheckinfolooktype);
            this.gbCheckinfo.Controls.Add(this.txtcheckinfoSerial);
            this.gbCheckinfo.Controls.Add(this.lbserial);
            this.gbCheckinfo.Controls.Add(this.dtgridCheckInfo);
            this.gbCheckinfo.Location = new System.Drawing.Point(8, 43);
            this.gbCheckinfo.Name = "gbCheckinfo";
            this.gbCheckinfo.Size = new System.Drawing.Size(874, 472);
            this.gbCheckinfo.TabIndex = 15;
            this.gbCheckinfo.TabStop = false;
            this.gbCheckinfo.Text = "Info";
            this.gbCheckinfo.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(329, 32);
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
            this.label3.Location = new System.Drawing.Point(41, 37);
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
            this.cbgrcheckinfolooktype.Location = new System.Drawing.Point(135, 37);
            this.cbgrcheckinfolooktype.Name = "cbgrcheckinfolooktype";
            this.cbgrcheckinfolooktype.Size = new System.Drawing.Size(121, 21);
            this.cbgrcheckinfolooktype.TabIndex = 3;
            this.cbgrcheckinfolooktype.SelectedIndexChanged += new System.EventHandler(this.cbgrcheckinfolooktype_SelectedIndexChanged);
            // 
            // txtcheckinfoSerial
            // 
            this.txtcheckinfoSerial.Enabled = false;
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
            this.lbserial.Location = new System.Drawing.Point(41, 88);
            this.lbserial.Name = "lbserial";
            this.lbserial.Size = new System.Drawing.Size(49, 20);
            this.lbserial.TabIndex = 1;
            this.lbserial.Text = "Serial";
            // 
            // dtgridCheckInfo
            // 
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
            this.dtgridCheckInfo.Size = new System.Drawing.Size(865, 329);
            this.dtgridCheckInfo.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Count";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(119, 174);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(121, 22);
            this.txtCount.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(892, 545);
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
            this.info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridputinstore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbPutout.ResumeLayout(false);
            this.gbPutout.PerformLayout();
            this.gbPutinSMT.ResumeLayout(false);
            this.gbPutinSMT.PerformLayout();
            this.gbSpinSolder.ResumeLayout(false);
            this.gbSpinSolder.PerformLayout();
            this.gbLogIn.ResumeLayout(false);
            this.gbLogIn.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbsticklable.ResumeLayout(false);
            this.gbsticklable.PerformLayout();
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
        private System.Windows.Forms.TextBox txtputinSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbPutout;
        private System.Windows.Forms.GroupBox gbSpinSolder;
        private System.Windows.Forms.TextBox txtspinconfirm;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.TextBox txtputinSMTconfirm;
        private System.Windows.Forms.Label lbputinSMTconfirm;
        private System.Windows.Forms.ToolStripMenuItem showInfoRealTimeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgridShowinfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
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
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dtgridputinstore;
        private System.Windows.Forms.GroupBox info;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbbputinsearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnloaddata;
        private System.Windows.Forms.Button btnimporttoDB;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btntk;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn where;
        private System.Windows.Forms.Button btnsaveCSV;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label5;
    }
}

