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


namespace QLTS_LG
{
    public partial class Borrow : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        UserUpdate UserFunc = new UserUpdate();

        public Borrow()
        {
            InitializeComponent();
        }

        public string strSearchPublic = "SELECT a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, b.Spec, c.Ten_loai" +
            " FROM Luu_kho as a " +
            " inner join Tai_san as b on a.Ma_TS = b.Ma_TS" +
            " inner join Loai_TS_cap2 as c on b.Ma_Loai_TS_cap2 = c.Ma_loai ";

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
                string SN = strSearchPublic + " where b.[S/N] = '" + txtSN.Text.ToString() + "'";
                SqlDataAdapter daSN = new SqlDataAdapter(SN, con);
                DataTable dtSN = new DataTable();
                daSN.Fill(dtSN);
                dgvQuerry.DataSource = dtSN;
            }
            else if(txtIT_Tag.Text.ToString() != "")
            {
                string IT = strSearchPublic + " where b.IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";
                SqlDataAdapter daIT = new SqlDataAdapter(IT, con);
                DataTable dtIT = new DataTable();
                daIT.Fill(dtIT);
                dgvQuerry.DataSource = dtIT;
            }
            else if(txtFaTag.Text.ToString() != "")
            {
                string FA = strSearchPublic + " where b.FA_Tag = '" + txtFaTag.Text.ToString() + "'";
                SqlDataAdapter daFA = new SqlDataAdapter(FA, con);
                DataTable dtFA = new DataTable();
                daFA.Fill(dtFA);
                dgvQuerry.DataSource = dtFA;
            }
            else if (txtSN.Text.ToString() == "" && txtIT_Tag.Text.ToString() == "" && txtFaTag.Text.ToString() == "")
            {
                string strSelect = "SELECT a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, b.Spec, c.Ten_loai" +
                " FROM Luu_kho as a " +
                " inner join Tai_san as b on a.Ma_TS = b.Ma_TS" +
                " inner join Loai_TS_cap2 as c on b.Ma_Loai_TS_cap2 = c.Ma_loai " +
                " WHERE a.Tinh_Trang = 'OK' OR a.Tinh_Trang = 'NE'";

                SqlDataAdapter daSelect = new SqlDataAdapter(strSelect, con);
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                string strInsertBB = "INSERT INTO Bien_Ban(So_Bien_ban, Ma_loai_BB, Reason, DATE, [User ID]) VALUES (@So_BB, @Code, @Reason, @Date, @ID)";
                SqlCommand cmdInBB = new SqlCommand();
                cmdInBB.Connection = con;
                cmdInBB.CommandType = CommandType.Text;
                cmdInBB.CommandText = strInsertBB;
                cmdInBB.Parameters.AddWithValue("@So_BB", txtSoBB.Text.ToString());
                cmdInBB.Parameters.AddWithValue("@Code", "TEMP");
                cmdInBB.Parameters.AddWithValue("@Reason", txtReason.Text.ToString());
                cmdInBB.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                cmdInBB.Parameters.AddWithValue("@ID", txtUserID.Text.ToString());
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
                            string strInBorrow = "INSERT INTO Muon_vat_tu(So_BB, Ma_TS, Reason, Due_date, [Qua_han?], ID_nguoi_muon, Approved, Borrow_code)" +
                                " VALUES(@SoBB, @MTS, @Reason, @Due, @Expired_check, @IDUser, @App, @Brr_code)";
                            SqlCommand cmdBrr = new SqlCommand();
                            cmdBrr.Connection = con;
                            cmdBrr.CommandType = CommandType.Text;
                            cmdBrr.CommandText = strInBorrow;
                            cmdBrr.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
                            cmdBrr.Parameters.AddWithValue("@MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value));
                            cmdBrr.Parameters.AddWithValue("@Reason", txtReason.Text.ToString());
                            cmdBrr.Parameters.AddWithValue("@Due", dateTimePicker1.Value.ToString());
                            cmdBrr.Parameters.AddWithValue("@Expired_check", false);
                            cmdBrr.Parameters.AddWithValue("@IDUser", txtUserID.Text.ToString());
                            cmdBrr.Parameters.AddWithValue("@App", false);
                            cmdBrr.Parameters.AddWithValue("@Brr_code", "ST");
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
                            string strInBorrow = "INSERT INTO Muon_vat_tu(So_BB, Ma_TS, Reason,  [Qua_han?], ID_nguoi_muon, Approved, Borrow_code)" +
                                " VALUES(@SoBB, @MTS, @Reason,  @Expired_check, @IDUser, @App, @Brr_code)";
                            SqlCommand cmdBrr = new SqlCommand();
                            cmdBrr.Connection = con;
                            cmdBrr.CommandType = CommandType.Text;
                            cmdBrr.CommandText = strInBorrow;
                            cmdBrr.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
                            cmdBrr.Parameters.AddWithValue("@MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value));
                            cmdBrr.Parameters.AddWithValue("@Reason", txtReason.Text.ToString());
                            //cmdBrr.Parameters.AddWithValue("@Due", "");
                            cmdBrr.Parameters.AddWithValue("@Expired_check", false);
                            cmdBrr.Parameters.AddWithValue("@IDUser", txtUserID.Text.ToString());
                            cmdBrr.Parameters.AddWithValue("@App", false);
                            cmdBrr.Parameters.AddWithValue("@Brr_code", "LT");
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
                        string strClear = "DELETE FROM Luu_kho WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
                        SqlCommand cmdClear = new SqlCommand();
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

                MessageBox.Show("Mượn là mất cất là còn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         
                dgvQuerry.DataSource = null;
                dgvQuerry.Rows.Clear();
                dgvSelected.DataSource = null;
                dgvSelected.Rows.Clear();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "NG";
                lblStatus.ForeColor = System.Drawing.Color.Red;

                MessageBox.Show(ex.Message);

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
            string SearchType = strSearchPublic + " where b.Ma_Loai_TS_cap2 = @Type";

            SqlCommand cmdSearchType = new SqlCommand();
            cmdSearchType.Connection = con;
            cmdSearchType.CommandType = CommandType.Text;
            cmdSearchType.CommandText = SearchType;
            cmdSearchType.Parameters.AddWithValue("@Type", Convert.ToInt32(cbType.SelectedValue.GetHashCode()));
            SqlDataAdapter daType = new SqlDataAdapter(cmdSearchType);
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
            string SearchStatus = strSearchPublic + " where b.Ma_tinh_trang = @Status";

            SqlCommand cmdSearchStatus = new SqlCommand();
            cmdSearchStatus.Connection = con;
            cmdSearchStatus.CommandType = CommandType.Text;
            cmdSearchStatus.CommandText = SearchStatus;
            cmdSearchStatus.Parameters.AddWithValue("@Status", cbStatus.SelectedValue.ToString());
            SqlDataAdapter daStatus = new SqlDataAdapter(cmdSearchStatus);
            DataTable dtStatus = new DataTable();
            daStatus.Fill(dtStatus);
            dgvQuerry.DataSource = dtStatus;

            btnTransfer.Enabled = true;
        }
    }
}
