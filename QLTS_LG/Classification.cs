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
    public partial class Classification : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        AutoGenAsssetCode AutoGen = new AutoGenAsssetCode();

        public Classification()
        {
            InitializeComponent();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void tabDevice_Click(object sender, EventArgs e)
        {

        }

        private void Classification_Load(object sender, EventArgs e)
        {
            LoadTypeDevice();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main main = new Main();
            //main.ShowDialog();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            try
            {
                string TypeCode = "";
                AutoGenAsssetCode asssetCode = new AutoGenAsssetCode();
                asssetCode.AutoGenTypeCode();
                TypeCode = asssetCode.TypeCode;

                string strNewType = "Insert into Loai_TS_cap2 (Ma_loai, Ten_loai, Phan_loai) VALUES (@Type, @Name, @Class)";
                SqlCommand cmdNewType = new SqlCommand();
                cmdNewType.Connection = con;
                cmdNewType.CommandType = CommandType.Text;
                cmdNewType.CommandText = strNewType;
                cmdNewType.Parameters.AddWithValue("@Type", TypeCode.ToString());
                cmdNewType.Parameters.AddWithValue("@Name", txtType2Name.Text.ToString());
                cmdNewType.Parameters.AddWithValue("@Class", cbType1.SelectedValue);
                con.Open();
                cmdNewType.ExecuteNonQuery();
                con.Close();

                LoadTypeDevice();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTypeDevice()
        {
            LoadComboboxData loadCombobox = new LoadComboboxData();
            loadCombobox.LoadDataType1(cbType1);

            string strQuerryType = "SELECT a.Ma_loai, a.Ten_loai, b.Ten_loai " +
                "FROM Loai_TS_cap2 AS a " +
                " INNER JOIN Loai_TS_cap1 AS b ON a.Phan_loai = b.Ma_loai ORDER BY a.Ma_loai ASC";
            SqlDataAdapter daQuerryType = new SqlDataAdapter(strQuerryType, con);
            DataTable table = new DataTable();
            daQuerryType.Fill(table);
            dgvShow.DataSource = table;
            dgvShow.Columns[0].HeaderText = "Mã Số";
            dgvShow.Columns[1].HeaderText = "Loại Thiết Bị";
            dgvShow.Columns[2].HeaderText = "Phân Loại Tài Sản";

            string strQuerryUnit = "select * from Unit";
            SqlDataAdapter daQuerryUnit = new SqlDataAdapter(strQuerryUnit, con);
            DataTable dtUnit = new DataTable();
            daQuerryUnit.Fill(dtUnit);
            dgvUnit.DataSource = dtUnit;
            dgvUnit.Columns[0].HeaderText = "Mã đơn vị";
            dgvUnit.Columns[1].HeaderText = "Đơn vị tính";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int index = dgvShow.CurrentCell.RowIndex;
            txtType2Name.Text = dgvShow.Rows[index].Cells["Ten_loai"].Value.ToString();
            cbType1.Text = dgvShow.Rows[index].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = dgvShow.CurrentCell.RowIndex;
            string TypeCode = dgvShow.Rows[index].Cells["Ma_loai"].Value.ToString();

            string strUpdate = "update Loai_TS_cap2 set Ten_loai = '" + txtType2Name.Text.ToString() + "', Phan_loai = '" + cbType1.SelectedValue + "'" +
                "where Ma_loai = '" +TypeCode.ToString() + "'";
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = con;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = strUpdate;
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

            LoadTypeDevice();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = dgvShow.CurrentCell.RowIndex;
            string TypeCode = dgvShow.Rows[index].Cells["Ma_loai"].Value.ToString();

            string strDel = "delete from Loai_TS_cap2 where Ma_loai = '" + TypeCode + "'";
            SqlCommand cmdXoa = new SqlCommand();
            cmdXoa.Connection = con;
            cmdXoa.CommandType = CommandType.Text;
            cmdXoa.CommandText = strDel;
            con.Open();
            cmdXoa.ExecuteNonQuery();
            con.Close();

            LoadTypeDevice();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string unit_id = "";
                AutoGen.AutoGenUnit();
                unit_id = AutoGen.unit_id;
                string strNewUnit = "insert into Unit(unit_id, unit_name) values (@id, @name)";
                SqlCommand cmdUnit = new SqlCommand();
                cmdUnit.Connection = con;
                cmdUnit.CommandType = CommandType.Text;
                cmdUnit.CommandText = strNewUnit;
                cmdUnit.Parameters.AddWithValue("@id", unit_id);
                cmdUnit.Parameters.AddWithValue("@name", txtUnit.Text.ToString());
                con.Open();
                cmdUnit.ExecuteNonQuery();
                con.Close();

                LoadTypeDevice();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBacktoMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main main = new Main();
            //main.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int para = dgvUnit.CurrentCell.RowIndex;
            string Code = dgvUnit.Rows[para].Cells["unit_id"].Value.ToString();

            string strXoa = "delete from Unit where unit_id = '" + Code + "'";
            SqlCommand cmdXoa = new SqlCommand();
            cmdXoa.Connection = con;
            cmdXoa.CommandType = CommandType.Text;
            cmdXoa.CommandText = strXoa;
            con.Open();
            cmdXoa.ExecuteNonQuery();
            con.Close();

            LoadTypeDevice();
        }
    }
}
