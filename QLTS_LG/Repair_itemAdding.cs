using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace QLTS_LG
{

    public partial class Repair_itemAdding : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        CopyGridView CopyGrid = new CopyGridView();
        DataTable dtSummaryData = new DataTable();
        NewRepair_Beta mainFrm = new NewRepair_Beta();
        AntiDuplicated Clear = new AntiDuplicated();
        DataTable dt = new DataTable();
        DataTable dtSource = new DataTable();
        DataTable dtSearch = new DataTable();
        public string itemID { get; set; }

        public string strSearchPublic = "SELECT a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, b.Spec, c.Ten_loai" +
               " FROM Luu_kho a " +
               " inner join Tai_san b on a.Ma_TS = b.Ma_TS" +
               " inner join Loai_TS_cap2 c on b.Ma_Loai_TS_cap2 = c.Ma_loai ";
        public Repair_itemAdding()
        {
            InitializeComponent();
        }

        private void Repair_itemAdding_Load(object sender, EventArgs e)
        {
            lblRepairItemID.Text = itemID.ToString();
            //btnDeleteAddedItem.Enabled = false;

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "Select";
            column.Name = "Select";
            column.Visible = true;

            dgvAddingItem.Columns.Add(column);
            dgvAddingItem.Columns["Select"].DisplayIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strSearch = strSearchPublic + " WHERE c.Phan_loai = 'MAT' and (b.Ma_Tinh_Trang = 'OK' OR b.Ma_Tinh_Trang = 'NE')";
            OracleDataAdapter daSearch = new OracleDataAdapter(strSearch, con);

            daSearch.Fill(dtSearch);

            dgvAddingItem.DataSource = dtSearch;
            //kiem tra neu vat tu material da duoc su dung lien tu dong xoa khoi danh sach cap phat phuc vu sua chua
            dgvFilterRecursive();
        }
        public void dgvFilterRecursive()
        {          
            if (NewRepair_Beta.SummaryData != null)
            {
                for (int i = 0; i < dgvAddingItem.Rows.Count; i++)

                {
                    for (int j = 0; j < NewRepair_Beta.SummaryData.Rows.Count; j++)
                    {
                        if (Convert.ToInt32(dgvAddingItem.Rows[i].Cells["Ma_TS"].Value) == Convert.ToInt32(NewRepair_Beta.SummaryData.Rows[j]["VTX"]))
                        {
                            int Rowindex = dgvAddingItem.Rows[i].Index;
                            dgvAddingItem.Rows.RemoveAt(i);
                            dgvFilterRecursive();
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else if (NewRepair_Beta.SummaryData is null)
            {

            }

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (dgvAddingSelected.DataSource != null)
            {
                DataTable dtGridView1 = new DataTable();
                //dtGridView1 = (DataTable)dgvAddingItem.DataSource;
                //dtSource.Merge(dtGridView1);
                //dgvAddingSelected.DataSource = dtSource;
                foreach (DataGridViewColumn column in dgvAddingItem.Columns)
                {
                    dtGridView1.Columns.Add(column.HeaderText);
                }
                foreach (DataGridViewRow row in dgvAddingItem.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (CheckRow)
                    {
                        dtGridView1.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dtGridView1.Rows[dtGridView1.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }

                }
                //dtSource.Merge(dtGridView1);
                dgvAddingSelected.DataSource = dtGridView1;
            }
            else if (dgvAddingSelected.DataSource is null)
            {
                CopyGrid.CopyDataGridView(dgvAddingItem, dgvAddingSelected);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dtSummaryData.Columns.Add("MA_TS");
                dtSummaryData.Columns.Add("VTX");
                foreach (DataGridViewRow row in dgvAddingSelected.Rows)
                {
                    Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                    if (CheckRow)
                    {
                        DataRow dr = null;
                        dr = dtSummaryData.NewRow();
                        dr["MA_TS"] = lblRepairItemID.Text.ToString();
                        dr["VTX"] = row.Cells["MA_TS"].Value.ToString();
                        dtSummaryData.Rows.Add(dr);

                        //mainFrm.SummaryData = dtSummaryData;
                    }

                }
                if (NewRepair_Beta.SummaryData is null)
                {

                    NewRepair_Beta.SummaryData = dtSummaryData;
                }
                else if (NewRepair_Beta.SummaryData != null)
                {

                    NewRepair_Beta.SummaryData.Merge(dtSummaryData);
                }
                //MessageBox.Show("Success!");
                DialogResult dialog = MessageBox.Show("Luu thanh cong", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    this.Hide();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewForm frm = new PreviewForm();
            frm.SummaryData = NewRepair_Beta.SummaryData;
            frm.LoadAddingItemPreview();
            frm.ShowDialog();
        }
        public void ReviewAddedItem(int itemID)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "Select";
            column.Name = "Select";
            column.Visible = true;

            dgvAddingSelected.Columns.Add(column);
            dgvAddingSelected.Columns["Select"].DisplayIndex = 0;
            if (NewRepair_Beta.SummaryData != null)
            {
                DataRow[] dr = NewRepair_Beta.SummaryData.Select("Ma_TS = '" + Convert.ToInt32(itemID) + "'");
                foreach (DataRow row in dr)
                {
                    string strQuerry = strSearchPublic + " where a.Ma_TS = '" + row["VTX"].ToString() + "'";
                    OracleDataAdapter daAdded = new OracleDataAdapter(strQuerry, con);

                    daAdded.Fill(dt);

                    if (dt is null)
                    {
                        dtSource = dt;
                    }
                    else if (dt != null)
                    {
                        dtSource.Merge(dt);
                    }

                }
                dtSource.Merge(dt);
                dtSource = Clear.AntiTableRowDuplicate(dtSource, "Ma_TS");
                dgvAddingSelected.DataSource = dtSource;
            }
            else if (NewRepair_Beta.SummaryData is null)
            {
                MessageBox.Show("Chua khoi tao vat tu di kem!!!");
            }


        }

        private void btnDeleteAddedItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAddingSelected.Rows.Count; i++)
            {
                Boolean CheckRow = Convert.ToBoolean(dgvAddingSelected.Rows[i].Cells["Select"].Value);
                if(CheckRow)
                {
                    for (int j = 0; j < NewRepair_Beta.SummaryData.Rows.Count; j++)
                    {
                        if (Convert.ToInt32(dgvAddingSelected.Rows[i].Cells["Ma_TS"].Value) == Convert.ToInt32(NewRepair_Beta.SummaryData.Rows[j]["VTX"]))
                        {
                            NewRepair_Beta.SummaryData.Rows.RemoveAt(j);
                            dgvAddingSelected.Rows.RemoveAt(i);
                        }
                    }
                }
                

            }
            
        }
    }
}
