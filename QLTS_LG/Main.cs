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

namespace QLTS_LG
{
    public partial class Main : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        AutoComplete auto = new AutoComplete();
        Permission per = new Permission();
        public string username1 { get; set; }

        public Main()
        {
            InitializeComponent();

        }


        public void CheckNotification()
        {
            int Number = dgvOverDue.Rows.Count;
            if(Number == 2)
            {
                lblExpired.Text = "There is one device need to be returned to storage!!!";
                lblExpired.ForeColor = System.Drawing.Color.Red;
            }
            else if(Number > 2)
            {
                Number++;
                lblExpired.Text = "There are " + Number.ToString() + " devices need to be returned to storage!!!";
                lblExpired.ForeColor = System.Drawing.Color.Red;
            }
            else if(Number == 0)
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

        public void CheckOverDue()
        {
            string strAutoCheck = "UPDATE Muon_vat_tu SET [Qua_han?] =  'true' WHERE Due_date < GETDATE() AND Due_date IS NOT NULL";
            SqlCommand cmdAutoCheck = new SqlCommand();
            cmdAutoCheck.Connection = con;
            cmdAutoCheck.CommandType = CommandType.Text;
            cmdAutoCheck.CommandText = strAutoCheck;
            con.Open();
            cmdAutoCheck.ExecuteNonQuery();
            con.Close();
        }
        public void OutStorageLoad()
        {
            string strOut = "SELECT * FROM Xuat_Kho AS a WHERE a.Approved = 'false'";
            SqlCommand cmdOut = new SqlCommand();
            cmdOut.Connection = con;
            cmdOut.CommandType = CommandType.Text;
            cmdOut.CommandText = strOut;
            SqlDataAdapter daOut = new SqlDataAdapter(cmdOut);
            DataTable dtOut = new DataTable();
            daOut.Fill(dtOut);
            dataGridView1.DataSource = dtOut;

            string strRepair = "SELECT * FROM Sua_chua AS a WHERE a.Approved = 'false'";
            SqlCommand cmdRepair = new SqlCommand();
            cmdRepair.Connection = con;
            cmdRepair.CommandType = CommandType.Text;
            cmdRepair.CommandText = strRepair;
            SqlDataAdapter daRepair = new SqlDataAdapter(cmdRepair);
            DataTable dtRepair = new DataTable();
            daRepair.Fill(dtRepair);
            dataGridView2.DataSource = dtRepair;

            string strBorrow = "SELECT * FROM Muon_vat_tu AS a WHERE a.Approved = 'false'";
            SqlCommand cmdBorrow = new SqlCommand();
            cmdBorrow.Connection = con;
            cmdBorrow.CommandType = CommandType.Text;
            cmdBorrow.CommandText = strBorrow;
            SqlDataAdapter daBorrow = new SqlDataAdapter(cmdBorrow);
            DataTable dtBorrow = new DataTable();
            daBorrow.Fill(dtBorrow);
            dataGridView3.DataSource = dtBorrow;

            string strNew = "select a.So_BB, a.Ma_TS, a.Approved, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, d.Ten_loai, b.Ma_tinh_trang, c.Ten_tinh_trang from Nhap_Moi as a " +
                "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                "inner join Status as c on c.Ma_tinh_trang = b.Ma_tinh_trang " +
                "inner join Loai_TS_cap2 as d on d.Ma_loai = b.Ma_Loai_TS_cap2 " +
                " where a.Approved = 'false' ";
            SqlCommand cmdNew = new SqlCommand();
            cmdNew.Connection = con;
            cmdNew.CommandType = CommandType.Text;
            cmdNew.CommandText = strNew;
            SqlDataAdapter daNew = new SqlDataAdapter(cmdNew);
            DataTable dtNew = new DataTable();
            daNew.Fill(dtNew);
            dgvNew.DataSource = dtNew;

            string strRevoke = "select * from Nhan_tra_TS as a where a.Approved = 'false'";
            SqlCommand cmdRevoke = new SqlCommand();
            cmdRevoke.Connection = con;
            cmdRevoke.CommandType = CommandType.Text;
            cmdRevoke.CommandText = strRevoke;
            SqlDataAdapter daRevoke = new SqlDataAdapter(cmdRevoke);
            DataTable dtRevoke = new DataTable();
            daRevoke.Fill(dtRevoke);
            dgvRevoke.DataSource = dtRevoke;

            string strDispose = "select * from Huy_TS where Approved = 'false'";
            SqlCommand cmdDispose = new SqlCommand();
            cmdDispose.Connection = con;
            cmdDispose.CommandType = CommandType.Text;
            cmdDispose.CommandText = strDispose;
            SqlDataAdapter daDispose = new SqlDataAdapter(cmdDispose);
            DataTable dtDispose = new DataTable();
            daDispose.Fill(dtDispose);
            dgvDispose.DataSource = dtDispose;


            CheckOverDue();
            CheckNotification();

            string strLoadOverDue = "SELECT * FROM Muon_vat_tu WHERE [Qua_han?] = 'true' and Ngay_tra_thuc is null";
            SqlDataAdapter daLoadOverDue = new SqlDataAdapter(strLoadOverDue, con);
            DataTable dtLoadOverDue = new DataTable();
            daLoadOverDue.Fill(dtLoadOverDue);
            dgvOverDue.DataSource = dtLoadOverDue;

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
        public void SearchBB(int DMBB)
        {
            Search_BB _BB = new Search_BB();
            _BB.stNhan = DMBB.ToString();
            _BB.strNhan = DMBB.ToString();
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
            SearchBB(1);
        }

        private void menuInStorageBB_Click(object sender, EventArgs e)
        {
            SearchBB(2);
        }

        private void menuOutStorageBB_Click(object sender, EventArgs e)
        {
            SearchBB(3);
        }

        private void menuLendingBB_Click(object sender, EventArgs e)
        {
            SearchBB(4);
        }

        private void menuRepairBB_Click(object sender, EventArgs e)
        {
            SearchBB(5);
        }

        private void menuDisposeBB_Click(object sender, EventArgs e)
        {
            SearchBB(6);
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
            string strOut = "SELECT * FROM  Xuat_Kho WHERE Approved = 'false'";
            SqlCommand cmdOut = new SqlCommand();
            cmdOut.Connection = con;
            cmdOut.CommandType = CommandType.Text;
            cmdOut.CommandText = strOut;
            SqlDataAdapter daOut = new SqlDataAdapter(cmdOut);
            DataTable dtOut = new DataTable();
            daOut.Fill(dtOut);
            dataGridView1.DataSource = dtOut;
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
                    string strUpdate = "UPDATE Xuat_Kho SET Approved = 'true' WHERE Ma_TS ='" + row.Cells["Ma_TS"].Value.ToString() + "'";
                    SqlCommand cmdUpdate = new SqlCommand();
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.CommandText = strUpdate;
                    cmdUpdate.Connection = con;
                    con.Open();
                    cmdUpdate.ExecuteNonQuery();
                    con.Close();

                    string strToOut = "INSERT INTO Ngoai_Kho (Ma_TS, ID_User, Latest_Day_Out) VALUES (@Ma_TS, @ID_User, @Date)";
                    SqlCommand cmdToOut = new SqlCommand();
                    cmdToOut.Connection = con;
                    cmdToOut.CommandType = CommandType.Text;
                    cmdToOut.CommandText = strToOut;
                    cmdToOut.Parameters.AddWithValue("@Ma_TS", row.Cells["Ma_TS"].Value.ToString());
                    cmdToOut.Parameters.AddWithValue("@ID_User", row.Cells["ID_nguoi_nhan"].Value.ToString());
                    cmdToOut.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
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
                        string strUpdate = "UPDATE Sua_chua SET Approved = 'true' WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        SqlCommand cmdUpdate = new SqlCommand();
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
                            string strRepair = "INSERT INTO Ngoai_Kho (Ma_TS, ID_User, Latest_Day_Out) VALUES (@Ma_TS, @ID_User, @Date)";
                            SqlCommand cmdRepair = new SqlCommand();
                            cmdRepair.Connection = con;
                            cmdRepair.CommandType = CommandType.Text;
                            cmdRepair.CommandText = strRepair;
                            cmdRepair.Parameters.AddWithValue("@Ma_TS", row.Cells["Vat_tu_xuat"].Value.ToString());
                            cmdRepair.Parameters.AddWithValue("@ID_User", row.Cells["ID_nguoi_y/c"].Value.ToString());
                            cmdRepair.Parameters.AddWithValue("@Date", row.Cells["Ngay_update"].Value.ToString());

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
                        string strRepair2 = "INSERT INTO Ngoai_Kho (Ma_TS, ID_User, Latest_Day_Out) VALUES (@Ma_TS, @ID_User, @Date)";
                        SqlCommand cmdRepair2 = new SqlCommand();
                        cmdRepair2.Connection = con;
                        cmdRepair2.CommandType = CommandType.Text;
                        cmdRepair2.CommandText = strRepair2;
                        cmdRepair2.Parameters.AddWithValue("@Ma_TS", row.Cells["Ma_TS"].Value.ToString());
                        cmdRepair2.Parameters.AddWithValue("@ID_User", row.Cells["ID_nguoi_y/c"].Value.ToString());
                        cmdRepair2.Parameters.AddWithValue("@Date", row.Cells["Ngay_update"].Value.ToString());
                        con.Open();
                        cmdRepair2.ExecuteNonQuery();
                        con.Close();
                    }
                }
                string tableName = "Ngoai_Kho";
                string fieldName = "Ma_TS";

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

                        string strBrr = "UPDATE Muon_vat_tu SET Approved = 'true' WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        SqlCommand cmdBrrUpdate = new SqlCommand();
                        cmdBrrUpdate.Connection = con;
                        cmdBrrUpdate.CommandType = CommandType.Text;
                        cmdBrrUpdate.CommandText = strBrr;
                        con.Open();
                        cmdBrrUpdate.ExecuteNonQuery();
                        con.Close();

                        string strXuat = "INSERT INTO Ngoai_Kho (Ma_TS, ID_User, Latest_Day_Out) VALUES (@MTS, @IDUser, @Date)";
                        SqlCommand cmdOut = new SqlCommand();
                        cmdOut.Connection = con;
                        cmdOut.CommandType = CommandType.Text;
                        cmdOut.CommandText = strXuat;
                        cmdOut.Parameters.AddWithValue("@MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value));
                        cmdOut.Parameters.AddWithValue("@IDUser", row.Cells["ID_nguoi_muon"].Value.ToString());
                        cmdOut.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
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
            OpenURL("https://www.lg.com/vn");
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
                        string strApproveNew = "update Nhap_Moi set Approved = 'true' where Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        SqlCommand cmdAppNew = new SqlCommand();
                        cmdAppNew.Connection = con;
                        cmdAppNew.CommandType = CommandType.Text;
                        cmdAppNew.CommandText = strApproveNew;
                        con.Open();
                        cmdAppNew.ExecuteNonQuery();
                        con.Close();

                        string strInStorage = "insert into Luu_kho (Ma_TS, Tinh_Trang, Ngay_update) values (@MTS, @Status, @Date)";
                        SqlCommand cmdInNew = new SqlCommand();
                        cmdInNew.Connection = con;
                        cmdInNew.CommandType = CommandType.Text;
                        cmdInNew.CommandText = strInStorage;
                        cmdInNew.Parameters.AddWithValue("@MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value));
                        cmdInNew.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        cmdInNew.Parameters.AddWithValue("@Status", row.Cells["Ma_tinh_trang"].Value.ToString());
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
                        string strAppRevoke = "update Nhan_tra_TS set Approved = 'true' where Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        SqlCommand cmdAppRevoke = new SqlCommand();
                        cmdAppRevoke.Connection = con;
                        cmdAppRevoke.CommandType = CommandType.Text;
                        cmdAppRevoke.CommandText = strAppRevoke;
                        con.Open();
                        cmdAppRevoke.ExecuteNonQuery();
                        con.Close();

                        string strRevoke = "insert into Luu_kho (Ma_TS, Tinh_Trang, Ngay_update) values (@MTS, @Status, @Date)";
                        SqlCommand cmdRevoke = new SqlCommand();
                        cmdRevoke.Connection = con;
                        cmdRevoke.CommandType = CommandType.Text;
                        cmdRevoke.CommandText = strRevoke;
                        cmdRevoke.Parameters.AddWithValue("@MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value));
                        cmdRevoke.Parameters.AddWithValue("@Status", row.Cells["Ma_tinh_trang"].Value.ToString());
                        cmdRevoke.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        con.Open();
                        cmdRevoke.ExecuteNonQuery();
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

        private void btnAppDispose_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDispose.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["SelectDispose"].Value);
                    if (CheckRow)
                    {
                        string strApp = "update Huy_TS set Approved = 'true' where Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        SqlCommand cmdApp = new SqlCommand();
                        cmdApp.Connection = con;
                        cmdApp.CommandType = CommandType.Text;
                        cmdApp.CommandText = strApp;
                        con.Open();
                        cmdApp.ExecuteNonQuery();
                        con.Close();

                        string strDispose = "DELETE FROM Luu_kho WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        SqlCommand cmdDispose = new SqlCommand();
                        cmdDispose.Connection = con;
                        cmdDispose.CommandType = CommandType.Text;
                        cmdDispose.CommandText = strDispose;
                        con.Open();
                        cmdDispose.ExecuteNonQuery();
                        con.Close();

                        string strUpdate = "update Tai_san set Ma_tinh_trang = 'DIS' where Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        SqlCommand cmdUpdate = new SqlCommand();
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
    }
}
