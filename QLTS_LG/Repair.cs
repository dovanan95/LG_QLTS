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
using System.IO;

namespace QLTS_LG
{
    public partial class Repair : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        CopyGridView CopyGrid = new CopyGridView();
        AutoComplete AutoComplete = new AutoComplete();


        public Repair()
        {
            InitializeComponent();
        }

        public string strSearchPublic = "SELECT a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, b.Spec, c.Ten_loai" +
                " FROM Luu_kho as a " +
                " inner join Tai_san as b on a.Ma_TS = b.Ma_TS" +
                " inner join Loai_TS_cap2 as c on b.Ma_Loai_TS_cap2 = c.Ma_loai ";

        public void LoadTypeMaterial()
        {
            con.Open();
            string cmdLoaiTS2 = "SELECT * FROM Loai_TS_cap2 where Phan_loai = 'MAT'";
            SqlCommand cmd = new SqlCommand(cmdLoaiTS2, con);
            DataTable dtLoaiTS2 = new DataTable();
            SqlDataAdapter daLoaiTS2 = new SqlDataAdapter(cmd);
            daLoaiTS2.Fill(dtLoaiTS2);
            cbType_Add.DataSource = dtLoaiTS2;
            cbType_Add.DisplayMember = "Ten_loai";
            cbType_Add.ValueMember = "Ma_loai";
            cbType_Add.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Repair_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "Select";
            column.Name = "Select";
            column.Visible = true;

            dgvRepairDevice.Columns.Add(column);
            dgvRepairDevice.Columns["Select"].DisplayIndex = 0;

            DataGridViewCheckBoxColumn column2 = new DataGridViewCheckBoxColumn();
            column2.HeaderText = "Select";
            column2.Name = "Select";
            column2.Visible = true;

            dgvAddingDevice.Columns.Add(column2);
            dgvAddingDevice.Columns["Select"].DisplayIndex = 0;

            //rdrYesUse.Checked = true;


            //dgvListDevice.Columns.Add("Ma_TS_Repair", "Vật tư cần sửa chữa");
            LoadComboboxData load = new LoadComboboxData();
            load.LoadDataType(cbType_Repair);
            //load.LoadDataType(cbType_Add);
            LoadTypeMaterial();


        }

