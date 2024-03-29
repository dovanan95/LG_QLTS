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
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class Revoke : Form
    {

        public string strSearchPublic = "SELECT a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, c.Ten_loai, d.Ten_tinh_trang, e.USER_ID " +
                "FROM Ngoai_Kho a " +
                "inner join bien_ban e on a.SO_BB = e.SO_BIEN_BAN " +
                "INNER JOIN  Tai_san b ON a.Ma_TS = b.Ma_TS " +
                "INNER JOIN Loai_TS_cap2 c ON b.Ma_Loai_TS_cap2 = c.Ma_loai " +
                "INNER JOIN Status d On b.Ma_tinh_trang = d.Ma_tinh_trang ";

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleConnection con2 = new OracleConnection(connectionString);
        OracleConnection con3 = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();
        AntiDuplicated AntiDuplicated = new AntiDuplicated();
        AutoTask AutoTask = new AutoTask();
        Excel Excel = new Excel();

        Permission IT_OP = new Permission();

        UserUpdate update = new UserUpdate();

        //string ITOP = Permission.ITOP;
        Report Report = new Report();

        bool flag = false;

        public Revoke()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            string strSearch = "SELECT a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, c.Ten_loai, d.Ten_tinh_trang, a.ID_User " +
                "FROM Ngoai_Kho a " +
                "INNER JOIN  Tai_san b ON a.Ma_TS = b.Ma_TS " +
                "INNER JOIN Loai_TS_cap2 c ON b.Ma_Loai_TS_cap2 = c.Ma_loai " +
                "INNER JOIN Status d On b.Ma_tinh_trang = d.Ma_tinh_trang ";
            OracleCommand cmdSearch = new OracleCommand();

            cmdSearch.Connection = con;
            cmdSearch.CommandType = CommandType.Text;
            cmdSearch.CommandText = strSearch;

            /*cmdSearch.Parameters.Add("@SN", txtSN.Text.ToString());
            cmdSearch.Parameters.Add("@FA_Tag", txtFATag.Text.ToString());
            cmdSearch.Parameters.Add("@IT_Tag", txtIT_Tag.Text.ToString());*/

            con.Open();
            cmdSearch.ExecuteNonQuery();
            OracleDataAdapter daSearch = new OracleDataAdapter(cmdSearch);
            DataTable dtSearch = new DataTable();
            daSearch.Fill(dtSearch);
            dataGridView1.DataSource = dtSearch;
            con.Close();
        }

        public void LoadData2()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                string strSearch2 = "select a.Ma_TS, b.Ten_TS, d.Ten_loai, b.SN, b.FA_Tag, b.IT_Tag, c.Ten_tinh_trang " +
                    "from Ngoai_Kho a " +
                    "inner join BIEN_BAN e on a.So_BB = e.SO_BIEN_BAN " +
                    "inner join Tai_san b on b.Ma_TS = a.Ma_TS " +
                    "inner join Status c on c.Ma_tinh_trang = b.Ma_tinh_trang " +
                    "inner join Loai_TS_cap2 d on d.Ma_loai =  b.Ma_Loai_TS_cap2 " +
                    "where a.Ma_TS = :MTS";

                /*string strSearch2 = "SELECT a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, c.Ten_loai, d.Ten_tinh_trang " +
                "FROM Ngoai_Kho a " +
                "INNER JOIN  Tai_san b ON a.Ma_TS = b.Ma_TS " +
                "INNER JOIN Loai_TS_cap2 c ON b.Ma_Loai_TS_cap2 = c.Ma_loai " +
                "INNER JOIN Status d On b.Ma_tinh_trang = d.Ma_tinh_trang " +
                "WHERE b.SN = @SN OR b.FA_Tag = @FA_Tag OR b.IT_Tag = @IT_Tag";*/
                OracleCommand cmdSearch2 = new OracleCommand();

                cmdSearch2.Connection = con;
                cmdSearch2.CommandType = CommandType.Text;
                cmdSearch2.CommandText = strSearch2;

                cmdSearch2.Parameters.Add("MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value));
                /*cmdSearch.Parameters.Add("@SN", txtSN.Text.ToString());
                cmdSearch.Parameters.Add("@FA_Tag", txtFATag.Text.ToString());
                cmdSearch.Parameters.Add("@IT_Tag", txtIT_Tag.Text.ToString());*/

                con.Open();
                cmdSearch2.ExecuteNonQuery();
                OracleDataAdapter daSearch = new OracleDataAdapter(cmdSearch2);
                DataTable dtSearch = new DataTable();
                daSearch.Fill(dtSearch);
                dataGridView2.DataSource = dtSearch;
                con.Close();
            }
        }

        public void UpdateOK()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                if (CheckRow)
                {
                    string strAfterUpdate = strSearchPublic + " where a.Ma_TS = '" + Convert.ToInt32(row.Cells["Ma_TS"].Value) + "'";
                    OracleCommand cmdUpdate = new OracleCommand(strAfterUpdate, con2);
                    OracleDataAdapter daUpdate = new OracleDataAdapter(cmdUpdate);
                    DataTable dtUpdate = new DataTable();
                    daUpdate.Fill(dtUpdate);
                    dataGridView1.DataSource = dtUpdate;
                }
            }

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main frm = new Main();
            //frm.ShowDialog();
            frm.OutStorageLoad();
        }

        private void bntNewBB_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row2 in dataGridView2.Rows)
                {
                    Boolean CheckRow2 = Convert.ToBoolean(row2.Cells["Select"].Value);
                    if (CheckRow2)
                    {
                        if (row2.Cells["Remark"].Value == null && row2.Cells["Ten_tinh_trang"].Value.ToString().Trim() == "NG")
                        {
                            //MessageBox.Show("Check Remark for NG items!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flag = true;
                            break;
                        }

                    }
                }

                //first check if Status == NG, Remark field to be filled up is obligated

                if (flag == true)
                {
                    MessageBox.Show("Check Remark for NG items!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    flag = false;
                    foreach (DataGridViewRow rowNG in dataGridView2.Rows)
                    {
                        Boolean CheckRowNG = Convert.ToBoolean(rowNG.Cells["Select"].Value);
                        if (CheckRowNG)
                        {

                            if (rowNG.Cells["Remark"].Value == null && rowNG.Cells["Ten_tinh_trang"].Value.ToString().Trim() == "NG")
                            {
                                rowNG.Cells["Remark"].Style.BackColor = Color.Red;
                                rowNG.Cells["Remark"].Style.ForeColor = Color.Yellow;
                                rowNG.Cells["Ten_tinh_trang"].Style.BackColor = Color.Red;
                                rowNG.Cells["Ten_tinh_trang"].Style.ForeColor = Color.Yellow;
                            }
                        }
                    }
                }
                else
                {
                    string strInsertBB = "INSERT INTO Bien_Ban (So_Bien_Ban, Ma_loai_BB, CL_DATE, REASON, User_ID, IT_OP, APPROVED) VALUES (:So_Bien_Ban, :Ma_loai_BB, CURRENT_DATE, :reason, :ID, :ITOP, :APP)";
                    OracleCommand cmdInsertBB = new OracleCommand();
                    cmdInsertBB.Connection = con;
                    cmdInsertBB.CommandType = CommandType.Text;
                    cmdInsertBB.CommandText = strInsertBB;
                    cmdInsertBB.Parameters.Add(new OracleParameter("So_Bien_Ban", txtSoBB.Text.ToString()));
                    cmdInsertBB.Parameters.Add(new OracleParameter("Ma_loai_BB", "IN"));
                    //cmdInsertBB.Parameters.Add("@DATE", DateTime.Now.ToString());
                    cmdInsertBB.Parameters.Add(new OracleParameter("reason", txtReason.Text.ToString()));
                    cmdInsertBB.Parameters.Add(new OracleParameter("ID", txtUserID2.Text.ToString()));
                    cmdInsertBB.Parameters.Add(new OracleParameter("ITOP", IT_OP.Get_IT_User()));
                    cmdInsertBB.Parameters.Add(new OracleParameter("APP", "N"));
                    con.Open();
                    cmdInsertBB.ExecuteNonQuery();
                    con.Close();


                    //Insert ngày thu hồi vật tư đối với các vật tư cho mượn.
                    /*string strSelectBorrow = "SELECT * FROM Muon_vat_tu";
                    OracleCommand cmdSelectBorrow = new OracleCommand(strSelectBorrow, con);
                    OracleDataReader rdrSelectBorrow = null;
                    con.Open();
                    rdrSelectBorrow = cmdSelectBorrow.ExecuteReader();
                    while (rdrSelectBorrow.Read())
                    {
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            Boolean checkRow = Convert.ToBoolean(row.Cells["Select"].Value);
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
                    con.Close();*/


                    string strSelect_TS = "SELECT * FROM Tai_san";
                    OracleCommand cmdSelect_TS = new OracleCommand(strSelect_TS, con);
                    OracleDataReader rdrSelect_TS = null;
                    con.Open();
                    rdrSelect_TS = cmdSelect_TS.ExecuteReader();
                    while (rdrSelect_TS.Read())
                    {
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                            if (CheckRow == true)
                            {
                                if (row.Cells["Ma_TS"].Value.ToString() == rdrSelect_TS["Ma_TS"].ToString())
                                {
                                    string strStatusCode = rdrSelect_TS["Ma_tinh_trang"].ToString();
                                    string strReceived = "INSERT INTO Nhan_tra_TS (So_BB_nhan, Ma_TS, ID_Nguoi_tra, Ma_tinh_trang, Remark, Approved, IT_OP) VALUES (:BB_No, :Ma_TS, :User_ID, :Status, :Remark, :App, :ITOP)";
                                    OracleCommand cmdReceived = new OracleCommand();
                                    cmdReceived.Connection = con2;
                                    cmdReceived.CommandType = CommandType.Text;
                                    cmdReceived.CommandText = strReceived;
                                    cmdReceived.Parameters.Add(new OracleParameter("BB_No", txtSoBB.Text.ToString()));
                                    cmdReceived.Parameters.Add(new OracleParameter("Ma_TS", Convert.ToInt32(row.Cells["Ma_TS"].Value)));
                                    cmdReceived.Parameters.Add(new OracleParameter("User_ID", txtUserID2.Text.ToString()));
                                    cmdReceived.Parameters.Add(new OracleParameter("Status", strStatusCode));

                                    if (row.Cells["Remark"].Value != null)
                                    {
                                        cmdReceived.Parameters.Add(new OracleParameter("Remark", row.Cells["Remark"].Value.ToString()));
                                    }
                                    else if (row.Cells["Remark"].Value == null)
                                    {
                                        cmdReceived.Parameters.Add(new OracleParameter("Remark", ""));
                                    }
                                    cmdReceived.Parameters.Add(new OracleParameter("App", '0'));
                                    cmdReceived.Parameters.Add(new OracleParameter("ITOP", IT_OP.Get_IT_User()));
                                    con2.Open();
                                    cmdReceived.ExecuteNonQuery();
                                    con2.Close();

                                    /*string strIn_Storage = "INSERT INTO Luu_kho (Ma_TS, Tinh_Trang, Ngay_update) VALUES (@Ma_TS, @Status, @DATE)";
                                    OracleCommand cmdIn_Storage = new OracleCommand();
                                    cmdIn_Storage.Connection = con2;
                                    cmdIn_Storage.CommandType = CommandType.Text;
                                    cmdIn_Storage.CommandText = strIn_Storage;
                                    cmdIn_Storage.Parameters.Add("@Ma_TS", Convert.ToInt32(row.Cells["Ma_TS"].Value));
                                    cmdIn_Storage.Parameters.Add("@Status", strStatusCode);
                                    cmdIn_Storage.Parameters.Add("@DATE", DateTime.Now.ToString());
                                    con2.Open();
                                    cmdIn_Storage.ExecuteNonQuery();
                                    con2.Close();*/


                                }
                            }
                        }
                    }
                    con.Close();

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (CheckRow == true)
                        {

                            AutoTask.ToBufferIN(Convert.ToInt32(row.Cells["Ma_TS"].Value));
                            string strDEL = "DELETE FROM Ngoai_Kho WHERE Ma_TS = '" + Convert.ToInt32(row.Cells["Ma_TS"].Value) + "'";
                            OracleCommand cmdDEL = new OracleCommand();
                            cmdDEL.Connection = con;
                            cmdDEL.CommandType = CommandType.Text;
                            cmdDEL.CommandText = strDEL;
                            con.Open();
                            cmdDEL.ExecuteNonQuery();
                            con.Close();
                        }
                    }


                    MessageBox.Show("Successful!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AutoGenBB Bien_Ban = new AutoGenBB();
            Bien_Ban.AutoGenBBBG();
            txtSoBB.Text = Bien_Ban.SoBBBG;
            txtReason.ResetText();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSN.Text.ToString() != "")
            {
                string strSN = strSearchPublic + " where b.SN = '" + txtSN.Text.ToString() + "'";
                OracleDataAdapter daSN = new OracleDataAdapter(strSN, con);
                DataTable dtSN = new DataTable();
                daSN.Fill(dtSN);
                dataGridView1.DataSource = dtSN;
            }
            else if (txtFATag.Text.ToString() != "")
            {
                string strFA = strSearchPublic + " where b.FA_Tag = '" + txtFATag.Text.ToString() + "'";
                OracleDataAdapter daFA = new OracleDataAdapter(strFA, con);
                DataTable dtFA = new DataTable();
                daFA.Fill(dtFA);
                dataGridView1.DataSource = dtFA;
            }
            else if (txtIT_Tag.Text.ToString() != "")
            {
                string strIT = strSearchPublic + " where b.IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";
                OracleDataAdapter daIT = new OracleDataAdapter(strIT, con);
                DataTable dtIT = new DataTable();
                daIT.Fill(dtIT);
                dataGridView1.DataSource = dtIT;
            }
            else if (txtUserID.Text.ToString() != "")
            {
                string ID = strSearchPublic + " where e.USER_ID = '" + txtUserID.Text.ToString().ToUpper() + "'";
                OracleDataAdapter daID = new OracleDataAdapter(ID, con);
                DataTable dtID = new DataTable();
                daID.Fill(dtID);
                dataGridView1.DataSource = dtID;
            }
            else if (txtSN.Text.ToString() == "" && txtIT_Tag.Text.ToString() == "" && txtFATag.Text.ToString() == "")
            {
                LoadData();
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Columns.Count == 0)
                {
                    //duyet tat ca cac cot cua bang 1
                    foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
                    {
                        //chuyen cac cot cua bang 1 ve dang clone (khong so huu) sau do add vao bang 2
                        dataGridView2.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }

                }
                //tao doi tuong row trong datagridviewrow
                DataGridViewRow row = new DataGridViewRow();
                //xet hang duoc chon trong bang 1
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //doi tuong row duoc gan voi row trong bang 1 duoc chon va dua ve dang clone
                    row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                    int intColIndex = 0; //khai bao value so column/cell
                                         //xet tat ca cell trong row duoc chon cua bang 1
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        //gan gia tri tung cell cua doi tuong row bang gia tri cua cac cell trong 1 dong của bang 1
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Select"].Value) == true)
                    {
                        dataGridView2.Rows.Add(row); //add cac row da duoc check vao bang 2
                        int n = dataGridView1.Rows[i].Index; //lay so dong cua row vua duoc move sang bang 2
                        dataGridView1.Rows.RemoveAt(n); //xoa row do khỏ datagridview
                    }
                }
                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Refresh();
                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    int Check = Convert.ToInt32(dataGridView2.Rows[j].Cells["Ma_TS"].Value);
                    for (int k = j + 1; k < dataGridView2.Rows.Count; k++)
                    {
                        int Check2 = Convert.ToInt32(dataGridView2.Rows[k].Cells["Ma_TS"].Value);
                        if (Check == Check2)
                        {
                            dataGridView2.Rows.Add();
                            int n2 = dataGridView2.Rows[k].Index;
                            dataGridView2.Rows.RemoveAt(n2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = "Remark";
            column.HeaderText = "Remark";
            column.Visible = true;
            dataGridView2.Columns.Add(column);

            AntiDuplicated.AntiColumnDuplicate(dataGridView2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Revoke_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "Select";
            column.Name = "Select";
            column.Visible = true;

            dataGridView1.Columns.Add(column);
            dataGridView1.Columns["Select"].DisplayIndex = 0;
            dataGridView2.AllowUserToAddRows = false;

            con.Open();
            string strcbStatus = "SELECT * FROM Status";
            OracleCommand cmdStatus = new OracleCommand(strcbStatus, con);
            OracleDataAdapter daStatus = new OracleDataAdapter(cmdStatus);
            DataTable dtStatus = new DataTable();
            daStatus.Fill(dtStatus);
            cbStatus.DataSource = dtStatus;
            cbStatus.DisplayMember = "Ten_tinh_trang";
            cbStatus.ValueMember = "Ma_tinh_trang";
            cmdStatus.ExecuteNonQuery();
            con.Close();

            LoadComboboxData comboboxData = new LoadComboboxData();
            comboboxData.LoadDataType(cbTypeLV2);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Boolean checkRow = Convert.ToBoolean(row.Cells["Select"].Value);
                if (checkRow)
                {
                    //int Index = dataGridView2.CurrentCell.RowIndex;
                    //string strCode = dataGridView2.Rows[Index].Cells["Ma_TS"].Value.ToString();
                    string strCode = row.Cells["Ma_TS"].Value.ToString();
                    string strUpdateStatus = "UPDATE Tai_san SET Ma_tinh_trang = :StatusCode WHERE Ma_TS = '" + strCode + "'";
                    OracleCommand cmdUpdateStatus = new OracleCommand();
                    cmdUpdateStatus.Connection = con;
                    cmdUpdateStatus.CommandType = CommandType.Text;
                    cmdUpdateStatus.CommandText = strUpdateStatus;
                    cmdUpdateStatus.Parameters.Add(new OracleParameter("StatusCode", cbStatus.SelectedValue));
                    con.Open();
                    cmdUpdateStatus.ExecuteNonQuery();
                    con.Close();

                }

            }
            btnSearch_Click(this, new EventArgs());
        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnUserSearch_Click(object sender, EventArgs e)
        {

            update.SearchUser(txtIDSearch, txtUserID2, txtUser_Name, txtPhone, txtMail, txtDept, chkOSP, btnUpdateUser);
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {

            UserUpdate update = new UserUpdate();
            update.UpdateUser(txtUserID2, txtUser_Name, txtPhone, txtMail, txtDept, chkOSP);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            UserUpdate update = new UserUpdate();
            update.InsertUser(txtUserID2, txtUser_Name, txtPhone, txtMail, txtDept, chkOSP);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                string ColumnName = dataGridView2.Columns["Select"].Name.ToString();
                AutoComplete complete = new AutoComplete();
                complete.AutoSelectAll(dataGridView2, ColumnName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                if (CheckRow)
                {
                    dataGridView2.Rows.RemoveAt(row.Index);
                }

            }
        }

        private void btnInsertRemark_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.Rows[index].Cells["Remark"].Value = txtRemark.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                //txtRemark.Text = dataGridView2.Rows[index].Cells["Remark"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtIDSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtIDSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUserSearch_Click(this, new EventArgs());
            }
        }

        private void cbTypeLV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SearchType = strSearchPublic + " where b.Ma_Loai_TS_cap2 = :Type";

                OracleCommand cmdSearchType = new OracleCommand();
                cmdSearchType.Connection = con;
                cmdSearchType.CommandType = CommandType.Text;
                cmdSearchType.CommandText = SearchType;
                cmdSearchType.Parameters.Add(new OracleParameter("Type", cbTypeLV2.SelectedValue.ToString()));
                OracleDataAdapter daType = new OracleDataAdapter(cmdSearchType);
                DataTable dtType = new DataTable();
                daType.Fill(dtType);
                dataGridView1.DataSource = dtType;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void txtFATag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void txtIT_Tag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void lblReport_Click(object sender, EventArgs e)
        {
            //Report.TestBB(txtSoBB.Text.ToString());
            Report.Print_Bien_Ban(txtSoBB.Text.ToString());
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportExcelFromDGV(dataGridView1);
        }
    }
}

