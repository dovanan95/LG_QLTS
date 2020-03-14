namespace QLTS_LG
{
    partial class Repair_itemAdding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repair_itemAdding));
            this.lblRepairItemID = new System.Windows.Forms.Label();
            this.dgvAddingItem = new System.Windows.Forms.DataGridView();
            this.dgvAddingSelected = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnDeleteAddedItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddingItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddingSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRepairItemID
            // 
            this.lblRepairItemID.AutoSize = true;
            this.lblRepairItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepairItemID.ForeColor = System.Drawing.Color.Red;
            this.lblRepairItemID.Location = new System.Drawing.Point(151, 40);
            this.lblRepairItemID.Name = "lblRepairItemID";
            this.lblRepairItemID.Size = new System.Drawing.Size(28, 24);
            this.lblRepairItemID.TabIndex = 0;
            this.lblRepairItemID.Text = "...";
            // 
            // dgvAddingItem
            // 
            this.dgvAddingItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddingItem.Location = new System.Drawing.Point(24, 100);
            this.dgvAddingItem.Name = "dgvAddingItem";
            this.dgvAddingItem.Size = new System.Drawing.Size(637, 173);
            this.dgvAddingItem.TabIndex = 1;
            // 
            // dgvAddingSelected
            // 
            this.dgvAddingSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddingSelected.Location = new System.Drawing.Point(24, 339);
            this.dgvAddingSelected.Name = "dgvAddingSelected";
            this.dgvAddingSelected.Size = new System.Drawing.Size(637, 164);
            this.dgvAddingSelected.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(586, 523);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(24, 294);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 4;
            this.btnTransfer.Text = ">>";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(586, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã Tài Sản:";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(498, 523);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnDeleteAddedItem
            // 
            this.btnDeleteAddedItem.Location = new System.Drawing.Point(586, 294);
            this.btnDeleteAddedItem.Name = "btnDeleteAddedItem";
            this.btnDeleteAddedItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAddedItem.TabIndex = 8;
            this.btnDeleteAddedItem.Text = "Delete";
            this.btnDeleteAddedItem.UseVisualStyleBackColor = true;
            this.btnDeleteAddedItem.Click += new System.EventHandler(this.btnDeleteAddedItem_Click);
            // 
            // Repair_itemAdding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 584);
            this.Controls.Add(this.btnDeleteAddedItem);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvAddingSelected);
            this.Controls.Add(this.dgvAddingItem);
            this.Controls.Add(this.lblRepairItemID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Repair_itemAdding";
            this.Text = "Vật Tư Bổ Sung";
            this.Load += new System.EventHandler(this.Repair_itemAdding_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddingItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddingSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRepairItemID;
        private System.Windows.Forms.DataGridView dgvAddingItem;
        private System.Windows.Forms.DataGridView dgvAddingSelected;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnDeleteAddedItem;
    }
}