        private void dgvRepairDevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRepairDevice.Rows)
            {
                row.Cells["Select"].Value = false;
            }
            dgvRepairDevice.CurrentRow.Cells["Select"].Value = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rdrYesUse.Checked == false && rdrNoUse.Checked == false)
            {
                MessageBox.Show("Please choose Yes/No Using additional Device!!!");
            }
            else
            {
                if (txtSN.Text.ToString() != "")
                {
                    string SN1 = strSearchPublic + " where b.[S/N] = '" + txtSN.Text.ToString() + "'";
                    SqlDataAdapter daSN1 = new SqlDataAdapter(SN1, con);
                    DataTable dtSN1 = new DataTable();
                    daSN1.Fill(dtSN1);
                    dgvRepairDevice.DataSource = dtSN1;
                }
                else if (txtFaTag.Text.ToString() != "")
                {
                    string FA1 = strSearchPublic + " where b.FA_Tag = '" + txtFaTag.Text.ToString() + "'";
                    SqlDataAdapter daFA1 = new SqlDataAdapter(FA1, con);
                    DataTable dtFA1 = new DataTable();
                    daFA1.Fill(dtFA1);
                    dgvRepairDevice.DataSource = dtFA1;
                }
                else if (txtIT_Tag.Text.ToString() != "")
                {
                    string IT1 = strSearchPublic + " where b.IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";
                    SqlDataAdapter daIT1 = new SqlDataAdapter(IT1, con);
                    DataTable dtIT1 = new DataTable();
                    daIT1.Fill(dtIT1);
                    dgvRepairDevice.DataSource = dtIT1;
                }
                else if (txtSN.Text.ToString() == "" && txtIT_Tag.Text.ToString() == "" && txtFaTag.Text.ToString() == "")
                {
                    string strSearch = strSearchPublic + " WHERE a.Tinh_Trang = 'NG'";
                    SqlDataAdapter daSearch = new SqlDataAdapter(strSearch, con);
                    DataTable dtSearch = new DataTable();
                    daSearch.Fill(dtSearch);
                    dgvRepairDevice.DataSource = dtSearch;
                }
            }


        }

        private void btnSearchDeviceOutForRepair_Click(object sender, EventArgs e)
        {
            if (rdrYesUse.Checked == false && rdrNoUse.Checked == false)
            {
                MessageBox.Show("Please choose Yes/No Using additional Device!!!");
            }
            else
            {
                if(txtMTS.Text.ToString() != "")
                {
                    string MTS = strSearchPublic + " where a.Ma_TS = '" + txtMTS.Text.ToString() + "'";
                    SqlDataAdapter daMTS = new SqlDataAdapter(MTS, con);
                    DataTable dtMTS = new DataTable();
                    daMTS.Fill(dtMTS);
                    dgvAddingDevice.DataSource = dtMTS;

                    txtName.Text = dtMTS.Rows[0]["Ten_TS"].ToString();
                    Model.Text = dtMTS.Rows[0]["Model"].ToString();
                    txtSpec.Text = dtMTS.Rows[0]["Spec"].ToString();
                    cbType_Add.Text = dtMTS.Rows[0]["Ten_loai"].ToString();
                }
                else if(txtMTS.Text.ToString() == "")
                {
                    string strSearch = strSearchPublic + " WHERE c.Phan_loai = 'MAT' and (a.Tinh_Trang = 'OK' OR a.Tinh_Trang = 'NE')";
                    SqlDataAdapter daSearch = new SqlDataAdapter(strSearch, con);
                    DataTable dtSearch = new DataTable();
                    daSearch.Fill(dtSearch);
                    dgvAddingDevice.DataSource = dtSearch;
                }



                /*if (txtSN2.Text.ToString() != "")
                {
                    string SN2 = strSearchPublic + " where b.[S/N] = '" + txtSN2.Text.ToString() + "'";
                    SqlDataAdapter daSN2 = new SqlDataAdapter(SN2, con);
                    DataTable dtSN2 = new DataTable();
                    daSN2.Fill(dtSN2);
                    dgvAddingDevice.DataSource = dtSN2;
                }
                else if (txtFaTag2.Text.ToString() != "")
                {
                    string FA2 = strSearchPublic + " where b.FA_Tag = '" + txtFaTag2.Text.ToString() + "'";
                    SqlDataAdapter daFA2 = new SqlDataAdapter(FA2, con);
                    DataTable dtFA2 = new DataTable();
                    daFA2.Fill(dtFA2);
                    dgvAddingDevice.DataSource = dtFA2;
                }
                else if (txtITTag2.Text.ToString() != "")
                {
                    string IT2 = strSearchPublic + " where b.IT_Tag = '" + txtITTag2.Text.ToString() + "'";
                    SqlDataAdapter daIT2 = new SqlDataAdapter(IT2, con);
                    DataTable dtIT2 = new DataTable();
                    daIT2.Fill(dtIT2);
                    dgvAddingDevice.DataSource = dtIT2;
                }
                else if (txtSN.Text.ToString() == "" && txtIT_Tag.Text.ToString() == "" && txtFaTag.Text.ToString() == "")
                {
                    string strSearch = strSearchPublic + " WHERE a.Tinh_Trang = 'OK' OR a.Tinh_Trang = 'NE'";
                    SqlDataAdapter daSearch = new SqlDataAdapter(strSearch, con);
                    DataTable dtSearch = new DataTable();
                    daSearch.Fill(dtSearch);
                    dgvAddingDevice.DataSource = dtSearch;
                }*/
            }



            if (rdrNoUse.Checked == true)
            {
                btnTransfer.Enabled = false;
                btnSearchDeviceOutForRepair.Enabled = false;
            }
            else if (rdrYesUse.Checked == true)
            {
                btnTransfer.Enabled = true;
                btnSearchDeviceOutForRepair.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main frm = new Main();
            //frm.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            CopyGridView copyGrid = new CopyGridView();
            copyGrid.CopyDataGridView(dgvAddingDevice, dgvAddOutDevice);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdrYesUse.Checked == true)
                {
                    CopyGridView copyGrid = new CopyGridView();
                    copyGrid.copyDataGridViewNotDelete(dgvAddOutDevice, dgvListDevice);

                    dgvListDevice.Columns.Add("Ma_TS_Repair", "Vật tư cần sửa chữa");

                    foreach (DataGridViewRow row in dgvRepairDevice.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            string MTS = row.Cells["Ma_TS"].Value.ToString();
                            foreach (DataGridViewRow row2 in dgvListDevice.Rows)
                            {
                                row2.Cells["Ma_TS_Repair"].Value = MTS;
                            }
                        }
                    }


                    AntiDuplicated antiDuplicated = new AntiDuplicated();
                    antiDuplicated.AntiColumnDuplicate(dgvListDevice);

                    string ColumnName = dgvAddOutDevice.Columns["Select"].Name.ToString();
                    AutoComplete.AutoUnselectAll(dgvAddOutDevice, ColumnName);

                    foreach (DataGridViewRow row in dgvRepairDevice.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            int n = row.Index;
                            dgvRepairDevice.Rows.RemoveAt(n);
                        }
                    }

                }
                else if (rdrNoUse.Checked == true)
                {
                    CopyGridView copyGrid = new CopyGridView();
                    copyGrid.CopyDataGridView(dgvRepairDevice, dgvListDevice);

                    foreach (DataGridViewRow row in dgvRepairDevice.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            int n = row.Index;
                            dgvRepairDevice.Rows.RemoveAt(n);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCreateSoBB_Click(object sender, EventArgs e)
        {
            AutoGenBB autoGen = new AutoGenBB();
            autoGen.AutoGenBBBG();
            txtSoBB.Text = autoGen.SoBBBG;

            lblStatus.ForeColor = System.Drawing.Color.Yellow;
            lblStatus.Text = "Ready";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string strBB = "INSERT INTO Bien_Ban (So_Bien_ban, Ma_loai_BB, DATE, [User ID]) VALUES (@SoBB, @Type, @Date, @ID)";
                SqlCommand cmdBB = new SqlCommand();
                cmdBB.CommandType = CommandType.Text;
                cmdBB.CommandText = strBB;
                cmdBB.Connection = con;
                cmdBB.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
                cmdBB.Parameters.AddWithValue("@Type", "REP");
                cmdBB.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                cmdBB.Parameters.AddWithValue("@ID", txtUserID.Text.ToString());
                con.Open();
                cmdBB.ExecuteNonQuery();
                con.Close();

                if (rdrYesUse.Checked == true)
                {
                    foreach (DataGridViewRow rowRepair in dgvListFinal.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(rowRepair.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            string strInsertToRepair = "INSERT INTO Sua_chua (BB_sua, Ma_TS, Vat_tu_xuat, [ID_nguoi_y/c], Status, Ngay_update, Approved)" +
                        "VALUES (@BBsua, @MaTS, @VTX, @ID, @Status, @Date, @App)";
                            SqlCommand cmdInsertToRePair = new SqlCommand();
                            cmdInsertToRePair.Connection = con;
                            cmdInsertToRePair.CommandType = CommandType.Text;
                            cmdInsertToRePair.CommandText = strInsertToRepair;
                            cmdInsertToRePair.Parameters.AddWithValue("@BBsua", txtSoBB.Text.ToString());
                            cmdInsertToRePair.Parameters.AddWithValue("@MaTS", rowRepair.Cells["Ma_TS_Repair"].Value.ToString());
                            cmdInsertToRePair.Parameters.AddWithValue("@VTX", rowRepair.Cells["Ma_TS"].Value.ToString());
                            cmdInsertToRePair.Parameters.AddWithValue("@ID", txtUserID.Text.ToString());
                            cmdInsertToRePair.Parameters.AddWithValue("@Status", "OK");
                            cmdInsertToRePair.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                            cmdInsertToRePair.Parameters.AddWithValue("@App", false);
                            con.Open();
                            cmdInsertToRePair.ExecuteNonQuery();
                            con.Close();

                            string strUpdateStatus = "UPDATE Tai_san SET Ma_tinh_trang = 'OK' WHERE Ma_TS = '" + rowRepair.Cells["Ma_TS_Repair"].Value.ToString() + "'";
                            SqlCommand cmdUpdateStatus = new SqlCommand();
                            cmdUpdateStatus.Connection = con;
                            cmdUpdateStatus.CommandType = CommandType.Text;
                            cmdUpdateStatus.CommandText = strUpdateStatus;
                            con.Open();
                            cmdUpdateStatus.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    foreach (DataGridViewRow rowdel in dgvListFinal.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(rowdel.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            string Delete = "DELETE FROM Luu_kho WHERE Ma_TS = @MaTS";
                            SqlCommand cmdXoa = new SqlCommand();
                            cmdXoa.Connection = con;
                            cmdXoa.CommandType = CommandType.Text;
                            cmdXoa.CommandText = Delete;
                            cmdXoa.Parameters.AddWithValue("@MaTS", rowdel.Cells["Ma_TS_Repair"].Value.ToString());
                            con.Open();
                            cmdXoa.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    foreach (DataGridViewRow row in dgvListFinal.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            string strDEL = "DELETE FROM Luu_kho WHERE Ma_TS = @MaTS";
                            SqlCommand cmdDEL = new SqlCommand();
                            cmdDEL.Connection = con;
                            cmdDEL.CommandType = CommandType.Text;
                            cmdDEL.CommandText = strDEL;
                            cmdDEL.Parameters.AddWithValue("@MaTS", row.Cells["Ma_TS"].Value.ToString());
                            con.Open();
                            cmdDEL.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
                else if (rdrNoUse.Checked == true)
                {
                    foreach (DataGridViewRow row in dgvListFinal.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            string strInsertToRepair = "INSERT INTO Sua_chua (BB_sua, Ma_TS, [ID_nguoi_y/c], Status, Ngay_update, Approved)" +
                        "VALUES (@BBsua, @MaTS, @ID, @Status, @Date, @App)";
                            SqlCommand cmdInsertToRePair = new SqlCommand();
                            cmdInsertToRePair.Connection = con;
                            cmdInsertToRePair.CommandType = CommandType.Text;
                            cmdInsertToRePair.CommandText = strInsertToRepair;
                            cmdInsertToRePair.Parameters.AddWithValue("@BBsua", txtSoBB.Text.ToString());
                            cmdInsertToRePair.Parameters.AddWithValue("@MaTS", row.Cells["Ma_TS"].Value.ToString());
                            //cmdInsertToRePair.Parameters.AddWithValue("@VTX", "");
                            cmdInsertToRePair.Parameters.AddWithValue("@ID", txtUserID.Text.ToString());
                            cmdInsertToRePair.Parameters.AddWithValue("@Status", "OK");
                            cmdInsertToRePair.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                            cmdInsertToRePair.Parameters.AddWithValue("@App", false);
                            con.Open();
                            cmdInsertToRePair.ExecuteNonQuery();
                            con.Close();

                            string strUpdateStatus = "UPDATE Tai_san SET Ma_tinh_trang = 'OK' WHERE Ma_TS= '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                            SqlCommand cmdUpdateStatus = new SqlCommand();
                            cmdUpdateStatus.Connection = con;
                            cmdUpdateStatus.CommandType = CommandType.Text;
                            cmdUpdateStatus.CommandText = strUpdateStatus;
                            con.Open();
                            cmdUpdateStatus.ExecuteNonQuery();
                            con.Close();


                        }
                    }
                    foreach (DataGridViewRow row in dgvListFinal.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            string strDEL = "DELETE FROM Luu_kho WHERE Ma_TS = @MaTS";
                            SqlCommand cmdDEL = new SqlCommand();
                            cmdDEL.Connection = con;
                            cmdDEL.CommandType = CommandType.Text;
                            cmdDEL.CommandText = strDEL;
                            cmdDEL.Parameters.AddWithValue("@MaTS", row.Cells["Ma_TS"].Value.ToString());
                            con.Open();
                            cmdDEL.ExecuteNonQuery();
                            con.Close();
                        }
                    }


                }
                else if(rdrNoUse.Checked == false && rdrYesUse.Checked == false)
                {
                    MessageBox.Show("Please Choose Yes/No using additional material!", "Warning");
                }

                lblStatus.Text = "OK";
                lblStatus.ForeColor = System.Drawing.Color.Chartreuse;



                MessageBox.Show("Complete!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvListDevice.Rows.Clear();
                dgvRepairDevice.DataSource = null;
                dgvRepairDevice.Rows.Clear();
                dgvAddingDevice.DataSource = null;
                dgvAddingDevice.Rows.Clear();
                dgvAddOutDevice.DataSource = null;
                dgvAddOutDevice.Rows.Clear();
                dgvListFinal.DataSource = null;
                dgvListFinal.Rows.Clear();
                dgvListFinal.Columns.Clear();
                rdrYesUse.Enabled = true;
                rdrNoUse.Enabled = true;
                rdrNoUse.Checked = false;
                rdrYesUse.Checked = false;
                btnSearchDeviceOutForRepair.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblStatus.Text = "NG";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnUserSearch_Click(object sender, EventArgs e)
        {
            string Search_User = "SELECT * FROM _User WHERE _User.ID='" + txtIDSearch.Text.ToString() + "'";
            SqlDataAdapter daSearch = new SqlDataAdapter(Search_User, con);
            DataTable dtSearch = new DataTable();
            daSearch.Fill(dtSearch);

            if (dtSearch.Rows.Count > 0)
            {
                txtUserID.Text = dtSearch.Rows[0]["ID"].ToString();
                txtUserName.Text = dtSearch.Rows[0]["Name"].ToString();
                txtPhone.Text = dtSearch.Rows[0]["Phone"].ToString();
                txtMail.Text = dtSearch.Rows[0]["Mail"].ToString();
                txtDept.Text = dtSearch.Rows[0]["Dept"].ToString();
                chkOSP.Checked = Convert.ToBoolean(dtSearch.Rows[0]["OSP"]);
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Khong co thong tin!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            UserUpdate update = new UserUpdate();
            update.UpdateUser(txtUserID, txtUserName, txtPhone, txtMail, txtDept, chkOSP);
        }

        private void btnInsertUser_Click(object sender, EventArgs e)
        {
            UserUpdate update = new UserUpdate();
            update.InsertUser(txtUserID, txtUserName, txtPhone, txtMail, txtDept, chkOSP);
        }

        private void btnFinalTransfer_Click(object sender, EventArgs e)
        {
            CopyGrid.CopyDataGridView(dgvListDevice, dgvListFinal);
            dgvAddOutDevice.Rows.Clear();
        }

        private void rdrYesUse_CheckedChanged(object sender, EventArgs e)
        {
            if (rdrYesUse.Checked == true)
            {
                rdrNoUse.Enabled = false;
            }
        }

        private void rdrNoUse_CheckedChanged(object sender, EventArgs e)
        {
            if (rdrNoUse.Checked == true)
            {
                rdrYesUse.Enabled = false;
            }
        }

        private void txtIDSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUserSearch_Click(this, new EventArgs());
            }
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbType_Repair_SelectedIndexChanged(object sender, EventArgs e)
        {

            string SearchType = strSearchPublic + " where b.Ma_Loai_TS_cap2 = @Type and a.Tinh_Trang = 'NG'";

            SqlCommand cmdSearchType = new SqlCommand();
            cmdSearchType.Connection = con;
            cmdSearchType.CommandType = CommandType.Text;
            cmdSearchType.CommandText = SearchType;
            cmdSearchType.Parameters.AddWithValue("@Type", Convert.ToInt32(cbType_Repair.SelectedValue.GetHashCode()));
            SqlDataAdapter daType = new SqlDataAdapter(cmdSearchType);
            DataTable dtType = new DataTable();
            daType.Fill(dtType);
            dgvRepairDevice.DataSource = dtType;

        }

        private void cbType_Add_SelectedIndexChanged(object sender, EventArgs e)
        {

            string SearchType2 = strSearchPublic + " where b.Ma_Loai_TS_cap2 = @Type and (a.Tinh_Trang = 'OK' OR a.Tinh_Trang = 'NE')";

            SqlCommand cmdSearchType2 = new SqlCommand();
            cmdSearchType2.Connection = con;
            cmdSearchType2.CommandType = CommandType.Text;
            cmdSearchType2.CommandText = SearchType2;
            cmdSearchType2.Parameters.AddWithValue("@Type", Convert.ToInt32(cbType_Add.SelectedValue.GetHashCode()));
            SqlDataAdapter daType2 = new SqlDataAdapter(cmdSearchType2);
            DataTable dtType2 = new DataTable();
            daType2.Fill(dtType2);
            dgvAddingDevice.DataSource = dtType2;

        }

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());

            }
        }

        private void txtFaTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());

            }
        }

        private void txtIT_Tag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());

            }
        }

        private void txtSN2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchDeviceOutForRepair_Click(this, new EventArgs());

            }
        }

        private void txtFaTag2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchDeviceOutForRepair_Click(this, new EventArgs());

            }
        }

        private void txtITTag2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchDeviceOutForRepair_Click(this, new EventArgs());

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvListFinal.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                if (CheckRow)
                {
                    dgvListFinal.Rows.RemoveAt(row.Index);
                }
            }
        }
    }
}
