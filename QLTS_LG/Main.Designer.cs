namespace QLTS_LG
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCauHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOutStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBBBG = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddNewBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInStorageBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOutStorageBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLendingBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRepairBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisposeBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJob = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReCall = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDistribute = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLending = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDispose = new System.Windows.Forms.ToolStripMenuItem();
            this.chỉnhSửaDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phânLoạiTàiSảnCấp1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phânLoạiTàiSảnCấp2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phânLoạiBiênBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIntro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContact = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCauHinh,
            this.menuSearch,
            this.menuJob,
            this.chỉnhSửaDữLiệuToolStripMenuItem,
            this.menuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1330, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuCauHinh
            // 
            this.menuCauHinh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogin,
            this.menuAddUser,
            this.menuChangePass,
            this.menuPermission,
            this.menuLogOut,
            this.ExitToolStripMenuItem});
            this.menuCauHinh.Name = "menuCauHinh";
            this.menuCauHinh.Size = new System.Drawing.Size(150, 25);
            this.menuCauHinh.Text = "Cấu hình hệ thống";
            this.menuCauHinh.Click += new System.EventHandler(this.addNewMenu_Click);
            // 
            // menuLogin
            // 
            this.menuLogin.Name = "menuLogin";
            this.menuLogin.Size = new System.Drawing.Size(205, 26);
            this.menuLogin.Text = "Chuyển Tài Khoản";
            // 
            // menuAddUser
            // 
            this.menuAddUser.Name = "menuAddUser";
            this.menuAddUser.Size = new System.Drawing.Size(205, 26);
            this.menuAddUser.Text = "Đăng ký User";
            // 
            // menuChangePass
            // 
            this.menuChangePass.Name = "menuChangePass";
            this.menuChangePass.Size = new System.Drawing.Size(205, 26);
            this.menuChangePass.Text = "Đổi Mật Khẩu";
            this.menuChangePass.Click += new System.EventHandler(this.menuChangePass_Click);
            // 
            // menuPermission
            // 
            this.menuPermission.Name = "menuPermission";
            this.menuPermission.Size = new System.Drawing.Size(205, 26);
            this.menuPermission.Text = "Phân Quyền (*)";
            // 
            // menuLogOut
            // 
            this.menuLogOut.Name = "menuLogOut";
            this.menuLogOut.Size = new System.Drawing.Size(205, 26);
            this.menuLogOut.Text = "Đăng Xuất";
            this.menuLogOut.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.ExitToolStripMenuItem.Text = "Thoát";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // menuSearch
            // 
            this.menuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTS,
            this.menuBBBG,
            this.menuUser,
            this.menuHist});
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.Size = new System.Drawing.Size(76, 25);
            this.menuSearch.Text = "Tra Cứu";
            // 
            // menuTS
            // 
            this.menuTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInStorage,
            this.menuOutStorage});
            this.menuTS.Name = "menuTS";
            this.menuTS.Size = new System.Drawing.Size(317, 26);
            this.menuTS.Text = "Danh Mục Tài Sản";
            // 
            // menuInStorage
            // 
            this.menuInStorage.Name = "menuInStorage";
            this.menuInStorage.Size = new System.Drawing.Size(153, 26);
            this.menuInStorage.Text = "Lưu Kho";
            this.menuInStorage.Click += new System.EventHandler(this.menuInStorage_Click);
            // 
            // menuOutStorage
            // 
            this.menuOutStorage.Name = "menuOutStorage";
            this.menuOutStorage.Size = new System.Drawing.Size(153, 26);
            this.menuOutStorage.Text = "Ngoại Kho";
            this.menuOutStorage.Click += new System.EventHandler(this.menuOutStorage_Click);
            // 
            // menuBBBG
            // 
            this.menuBBBG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddNewBB,
            this.menuInStorageBB,
            this.menuOutStorageBB,
            this.menuLendingBB,
            this.menuRepairBB,
            this.menuDisposeBB});
            this.menuBBBG.Name = "menuBBBG";
            this.menuBBBG.Size = new System.Drawing.Size(317, 26);
            this.menuBBBG.Text = "Danh Mục Biên Bản";
            // 
            // menuAddNewBB
            // 
            this.menuAddNewBB.Name = "menuAddNewBB";
            this.menuAddNewBB.Size = new System.Drawing.Size(162, 26);
            this.menuAddNewBB.Text = "Nhâp Mới";
            this.menuAddNewBB.Click += new System.EventHandler(this.nhâpMớiToolStripMenuItem_Click);
            // 
            // menuInStorageBB
            // 
            this.menuInStorageBB.Name = "menuInStorageBB";
            this.menuInStorageBB.Size = new System.Drawing.Size(162, 26);
            this.menuInStorageBB.Text = "Nhập Kho";
            this.menuInStorageBB.Click += new System.EventHandler(this.menuInStorageBB_Click);
            // 
            // menuOutStorageBB
            // 
            this.menuOutStorageBB.Name = "menuOutStorageBB";
            this.menuOutStorageBB.Size = new System.Drawing.Size(162, 26);
            this.menuOutStorageBB.Text = "Xuất Kho";
            this.menuOutStorageBB.Click += new System.EventHandler(this.menuOutStorageBB_Click);
            // 
            // menuLendingBB
            // 
            this.menuLendingBB.Name = "menuLendingBB";
            this.menuLendingBB.Size = new System.Drawing.Size(162, 26);
            this.menuLendingBB.Text = "Cho Mượn";
            this.menuLendingBB.Click += new System.EventHandler(this.menuLendingBB_Click);
            // 
            // menuRepairBB
            // 
            this.menuRepairBB.Name = "menuRepairBB";
            this.menuRepairBB.Size = new System.Drawing.Size(162, 26);
            this.menuRepairBB.Text = "Sửa Chữa";
            this.menuRepairBB.Click += new System.EventHandler(this.menuRepairBB_Click);
            // 
            // menuDisposeBB
            // 
            this.menuDisposeBB.Name = "menuDisposeBB";
            this.menuDisposeBB.Size = new System.Drawing.Size(162, 26);
            this.menuDisposeBB.Text = "Hủy Tài Sản";
            this.menuDisposeBB.Click += new System.EventHandler(this.menuDisposeBB_Click);
            // 
            // menuUser
            // 
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(317, 26);
            this.menuUser.Text = "Danh Mục Người Sử Dụng Tài Sản";
            // 
            // menuHist
            // 
            this.menuHist.Name = "menuHist";
            this.menuHist.Size = new System.Drawing.Size(317, 26);
            this.menuHist.Text = "Lịch Sử Giao Dịch";
            this.menuHist.Click += new System.EventHandler(this.menuHist_Click);
            // 
            // menuJob
            // 
            this.menuJob.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddNew,
            this.menuReCall,
            this.menuDistribute,
            this.menuLending,
            this.MenuRepair,
            this.menuDispose});
            this.menuJob.Name = "menuJob";
            this.menuJob.Size = new System.Drawing.Size(96, 25);
            this.menuJob.Text = "Nghiệp Vụ";
            // 
            // menuAddNew
            // 
            this.menuAddNew.Name = "menuAddNew";
            this.menuAddNew.Size = new System.Drawing.Size(180, 26);
            this.menuAddNew.Text = "Nhập Mới";
            this.menuAddNew.Click += new System.EventHandler(this.menuAddNew_Click);
            // 
            // menuReCall
            // 
            this.menuReCall.Name = "menuReCall";
            this.menuReCall.Size = new System.Drawing.Size(180, 26);
            this.menuReCall.Text = "Thu Hồi";
            this.menuReCall.Click += new System.EventHandler(this.menuReCall_Click);
            // 
            // menuDistribute
            // 
            this.menuDistribute.Name = "menuDistribute";
            this.menuDistribute.Size = new System.Drawing.Size(180, 26);
            this.menuDistribute.Text = "Cấp Phát";
            // 
            // menuLending
            // 
            this.menuLending.Name = "menuLending";
            this.menuLending.Size = new System.Drawing.Size(180, 26);
            this.menuLending.Text = "Cho Mượn";
            // 
            // MenuRepair
            // 
            this.MenuRepair.Name = "MenuRepair";
            this.MenuRepair.Size = new System.Drawing.Size(180, 26);
            this.MenuRepair.Text = "Sửa chữa";
            // 
            // menuDispose
            // 
            this.menuDispose.Name = "menuDispose";
            this.menuDispose.Size = new System.Drawing.Size(180, 26);
            this.menuDispose.Text = "Tiêu Hủy";
            // 
            // chỉnhSửaDữLiệuToolStripMenuItem
            // 
            this.chỉnhSửaDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phânLoạiTàiSảnCấp1ToolStripMenuItem,
            this.phânLoạiTàiSảnCấp2ToolStripMenuItem,
            this.phânLoạiBiênBảnToolStripMenuItem});
            this.chỉnhSửaDữLiệuToolStripMenuItem.Name = "chỉnhSửaDữLiệuToolStripMenuItem";
            this.chỉnhSửaDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(150, 25);
            this.chỉnhSửaDữLiệuToolStripMenuItem.Text = "Chỉnh Sửa Dữ Liệu";
            // 
            // phânLoạiTàiSảnCấp1ToolStripMenuItem
            // 
            this.phânLoạiTàiSảnCấp1ToolStripMenuItem.Name = "phânLoạiTàiSảnCấp1ToolStripMenuItem";
            this.phânLoạiTàiSảnCấp1ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.phânLoạiTàiSảnCấp1ToolStripMenuItem.Text = "Phân Loại Tài Sản Cấp 1";
            // 
            // phânLoạiTàiSảnCấp2ToolStripMenuItem
            // 
            this.phânLoạiTàiSảnCấp2ToolStripMenuItem.Name = "phânLoạiTàiSảnCấp2ToolStripMenuItem";
            this.phânLoạiTàiSảnCấp2ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.phânLoạiTàiSảnCấp2ToolStripMenuItem.Text = "Phân Loại Tài Sản Cấp 2";
            // 
            // phânLoạiBiênBảnToolStripMenuItem
            // 
            this.phânLoạiBiênBảnToolStripMenuItem.Name = "phânLoạiBiênBảnToolStripMenuItem";
            this.phânLoạiBiênBảnToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.phânLoạiBiênBảnToolStripMenuItem.Text = "Phân Loại Biên Bản";
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIntro,
            this.menuContact});
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(64, 25);
            this.menuAbout.Text = "About";
            // 
            // menuIntro
            // 
            this.menuIntro.Name = "menuIntro";
            this.menuIntro.Size = new System.Drawing.Size(151, 26);
            this.menuIntro.Text = "Giới Thiệu";
            // 
            // menuContact
            // 
            this.menuContact.Name = "menuContact";
            this.menuContact.Size = new System.Drawing.Size(151, 26);
            this.menuContact.Text = "Liên Hệ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 545);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCauHinh;
        private System.Windows.Forms.ToolStripMenuItem menuSearch;
        private System.Windows.Forms.ToolStripMenuItem menuLogin;
        private System.Windows.Forms.ToolStripMenuItem menuAddUser;
        private System.Windows.Forms.ToolStripMenuItem menuChangePass;
        private System.Windows.Forms.ToolStripMenuItem menuLogOut;
        private System.Windows.Forms.ToolStripMenuItem menuPermission;
        private System.Windows.Forms.ToolStripMenuItem menuTS;
        private System.Windows.Forms.ToolStripMenuItem menuInStorage;
        private System.Windows.Forms.ToolStripMenuItem menuOutStorage;
        private System.Windows.Forms.ToolStripMenuItem menuBBBG;
        private System.Windows.Forms.ToolStripMenuItem menuUser;
        private System.Windows.Forms.ToolStripMenuItem menuJob;
        private System.Windows.Forms.ToolStripMenuItem menuAddNew;
        private System.Windows.Forms.ToolStripMenuItem menuReCall;
        private System.Windows.Forms.ToolStripMenuItem menuDistribute;
        private System.Windows.Forms.ToolStripMenuItem menuLending;
        private System.Windows.Forms.ToolStripMenuItem MenuRepair;
        private System.Windows.Forms.ToolStripMenuItem menuDispose;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuIntro;
        private System.Windows.Forms.ToolStripMenuItem menuContact;
        private System.Windows.Forms.ToolStripMenuItem menuHist;
        private System.Windows.Forms.ToolStripMenuItem menuAddNewBB;
        private System.Windows.Forms.ToolStripMenuItem menuInStorageBB;
        private System.Windows.Forms.ToolStripMenuItem menuOutStorageBB;
        private System.Windows.Forms.ToolStripMenuItem menuLendingBB;
        private System.Windows.Forms.ToolStripMenuItem menuRepairBB;
        private System.Windows.Forms.ToolStripMenuItem menuDisposeBB;
        private System.Windows.Forms.ToolStripMenuItem chỉnhSửaDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phânLoạiTàiSảnCấp1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phânLoạiTàiSảnCấp2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phânLoạiBiênBảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}