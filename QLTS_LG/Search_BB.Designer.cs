﻿namespace QLTS_LG
{
    partial class Search_BB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search_BB));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoBB = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbLoaiBB = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.EP_download = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnPrintOnline = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(680, 424);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitle.Location = new System.Drawing.Point(127, 44);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(49, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(182, 250);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(263, 250);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số Biên Bản";
            // 
            // txtSoBB
            // 
            this.txtSoBB.Location = new System.Drawing.Point(54, 45);
            this.txtSoBB.Name = "txtSoBB";
            this.txtSoBB.Size = new System.Drawing.Size(209, 20);
            this.txtSoBB.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(54, 87);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(209, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(54, 129);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(209, 20);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbLoaiBB);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoBB);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 241);
            this.panel1.TabIndex = 9;
            // 
            // cbLoaiBB
            // 
            this.cbLoaiBB.FormattingEnabled = true;
            this.cbLoaiBB.Location = new System.Drawing.Point(54, 167);
            this.cbLoaiBB.Name = "cbLoaiBB";
            this.cbLoaiBB.Size = new System.Drawing.Size(209, 21);
            this.cbLoaiBB.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(73, 107);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnPrintOnline);
            this.splitContainer1.Panel1.Controls.Add(this.EP_download);
            this.splitContainer1.Panel1.Controls.Add(this.btnReport);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.btnBack);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1035, 427);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 10;
            // 
            // EP_download
            // 
            this.EP_download.Location = new System.Drawing.Point(101, 333);
            this.EP_download.Name = "EP_download";
            this.EP_download.Size = new System.Drawing.Size(167, 23);
            this.EP_download.TabIndex = 11;
            this.EP_download.Text = "Download EP Approved";
            this.EP_download.UseVisualStyleBackColor = true;
            this.EP_download.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(101, 250);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "Report Print";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnPrintOnline
            // 
            this.btnPrintOnline.ForeColor = System.Drawing.Color.Brown;
            this.btnPrintOnline.Location = new System.Drawing.Point(101, 291);
            this.btnPrintOnline.Name = "btnPrintOnline";
            this.btnPrintOnline.Size = new System.Drawing.Size(167, 23);
            this.btnPrintOnline.TabIndex = 12;
            this.btnPrintOnline.Text = "Report Print Online";
            this.btnPrintOnline.UseVisualStyleBackColor = true;
            this.btnPrintOnline.Click += new System.EventHandler(this.btnPrintOnline_Click);
            // 
            // Search_BB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 591);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search_BB";
            this.Text = "Search_BB";
            this.Load += new System.EventHandler(this.Search_BB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoBB;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbLoaiBB;
        private System.Windows.Forms.Button EP_download;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnPrintOnline;
    }
}