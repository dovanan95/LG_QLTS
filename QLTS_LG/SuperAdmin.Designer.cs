namespace QLTS_LG
{
    partial class SuperAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdmin));
            this.btnQuerry = new System.Windows.Forms.Button();
            this.txtQuerry = new System.Windows.Forms.TextBox();
            this.dgvQuerry = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuerry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuerry
            // 
            this.btnQuerry.Location = new System.Drawing.Point(941, 164);
            this.btnQuerry.Name = "btnQuerry";
            this.btnQuerry.Size = new System.Drawing.Size(75, 23);
            this.btnQuerry.TabIndex = 0;
            this.btnQuerry.Text = "Querry";
            this.btnQuerry.UseVisualStyleBackColor = true;
            this.btnQuerry.Click += new System.EventHandler(this.btnQuerry_Click);
            // 
            // txtQuerry
            // 
            this.txtQuerry.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtQuerry.Location = new System.Drawing.Point(34, 44);
            this.txtQuerry.Multiline = true;
            this.txtQuerry.Name = "txtQuerry";
            this.txtQuerry.Size = new System.Drawing.Size(1116, 112);
            this.txtQuerry.TabIndex = 1;
            this.txtQuerry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuerry_KeyDown);
            // 
            // dgvQuerry
            // 
            this.dgvQuerry.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvQuerry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuerry.Location = new System.Drawing.Point(34, 235);
            this.dgvQuerry.Name = "dgvQuerry";
            this.dgvQuerry.Size = new System.Drawing.Size(1116, 333);
            this.dgvQuerry.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(941, 193);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.ForeColor = System.Drawing.Color.Crimson;
            this.btnExecute.Location = new System.Drawing.Point(860, 164);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute !";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(860, 193);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLTS_LG.Properties.Resources.flag_wave_250;
            this.pictureBox1.Location = new System.Drawing.Point(1022, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // SuperAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::QLTS_LG.Properties.Resources.IT_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 593);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnQuerry);
            this.Controls.Add(this.dgvQuerry);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtQuerry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuperAdmin";
            this.Text = "SuperAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuerry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuerry;
        private System.Windows.Forms.TextBox txtQuerry;
        private System.Windows.Forms.DataGridView dgvQuerry;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}