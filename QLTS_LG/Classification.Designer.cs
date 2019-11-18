namespace QLTS_LG
{
    partial class Classification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Classification));
            this.tabModel = new System.Windows.Forms.TabControl();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddType = new System.Windows.Forms.Button();
            this.txtType2Name = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType1 = new System.Windows.Forms.ComboBox();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.tabUnit = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBacktoMenu = new System.Windows.Forms.Button();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvUnit = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.cbTypeLV2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.dgvModel = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTypeLevel1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBackModel = new System.Windows.Forms.Button();
            this.btnUpdateModel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabModel.SuspendLayout();
            this.tabDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.tabUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnit)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).BeginInit();
            this.SuspendLayout();
            // 
            // tabModel
            // 
            this.tabModel.Controls.Add(this.tabDevice);
            this.tabModel.Controls.Add(this.tabUnit);
            this.tabModel.Controls.Add(this.tabPage1);
            this.tabModel.Location = new System.Drawing.Point(22, 70);
            this.tabModel.Name = "tabModel";
            this.tabModel.SelectedIndex = 0;
            this.tabModel.Size = new System.Drawing.Size(1272, 492);
            this.tabModel.TabIndex = 0;
            // 
            // tabDevice
            // 
            this.tabDevice.BackColor = System.Drawing.SystemColors.Menu;
            this.tabDevice.Controls.Add(this.splitContainer1);
            this.tabDevice.Location = new System.Drawing.Point(4, 22);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevice.Size = new System.Drawing.Size(1264, 466);
            this.tabDevice.TabIndex = 1;
            this.tabDevice.Text = "Phân Loại Tài Sản";
            this.tabDevice.Click += new System.EventHandler(this.tabDevice_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(44, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer1.Panel1.Controls.Add(this.btnBack);
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddType);
            this.splitContainer1.Panel1.Controls.Add(this.txtType2Name);
            this.splitContainer1.Panel1.Controls.Add(this.btnXoa);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnSua);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cbType1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvShow);
            this.splitContainer1.Size = new System.Drawing.Size(1185, 417);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(288, 278);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(288, 249);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(207, 249);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(75, 23);
            this.btnAddType.TabIndex = 0;
            this.btnAddType.Text = "Thêm";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // txtType2Name
            // 
            this.txtType2Name.Location = new System.Drawing.Point(18, 169);
            this.txtType2Name.Name = "txtType2Name";
            this.txtType2Name.Size = new System.Drawing.Size(345, 20);
            this.txtType2Name.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(207, 307);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phân Loại (Level 1)";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(207, 278);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Loại Vật Tư (Level 2)";
            // 
            // cbType1
            // 
            this.cbType1.FormattingEnabled = true;
            this.cbType1.Location = new System.Drawing.Point(18, 74);
            this.cbType1.Name = "cbType1";
            this.cbType1.Size = new System.Drawing.Size(345, 21);
            this.cbType1.TabIndex = 2;
            // 
            // dgvShow
            // 
            this.dgvShow.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvShow.Location = new System.Drawing.Point(3, 3);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.Size = new System.Drawing.Size(780, 411);
            this.dgvShow.TabIndex = 0;
            // 
            // tabUnit
            // 
            this.tabUnit.Controls.Add(this.splitContainer2);
            this.tabUnit.Location = new System.Drawing.Point(4, 22);
            this.tabUnit.Name = "tabUnit";
            this.tabUnit.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnit.Size = new System.Drawing.Size(1264, 466);
            this.tabUnit.TabIndex = 2;
            this.tabUnit.Text = "Phân Loại Đơn Vị Tính";
            this.tabUnit.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.splitContainer2.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel1.Controls.Add(this.btnBacktoMenu);
            this.splitContainer2.Panel1.Controls.Add(this.txtUnit);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.btnAdd);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvUnit);
            this.splitContainer2.Size = new System.Drawing.Size(1258, 460);
            this.splitContainer2.SplitterDistance = 419;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(215, 138);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBacktoMenu
            // 
            this.btnBacktoMenu.Location = new System.Drawing.Point(295, 138);
            this.btnBacktoMenu.Name = "btnBacktoMenu";
            this.btnBacktoMenu.Size = new System.Drawing.Size(75, 23);
            this.btnBacktoMenu.TabIndex = 3;
            this.btnBacktoMenu.Text = "Back";
            this.btnBacktoMenu.UseVisualStyleBackColor = true;
            this.btnBacktoMenu.Click += new System.EventHandler(this.btnBacktoMenu_Click);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(67, 98);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(303, 20);
            this.txtUnit.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cornsilk;
            this.label3.Location = new System.Drawing.Point(10, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đơn vị";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(134, 138);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvUnit
            // 
            this.dgvUnit.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgvUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnit.Location = new System.Drawing.Point(3, 3);
            this.dgvUnit.Name = "dgvUnit";
            this.dgvUnit.Size = new System.Drawing.Size(829, 454);
            this.dgvUnit.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Beige;
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnUpdateModel);
            this.tabPage1.Controls.Add(this.btnBackModel);
            this.tabPage1.Controls.Add(this.cbTypeLevel1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnAddModel);
            this.tabPage1.Controls.Add(this.cbTypeLV2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtModelName);
            this.tabPage1.Controls.Add(this.dgvModel);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1264, 466);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Model";
            // 
            // btnAddModel
            // 
            this.btnAddModel.Location = new System.Drawing.Point(111, 342);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(75, 23);
            this.btnAddModel.TabIndex = 5;
            this.btnAddModel.Text = "New";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // cbTypeLV2
            // 
            this.cbTypeLV2.FormattingEnabled = true;
            this.cbTypeLV2.Location = new System.Drawing.Point(38, 194);
            this.cbTypeLV2.Name = "cbTypeLV2";
            this.cbTypeLV2.Size = new System.Drawing.Size(391, 21);
            this.cbTypeLV2.TabIndex = 4;
            this.cbTypeLV2.SelectedIndexChanged += new System.EventHandler(this.cbTypeLV2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Phân Loại Tài Sản Level 2";
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(38, 275);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(391, 20);
            this.txtModelName.TabIndex = 2;
            // 
            // dgvModel
            // 
            this.dgvModel.BackgroundColor = System.Drawing.Color.White;
            this.dgvModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModel.Location = new System.Drawing.Point(491, 6);
            this.dgvModel.Name = "dgvModel";
            this.dgvModel.Size = new System.Drawing.Size(767, 454);
            this.dgvModel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Model Name";
            // 
            // cbTypeLevel1
            // 
            this.cbTypeLevel1.FormattingEnabled = true;
            this.cbTypeLevel1.Location = new System.Drawing.Point(38, 105);
            this.cbTypeLevel1.Name = "cbTypeLevel1";
            this.cbTypeLevel1.Size = new System.Drawing.Size(391, 21);
            this.cbTypeLevel1.TabIndex = 7;
            this.cbTypeLevel1.SelectedIndexChanged += new System.EventHandler(this.cbTypeLevel1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Phân Loại Tài Sản Level 1";
            // 
            // btnBackModel
            // 
            this.btnBackModel.Location = new System.Drawing.Point(354, 342);
            this.btnBackModel.Name = "btnBackModel";
            this.btnBackModel.Size = new System.Drawing.Size(75, 23);
            this.btnBackModel.TabIndex = 8;
            this.btnBackModel.Text = "Back";
            this.btnBackModel.UseVisualStyleBackColor = true;
            this.btnBackModel.Click += new System.EventHandler(this.btnBackModel_Click);
            // 
            // btnUpdateModel
            // 
            this.btnUpdateModel.Location = new System.Drawing.Point(192, 342);
            this.btnUpdateModel.Name = "btnUpdateModel";
            this.btnUpdateModel.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateModel.TabIndex = 9;
            this.btnUpdateModel.Text = "Modify";
            this.btnUpdateModel.UseVisualStyleBackColor = true;
            this.btnUpdateModel.Click += new System.EventHandler(this.btnUpdateModel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 342);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Classification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1317, 619);
            this.Controls.Add(this.tabModel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Classification";
            this.Text = "Classification";
            this.Load += new System.EventHandler(this.Classification_Load);
            this.tabModel.ResumeLayout(false);
            this.tabDevice.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.tabUnit.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnit)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabModel;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.TabPage tabUnit;
        private System.Windows.Forms.TextBox txtType2Name;
        private System.Windows.Forms.ComboBox cbType1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBacktoMenu;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.DataGridView dgvModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTypeLV2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.ComboBox cbTypeLevel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBackModel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdateModel;
    }
}