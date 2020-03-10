using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class Main : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleConnection con2 = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();
        DataTable dtLoadOverDue = new DataTable();
        AutoComplete auto = new AutoComplete();
        Permission per = new Permission();
        AutoTask AutoTask = new AutoTask();
        AntiDuplicated AntiDuplicated = new AntiDuplicated();
        WS_ORG.QLTS_ORG ITS_ORG = new WS_ORG.QLTS_ORG();

        public string username1 { get; set; }

        public Main()
        {
            InitializeComponent();

        }


        public void CheckNotification()
        {
            //int Number = dgvOverDue.Rows.Count;
            int Number = dtLoadOverDue.Rows.Count;
            if (Number == 1)
            {
                lblExpired.Text = "There is one device need to be returned to storage!!!";
                lblExpired.ForeColor = System.Drawing.Color.Red;

            }
            else if (Number > 1)
            {
                //Number++;
                lblExpired.Text = "There are " + Number.ToString() + " devices need to be returned to storage!!!";
                lblExpired.ForeColor = System.Drawing.Color.Red;
            }
            else if (Number == 0)
            {
                lblExpired.Text = "No devices need to be returned.";
                lblExpired.ForeColor = System.Drawing.Color.Green;
            }
        }
        public void Search_Item(int SoDanhMuc)
        {
            this.Hide();
            string text = SoDanhMuc.ToString();
            Form frm = new Search(text);
            //frm.Text = "Danh Mục";
            frm.ShowDialog();


        }
        public void NSCBGTS_Check()
        {
            DataTable dtCheck = new DataTable();
            dtCheck = AutoTask.LoadFromNSCBGTS();
            if (dtCheck.Rows.Count != 0)
            {
                menuRevokeRequirement.ForeColor = System.Drawing.Color.Yellow;
                menuRevokeRequirement.BackColor = System.Drawing.Color.Red;
            }
            else if (dtCheck.Rows.Count == 0)
            {
                menuRevokeRequirement.BackColor = System.Drawing.Color.Green;
                menuRevokeRequirement.ForeColor = System.Drawing.Color.White;
            }
        }

        public void CheckOverDue()
        {
            string strAutoCheck = "UPDATE Muon_vat_tu SET Qua_han =  1 WHERE Due_date < CURRENT_DATE AND Due_date IS NOT NULL";
            OracleCommand cmdAutoCheck = new OracleCommand();
            cmdAutoCheck.Connection = con;
            cmdAutoCheck.CommandType = CommandType.Text;
            cmdAutoCheck.CommandText = strAutoCheck;
            con.Open();
            cmdAutoCheck.ExecuteNonQuery();
            con.Close();
        }
        public void OutStorageLoad()
        {

            //ITS_ORG.CheckResignation();

            NSCBGTS_Check();

            string strOut = "SELECT f.So_Bien_Ban, a.Ma_TS, b.Ten_TS, b.IT_Tag, b.SN, b.FA_Tag, b.Model, c.Ten_loai, d.UNIT_NAME, e.TEN_TINH_TRANG, f.USER_ID, f.CL_DATE " +
                "FROM Xuat_Kho a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Loai_TS_cap2 c on b.Ma_loai_TS_cap2 = c.Ma_loai " +
                "inner join UNIT d on b.UNIT = d.UNIT_ID " +
                "inner join STATUS e on b.MA_TINH_TRANG = e.MA_TINH_TRANG " +
                "inner join BIEN_BAN f on a.So_BB_Xuat = f.So_Bien_Ban " +
                "WHERE a.Approved = 0";
            OracleCommand cmdOut = new OracleCommand();
            cmdOut.Connection = con;
            cmdOut.CommandType = CommandType.Text;
            cmdOut.CommandText = strOut;
            OracleDataAdapter daOut = new OracleDataAdapter(cmdOut);
            DataTable dtOut = new DataTable();
            daOut.Fill(dtOut);
            dataGridView1.DataSource = dtOut;

            string strRepair = "SELECT f.So_Bien_Ban, a.Ma_TS, b.Ten_TS, b.IT_Tag, b.SN, b.FA_Tag, b.Model, c.Ten_loai, d.UNIT_NAME, e.TEN_TINH_TRANG, a.Vat_tu_xuat, f.USER_ID, f.CL_DATE " +
                "FROM Sua_chua a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Loai_TS_cap2 c on b.Ma_loai_TS_cap2 = c.Ma_loai " +
                "inner join UNIT d on b.UNIT = d.UNIT_ID " +
                "inner join STATUS e on b.MA_TINH_TRANG = e.MA_TINH_TRANG " +
                "inner join BIEN_BAN f on a.BB_Sua = f.So_Bien_Ban " +
                "WHERE a.Approved = 0";
            OracleCommand cmdRepair = new OracleCommand();
            cmdRepair.Connection = con;
            cmdRepair.CommandType = CommandType.Text;
            cmdRepair.CommandText = strRepair;
            OracleDataAdapter daRepair = new OracleDataAdapter(cmdRepair);
            DataTable dtRepair = new DataTable();
            daRepair.Fill(dtRepair);
            dataGridView2.DataSource = dtRepair;

            string strBorrow = "SELECT f.So_Bien_Ban, a.Ma_TS, b.Ten_TS, b.IT_Tag, b.SN, b.FA_Tag, b.Model, c.Ten_loai, d.UNIT_NAME, e.TEN_TINH_TRANG, f.USER_ID, f.CL_DATE, a.due_date, g.BORROW_TYPE " +
                "FROM Muon_vat_tu a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Loai_TS_cap2 c on b.Ma_loai_TS_cap2 = c.Ma_loai " +
                "inner join UNIT d on b.UNIT = d.UNIT_ID " +
                "inner join STATUS e on b.MA_TINH_TRANG = e.MA_TINH_TRANG " +
                "inner join BIEN_BAN f on a.So_BB = f.So_Bien_Ban " +
                "inner join BORROW_STYLE g on a.BORROW_CODE = g.BORROW_CODE " +
                "WHERE a.Approved = 0";
            OracleCommand cmdBorrow = new OracleCommand();
            cmdBorrow.Connection = con;
            cmdBorrow.CommandType = CommandType.Text;
            cmdBorrow.CommandText = strBorrow;
            OracleDataAdapter daBorrow = new OracleDataAdapter(cmdBorrow);
            DataTable dtBorrow = new DataTable();
            daBorrow.Fill(dtBorrow);
            dataGridView3.DataSource = dtBorrow;

            string strNew = "SELECT f.So_Bien_Ban, a.Ma_TS, b.Ten_TS, b.IT_Tag, b.SN, b.FA_Tag, b.Model, c.Ten_loai, d.UNIT_NAME, e.TEN_TINH_TRANG, f.USER_ID, f.CL_DATE " +
                "FROM Nhap_Moi a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Loai_TS_cap2 c on b.Ma_loai_TS_cap2 = c.Ma_loai " +
                "inner join UNIT d on b.UNIT = d.UNIT_ID " +
                "inner join STATUS e on b.MA_TINH_TRANG = e.MA_TINH_TRANG " +
                "inner join BIEN_BAN f on a.So_BB = f.So_Bien_Ban " +
                "WHERE a.Approved = 0";
            OracleCommand cmdNew = new OracleCommand();
            cmdNew.Connection = con;
            cmdNew.CommandType = CommandType.Text;
            cmdNew.CommandText = strNew;
            OracleDataAdapter daNew = new OracleDataAdapter(cmdNew);
            DataTable dtNew = new DataTable();
            daNew.Fill(dtNew);
            dgvNew.DataSource = dtNew;

            string strRevoke = "SELECT f.So_Bien_Ban, a.Ma_TS, b.Ten_TS, b.IT_Tag, b.SN, b.FA_Tag, b.Model, c.Ten_loai, d.UNIT_NAME, e.TEN_TINH_TRANG, f.USER_ID, f.CL_DATE " +
                "FROM Nhan_tra_TS a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Loai_TS_cap2 c on b.Ma_loai_TS_cap2 = c.Ma_loai " +
                "inner join UNIT d on b.UNIT = d.UNIT_ID " +
                "inner join STATUS e on b.MA_TINH_TRANG = e.MA_TINH_TRANG " +
                "inner join BIEN_BAN f on a.So_BB_nhan = f.So_Bien_Ban " +
                "WHERE a.Approved = 0";
            OracleCommand cmdRevoke = new OracleCommand();
            cmdRevoke.Connection = con;
            cmdRevoke.CommandType = CommandType.Text;
            cmdRevoke.CommandText = strRevoke;
            OracleDataAdapter daRevoke = new OracleDataAdapter(cmdRevoke);
            DataTable dtRevoke = new DataTable();
            daRevoke.Fill(dtRevoke);
            dgvRevoke.DataSource = dtRevoke;

            string strDispose = "SELECT f.So_Bien_Ban, a.Ma_TS, b.Ten_TS, b.IT_Tag, b.SN, b.FA_Tag, b.Model, c.Ten_loai, d.UNIT_NAME, e.TEN_TINH_TRANG, f.USER_ID, f.CL_DATE " +
                "FROM Huy_TS a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Loai_TS_cap2 c on b.Ma_loai_TS_cap2 = c.Ma_loai " +
                "inner join UNIT d on b.UNIT = d.UNIT_ID " +
                "inner join STATUS e on b.MA_TINH_TRANG = e.MA_TINH_TRANG " +
                "inner join BIEN_BAN f on a.BB_Huy = f.So_Bien_Ban " +
                "WHERE a.Approved = 0";
            OracleCommand cmdDispose = new OracleCommand();
            cmdDispose.Connection = con;
            cmdDispose.CommandType = CommandType.Text;
            cmdDispose.CommandText = strDispose;
            OracleDataAdapter daDispose = new OracleDataAdapter(cmdDispose);
            DataTable dtDispose = new DataTable();
            daDispose.Fill(dtDispose);
            dgvDispose.DataSource = dtDispose;


            CheckOverDue();

            dtLoadOverDue.Clear();
            string strLoadOverDue = "SELECT * FROM Muon_vat_tu WHERE Qua_han = 1 and Ngay_tra_thuc is null and APPROVED = 1";
            OracleDataAdapter daLoadOverDue = new OracleDataAdapter(strLoadOverDue, con);
            //DataTable dtLoadOverDue = new DataTable();
            daLoadOverDue.Fill(dtLoadOverDue);
            dgvOverDue.DataSource = dtLoadOverDue;

            CheckNotification();

            superDataToolStripMenuItem.Visible = false;

            username1 = Login.username;

            if (username1 == "an.do")
            {
                superDataToolStripMenuItem.Visible = true;
            }

            if (per.CheckPermission() == "user")
            {
                panelBorrow.Visible = false;
                panelOut.Visible = false;
                panelRepair.Visible = false;
                menuAddUser.Enabled = false;
                menuDeviceType.Visible = false;
                menuHRM.Visible = false;
                pnlDispose.Visible = false;
                pnlNew.Visible = false;
                pnlRevoke.Visible = false;
                menuDataModify.Visible = false;
            }

            if (per.CheckPermission() == "guest")
            {
                panelBorrow.Visible = false;
                panelOut.Visible = false;
                panelRepair.Visible = false;
                menuAddUser.Visible = false;
                menuDeviceType.Visible = false;
                menuJob.Visible = false;
                menuDataModify.Visible = false;
                pnlRevoke.Visible = false;
                pnlNew.Visible = false;
                pnlDispose.Visible = false;
            }

        }
        public void SearchBB(string DMBB)
        {
            Search_BB _BB = new Search_BB();
            _BB.stNhan = DMBB;
            //_BB.strNhan = DMBB;
            this.Hide();
            _BB.ShowDialog();

        }
        private void Main_Load(object sender, EventArgs e)
        {
            OutStorageLoad();

        }

        private void addNewMenu_Click(object sender, EventArgs e)
        {

        }

        private void menuChangePass_Click(object sender, EventArgs e)
        {
            Change_Password change = new Change_Password();
            //this.Hide();
            change.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Login login = new Login();
                this.Hide();
                login.ShowDialog();
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuInStorage_Click(object sender, EventArgs e)
        {
            this.Close();
            //int SoDanhMuc = 1;
            Search_Item(1);
        }

        private void menuOutStorage_Click(object sender, EventArgs e)
        {
            this.Close();
            //int SoDanhMuc = 2;
            Search_Item(2);
        }

        private void menuAddNew_Click(object sender, EventArgs e)
        {

            AddNewItem frm = new AddNewItem();
            //this.Hide();
            frm.ShowDialog();
            //this.Hide();
        }

        private void nhâpMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBB("1");
        }

        private void menuInStorageBB_Click(object sender, EventArgs e)
        {
            SearchBB("2");
        }

        private void menuOutStorageBB_Click(object sender, EventArgs e)
        {
            SearchBB("3");
        }

        private void menuLendingBB_Click(object sender, EventArgs e)
        {
            SearchBB("4");
        }

        private void menuRepairBB_Click(object sender, EventArgs e)
        {
            SearchBB("5");
        }

        private void menuDisposeBB_Click(object sender, EventArgs e)
        {
            SearchBB("6");
        }

        private void menuHist_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            //this.Hide();
            transaction.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void menuReCall_Click(object sender, EventArgs e)
        {

            Revoke frm = new Revoke();
            //this.Hide();
            frm.ShowDialog();
        }

        private void menuDistribute_Click(object sender, EventArgs e)
        {

            Distribute frm = new Distribute();
            //this.Hide();
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            OutStorageLoad();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            //AutoStickDuplicatedMTS();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnApproveOut_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //string strAssetCode = row.Cells["Ma_TS"].Value.ToString();
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    AutoTask.UpdateApprovedOfBB(row.Cells["So_bien_ban"].Value.ToString());
                    AutoTask.BufferClear(Convert.ToInt32(row.Cells["Ma_TS"].Value));

                    string strUpdate = "UPDATE Xuat_Kho SET Approved = 1 WHERE Ma_TS ='" + row.Cells["Ma_TS"].Value.ToString() + "'";
                    OracleCommand cmdUpdate = new OracleCommand();
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.CommandText = strUpdate;
                    cmdUpdate.Connection = con;
                    con.Open();
                    cmdUpdate.ExecuteNonQuery();
                    con.Close();

                    string strToOut = "INSERT INTO Ngoai_Kho (Ma_TS, ID_User, Latest_Day_Out, So_BB) VALUES (:Ma_TS, :ID_User, CURRENT_DATE, :So_BB)";
                    OracleCommand cmdToOut = new OracleCommand();
                    cmdToOut.Connection = con;
                    cmdToOut.CommandType = CommandType.Text;
                    cmdToOut.CommandText = strToOut;
                    cmdToOut.Parameters.Add(new OracleParameter("Ma_TS", row.Cells["Ma_TS"].Value.ToString()));
                    cmdToOut.Parameters.Add(new OracleParameter("ID_User", row.Cells["USER_ID"].Value.ToString()));
                    cmdToOut.Parameters.Add(new OracleParameter("So_BB", row.Cells["So_Bien_Ban"].Value.ToString()));
                    //cmdToOut.Parameters.Add("@Date", DateTime.Now.ToString());
                    con.Open();
                    cmdToOut.ExecuteNonQuery();
                    con.Close();
                }

            }



            OutStorageLoad();
        }

        private void btnSelectOut_Click(object sender, EventArgs e)
        {

            auto.AutoSelectAll(dataGridView1, "Select");
        }

        private void menuDispose_Click(object sender, EventArgs e)
        {
            //this.Close();
            //this.Hide();
            //this.Close();
            Disposal frm = new Disposal();
            frm.ShowDialog();


        }

        private void MenuRepair_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //this.Close();
            Repair frm = new Repair();
            frm.ShowDialog();
        }

        private void btnApproveRepair_Click(object sender, EventArgs e)
        {
            try
            {
                AutoStickDuplicatedMTS();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectRepair"].Value);
                if (CheckRow)
                {
                    AutoTask.UpdateApprovedOfBB(row.Cells["So_Bien_Ban"].Value.ToString());
                    AutoTask.BufferClear(Convert.ToInt32(row.Cells["Ma_TS"].Value));
                    if(row.Cells["vat_tu_xuat"].Value.ToString() != "")
                    {
                        AutoTask.BufferClear(Convert.ToInt32(row.Cells["vat_tu_xuat"].Value));
                    }
                    else if(row.Cells["vat_tu_xuat"].Value.ToString() == "")
                    {

                    }
                    

                    string strUpdate = "UPDATE Sua_chua SET Approved = 1 WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                    OracleCommand cmdUpdate = new OracleCommand();
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.CommandText = strUpdate;
                    cmdUpdate.Connection = con;
                    con.Open();
                    cmdUpdate.ExecuteNonQuery();
                    con.Close();


                }
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Boolean ChkRow = Convert.ToBoolean(row.Cells["SelectRepair"].Value);


                if (ChkRow == true)
                {
                    string VTX = row.Cells["Vat_tu_xuat"].Value.ToString();
                    if (VTX != "")
                    {
                        string strRepair = "INSERT INTO Ngoai_Kho (Ma_TS, ID_User, Latest_Day_Out, So_BB) VALUES (:Ma_TS, :ID_User, CURRENT_DATE, :SoBB)";
                        OracleCommand cmdRepair = new OracleCommand();
                        cmdRepair.Connection = con;
                        cmdRepair.CommandType = CommandType.Text;
                        cmdRepair.CommandText = strRepair;
                        cmdRepair.Parameters.Add(new OracleParameter("Ma_TS", row.Cells["Vat_tu_xuat"].Value.ToString()));
                        cmdRepair.Parameters.Add(new OracleParameter("ID_User", row.Cells["USER_ID"].Value.ToString()));
                        cmdRepair.Parameters.Add(new OracleParameter("SoBB", row.Cells["So_Bien_Ban"].Value.ToString()));
                        //cmdRepair.Parameters.Add(new OracleParameter("clDate", row.Cells["Ngay_update"].Value.ToString()));

                        con.Open();
                        cmdRepair.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (VTX == "")
                    {

                    }
                }


            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Boolean ChkRow = Convert.ToBoolean(row.Cells["SelectRepair"].Value);
                if (ChkRow)
                {
                    string strRepair2 = "INSERT INTO Ngoai_Kho (Ma_TS, ID_User, Latest_Day_Out, So_BB) VALUES (:Ma_TS, :ID_User, CURRENT_DATE, :So_BB)";
                    OracleCommand cmdRepair2 = new OracleCommand();
                    cmdRepair2.Connection = con;
                    cmdRepair2.CommandType = CommandType.Text;
                    cmdRepair2.CommandText = strRepair2;
                    cmdRepair2.Parameters.Add(new OracleParameter("Ma_TS", row.Cells["Ma_TS"].Value.ToString()));
                    cmdRepair2.Parameters.Add(new OracleParameter("ID_User", row.Cells["USER_ID"].Value.ToString()));
                    //cmdRepair2.Parameters.Add("clDate", row.Cells["Ngay_update"].Value.ToString());
                    cmdRepair2.Parameters.Add(new OracleParameter("So_BB", row.Cells["So_Bien_Ban"].Value.ToString()));
                    con.Open();
                    cmdRepair2.ExecuteNonQuery();
                    con.Close();
                }
            }
            string tableName = "NGOAI_KHO";
            string fieldName = "MA_TS";

            AntiDuplicated antiDuplicated = new AntiDuplicated();
            antiDuplicated.DeleteDuplicatedRow(tableName, fieldName);

            OutStorageLoad();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void menuLending_Click(object sender, EventArgs e)
        {
            Borrow borrow = new Borrow();
            //this.Hide();
            borrow.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //AutoStickDuplicatedMTS();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //AutoStickDuplicatedMTS();
        }
        public void AutoStickDuplicatedMTS()
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                Boolean CheckRow = Convert.ToBoolean(dataGridView2.Rows[i].Cells["SelectRepair"].Value);
                for (int j = i + 1; j < dataGridView2.Rows.Count - 1; j++)
                {
                    Boolean CheckRow2 = Convert.ToBoolean(dataGridView2.Rows[j].Cells["SelectRepair"].Value);

                    if (CheckRow == true)
                    {
                        if (dataGridView2.Rows[i].Cells["Ma_TS"].Value.ToString() == dataGridView2.Rows[j].Cells["Ma_TS"].Value.ToString())
                        {
                            dataGridView2.Rows[j].Cells["SelectRepair"].Value = true;
                            dataGridView2.Rows[i].Cells["SelectRepair"].Value = true;
                        }
                    }


                }
            }
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
            {
                Boolean CheckRow = Convert.ToBoolean(dataGridView2.Rows[i].Cells["SelectRepair"].Value);
                for (int j = dataGridView2.Rows.Count - 2; j >= 0; j--)
                {
                    Boolean CheckRow2 = Convert.ToBoolean(dataGridView2.Rows[j].Cells["SelectRepair"].Value);
                    if (CheckRow == true)
                    {
                        if (dataGridView2.Rows[i].Cells["Ma_TS"].Value.ToString() == dataGridView2.Rows[j].Cells["Ma_TS"].Value.ToString())
                        {
                            dataGridView2.Rows[j].Cells["SelectRepair"].Value = true;
                            dataGridView2.Rows[i].Cells["SelectRepair"].Value = true;
                        }
                    }
                }
            }
        }

        private void btnSelectRepair_Click(object sender, EventArgs e)
        {
            auto.AutoSelectAll(dataGridView2, "SelectRepair");
        }

        private void btnSelectLend_Click(object sender, EventArgs e)
        {
            auto.AutoSelectAll(dataGridView3, "SelectBorrow");
        }

        private void btnApproveLend_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectBorrow"].Value);
                    if (CheckRow)
                    {
                        AutoTask.UpdateApprovedOfBB(row.Cells["So_Bien_Ban"].Value.ToString());
                        AutoTask.BufferClear(Convert.ToInt32(row.Cells["Ma_TS"].Value));

                        string strBrr = "UPDATE Muon_vat_tu SET Approved = 1 WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        OracleCommand cmdBrrUpdate = new OracleCommand();
                        cmdBrrUpdate.Connection = con;
                        cmdBrrUpdate.CommandType = CommandType.Text;
                        cmdBrrUpdate.CommandText = strBrr;
                        con.Open();
                        cmdBrrUpdate.ExecuteNonQuery();
                        con.Close();

                        string strXuat = "INSERT INTO Ngoai_Kho (Ma_TS, ID_User, Latest_Day_Out, So_BB) VALUES (:MTS, :IDUser, CURRENT_DATE, :SoBB)";
                        OracleCommand cmdOut = new OracleCommand();
                        cmdOut.Connection = con;
                        cmdOut.CommandType = CommandType.Text;
                        cmdOut.CommandText = strXuat;
                        cmdOut.Parameters.Add(new OracleParameter("MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value)));
                        cmdOut.Parameters.Add(new OracleParameter("IDUser", row.Cells["USER_ID"].Value.ToString()));
                        cmdOut.Parameters.Add(new OracleParameter("SoBB", row.Cells["So_Bien_Ban"].Value.ToString()));
                        //cmdOut.Parameters.Add("@Date", DateTime.Now.ToString());
                        con.Open();
                        cmdOut.ExecuteNonQuery();
                        con.Close();
                    }
                }
                OutStorageLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabCheckExpiredBorrow_Click(object sender, EventArgs e)
        {

        }

        private void phânLoạiBiênBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classification classification = new Classification();
            //this.Hide();
            classification.ShowDialog();
        }

        private void menuAddUser_Click(object sender, EventArgs e)
        {
            UserReg userReg = new UserReg();
            //this.Hide();
            userReg.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenURL("http://10.224.50.222:49155/Bien_Ban.aspx");
        }
        private void OpenURL(string url)
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            // Get the default browser path on the system
            string Default_Browser_Path = ((string)registryKey.GetValue(null, null)).Split('"')[1];

            Process p = new Process();
            p.StartInfo.FileName = Default_Browser_Path;
            p.StartInfo.Arguments = url;
            p.Start();
        }

        private void superDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuperAdmin superAdmin = new SuperAdmin();
            this.Hide();
            superAdmin.ShowDialog();
        }

        private void menuTS_Click(object sender, EventArgs e)
        {

        }

        private void menuUser_Click(object sender, EventArgs e)
        {
            User_Transaction frm = new User_Transaction();
            //this.Hide();
            frm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            OutStorageLoad();

        }

        private void btnSelectAllNew_Click(object sender, EventArgs e)
        {
            auto.AutoSelectAll(dgvNew, "SelectNew");
        }

        private void btnSelectAllRevoke_Click(object sender, EventArgs e)
        {
            auto.AutoSelectAll(dgvRevoke, "SelectRevoke");
        }

        private void btnAllDispose_Click(object sender, EventArgs e)
        {
            auto.AutoSelectAll(dgvDispose, "SelectDispose");
        }

        private void btnAppNew_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvNew.Rows)
                {
                    Boolean ChecRow = Convert.ToBoolean(row.Cells["SelectNew"].Value);
                    if (ChecRow)
                    {
                        AutoTask.UpdateApprovedOfBB(row.Cells["So_Bien_Ban"].Value.ToString());

                        string strApproveNew = "update Nhap_Moi set Approved = 1 where Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        OracleCommand cmdAppNew = new OracleCommand();
                        cmdAppNew.Connection = con;
                        cmdAppNew.CommandType = CommandType.Text;
                        cmdAppNew.CommandText = strApproveNew;
                        con.Open();
                        cmdAppNew.ExecuteNonQuery();
                        con.Close();

                        string strInStorage = "insert into Luu_kho (Ma_TS, Tinh_Trang, Ngay_update, So_BB) values (:MTS, :Status, CURRENT_DATE, :SoBB)";
                        OracleCommand cmdInNew = new OracleCommand();
                        cmdInNew.Connection = con;
                        cmdInNew.CommandType = CommandType.Text;
                        cmdInNew.CommandText = strInStorage;
                        cmdInNew.Parameters.Add(new OracleParameter("MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value)));
                        //cmdInNew.Parameters.Add("clDate", DateTime.Now.ToString());
                        cmdInNew.Parameters.Add(new OracleParameter("Status", row.Cells["Ten_tinh_trang"].Value.ToString()));
                        cmdInNew.Parameters.Add(new OracleParameter("SoBB", row.Cells["So_Bien_Ban"].Value.ToString()));
                        con.Open();
                        cmdInNew.ExecuteNonQuery();
                        con.Close();
                    }
                }
                OutStorageLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnApproveRevoke_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvRevoke.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectRevoke"].Value);
                    if (CheckRow)
                    {
                        AutoTask.UpdateApprovedOfBB(row.Cells["So_Bien_Ban"].Value.ToString());
                        AutoTask.BufferClear(Convert.ToInt32(row.Cells["Ma_TS"].Value));

                        string strAppRevoke = "update Nhan_tra_TS set Approved = 1 where Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        OracleCommand cmdAppRevoke = new OracleCommand();
                        cmdAppRevoke.Connection = con;
                        cmdAppRevoke.CommandType = CommandType.Text;
                        cmdAppRevoke.CommandText = strAppRevoke;
                        con.Open();
                        cmdAppRevoke.ExecuteNonQuery();
                        con.Close();

                        string strRevoke = "insert into Luu_kho (Ma_TS, Tinh_Trang, Ngay_update, So_BB) values (:MTS, :Status, CURRENT_DATE, :SoBB)";
                        OracleCommand cmdRevoke = new OracleCommand();
                        cmdRevoke.Connection = con;
                        cmdRevoke.CommandType = CommandType.Text;
                        cmdRevoke.CommandText = strRevoke;
                        cmdRevoke.Parameters.Add(new OracleParameter("MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value)));
                        cmdRevoke.Parameters.Add(new OracleParameter("Status", row.Cells["Ten_tinh_trang"].Value.ToString()));
                        cmdRevoke.Parameters.Add(new OracleParameter("SoBB", row.Cells["So_Bien_Ban"].Value.ToString()));
                        //cmdRevoke.Parameters.Add("@Date", DateTime.Now.ToString());
                        con.Open();
                        cmdRevoke.ExecuteNonQuery();
                        con.Close();


                    }
                }
                //Insert ngày thu hồi vật tư đối với các vật tư cho mượn.
                string strSelectBorrow = "SELECT * FROM Muon_vat_tu";
                OracleCommand cmdSelectBorrow = new OracleCommand(strSelectBorrow, con);
                OracleDataReader rdrSelectBorrow = null;
                con.Open();
                rdrSelectBorrow = cmdSelectBorrow.ExecuteReader();
                while (rdrSelectBorrow.Read())
                {
                    foreach (DataGridViewRow row in dgvRevoke.Rows)
                    {
                        Boolean checkRow = Convert.ToBoolean(row.Cells["SelectRevoke"].Value);
                        if (checkRow == true)
                        {
                            if (row.Cells["Ma_TS"].Value.ToString() == rdrSelectBorrow["Ma_TS"].ToString() && rdrSelectBorrow["Ngay_tra_thuc"].ToString() == "")
                            {
                                string strInsertDate = "UPDATE Muon_vat_tu SET Ngay_tra_thuc = CURRENT_DATE WHERE Ma_TS = :Ma_TS";
                                OracleCommand cmdInsertDate = new OracleCommand();
                                cmdInsertDate.Connection = con2;
                                cmdInsertDate.CommandType = CommandType.Text;
                                cmdInsertDate.CommandText = strInsertDate;
                                //cmdInsertDate.Parameters.Add("@DATE", DateTime.Now.ToString());
                                cmdInsertDate.Parameters.Add("Ma_TS", row.Cells["Ma_TS"].Value.ToString());
                                con2.Open();
                                cmdInsertDate.ExecuteNonQuery();
                                con2.Close();
                            }
                        }
                    }
                }
                con.Close();
                OutStorageLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAppDispose_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDispose.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectDispose"].Value);
                    if (CheckRow)
                    {
                        AutoTask.UpdateApprovedOfBB(row.Cells["So_Bien_Ban"].Value.ToString());

                        string strApp = "update Huy_TS set Approved = 1 where Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        OracleCommand cmdApp = new OracleCommand();
                        cmdApp.Connection = con;
                        cmdApp.CommandType = CommandType.Text;
                        cmdApp.CommandText = strApp;
                        con.Open();
                        cmdApp.ExecuteNonQuery();
                        con.Close();

                        string strDispose = "DELETE FROM Luu_kho WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        OracleCommand cmdDispose = new OracleCommand();
                        cmdDispose.Connection = con;
                        cmdDispose.CommandType = CommandType.Text;
                        cmdDispose.CommandText = strDispose;
                        con.Open();
                        cmdDispose.ExecuteNonQuery();
                        con.Close();

                        string strUpdate = "update Tai_san set Ma_tinh_trang = 'DIS' where Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        OracleCommand cmdUpdate = new OracleCommand();
                        cmdUpdate.Connection = con;
                        cmdUpdate.CommandType = CommandType.Text;
                        cmdUpdate.CommandText = strUpdate;
                        con.Open();
                        cmdUpdate.ExecuteNonQuery();
                        con.Close();
                    }
                }

                OutStorageLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuHRM_Click(object sender, EventArgs e)
        {
            User_Management management = new User_Management();
            management.ShowDialog();
        }

        private void oRGNAMEMANAGEMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ORG_NAME org = new ORG_NAME();
            org.ShowDialog();
        }

        private void organizationManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ORG_NAME org = new ORG_NAME();
            org.ShowDialog();
        }

        private void menuIntro_Click(object sender, EventArgs e)
        {
            Introduce introduce = new Introduce();
            introduce.ShowDialog();
        }

        private void menuDataModify_Click(object sender, EventArgs e)
        {

        }

        private void menuRevokeRequirement_Click(object sender, EventArgs e)
        {
            Revoke_Requirement revoke_Requirement = new Revoke_Requirement();
            revoke_Requirement.ShowDialog();
        }

        private void btnRejectDisposal_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDispose.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectDispose"].Value);
                if (CheckRow)
                {
                    string SoBB = row.Cells["So_Bien_Ban"].Value.ToString();
                    int Ma_TS = Convert.ToInt32(row.Cells["Ma_TS"].Value);
                    string cleadDISPOSE = "delete from Huy_TS where Ma_TS = " + Ma_TS + " and BB_Huy = '" + SoBB + "'";
                    OracleCommand cmdClear = new OracleCommand(cleadDISPOSE, con);
                    con.Open();
                    cmdClear.ExecuteNonQuery();
                    con.Close();
                }
            }
            OutStorageLoad();
        }

        private void btnRejectOut_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                if (CheckRow)
                {
                    string SoBB = row.Cells["So_Bien_Ban"].Value.ToString();


                    string DELBB2 = "delete from Xuat_kho where Ma_TS = " + Convert.ToInt32(row.Cells["Ma_TS"].Value) + " and So_BB_Xuat = '" + SoBB + "'";
                    OracleCommand cmdel2 = new OracleCommand(DELBB2, con);
                    con.Open();
                    cmdel2.ExecuteNonQuery();
                    con.Close();

                    AutoTask.BUFFERtoLuuKho(Convert.ToInt32(row.Cells["Ma_TS"].Value));
                    AntiDuplicated.DeleteDuplicatedRow("Luu_Kho", "Ma_TS");
                }
            }
            OutStorageLoad();
        }

        private void btnRejectRepair_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectRepair"].Value);
                if (CheckRow)
                {
                    string SoBB = row.Cells["So_Bien_Ban"].Value.ToString();


                    string DELBB2 = "delete from Sua_chua where Ma_TS = " + Convert.ToInt32(row.Cells["Ma_TS"].Value) + " and BB_Sua = '" + SoBB + "'";
                    OracleCommand cmdel2 = new OracleCommand(DELBB2, con);
                    con.Open();
                    cmdel2.ExecuteNonQuery();
                    con.Close();

                    string reversedStatus = "update Tai_san set ma_tinh_trang = 'NG' where ma_ts = " + Convert.ToInt32(row.Cells["Ma_TS"].Value);
                    cmdel2 = new OracleCommand(reversedStatus, con);
                    con.Open();
                    cmdel2.ExecuteNonQuery();
                    con.Close();

                    AutoTask.BUFFERtoLuuKho(Convert.ToInt32(row.Cells["Ma_TS"].Value));
                    if (row.Cells["VAT_TU_XUAT"].Value.ToString() != "")
                    {
                        AutoTask.BUFFERtoLuuKho(Convert.ToInt32(row.Cells["vat_tu_xuat"].Value));
                    }
                    else if (row.Cells["VAT_TU_XUAT"].Value.ToString() == "")
                    {

                    }

                    AntiDuplicated.DeleteDuplicatedRow("Luu_Kho", "Ma_TS");
                }
            }
            OutStorageLoad();
        }

        private void btnRejectBorrow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectBorrow"].Value);
                if (CheckRow)
                {
                    string SoBB = row.Cells["So_Bien_Ban"].Value.ToString();


                    string DELBB2 = "delete from muon_vat_tu where Ma_TS = " + Convert.ToInt32(row.Cells["Ma_TS"].Value) + " and So_BB = '" + SoBB + "'";
                    OracleCommand cmdel2 = new OracleCommand(DELBB2, con);
                    con.Open();
                    cmdel2.ExecuteNonQuery();
                    con.Close();

                    AutoTask.BUFFERtoLuuKho(Convert.ToInt32(row.Cells["Ma_TS"].Value));
                    AntiDuplicated.DeleteDuplicatedRow("Luu_Kho", "Ma_TS");
                }
            }
            OutStorageLoad();
        }

        private void btnRejectInStorage_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRevoke.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectRevoke"].Value);
                if (CheckRow)
                {
                    string SoBB = row.Cells["So_Bien_Ban"].Value.ToString();
                    int Ma_TS = Convert.ToInt32(row.Cells["Ma_TS"].Value);

                    string DELBB2 = "delete from nhan_tra_ts where Ma_TS = " + Convert.ToInt32(row.Cells["Ma_TS"].Value) + " and So_BB_nhan = '" + SoBB + "'";
                    OracleCommand cmdel2 = new OracleCommand(DELBB2, con);
                    con.Open();
                    cmdel2.ExecuteNonQuery();
                    con.Close();

                    AutoTask.BUFFERtoNgoaiKho(Convert.ToInt32(row.Cells["Ma_TS"].Value));
                    AntiDuplicated.DeleteDuplicatedRow("Ngoai_Kho", "Ma_TS");
                }
            }
            OutStorageLoad();
        }

        private void btnRejectNew_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNew.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectNew"].Value);
                if (CheckRow)
                {
                    string clearTS = "delete from Tai_san where Ma_TS = " + Convert.ToInt32(row.Cells["Ma_TS"].Value);
                    string clearNEWITEM = "delete from Nhap_Moi where Ma_TS = " + Convert.ToInt32(row.Cells["Ma_TS"].Value) + " and So_BB = '" + row.Cells["So_Bien_Ban"].Value.ToString() + "'";
                    OracleCommand cmdReject = new OracleCommand(clearTS, con);
                    con.Open();
                    cmdReject.ExecuteNonQuery();
                    con.Close();

                    cmdReject = new OracleCommand(clearNEWITEM, con);
                    con.Open();
                    cmdReject.ExecuteNonQuery();
                    con.Close();
                }
            }
            OutStorageLoad();
        }

        private void MenuRepair_Beta_Click(object sender, EventArgs e)
        {
            NewRepair_Beta repair_beta = new NewRepair_Beta();
            repair_beta.ShowDialog();
        }
    }
}
