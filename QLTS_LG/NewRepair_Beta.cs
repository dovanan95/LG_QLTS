using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class NewRepair_Beta : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        LoadComboboxData load = new LoadComboboxData();
        CopyGridView CopyGrid = new CopyGridView();
        AutoComplete AutoComplete = new AutoComplete();
        UserUpdate update = new UserUpdate();
        Permission IT_OP = new Permission();
        Report Report = new Report();
        Excel Excel = new Excel();
        AutoTask AutoTask = new AutoTask();
        public static DataTable SummaryData { get; set; }
        //public static DataTable SummaryData2 { get; set; }
        public string itemID;
        public NewRepair_Beta()
        {
            InitializeComponent();
        }
        public string strSearchPublic = "SELECT a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, b.Spec, c.Ten_loai" +
               " FROM Luu_kho a " +
               " inner join Tai_san b on a.Ma_TS = b.Ma_TS" +
               " inner join Loai_TS_cap2 c on b.Ma_Loai_TS_cap2 = c.Ma_loai ";


        private void NewRepair_Beta_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "Select";
            column.Name = "Select";
            column.Visible = true;

            dgvRepairDevice.Columns.Add(column);
            dgvRepairDevice.Columns["Select"].DisplayIndex = 0;
            load.LoadDataType(cbType_Repair);

        }

        private void btnSearchDeviceRepair_Click(object sender, EventArgs e)
        {
            if (txtSN.Text.ToString() != "")
            {
                string SN1 = strSearchPublic + " where b.SN = '" + txtSN.Text.ToString() + "'";
                OracleDataAdapter daSN1 = new OracleDataAdapter(SN1, con);
                DataTable dtSN1 = new DataTable();
                daSN1.Fill(dtSN1);
                dgvRepairDevice.DataSource = dtSN1;
            }
            else if (txtFaTag.Text.ToString() != "")
            {
                string FA1 = strSearchPublic + " where b.FA_Tag = '" + txtFaTag.Text.ToString() + "'";
                OracleDataAdapter daFA1 = new OracleDataAdapter(FA1, con);
                DataTable dtFA1 = new DataTable();
                daFA1.Fill(dtFA1);
                dgvRepairDevice.DataSource = dtFA1;
            }
            else if (txtIT_Tag.Text.ToString() != "")
            {
                string IT1 = strSearchPublic + " where b.IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";
                OracleDataAdapter daIT1 = new OracleDataAdapter(IT1, con);
                DataTable dtIT1 = new DataTable();
                daIT1.Fill(dtIT1);
                dgvRepairDevice.DataSource = dtIT1;
            }
            else if (txtSN.Text.ToString() == "" && txtIT_Tag.Text.ToString() == "" && txtFaTag.Text.ToString() == "")
            {
                string strSearch = strSearchPublic + " WHERE c.Phan_loai = 'DE' and b.Ma_Tinh_Trang = 'NG'";
                OracleDataAdapter daSearch = new OracleDataAdapter(strSearch, con);
                DataTable dtSearch = new DataTable();
                daSearch.Fill(dtSearch);
                dgvRepairDevice.DataSource = dtSearch;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main frm = new Main();
            frm.OutStorageLoad();
        }

        private void btnUserSearch_Click(object sender, EventArgs e)
        {
            update.SearchUser(txtIDSearch, txtUserID, txtUserName, txtPhone, txtMail, txtDept, chkOSP, btnUpdate);
        }

        private void btnCreateSoBB_Click(object sender, EventArgs e)
        {
            if (NewRepair_Beta.SummaryData != null)
            {
                NewRepair_Beta.SummaryData.Clear();
            }

            AutoGenBB autoGen = new AutoGenBB();
            autoGen.AutoGenBBBG();
            txtSoBB.Text = autoGen.SoBBBG;

            lblStatus.ForeColor = System.Drawing.Color.Yellow;
            lblStatus.Text = "Ready";
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            CopyGrid.CopyDataGridView(dgvRepairDevice, dgvRepairSelected);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (NewRepair_Beta.SummaryData != null)
            {
                RecursiveDelete();
                foreach (DataGridViewRow row in dgvRepairSelected.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (CheckRow)
                    {
                        dgvRepairSelected.Rows.RemoveAt(row.Index);
                    }
                }
            }
            else if (NewRepair_Beta.SummaryData is null)
            {
                foreach (DataGridViewRow row in dgvRepairSelected.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (CheckRow)
                    {
                        dgvRepairSelected.Rows.RemoveAt(row.Index);
                    }
                }
            }

        }

        public void RecursiveDelete()
        {
            for (int i = 0; i < dgvRepairSelected.Rows.Count; i++)
            {
                Boolean CheckRow = Convert.ToBoolean(dgvRepairSelected.Rows[i].Cells["Select"].Value);
                if (CheckRow)
                {
                    for (int j = 0; j < NewRepair_Beta.SummaryData.Rows.Count; j++)
                    {
                        if (Convert.ToInt32(NewRepair_Beta.SummaryData.Rows[j]["Ma_TS"]) == Convert.ToInt32(dgvRepairSelected.Rows[i].Cells["Ma_TS"].Value))
                        {
                            NewRepair_Beta.SummaryData.Rows.RemoveAt(j);
                            RecursiveDelete();
                        }
                    }
                }
            }
        }

        private void txtIDSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUserSearch_Click(this, new EventArgs());
            }
        }

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchDeviceRepair_Click(this, new EventArgs());

            }
        }

        private void txtIT_Tag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchDeviceRepair_Click(this, new EventArgs());

            }
        }

        private void txtFaTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchDeviceRepair_Click(this, new EventArgs());

            }
        }

        private void cbType_Repair_SelectedIndexChanged(object sender, EventArgs e)
        {

            string SearchType = strSearchPublic + " where b.Ma_Loai_TS_cap2 = :Type and a.Tinh_Trang = 'NG'";

            OracleCommand cmdSearchType = new OracleCommand();
            cmdSearchType.Connection = con;
            cmdSearchType.CommandType = CommandType.Text;
            cmdSearchType.CommandText = SearchType;
            cmdSearchType.Parameters.Add(new OracleParameter("Type", cbType_Repair.SelectedValue.ToString()));
            OracleDataAdapter daType = new OracleDataAdapter(cmdSearchType);
            DataTable dtType = new DataTable();
            daType.Fill(dtType);
            dgvRepairDevice.DataSource = dtType;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Report.Print_Bien_Ban(txtSoBB.Text.ToString());
        }

        private void dgvRepairSelected_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int itemRowIndex = dgvRepairSelected.CurrentCell.RowIndex;
                itemID = dgvRepairSelected.Rows[itemRowIndex].Cells["Ma_TS"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRprAdding_Click(object sender, EventArgs e)
        {
            Repair_itemAdding frm = new Repair_itemAdding();
            frm.itemID = itemID;
            if (frm.itemID is null)
            {
                MessageBox.Show("Vui long chon 1 vat tu can sua chua! (click vào bang ben duoi)");
            }
            else if (frm.itemID != null)
            {
                frm.ShowDialog();
            }

        }

        private void dgvRepairSelected_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int itemRowIndex = dgvRepairSelected.CurrentCell.RowIndex;
                itemID = dgvRepairSelected.Rows[itemRowIndex].Cells["Ma_TS"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewForm frm = new PreviewForm();
            frm.SummaryData = SummaryData;
            frm.LoadAddingItemPreview();
            frm.ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strBB = "INSERT INTO Bien_Ban (So_Bien_ban, Ma_loai_BB, CL_DATE, User_ID, IT_OP, APPROVED) VALUES (:SoBB, :Type, CURRENT_DATE, :ID, :ITOP, :APP)";
                OracleCommand cmdBB = new OracleCommand();
                cmdBB.CommandType = CommandType.Text;
                cmdBB.CommandText = strBB;
                cmdBB.Connection = con;
                cmdBB.Parameters.Add(new OracleParameter("SoBB", txtSoBB.Text.ToString()));
                cmdBB.Parameters.Add(new OracleParameter("Type", "REP"));
                //cmdBB.Parameters.Add("@Date", DateTime.Now.ToString());
                cmdBB.Parameters.Add(new OracleParameter("ID", txtUserID.Text.ToString()));
                cmdBB.Parameters.Add(new OracleParameter("ITOP", IT_OP.Get_IT_User()));
                cmdBB.Parameters.Add(new OracleParameter("APP", "N"));
                con.Open();
                cmdBB.ExecuteNonQuery();
                con.Close();

                string strInsertToRepair = "INSERT INTO Sua_chua (BB_sua, Ma_TS, Vat_tu_xuat, ID_nguoi_yc, Status, Ngay_update, Approved, IT_OP)" +
                       "VALUES (:BBsua, :MaTS, :VTX, :ID, :Status, CURRENT_DATE, :App, :ITOP)";
                string strInsertToRepair_2 = "INSERT INTO Sua_chua (BB_sua, Ma_TS, ID_nguoi_yc, Status, Ngay_update, Approved, IT_OP)" +
                            "VALUES (:BBsua, :MaTS, :ID, :Status, CURRENT_DATE, :App, :ITOP)";
                foreach (DataGridViewRow row in dgvRepairSelected.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (CheckRow && CheckNoUseAddingItem(Convert.ToInt32(row.Cells["Ma_TS"].Value)) == false)
                    {

                        OracleCommand cmdInsertToRePair = new OracleCommand();
                        cmdInsertToRePair.Connection = con;
                        cmdInsertToRePair.CommandType = CommandType.Text;
                        cmdInsertToRePair.CommandText = strInsertToRepair_2;
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("BBsua", txtSoBB.Text.ToString()));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("MaTS", row.Cells["Ma_TS"].Value.ToString()));
                        //cmdInsertToRePair.Parameters.Add(new OracleParameter("VTX", row.Cells["Ma_TS"].Value.ToString()));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("ID", txtUserID.Text.ToString()));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("Status", "OK"));
                        //cmdInsertToRePair.Parameters.Add("@Date", DateTime.Now.ToString());
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("App", '0'));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("ITOP", IT_OP.Get_IT_User()));
                        con.Open();
                        cmdInsertToRePair.ExecuteNonQuery();
                        con.Close();

                        string strUpdateStatus = "UPDATE Tai_san SET Ma_tinh_trang = 'OK' WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        OracleCommand cmdUpdateStatus = new OracleCommand();
                        cmdUpdateStatus.Connection = con;
                        cmdUpdateStatus.CommandType = CommandType.Text;
                        cmdUpdateStatus.CommandText = strUpdateStatus;
                        con.Open();
                        cmdUpdateStatus.ExecuteNonQuery();
                        con.Close();

                        AutoTask.ToBufferOut(Convert.ToInt32(row.Cells["Ma_TS"].Value));

                        string strDEL = "DELETE FROM Luu_kho WHERE Ma_TS = :MaTS";
                        OracleCommand cmdDEL = new OracleCommand();
                        cmdDEL.Connection = con;
                        cmdDEL.CommandType = CommandType.Text;
                        cmdDEL.CommandText = strDEL;
                        cmdDEL.Parameters.Add(new OracleParameter("MaTS", row.Cells["Ma_TS"].Value.ToString()));
                        con.Open();
                        cmdDEL.ExecuteNonQuery();
                        con.Close();

                    }
                }
                if (NewRepair_Beta.SummaryData != null)
                {
                    foreach (DataRow row in NewRepair_Beta.SummaryData.Rows)
                    {
                        OracleCommand cmdInsertToRePair = new OracleCommand();
                        cmdInsertToRePair.Connection = con;
                        cmdInsertToRePair.CommandType = CommandType.Text;
                        cmdInsertToRePair.CommandText = strInsertToRepair;
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("BBsua", txtSoBB.Text.ToString()));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("MaTS", row["Ma_TS"].ToString()));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("VTX", row["VTX"].ToString()));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("ID", txtUserID.Text.ToString()));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("Status", "OK"));
                        //cmdInsertToRePair.Parameters.Add("@Date", DateTime.Now.ToString());
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("App", '0'));
                        cmdInsertToRePair.Parameters.Add(new OracleParameter("ITOP", IT_OP.Get_IT_User()));
                        con.Open();
                        cmdInsertToRePair.ExecuteNonQuery();
                        con.Close();

                        string strUpdateStatus = "UPDATE Tai_san SET Ma_tinh_trang = 'OK' WHERE Ma_TS = '" + row["Ma_TS"].ToString() + "'";
                        OracleCommand cmdUpdateStatus = new OracleCommand();
                        cmdUpdateStatus.Connection = con;
                        cmdUpdateStatus.CommandType = CommandType.Text;
                        cmdUpdateStatus.CommandText = strUpdateStatus;
                        con.Open();
                        cmdUpdateStatus.ExecuteNonQuery();
                        con.Close();

                        AutoTask.ToBufferOut(Convert.ToInt32(row["VTX"]));

                        string Delete = "DELETE FROM Luu_kho WHERE Ma_TS = :MaTS";
                        OracleCommand cmdXoa = new OracleCommand();
                        cmdXoa.Connection = con;
                        cmdXoa.CommandType = CommandType.Text;
                        cmdXoa.CommandText = Delete;
                        cmdXoa.Parameters.Add(new OracleParameter("MaTS", row["VTX"].ToString()));
                        con.Open();
                        cmdXoa.ExecuteNonQuery();
                        con.Close();

                        AutoTask.ToBufferOut(Convert.ToInt32(row["Ma_TS"]));

                        string strDEL = "DELETE FROM Luu_kho WHERE Ma_TS = :MaTS";
                        OracleCommand cmdDEL = new OracleCommand();
                        cmdDEL.Connection = con;
                        cmdDEL.CommandType = CommandType.Text;
                        cmdDEL.CommandText = strDEL;
                        cmdDEL.Parameters.Add(new OracleParameter("MaTS", row["Ma_TS"].ToString()));
                        con.Open();
                        cmdDEL.ExecuteNonQuery();
                        con.Close();
                    }
                }

                lblStatus.Text = "OK";
                lblStatus.ForeColor = System.Drawing.Color.Chartreuse;
                MessageBox.Show("Complete!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblStatus.Text = "NG";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                con.Close();
            }
        }
        public bool CheckNoUseAddingItem(int itemID)
        {
            bool flag = true;
            if (NewRepair_Beta.SummaryData != null)
            {
                DataRow[] CheckExist = NewRepair_Beta.SummaryData.Select("Ma_TS = '" + itemID + "'");
                if (CheckExist.Length > 0)
                {
                    flag = true;
                }
                else if (CheckExist.Length == 0)
                {
                    flag = false;
                }
            }
            else if (NewRepair_Beta.SummaryData is null)
            {
                flag = false;
            }

            return flag;
        }

        private void btnItemAddingPreview_Click(object sender, EventArgs e)
        {
            Repair_itemAdding frm = new Repair_itemAdding();
            frm.itemID = itemID;
            if (frm.itemID is null)
            {
                MessageBox.Show("Vui long chon 1 vat tu can sua chua! (click vào bang ben duoi)");
            }
            else if (frm.itemID != null)
            {
                frm.ReviewAddedItem(Convert.ToInt32(itemID));
                frm.ShowDialog();
            }
        }
    }
}
