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
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class Classification : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleConnection con2 = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();
        AutoGenAsssetCode AutoGen = new AutoGenAsssetCode();
        AntiDuplicated AntiDuplicated = new AntiDuplicated();
        LoadComboboxData LoadCombobox = new LoadComboboxData();

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

                string strNewType = "Insert into Loai_TS_cap2 (Ma_loai, Ten_loai, Phan_loai) VALUES (:Type, :Name, :Class)";
                OracleCommand cmdNewType = new OracleCommand();
                cmdNewType.Connection = con;
                cmdNewType.CommandType = CommandType.Text;
                cmdNewType.CommandText = strNewType;
                cmdNewType.Parameters.Add("Type", TypeCode.ToString());
                cmdNewType.Parameters.Add("Name", txtType2Name.Text.ToString());
                cmdNewType.Parameters.Add("Class", cbType1.SelectedValue);
                if (AntiDuplicated.CheckTypeLevel2(txtType2Name.Text.ToString().Trim(), cbType1.SelectedValue.ToString()))
                {
                    con.Open();
                    cmdNewType.ExecuteNonQuery();
                    con.Close();
                }
                else if (!(AntiDuplicated.CheckTypeLevel2(txtType2Name.Text.ToString().Trim(), cbType1.SelectedValue.ToString())))
                {
                    MessageBox.Show("Trùng!!!");
                }

                LoadTypeDevice();
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
        private void LoadTypeDevice()
        {
            LoadComboboxData loadCombobox = new LoadComboboxData();
            loadCombobox.LoadDataType1(cbType1);
            loadCombobox.LoadDataType(cbTypeLV2);
            loadCombobox.LoadDataType1(cbTypeLevel1);

            string strQuerryType = "SELECT a.Ma_loai, a.Ten_loai, b.Ten_loai " +
                "FROM Loai_TS_cap2 a " +
                " INNER JOIN Loai_TS_cap1 b ON a.Phan_loai = b.Ma_loai ORDER BY a.Ma_loai ASC";
            OracleDataAdapter daQuerryType = new OracleDataAdapter(strQuerryType, con);
            DataTable table = new DataTable();
            daQuerryType.Fill(table);
            dgvShow.DataSource = table;
            dgvShow.Columns[0].HeaderText = "Mã Số";
            dgvShow.Columns[1].HeaderText = "Loại Thiết Bị";
            dgvShow.Columns[2].HeaderText = "Phân Loại Tài Sản";

            string strQuerryUnit = "select * from Unit";
            OracleDataAdapter daQuerryUnit = new OracleDataAdapter(strQuerryUnit, con);
            DataTable dtUnit = new DataTable();
            daQuerryUnit.Fill(dtUnit);
            dgvUnit.DataSource = dtUnit;
            dgvUnit.Columns[0].HeaderText = "Mã đơn vị";
            dgvUnit.Columns[1].HeaderText = "Đơn vị tính";

            string QuerryModel = "select a.model_code, a.model, b.ten_loai, b.ma_loai from model a inner join loai_ts_cap2 b on a.type_code = b.ma_loai order by to_number(a.model_code)";
            OracleDataAdapter daModel = new OracleDataAdapter(QuerryModel, con);
            DataTable dtModel = new DataTable();
            daModel.Fill(dtModel);
            dgvModel.DataSource = dtModel;
            dgvModel.Columns[1].HeaderText = "Model";

            cbTypeLV2.Enabled = false;
            txtModelName.Enabled = false;
            btnAddModel.Enabled = false;

            if (Login.username == "an.do")
            {
                btnXoa.Enabled = true;
            }
            else if (Login.username != "an.do")
            {
                btnXoa.Visible = false;
            }
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
                "where Ma_loai = '" + TypeCode.ToString() + "'";
            OracleCommand cmdUpdate = new OracleCommand();
            cmdUpdate.Connection = con;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = strUpdate;
            if (AntiDuplicated.TypeModify(TypeCode) == true)
            {
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();
            }
            else if (AntiDuplicated.TypeModify(TypeCode) == false)
            {
                MessageBox.Show("Dữ liệu tài sản đã tồn tại. Anh chị không được phép sửa đổi.");
            }

            LoadTypeDevice();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = dgvShow.CurrentCell.RowIndex;
            string TypeCode = dgvShow.Rows[index].Cells["Ma_loai"].Value.ToString();

            string strDel = "delete from Loai_TS_cap2 where Ma_loai = '" + TypeCode + "'";
            OracleCommand cmdXoa = new OracleCommand();
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
                OracleCommand cmdUnit = new OracleCommand();
                cmdUnit.Connection = con;
                cmdUnit.CommandType = CommandType.Text;
                cmdUnit.CommandText = strNewUnit;
                cmdUnit.Parameters.Add("@id", unit_id);
                cmdUnit.Parameters.Add("@name", txtUnit.Text.ToString());
                con.Open();
                cmdUnit.ExecuteNonQuery();
                con.Close();

                LoadTypeDevice();
            }
            catch (Exception ex)
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
            OracleCommand cmdXoa = new OracleCommand();
            cmdXoa.Connection = con;
            cmdXoa.CommandType = CommandType.Text;
            cmdXoa.CommandText = strXoa;
            con.Open();
            cmdXoa.ExecuteNonQuery();
            con.Close();

            LoadTypeDevice();
        }

        private void cbTypeLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string querry = "select * from loai_ts_cap2 where phan_loai = '" + cbTypeLevel1.SelectedValue.ToString() + "' order by Ten_loai";
            OracleDataAdapter daquerry = new OracleDataAdapter(querry, con);
            DataTable dtquerry = new DataTable();
            daquerry.Fill(dtquerry);
            cbTypeLV2.DataSource = dtquerry;
            cbTypeLV2.ValueMember = "Ma_loai";
            cbTypeLV2.DisplayMember = "Ten_loai";
            cbTypeLV2.Enabled = true;
        }

        private void cbTypeLV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtModelName.Enabled = true;
            btnAddModel.Enabled = true;
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            if (!(txtModelName.Text is null))
            {
                AntiDuplicated.CheckModel2(txtModelName.Text.ToString(), Convert.ToInt32(cbTypeLV2.SelectedValue));
                LoadTypeDevice();
            }
            else if (txtModelName.Text is null)
            {
                MessageBox.Show("Nhập tên Model!!!");
            }
        }

        private void btnBackModel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateModel_Click(object sender, EventArgs e)
        {
            int index = dgvModel.CurrentCell.RowIndex;
            txtModelName.Text = dgvModel.Rows[index].Cells["MODEL"].Value.ToString();
            cbTypeLevel1.Enabled = false;
            cbTypeLV2.Enabled = false;
            txtModelName.Enabled = true;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = dgvModel.CurrentCell.RowIndex;
            string model_code = dgvModel.Rows[index].Cells["MODEL_CODE"].Value.ToString();
            string model_name = dgvModel.Rows[index].Cells["MODEL"].Value.ToString();
            int model_type_code = Convert.ToInt32(dgvModel.Rows[index].Cells["ma_loai"].Value);

            string typeLevel2 = dgvModel.Rows[index].Cells["TEN_LOAI"].Value.ToString();
            string updateModel = "update Model set model = '" + txtModelName.Text.ToString() + "' where model_code = '" + model_code + "'";
            OracleCommand cmdupdatemodel = new OracleCommand(updateModel, con);
            string duplicatedmodelname = "select * from model where model = '" + txtModelName.Text.ToString().Trim() + "' and type_code = " + model_type_code;
            OracleDataAdapter dacheckduplicate = new OracleDataAdapter(duplicatedmodelname, con2);
            DataTable dtcheck = new DataTable();
            dacheckduplicate.Fill(dtcheck);

            if (dtcheck.Rows.Count == 0)
            {
                if (AntiDuplicated.ModelModify(model_name, model_type_code) == true)
                {
                    con.Open();
                    cmdupdatemodel.ExecuteNonQuery();
                    con.Close();
                }
                else if (AntiDuplicated.ModelModify(model_name, model_type_code) == false)
                {
                    MessageBox.Show("Model đã được sử dụng. Anh chị không được phép thay đổi thông tin.");
                }
            }
            else if (dtcheck.Rows.Count > 0)
            {
                MessageBox.Show("Trùng!!!");
            }
            cbTypeLV2.Enabled = true;
            cbTypeLevel1.Enabled = true;
            LoadTypeDevice();
        }
    }
}
