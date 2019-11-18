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
using System.IO;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class Borrow : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();
        UserUpdate UserFunc = new UserUpdate();
        Permission IT_OP = new Permission();
        Report Report = new Report();
        UploadAndRetrieve UploadEPA = new UploadAndRetrieve();
        Excel Excel = new Excel();
        //string ITOP = Permission.ITOP;
        AutoTask AutoTask = new AutoTask();
        public Borrow()
        {
            InitializeComponent();
        }

        public string strSearchPublic = "SELECT a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, b.Spec, c.Ten_loai" +
            " FROM Luu_kho a " +
            " inner join Tai_san b on a.Ma_TS = b.Ma_TS" +
            " inner join Loai_TS_cap2 c on b.Ma_Loai_TS_cap2 = c.Ma_loai ";

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Borrow_Load(object sender, EventArgs e)
        {
            LoadComboboxData loadCombobox1 = new LoadComboboxData();
            loadCombobox1.LoadDataType(cbType);
            loadCombobox1.LoadDataStatus(cbStatus);

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.Name = "Select";
            column.HeaderText = "Select";
            dgvQuerry.Columns.Add(column);
            dgvQuerry.Columns["Select"].DisplayIndex = 0;
            dgvQuerry.AllowUserToAddRows = false;
            dgvSelected.AllowUserToAddRows = false;

            rdST.Checked = true;

            btnTransfer.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main main = new Main();
            main.OutStorageLoad();
            //main.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            UserFunc.SearchUser(txtIDSearch, txtUserID, txtUserName, txtPhone, txtMail, txtDept, chkOSP, btnUpdate);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserFunc.UpdateUser(txtUserID, txtUserName, txtPhone, txtMail, txtDept, chkOSP);
        }

        private void btnCreateBB_Click(object sender, EventArgs e)
        {
            AutoGenBB autoGen = new AutoGenBB();
            autoGen.AutoGenBBBG();
            txtSoBB.Text = autoGen.SoBBBG;

            lblStatus.ForeColor = System.Drawing.Color.Yellow;
            lblStatus.Text = "Ready";
        }

        private void btnSearchDeviceRepair_Click(object sender, EventArgs e)
        {
            if (txtSN.Text.ToString() != "")
            {
                string SN = strSearchPublic + " where b.SN = '" + txtSN.Text.ToString() + "'";
                OracleDataAdapter daSN = new OracleDataAdapter(SN, con);
                DataTable dtSN = new DataTable();
                daSN.Fill(dtSN);
                dgvQuerry.DataSource = dtSN;
            }
            else if(txtIT_Tag.Text.ToString() != "")
            {
                string IT = strSearchPublic + " where b.IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";
                OracleDataAdapter daIT = new OracleDataAdapter(IT, con);
                DataTable dtIT = new DataTable();
                daIT.Fill(dtIT);
                dgvQuerry.DataSource = dtIT;
            }
            else if(txtFaTag.Text.ToString() != "")
            {
                string FA = strSearchPublic + " where b.FA_Tag = '" + txtFaTag.Text.ToString() + "'";
                OracleDataAdapter daFA = new OracleDataAdapter(FA, con);
                DataTable dtFA = new DataTable();
                daFA.Fill(dtFA);
                dgvQuerry.DataSource = dtFA;
            }
            else if (txtSN.Text.ToString() == "" && txtIT_Tag.Text.ToString() == "" && txtFaTag.Text.ToString() == "")
            {
                string strSelect = "SELECT a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, b.Spec, c.Ten_loai" +
                " FROM Luu_kho a " +
                " inner join Tai_san b on a.Ma_TS = b.Ma_TS" +
                " inner join Loai_TS_cap2 c on b.Ma_Loai_TS_cap2 = c.Ma_loai " +
                " WHERE b.Ma_Tinh_Trang = 'OK' OR b.Ma_Tinh_Trang = 'NE'";

                OracleDataAdapter daSelect = new OracleDataAdapter(strSelect, con);
                DataTable dtSelect = new DataTable();
                daSelect.Fill(dtSelect);
                dgvQuerry.DataSource = dtSelect;
            }

            btnTransfer.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CopyGridView copy = new CopyGridView();
            copy.CopyDataGridView(dgvQuerry, dgvSelected);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            UserFunc.InsertUser(txtUserID, txtUserName, txtPhone, txtMail, txtDept, chkOSP);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                string columnName = dgvSelected.Columns["Select"].Name.ToString();
                AutoComplete auto = new AutoComplete();
                auto.AutoSelectAll(dgvSelected, columnName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Go_MainTask()
        {
            string strInsertBB = "INSERT INTO Bien_Ban(So_Bien_ban, Ma_loai_BB, Reason, CL_DATE, User_ID, IT_OP, APPROVED) VALUES (:So_BB, :Code, :Reason, CURRENT_DATE, :ID, :ITOP, :APP)";
            OracleCommand cmdInBB = new OracleCommand();
            cmdInBB.Connection = con;
            cmdInBB.CommandType = CommandType.Text;
            cmdInBB.CommandText = strInsertBB;
            cmdInBB.Parameters.Add(new OracleParameter("So_BB", txtSoBB.Text.ToString()));
            cmdInBB.Parameters.Add(new OracleParameter("Code", "TEMP"));
            cmdInBB.Parameters.Add(new OracleParameter("Reason", txtReason.Text.ToString()));
            //cmdInBB.Parameters.Add("clDate", DateTime.Now.ToString());
            cmdInBB.Parameters.Add(new OracleParameter("ID", txtUserID.Text.ToString()));
            cmdInBB.Parameters.Add(new OracleParameter("ITOP", IT_OP.Get_IT_User()));
            cmdInBB.Parameters.Add(new OracleParameter("APP", "N"));
            con.Open();
            cmdInBB.ExecuteNonQuery();
            con.Close();

            if (rdST.Checked == true)
            {
                foreach (DataGridViewRow row in dgvSelected.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (CheckRow)
                    {
                        string strInBorrow = "INSERT INTO Muon_vat_tu(So_BB, Ma_TS, Reason, Due_date, Qua_han, ID_nguoi_muon, Approved, Borrow_code, IT_OP)" +
                            " VALUES(:SoBB, :MTS, :Reason, (to_date(:Due, 'yyyy/mm/dd hh24:mi:ss')), :Expired_check, :IDUser, :App, :Brr_code, :ITOP)";
                        OracleCommand cmdBrr = new OracleCommand();
                        cmdBrr.Connection = con;
                        cmdBrr.CommandType = CommandType.Text;
                        cmdBrr.CommandText = strInBorrow;
                        cmdBrr.Parameters.Add(new OracleParameter("SoBB", txtSoBB.Text.ToString()));
                        cmdBrr.Parameters.Add(new OracleParameter("MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value)));
                        cmdBrr.Parameters.Add(new OracleParameter("Reason", txtReason.Text.ToString()));
                        cmdBrr.Parameters.Add(new OracleParameter("Due", dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm:ss")));
                        cmdBrr.Parameters.Add(new OracleParameter("Expired_check", '0'));
                        cmdBrr.Parameters.Add(new OracleParameter("IDUser", txtUserID.Text.ToString()));
                        cmdBrr.Parameters.Add(new OracleParameter("App", '0'));
                        cmdBrr.Parameters.Add(new OracleParameter("Brr_code", "ST"));
                        cmdBrr.Parameters.Add(new OracleParameter("ITOP", IT_OP.Get_IT_User()));
                        con.Open();
                        cmdBrr.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            else if (rdLT.Checked == true)
            {
                foreach (DataGridViewRow row in dgvSelected.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (CheckRow)
                    {
                        string strInBorrow = "INSERT INTO Muon_vat_tu(So_BB, Ma_TS, Reason,  Qua_han, ID_nguoi_muon, Approved, Borrow_code, IT_OP)" +
                            " VALUES(:SoBB, :MTS, :Reason,  :Expired_check, :IDUser, :App, :Brr_code, :ITOP)";
                        OracleCommand cmdBrr = new OracleCommand();
                        cmdBrr.Connection = con;
                        cmdBrr.CommandType = CommandType.Text;
                        cmdBrr.CommandText = strInBorrow;
                        cmdBrr.Parameters.Add(new OracleParameter("SoBB", txtSoBB.Text.ToString()));
                        cmdBrr.Parameters.Add(new OracleParameter("MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value)));
                        cmdBrr.Parameters.Add(new OracleParameter("Reason", txtReason.Text.ToString()));
                        //cmdBrr.Parameters.Add("@Due", "");
                        cmdBrr.Parameters.Add(new OracleParameter("Expired_check", '0'));
                        cmdBrr.Parameters.Add(new OracleParameter("IDUser", txtUserID.Text.ToString()));
                        cmdBrr.Parameters.Add(new OracleParameter("App", '0'));
                        cmdBrr.Parameters.Add(new OracleParameter("Brr_code", "LT"));
                        cmdBrr.Parameters.Add(new OracleParameter("ITOP", IT_OP.Get_IT_User()));
                        con.Open();
                        cmdBrr.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            foreach (DataGridViewRow row in dgvSelected.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                if (CheckRow)
                {
                    AutoTask.ToBufferOut(Convert.ToInt32(row.Cells["Ma_TS"].Value));

                    string strClear = "DELETE FROM Luu_kho WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                    OracleCommand cmdClear = new OracleCommand();
                    cmdClear.Connection = con;
                    cmdClear.CommandType = CommandType.Text;
                    cmdClear.CommandText = strClear;
                    con.Open();
                    cmdClear.ExecuteNonQuery();
                    con.Close();
                }
            }
            lblStatus.Text = "OK";
            lblStatus.ForeColor = System.Drawing.Color.Chartreuse;

            MessageBox.Show("Finished", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvQuerry.DataSource = null;
            dgvQuerry.Rows.Clear();
            dgvSelected.DataSource = null;
            dgvSelected.Rows.Clear();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                string DeviceQty = AutoTask.SoTaiSanDaBanGiao(txtUserID.Text.ToString().ToUpper());
                if (Convert.ToInt32(DeviceQty) != 0)
                {
                    DialogResult dialog = MessageBox.Show("Anh/Chị đã bàn giao " + DeviceQty + " thiết bị cho nhân sự này. Anh chị có muôn tiếp tục???", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        Go_MainTask();
                    }
                }
                else if (Convert.ToInt32(DeviceQty) == 0)
                {
                    Go_MainTask();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "NG";
                lblStatus.ForeColor = System.Drawing.Color.Red;

                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void rdLT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdLT.Checked == true)
            {
                dateTimePicker1.Enabled = false;
            }
        }

        private void rdST_CheckedChanged(object sender, EventArgs e)
        {
            if (rdST.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Quá khứ!!");
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void txtIDSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchUser_Click(this, new EventArgs());
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SearchType = strSearchPublic + " where b.Ma_Loai_TS_cap2 = :Type";

            OracleCommand cmdSearchType = new OracleCommand();
            cmdSearchType.Connection = con;
            cmdSearchType.CommandType = CommandType.Text;
            cmdSearchType.CommandText = SearchType;
            cmdSearchType.Parameters.Add(new OracleParameter("Type", cbType.SelectedValue.ToString()));
            OracleDataAdapter daType = new OracleDataAdapter(cmdSearchType);
            DataTable dtType = new DataTable();
            daType.Fill(dtType);
            dgvQuerry.DataSource = dtType;

            btnTransfer.Enabled = true;
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

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SearchStatus = strSearchPublic + " where b.Ma_tinh_trang = :Status";

            OracleCommand cmdSearchStatus = new OracleCommand();
            cmdSearchStatus.Connection = con;
            cmdSearchStatus.CommandType = CommandType.Text;
            cmdSearchStatus.CommandText = SearchStatus;
            cmdSearchStatus.Parameters.Add("Status", cbStatus.SelectedValue.ToString());
            OracleDataAdapter daStatus = new OracleDataAdapter(cmdSearchStatus);
            DataTable dtStatus = new DataTable();
            daStatus.Fill(dtStatus);
            dgvQuerry.DataSource = dtStatus;

            btnTransfer.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Report.TestBB(txtSoBB.Text.ToString());
            Report.Print_Bien_Ban(txtSoBB.Text.ToString());
        }

        private void btnEPA_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            UploadEPA.UploadToFileServer(txtSoBB, openFileDialog1);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Excel.ExportExcelFromDGV(dgvQuerry);
        }
    }
}
