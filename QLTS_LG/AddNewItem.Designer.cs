namespace QLTS_LG
{
    partial class AddNewItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewItem));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtMaTS = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbTypeLV1 = new System.Windows.Forms.ComboBox();
            this.loaiTScap1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTSDataSet = new QLTS_LG.QLTSDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenTS = new System.Windows.Forms.TextBox();
            this.cbTypeLV2 = new System.Windows.Forms.ComboBox();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.txtITTag = new System.Windows.Forms.TextBox();
            this.txtFATag = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.loai_TS_cap1TableAdapter = new QLTS_LG.QLTSDataSetTableAdapters.Loai_TS_cap1TableAdapter();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSoBB = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewBBNo = new System.Windows.Forms.Button();
            this.btnNewAssetID = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblSoBB = new System.Windows.Forms.Label();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnCloseBB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiTScap1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTSDataSet)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Tài Sản";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(17, 15);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(128, 49);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Thêm Mới";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtMaTS
            // 
            this.txtMaTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTS.Location = new System.Drawing.Point(143, 101);
            this.txtMaTS.Multiline = true;
            this.txtMaTS.Name = "txtMaTS";
            this.txtMaTS.Size = new System.Drawing.Size(196, 30);
            this.txtMaTS.TabIndex = 2;
            this.txtMaTS.Text = "==Mã Tài Sản==";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(75, 463);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1111, 236);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cbTypeLV1
            // 
            this.cbTypeLV1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTypeLV1.FormattingEnabled = true;
            this.cbTypeLV1.Location = new System.Drawing.Point(675, 210);
            this.cbTypeLV1.Name = "cbTypeLV1";
            this.cbTypeLV1.Size = new System.Drawing.Size(205, 28);
            this.cbTypeLV1.TabIndex = 5;
            this.cbTypeLV1.Text = "==Select==";
            // 
            // loaiTScap1BindingSource
            // 
            this.loaiTScap1BindingSource.DataMember = "Loai_TS_cap1";
            this.loaiTScap1BindingSource.DataSource = this.qLTSDataSet;
            // 
            // qLTSDataSet
            // 
            this.qLTSDataSet.DataSetName = "QLTSDataSet";
            this.qLTSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên Tài Sản";
            // 
            // txtTenTS
            // 
            this.txtTenTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTS.Location = new System.Drawing.Point(143, 164);
            this.txtTenTS.Multiline = true;
            this.txtTenTS.Name = "txtTenTS";
            this.txtTenTS.Size = new System.Drawing.Size(196, 31);
            this.txtTenTS.TabIndex = 7;
            this.txtTenTS.Text = "==Tên Tài Sản==";
            // 
            // cbTypeLV2
            // 
            this.cbTypeLV2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTypeLV2.FormattingEnabled = true;
            this.cbTypeLV2.Location = new System.Drawing.Point(675, 267);
            this.cbTypeLV2.Name = "cbTypeLV2";
            this.cbTypeLV2.Size = new System.Drawing.Size(205, 28);
            this.cbTypeLV2.TabIndex = 8;
            this.cbTypeLV2.Text = "==Select==";
            // 
            // txtSN
            // 
            this.txtSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSN.Location = new System.Drawing.Point(143, 230);
            this.txtSN.Multiline = true;
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(196, 32);
            this.txtSN.TabIndex = 9;
            this.txtSN.Text = "==Serial Number==";
            this.txtSN.TextChanged += new System.EventHandler(this.txtSN_TextChanged);
            // 
            // txtITTag
            // 
            this.txtITTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtITTag.Location = new System.Drawing.Point(143, 293);
            this.txtITTag.Multiline = true;
            this.txtITTag.Name = "txtITTag";
            this.txtITTag.Size = new System.Drawing.Size(196, 34);
            this.txtITTag.TabIndex = 10;
            this.txtITTag.Text = "==IT Tag==";
            this.txtITTag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFATag
            // 
            this.txtFATag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFATag.Location = new System.Drawing.Point(675, 31);
            this.txtFATag.Multiline = true;
            this.txtFATag.Name = "txtFATag";
            this.txtFATag.Size = new System.Drawing.Size(205, 36);
            this.txtFATag.TabIndex = 11;
            this.txtFATag.Text = "==FA Tag==";
            this.txtFATag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.Location = new System.Drawing.Point(675, 87);
            this.txtModel.Multiline = true;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(205, 34);
            this.txtModel.TabIndex = 12;
            this.txtModel.Text = "==Model==";
            this.txtModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(502, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Loại tài sản cấp 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(502, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Loại tài sản cấp 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.Location = new System.Drawing.Point(13, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Serial Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(502, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "FA Tag";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "IT Tag";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(502, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Model";
            // 
            // txtSpec
            // 
            this.txtSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpec.Location = new System.Drawing.Point(675, 143);
            this.txtSpec.Multiline = true;
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(205, 34);
            this.txtSpec.TabIndex = 19;
            this.txtSpec.Text = "==Spec==";
            this.txtSpec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(502, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Spec";
            // 
            // cbStatus
            // 
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(675, 320);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(205, 28);
            this.cbStatus.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(502, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Tình trạng";
            // 
            // loai_TS_cap1TableAdapter
            // 
            this.loai_TS_cap1TableAdapter.ClearBeforeFill = true;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByToolStripButton});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(1284, 25);
            this.fillByToolStrip.TabIndex = 23;
            this.fillByToolStrip.Text = "fillByToolStrip";
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(39, 22);
            this.fillByToolStripButton.Text = "FillBy";
            this.fillByToolStripButton.Click += new System.EventHandler(this.fillByToolStripButton_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(17, 157);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 49);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Sửa Dữ Liệu";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(17, 233);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(128, 49);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Xóa Dữ Liệu";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(90, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Số Biên Bản";
            // 
            // txtSoBB
            // 
            this.txtSoBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoBB.Location = new System.Drawing.Point(218, 12);
            this.txtSoBB.Multiline = true;
            this.txtSoBB.Name = "txtSoBB";
            this.txtSoBB.Size = new System.Drawing.Size(196, 30);
            this.txtSoBB.TabIndex = 27;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(17, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 49);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Lưu Dữ Liệu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewBBNo
            // 
            this.btnNewBBNo.Location = new System.Drawing.Point(438, 12);
            this.btnNewBBNo.Name = "btnNewBBNo";
            this.btnNewBBNo.Size = new System.Drawing.Size(82, 39);
            this.btnNewBBNo.TabIndex = 29;
            this.btnNewBBNo.Text = "Số Biên Bản Mới";
            this.btnNewBBNo.UseVisualStyleBackColor = true;
            this.btnNewBBNo.Click += new System.EventHandler(this.btnNewBBNo_Click);
            // 
            // btnNewAssetID
            // 
            this.btnNewAssetID.Location = new System.Drawing.Point(363, 91);
            this.btnNewAssetID.Name = "btnNewAssetID";
            this.btnNewAssetID.Size = new System.Drawing.Size(60, 40);
            this.btnNewAssetID.TabIndex = 30;
            this.btnNewAssetID.Text = "Mã Tài Sản Mới";
            this.btnNewAssetID.UseVisualStyleBackColor = true;
            this.btnNewAssetID.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button3.Location = new System.Drawing.Point(17, 312);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 49);
            this.button3.TabIndex = 31;
            this.button3.Text = "Trở Về";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlInfo.Controls.Add(this.lblSoBB);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Controls.Add(this.txtMaTS);
            this.pnlInfo.Controls.Add(this.btnNewAssetID);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.txtTenTS);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.txtSN);
            this.pnlInfo.Controls.Add(this.label7);
            this.pnlInfo.Controls.Add(this.txtITTag);
            this.pnlInfo.Controls.Add(this.cbStatus);
            this.pnlInfo.Controls.Add(this.label10);
            this.pnlInfo.Controls.Add(this.label6);
            this.pnlInfo.Controls.Add(this.txtFATag);
            this.pnlInfo.Controls.Add(this.cbTypeLV1);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.cbTypeLV2);
            this.pnlInfo.Controls.Add(this.txtSpec);
            this.pnlInfo.Controls.Add(this.label9);
            this.pnlInfo.Controls.Add(this.label8);
            this.pnlInfo.Controls.Add(this.txtModel);
            this.pnlInfo.Location = new System.Drawing.Point(253, 72);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(933, 385);
            this.pnlInfo.TabIndex = 32;
            // 
            // lblSoBB
            // 
            this.lblSoBB.AutoSize = true;
            this.lblSoBB.BackColor = System.Drawing.Color.Yellow;
            this.lblSoBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoBB.ForeColor = System.Drawing.Color.Crimson;
            this.lblSoBB.Location = new System.Drawing.Point(153, 31);
            this.lblSoBB.Name = "lblSoBB";
            this.lblSoBB.Size = new System.Drawing.Size(157, 29);
            this.lblSoBB.TabIndex = 31;
            this.lblSoBB.Text = "Số Biên Bản";
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.Ivory;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlControl.Controls.Add(this.btnAddNew);
            this.pnlControl.Controls.Add(this.btnSave);
            this.pnlControl.Controls.Add(this.button3);
            this.pnlControl.Controls.Add(this.btnUpdate);
            this.pnlControl.Controls.Add(this.btnDelete);
            this.pnlControl.Location = new System.Drawing.Point(75, 72);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(160, 385);
            this.pnlControl.TabIndex = 33;
            // 
            // btnCloseBB
            // 
            this.btnCloseBB.Location = new System.Drawing.Point(551, 12);
            this.btnCloseBB.Name = "btnCloseBB";
            this.btnCloseBB.Size = new System.Drawing.Size(82, 39);
            this.btnCloseBB.TabIndex = 34;
            this.btnCloseBB.Text = "Đóng Biên Bản";
            this.btnCloseBB.UseVisualStyleBackColor = true;
            this.btnCloseBB.Click += new System.EventHandler(this.btnCloseBB_Click);
            // 
            // AddNewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.btnCloseBB);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnNewBBNo);
            this.Controls.Add(this.txtSoBB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewItem";
            this.Text = "AddNewItem";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiTScap1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTSDataSet)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox txtMaTS;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbTypeLV1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenTS;
        private System.Windows.Forms.ComboBox cbTypeLV2;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.TextBox txtITTag;
        private System.Windows.Forms.TextBox txtFATag;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label10;
        private QLTSDataSet qLTSDataSet;
        private System.Windows.Forms.BindingSource loaiTScap1BindingSource;
        private QLTSDataSetTableAdapters.Loai_TS_cap1TableAdapter loai_TS_cap1TableAdapter;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSoBB;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewBBNo;
        private System.Windows.Forms.Button btnNewAssetID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnCloseBB;
        private System.Windows.Forms.Label lblSoBB;
    }
}