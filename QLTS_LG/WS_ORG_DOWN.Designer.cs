namespace QLTS_LG
{
    partial class WS_ORG_DOWN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WS_ORG_DOWN));
            this.dgvHR = new System.Windows.Forms.DataGridView();
            this.dgvQLTS = new System.Windows.Forms.DataGridView();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnDrawBack = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHR
            // 
            this.dgvHR.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvHR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHR.Location = new System.Drawing.Point(41, 25);
            this.dgvHR.Name = "dgvHR";
            this.dgvHR.Size = new System.Drawing.Size(478, 463);
            this.dgvHR.TabIndex = 0;
            // 
            // dgvQLTS
            // 
            this.dgvQLTS.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvQLTS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLTS.Location = new System.Drawing.Point(606, 25);
            this.dgvQLTS.Name = "dgvQLTS";
            this.dgvQLTS.Size = new System.Drawing.Size(478, 463);
            this.dgvQLTS.TabIndex = 1;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(525, 200);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 36);
            this.btnTransfer.TabIndex = 2;
            this.btnTransfer.Text = ">>";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnDrawBack
            // 
            this.btnDrawBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrawBack.Location = new System.Drawing.Point(525, 253);
            this.btnDrawBack.Name = "btnDrawBack";
            this.btnDrawBack.Size = new System.Drawing.Size(75, 36);
            this.btnDrawBack.TabIndex = 3;
            this.btnDrawBack.Text = "<<";
            this.btnDrawBack.UseVisualStyleBackColor = true;
            this.btnDrawBack.Click += new System.EventHandler(this.btnDrawBack_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(363, 508);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 36);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(444, 508);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 36);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(657, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "ORGANIZATION DATA";
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Crimson;
            this.btnImport.Location = new System.Drawing.Point(525, 311);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 36);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // WS_ORG_DOWN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1125, 596);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDrawBack);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.dgvQLTS);
            this.Controls.Add(this.dgvHR);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WS_ORG_DOWN";
            this.Text = "WS_ORG";
            this.Load += new System.EventHandler(this.WS_ORG_DOWN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHR;
        private System.Windows.Forms.DataGridView dgvQLTS;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnDrawBack;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
    }
}