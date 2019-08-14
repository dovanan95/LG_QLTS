namespace QLTS_LG
{
    partial class Distribute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Distribute));
            this.brnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIT_Tag = new System.Windows.Forms.TextBox();
            this.txtFA_Tag = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSN = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtSoBB = new System.Windows.Forms.TextBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tnInsertUser = new System.Windows.Forms.Button();
            this.chkOSP = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser_Name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUserID2 = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUserSearch = new System.Windows.Forms.Button();
            this.txtIDUser = new System.Windows.Forms.Label();
            this.txtIDSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // brnSearch
            // 
            this.brnSearch.Location = new System.Drawing.Point(605, 97);
            this.brnSearch.Name = "brnSearch";
            this.brnSearch.Size = new System.Drawing.Size(95, 23);
            this.brnSearch.TabIndex = 0;
            this.brnSearch.Text = "Search";
            this.brnSearch.UseVisualStyleBackColor = true;
            this.brnSearch.Click += new System.EventHandler(this.brnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(210, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1097, 188);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(444, 14);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(255, 21);
            this.cbType.TabIndex = 2;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // txtSN
            // 
            this.txtSN.Location = new System.Drawing.Point(81, 15);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(260, 20);
            this.txtSN.TabIndex = 3;
            this.txtSN.TextChanged += new System.EventHandler(this.txtSN_TextChanged);
            this.txtSN.Enter += new System.EventHandler(this.txtSN_Enter);
            this.txtSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSN_KeyDown);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(210, 424);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1097, 217);
            this.dataGridView2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số Biên Bản";
            // 
            // txtIT_Tag
            // 
            this.txtIT_Tag.Location = new System.Drawing.Point(81, 102);
            this.txtIT_Tag.Name = "txtIT_Tag";
            this.txtIT_Tag.Size = new System.Drawing.Size(260, 20);
            this.txtIT_Tag.TabIndex = 6;
            this.txtIT_Tag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIT_Tag_KeyDown);
            // 
            // txtFA_Tag
            // 
            this.txtFA_Tag.Location = new System.Drawing.Point(81, 58);
            this.txtFA_Tag.Name = "txtFA_Tag";
            this.txtFA_Tag.Size = new System.Drawing.Size(260, 20);
            this.txtFA_Tag.TabIndex = 7;
            this.txtFA_Tag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFA_Tag_KeyDown);
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(445, 57);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(255, 21);
            this.cbStatus.TabIndex = 8;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblSN);
            this.panel1.Controls.Add(this.txtSN);
            this.panel1.Controls.Add(this.cbStatus);
            this.panel1.Controls.Add(this.txtFA_Tag);
            this.panel1.Controls.Add(this.txtIT_Tag);
            this.panel1.Controls.Add(this.brnSearch);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Location = new System.Drawing.Point(35, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 160);
            this.panel1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(362, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Trạng Thái";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Info;
            this.label5.Location = new System.Drawing.Point(350, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Loại Tài Sản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(25, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "IT Tag";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(21, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "FA Tag";
            // 
            // lblSN
            // 
            this.lblSN.AutoSize = true;
            this.lblSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSN.ForeColor = System.Drawing.SystemColors.Info;
            this.lblSN.Location = new System.Drawing.Point(42, 18);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(30, 15);
            this.lblSN.TabIndex = 11;
            this.lblSN.Text = "S/N";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(16, 18);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(137, 30);
            this.btnTransfer.TabIndex = 9;
            this.btnTransfer.Text = ">>";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtSoBB
            // 
            this.txtSoBB.Location = new System.Drawing.Point(81, 6);
            this.txtSoBB.Name = "txtSoBB";
            this.txtSoBB.Size = new System.Drawing.Size(195, 20);
            this.txtSoBB.TabIndex = 9;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(280, 4);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(61, 23);
            this.btnGen.TabIndex = 16;
            this.btnGen.Text = "Generate";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tnInsertUser);
            this.panel2.Controls.Add(this.chkOSP);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtDept);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtUser_Name);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtUserID2);
            this.panel2.Controls.Add(this.txtPhone);
            this.panel2.Controls.Add(this.txtMail);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Location = new System.Drawing.Point(759, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 160);
            this.panel2.TabIndex = 16;
            // 
            // tnInsertUser
            // 
            this.tnInsertUser.Location = new System.Drawing.Point(369, 91);
            this.tnInsertUser.Name = "tnInsertUser";
            this.tnInsertUser.Size = new System.Drawing.Size(75, 23);
            this.tnInsertUser.TabIndex = 21;
            this.tnInsertUser.Text = "Insert";
            this.tnInsertUser.UseVisualStyleBackColor = true;
            this.tnInsertUser.Click += new System.EventHandler(this.tnInsertUser_Click);
            // 
            // chkOSP
            // 
            this.chkOSP.AutoSize = true;
            this.chkOSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOSP.ForeColor = System.Drawing.SystemColors.Info;
            this.chkOSP.Location = new System.Drawing.Point(312, 96);
            this.chkOSP.Name = "chkOSP";
            this.chkOSP.Size = new System.Drawing.Size(51, 17);
            this.chkOSP.TabIndex = 20;
            this.chkOSP.Text = "OSP";
            this.chkOSP.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Info;
            this.label12.Location = new System.Drawing.Point(74, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Dept";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(113, 93);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(164, 20);
            this.txtDept.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tên Người Nhận";
            // 
            // txtUser_Name
            // 
            this.txtUser_Name.Location = new System.Drawing.Point(114, 55);
            this.txtUser_Name.Name = "txtUser_Name";
            this.txtUser_Name.Size = new System.Drawing.Size(164, 20);
            this.txtUser_Name.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Info;
            this.label9.Location = new System.Drawing.Point(312, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Mail";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Info;
            this.label10.Location = new System.Drawing.Point(309, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Phone";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Info;
            this.label11.Location = new System.Drawing.Point(18, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "ID Người Nhận";
            // 
            // txtUserID2
            // 
            this.txtUserID2.Location = new System.Drawing.Point(114, 16);
            this.txtUserID2.Name = "txtUserID2";
            this.txtUserID2.Size = new System.Drawing.Size(164, 20);
            this.txtUserID2.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(369, 16);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(164, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(369, 55);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(164, 20);
            this.txtMail.TabIndex = 6;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(458, 90);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(16, 160);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 28);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.btnReport);
            this.pnlControl.Controls.Add(this.btnSelectAll);
            this.pnlControl.Controls.Add(this.btnCreate);
            this.pnlControl.Controls.Add(this.btnBack);
            this.pnlControl.Controls.Add(this.btnTransfer);
            this.pnlControl.Location = new System.Drawing.Point(35, 217);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(169, 424);
            this.pnlControl.TabIndex = 17;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(16, 111);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(137, 31);
            this.btnSelectAll.TabIndex = 16;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(16, 65);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(137, 29);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Lập Biên Bản";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUserSearch
            // 
            this.btnUserSearch.Location = new System.Drawing.Point(1248, 14);
            this.btnUserSearch.Name = "btnUserSearch";
            this.btnUserSearch.Size = new System.Drawing.Size(59, 23);
            this.btnUserSearch.TabIndex = 21;
            this.btnUserSearch.Text = "Search";
            this.btnUserSearch.UseVisualStyleBackColor = true;
            this.btnUserSearch.Click += new System.EventHandler(this.btnUserSearch_Click);
            // 
            // txtIDUser
            // 
            this.txtIDUser.AutoSize = true;
            this.txtIDUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDUser.ForeColor = System.Drawing.SystemColors.Info;
            this.txtIDUser.Location = new System.Drawing.Point(1017, 23);
            this.txtIDUser.Name = "txtIDUser";
            this.txtIDUser.Size = new System.Drawing.Size(50, 13);
            this.txtIDUser.TabIndex = 22;
            this.txtIDUser.Text = "User ID";
            // 
            // txtIDSearch
            // 
            this.txtIDSearch.Location = new System.Drawing.Point(1073, 16);
            this.txtIDSearch.Name = "txtIDSearch";
            this.txtIDSearch.Size = new System.Drawing.Size(166, 20);
            this.txtIDSearch.TabIndex = 23;
            this.txtIDSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDSearch_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnBrowse);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtReason);
            this.panel3.Controls.Add(this.txtSoBB);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnGen);
            this.panel3.Location = new System.Drawing.Point(35, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(950, 38);
            this.panel3.TabIndex = 24;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(839, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(106, 23);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(759, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "EP Approve";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(388, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Reason";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(444, 5);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(255, 20);
            this.txtReason.TabIndex = 17;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(16, 206);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(137, 32);
            this.btnReport.TabIndex = 25;
            this.btnReport.Text = "Xuất Biên Bản";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // Distribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1319, 714);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtIDSearch);
            this.Controls.Add(this.txtIDUser);
            this.Controls.Add(this.btnUserSearch);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Distribute";
            this.Text = "Distribute";
            this.Load += new System.EventHandler(this.Distribute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button brnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIT_Tag;
        private System.Windows.Forms.TextBox txtFA_Tag;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtSoBB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSN;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUserID2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser_Name;
        private System.Windows.Forms.CheckBox chkOSP;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnUserSearch;
        private System.Windows.Forms.Label txtIDUser;
        private System.Windows.Forms.TextBox txtIDSearch;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button tnInsertUser;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnReport;
    }
}