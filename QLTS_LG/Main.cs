﻿using System;
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

            CheckOverDue();

            string strLoadOverDue = "SELECT * FROM Muon_vat_tu WHERE [Qua_han?] = 'true'";
            SqlDataAdapter daLoadOverDue = new SqlDataAdapter(strLoadOverDue, con);
            DataTable dtLoadOverDue = new DataTable();
            daLoadOverDue.Fill(dtLoadOverDue);
            dgvOverDue.DataSource = dtLoadOverDue;

            superDataToolStripMenuItem.Visible = false;

            username1 = Login.username;

            if(username1 == "an.do")
            {
                superDataToolStripMenuItem.Visible = true;
            }
            
            if(per.CheckPermission() == "user")
            {
                panelBorrow.Visible = false;
                panelOut.Visible = false;
                panelRepair.Visible = false;
                menuAddUser.Enabled = false;
                menuDeviceType.Visible = false;
                
            }

            if(per.CheckPermission() == "guest")
            {
                panelBorrow.Visible = false;
                panelOut.Visible = false;
                panelRepair.Visible = false;
                menuAddUser.Visible = false;
                menuDeviceType.Visible = false;
                menuJob.Visible = false;
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
            //try
            //{
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

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //throw;
            //}
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
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                string strBrr = "UPDATE Muon_vat_tu SET Approved= 'true' WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
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
            OutStorageLoad();
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
    }
}