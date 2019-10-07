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
using System.Data.SqlClient;

namespace QLTS_LG
{
    public partial class Disposal : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        LoadComboboxData LoadCombobox = new LoadComboboxData();
        Permission IT_OP = new Permission();

        

        public Disposal()
        {
            InitializeComponent();
        }

        public string strSearchPublic = "select a.Ma_TS, b.Ten_TS, b.[S/N], b.IT_Tag, b.FA_Tag, b.Model, b.Unit, c.Ten_loai, d.Ten_tinh_trang " +
            "from Luu_kho as a " +
            "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
            "inner join Loai_TS_cap2 as c on b.Ma_Loai_TS_cap2 = c.Ma_loai " +
            "inner join Status as d on d.Ma_tinh_trang = b.Ma_tinh_trang ";

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main frm = new Main();
            //frm.ShowDialog();
            frm.OutStorageLoad();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AutoGenBB autoGenBB = new AutoGenBB();
            autoGenBB.AutoGenBBBG();
            txtSoBB.Text = autoGenBB.SoBBBG;

            lblStatus.Text = "Ready";
            lblStatus.ForeColor = System.Drawing.Color.Yellow;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            string columnName = dgvQuerry.Columns["Select"].Name.ToString();
            AutoComplete autoComplete = new AutoComplete();
            autoComplete.AutoSelectAll(dgvSelected, columnName);
        }

        private void Disposal_Load(object sender, EventArgs e)
        {
            LoadCombobox.LoadDataType(cbType);
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.Name = "Select";
            column.HeaderText = "Select";
            column.Visible = true;
            dgvQuerry.Columns.Add(column);
            dgvQuerry.Columns["Select"].DisplayIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSN.Text.ToString() != "")
            {
                string strSN = strSearchPublic + " where b.[S/N] = '" + txtSN.Text.ToString() + "'";
                SqlDataAdapter daSN = new SqlDataAdapter(strSN, con);
                DataTable dtSN = new DataTable();
                daSN.Fill(dtSN);
                dgvQuerry.DataSource = dtSN;
            }
            else if (txtFA_Tag.Text.ToString() != "")
            {
                string strFA = strSearchPublic + " where b.FA_Tag = '" + txtFA_Tag.Text.ToString() + "'";
                SqlDataAdapter daFA = new SqlDataAdapter(strFA, con);
                DataTable dtFA = new DataTable();
                daFA.Fill(dtFA);
                dgvQuerry.DataSource = dtFA;
            }
            else if (txtIT_Tag.Text.ToString() != "")
            {
                string strIT = strSearchPublic + " where b.IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";
                SqlDataAdapter daIT = new SqlDataAdapter(strIT, con);
                DataTable dtIT = new DataTable();
                daIT.Fill(dtIT);
                dgvQuerry.DataSource = dtIT;
            }
            else if (txtFA_Tag.Text.ToString() == "" && txtIT_Tag.Text.ToString() == "" && txtSN.Text.ToString() == "")
            {
                SqlDataAdapter daQuerry = new SqlDataAdapter(strSearchPublic, con);
                daQuerry.Fill(Table);
                dgvQuerry.DataSource = Table;
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            CopyGridView copyGrid = new CopyGridView();
            copyGrid.CopyDataGridView(dgvQuerry, dgvSelected);
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            try
            {
                string strBB = "INSERT INTO Bien_Ban (So_Bien_ban, Ma_loai_BB, DATE, IT_OP) VALUES (@SoBB, @Type, @Date, @ITOP)";
                SqlCommand cmdBB = new SqlCommand();
                cmdBB.Connection = con;
                cmdBB.CommandType = CommandType.Text;
                cmdBB.CommandText = strBB;
                cmdBB.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
                cmdBB.Parameters.AddWithValue("@Type", "DIS");
                cmdBB.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                cmdBB.Parameters.AddWithValue("@ITOP", IT_OP.Get_IT_User());
                con.Open();
                cmdBB.ExecuteNonQuery();
                con.Close();

                foreach (DataGridViewRow row in dgvSelected.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (CheckRow)
                    {
                        string strHuy = "INSERT INTO Huy_TS (BB_Huy, Ma_TS, Approved, IT_OP) VALUES (@BB, @MTS, @App, @ITOP)";
                        SqlCommand cmdHuy = new SqlCommand();
                        cmdHuy.Connection = con;
                        cmdHuy.CommandType = CommandType.Text;
                        cmdHuy.CommandText = strHuy;
                        cmdHuy.Parameters.AddWithValue("@BB", txtSoBB.Text.ToString());
                        cmdHuy.Parameters.AddWithValue("@MTS", Convert.ToInt32(row.Cells["Ma_TS"].Value));
                        cmdHuy.Parameters.AddWithValue("@App", false);
                        cmdHuy.Parameters.AddWithValue("@ITOP", IT_OP.Get_IT_User());
                        con.Open();
                        cmdHuy.ExecuteNonQuery();
                        con.Close();

                        /*string strDispose = "DELETE FROM Luu_kho WHERE Ma_TS = '" + row.Cells["Ma_TS"].Value.ToString() + "'";
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
                        con.Close();*/
                    }
                }

                dgvSelected.DataSource = null;
                dgvSelected.Rows.Clear();
                dgvQuerry.DataSource = null;
                dgvQuerry.Rows.Clear();

                lblStatus.Text = "OK";
                lblStatus.ForeColor = System.Drawing.Color.Chartreuse;

                MessageBox.Show("Complete!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
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

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSearchType = strSearchPublic + " where b.Ma_Loai_TS_cap2 = @Type";

            SqlCommand cmdSearchType = new SqlCommand();
            cmdSearchType.Connection = con;
            cmdSearchType.CommandType = CommandType.Text;
            cmdSearchType.CommandText = strSearchType;
            cmdSearchType.Parameters.AddWithValue("@Type", Convert.ToInt32(cbType.SelectedValue.GetHashCode()));
            SqlDataAdapter daType = new SqlDataAdapter(cmdSearchType);
            DataTable dtType = new DataTable();
            daType.Fill(dtType);
            dgvQuerry.DataSource = dtType;
        }

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void txtIT_Tag_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void txtFA_Tag_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }
    }
}
