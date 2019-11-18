namespace QLTS_LG
{
    partial class Revoke_Requirement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Revoke_Requirement));
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcelUser = new System.Windows.Forms.Button();
            this.btnExcelDevice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUser
            // 
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(12, 89);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.Size = new System.Drawing.Size(1121, 179);
            this.dgvUser.TabIndex = 0;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellClick);
            // 
            // dgvDevice
            // 
            this.dgvDevice.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevice.Location = new System.Drawing.Point(12, 309);
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.Size = new System.Drawing.Size(1121, 269);
            this.dgvDevice.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1058, 591);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhân Sự Đã Nghỉ Việc Nhưng Chưa Bàn Giao Tài Sản";
            // 
            // btnExcelUser
            // 
            this.btnExcelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelUser.ForeColor = System.Drawing.Color.Green;
            this.btnExcelUser.Location = new System.Drawing.Point(1058, 60);
            this.btnExcelUser.Name = "btnExcelUser";
            this.btnExcelUser.Size = new System.Drawing.Size(75, 23);
            this.btnExcelUser.TabIndex = 4;
            this.btnExcelUser.Text = "Excel";
            this.btnExcelUser.UseVisualStyleBackColor = true;
            this.btnExcelUser.Click += new System.EventHandler(this.btnExcelUser_Click);
            // 
            // btnExcelDevice
            // 
            this.btnExcelDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelDevice.ForeColor = System.Drawing.Color.Green;
            this.btnExcelDevice.Location = new System.Drawing.Point(1058, 280);
            this.btnExcelDevice.Name = "btnExcelDevice";
            this.btnExcelDevice.Size = new System.Drawing.Size(75, 23);
            this.btnExcelDevice.TabIndex = 5;
            this.btnExcelDevice.Text = "Excel";
            this.btnExcelDevice.UseVisualStyleBackColor = true;
            this.btnExcelDevice.Click += new System.EventHandler(this.btnExcelDevice_Click);
            // 
            // Revoke_Requirement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1145, 626);
            this.Controls.Add(this.btnExcelDevice);
            this.Controls.Add(this.btnExcelUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvDevice);
            this.Controls.Add(this.dgvUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Revoke_Requirement";
            this.Text = "Revoke_Requirement";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcelUser;
        private System.Windows.Forms.Button btnExcelDevice;
    }
}