namespace Stencil_Solder_Control
{
    partial class Setting
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
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkboxbcontrol = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbStencil = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtthaw = new System.Windows.Forms.TextBox();
            this.txtspin = new System.Windows.Forms.TextBox();
            this.txtturnaround = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtoutside = new System.Windows.Forms.TextBox();
            this.gbsolderpaste = new System.Windows.Forms.GroupBox();
            this.txtwashing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnsearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpartInter = new System.Windows.Forms.TextBox();
            this.txtpartNumber = new System.Windows.Forms.TextBox();
            this.btnexport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbmodelName = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.btnaddmodel = new System.Windows.Forms.Button();
            this.btnaddcus = new System.Windows.Forms.Button();
            this.gbStencil.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbsolderpaste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbtype
            // 
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Items.AddRange(new object[] {
            "Solder Paste",
            "Stencil"});
            this.cbtype.Location = new System.Drawing.Point(336, 23);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(121, 21);
            this.cbtype.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type";
            // 
            // checkboxbcontrol
            // 
            this.checkboxbcontrol.AutoSize = true;
            this.checkboxbcontrol.Location = new System.Drawing.Point(554, 23);
            this.checkboxbcontrol.Name = "checkboxbcontrol";
            this.checkboxbcontrol.Size = new System.Drawing.Size(108, 17);
            this.checkboxbcontrol.TabIndex = 2;
            this.checkboxbcontrol.Text = "Need to control ?";
            this.checkboxbcontrol.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer";
            // 
            // gbStencil
            // 
            this.gbStencil.Controls.Add(this.tableLayoutPanel1);
            this.gbStencil.Location = new System.Drawing.Point(32, 194);
            this.gbStencil.Name = "gbStencil";
            this.gbStencil.Size = new System.Drawing.Size(459, 138);
            this.gbStencil.TabIndex = 5;
            this.gbStencil.TabStop = false;
            this.gbStencil.Text = "Solde paste";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.7451F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.2549F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtthaw, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtspin, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtturnaround, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtoutside, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.83146F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.21348F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.95506F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(437, 110);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Max Outside (s)";
            // 
            // txtthaw
            // 
            this.txtthaw.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtthaw.Location = new System.Drawing.Point(167, 4);
            this.txtthaw.Name = "txtthaw";
            this.txtthaw.Size = new System.Drawing.Size(109, 20);
            this.txtthaw.TabIndex = 0;
            // 
            // txtspin
            // 
            this.txtspin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtspin.Location = new System.Drawing.Point(167, 31);
            this.txtspin.Name = "txtspin";
            this.txtspin.Size = new System.Drawing.Size(109, 20);
            this.txtspin.TabIndex = 1;
            // 
            // txtturnaround
            // 
            this.txtturnaround.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtturnaround.Location = new System.Drawing.Point(167, 55);
            this.txtturnaround.Name = "txtturnaround";
            this.txtturnaround.Size = new System.Drawing.Size(109, 20);
            this.txtturnaround.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Thawing (s)";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Spinning (s)";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Turn around (s)";
            // 
            // txtoutside
            // 
            this.txtoutside.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtoutside.Location = new System.Drawing.Point(167, 85);
            this.txtoutside.Name = "txtoutside";
            this.txtoutside.Size = new System.Drawing.Size(109, 20);
            this.txtoutside.TabIndex = 7;
            // 
            // gbsolderpaste
            // 
            this.gbsolderpaste.Controls.Add(this.txtwashing);
            this.gbsolderpaste.Controls.Add(this.label6);
            this.gbsolderpaste.Location = new System.Drawing.Point(580, 194);
            this.gbsolderpaste.Name = "gbsolderpaste";
            this.gbsolderpaste.Size = new System.Drawing.Size(498, 132);
            this.gbsolderpaste.TabIndex = 6;
            this.gbsolderpaste.TabStop = false;
            this.gbsolderpaste.Text = "Stencil";
            // 
            // txtwashing
            // 
            this.txtwashing.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtwashing.Location = new System.Drawing.Point(115, 21);
            this.txtwashing.Name = "txtwashing";
            this.txtwashing.Size = new System.Drawing.Size(109, 20);
            this.txtwashing.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Washing (s)";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(301, 156);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(382, 156);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 340);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1066, 173);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(220, 156);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 10;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(555, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Model";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Part Internal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(555, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Part Number";
            // 
            // txtpartInter
            // 
            this.txtpartInter.Location = new System.Drawing.Point(336, 105);
            this.txtpartInter.Name = "txtpartInter";
            this.txtpartInter.Size = new System.Drawing.Size(121, 20);
            this.txtpartInter.TabIndex = 13;
            // 
            // txtpartNumber
            // 
            this.txtpartNumber.Location = new System.Drawing.Point(627, 67);
            this.txtpartNumber.Name = "txtpartNumber";
            this.txtpartNumber.Size = new System.Drawing.Size(138, 20);
            this.txtpartNumber.TabIndex = 14;
            // 
            // btnexport
            // 
            this.btnexport.Location = new System.Drawing.Point(897, 156);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(75, 23);
            this.btnexport.TabIndex = 17;
            this.btnexport.Text = "Export";
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(816, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbmodelName
            // 
            this.cbmodelName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbmodelName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbmodelName.FormattingEnabled = true;
            this.cbmodelName.Location = new System.Drawing.Point(627, 105);
            this.cbmodelName.Name = "cbmodelName";
            this.cbmodelName.Size = new System.Drawing.Size(138, 21);
            this.cbmodelName.TabIndex = 19;
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(336, 68);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(121, 21);
            this.cbCustomer.TabIndex = 20;
            // 
            // btnaddmodel
            // 
            this.btnaddmodel.Location = new System.Drawing.Point(627, 156);
            this.btnaddmodel.Name = "btnaddmodel";
            this.btnaddmodel.Size = new System.Drawing.Size(75, 23);
            this.btnaddmodel.TabIndex = 21;
            this.btnaddmodel.Text = "Add Model";
            this.btnaddmodel.UseVisualStyleBackColor = true;
            this.btnaddmodel.Click += new System.EventHandler(this.btnaddmodel_Click);
            // 
            // btnaddcus
            // 
            this.btnaddcus.Location = new System.Drawing.Point(708, 156);
            this.btnaddcus.Name = "btnaddcus";
            this.btnaddcus.Size = new System.Drawing.Size(96, 23);
            this.btnaddcus.TabIndex = 22;
            this.btnaddcus.Text = "Add Customer";
            this.btnaddcus.UseVisualStyleBackColor = true;
            this.btnaddcus.Click += new System.EventHandler(this.btnaddcus_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 525);
            this.Controls.Add(this.btnaddcus);
            this.Controls.Add(this.btnaddmodel);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.cbmodelName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtpartInter);
            this.Controls.Add(this.txtpartNumber);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbsolderpaste);
            this.Controls.Add(this.gbStencil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkboxbcontrol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbtype);
            this.Name = "Setting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.gbStencil.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbsolderpaste.ResumeLayout(false);
            this.gbsolderpaste.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkboxbcontrol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbStencil;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtthaw;
        private System.Windows.Forms.TextBox txtspin;
        private System.Windows.Forms.TextBox txtturnaround;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbsolderpaste;
        private System.Windows.Forms.TextBox txtwashing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtpartInter;
        private System.Windows.Forms.TextBox txtpartNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtoutside;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbmodelName;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Button btnaddmodel;
        private System.Windows.Forms.Button btnaddcus;
    }
}