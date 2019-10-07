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
    public partial class AddNewItem : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlConnection con2 = new SqlConnection(connectionString);
        SqlConnection con3 = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        DataTable dtLoaiTS1 = new DataTable();
        DataTable dtLoaiTS2 = new DataTable();
        DataTable dtStatus = new DataTable();
        Permission IT_OP = new Permission();




        bool flag = false;

        bool flag_2 = false;

        bool flag_3 = false;

        string clear = AutoComplete.Clear;

        UploadAndRetrieve Upload = new UploadAndRetrieve();

        LoadComboboxData loaddata = new LoadComboboxData();

        AutoCompleteStringCollection AutoCompleteString = new AutoCompleteStringCollection();

        AntiDuplicated CheckDup = new AntiDuplicated();

        public void AddItem()
        {
            //con.Open();
            try
            {
                con.Open();
                string InsertCMD = "INSERT INTO Tai_san (Ma_TS, Ten_TS, Ma_Loai_TS_cap1, Ma_Loai_TS_cap2,[dbo].[Tai_san].[S/N], FA_Tag, IT_Tag, Model, Spec, Ma_tinh_trang, Unit)"
                                  + "VALUES(@Ma_TS, @Ten_TS, @Ma_Loai_TS_cap1, @Ma_Loai_TS_cap2, @SN, @FA_Tag, @IT_Tag, @Model, @Spec, @Ma_tinh_trang, @Unit)";
                using (SqlCommand command = new SqlCommand(InsertCMD, con))
                {
                    // command.CommandType = Text;
                    command.Parameters.AddWithValue("@Ma_TS", txtMaTS.Text.ToString());
                    command.Parameters.AddWithValue("@Ten_TS", txtTenTS.Text.ToString());
                    command.Parameters.AddWithValue("@Ma_Loai_TS_cap1", cbTypeLV1.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@Ma_Loai_TS_cap2", cbTypeLV2.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@SN", txtSN.Text.ToUpper());
                    command.Parameters.AddWithValue("@FA_Tag", txtFATag.Text.ToUpper());
                    command.Parameters.AddWithValue("@IT_Tag", txtITTag.Text.ToUpper());
                    if (cbModel.SelectedValue != null && cbModel.Text.ToString() != "")
                    {
                        command.Parameters.AddWithValue("@Model", cbModel.SelectedValue.ToString());
                    }
                    else if (cbModel.SelectedValue == null)
                    {
                        command.Parameters.AddWithValue("@Model", cbModel.Text.ToString());
                    }
                    else if (cbModel.SelectedValue != null && cbModel.Text.ToString() == "")
                    {
                        command.Parameters.AddWithValue("@Model", cbModel.Text.ToString());
                    }
                    command.Parameters.AddWithValue("@Spec", txtSpec.Text.ToString());
                    command.Parameters.AddWithValue("@Ma_tinh_trang", cbStatus.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@Unit", cbUnit.SelectedValue.ToString());
                    command.ExecuteNonQuery();
                    //txtSoBB.ResetText();
                    //ReloadData();
                }
                con.Close();
                // command.Connection = con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //con.Close();


            try
            {

                con.Open();
                SqlCommand input = new SqlCommand();
                input.Connection = con;
                input.CommandType = CommandType.Text;
                input.CommandText = "INSERT INTO Nhap_Moi (So_BB, Ma_TS, Approved, IT_OP) " +
                                    "VALUES(@So_BB, @Ma_TS, @App, @ITOP)";
                input.Parameters.AddWithValue("@So_BB", txtSoBB.Text.ToString());
                input.Parameters.AddWithValue("@Ma_TS", txtMaTS.Text.ToString());
                input.Parameters.AddWithValue("@App", false);
                input.Parameters.AddWithValue("@ITOP", IT_OP.Get_IT_User());
                input.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            /*con.Open();
            SqlCommand Save = new SqlCommand();
            Save.Connection = con;
            Save.CommandType = CommandType.Text;
            Save.CommandText = "INSERT INTO Luu_kho (Ma_TS, Tinh_Trang, Ngay_update) VALUES (@Ma_TS, @Tinh_Trang, @Ngay_update)";
            Save.Parameters.AddWithValue("@Ma_TS", txtMaTS.Text.ToString());
            Save.Parameters.AddWithValue("@Tinh_Trang", "NE");
            Save.Parameters.AddWithValue("@Ngay_update", DateTime.Now.ToString());
            Save.ExecuteNonQuery();
            con.Close();*/

            ReloadData();
            //txtSoBB.ResetText();
            btnAddNew.Enabled = false;
        }

        public void ReloadData()
        {
            try
            {
                con.Open();
                DataTable data = new DataTable();
                data.Clear();
                SqlDataAdapter adapterdgv = new SqlDataAdapter(
                    "SELECT a.Ma_TS, a.Ten_TS, b.Ten_loai, c.Ten_loai, a.[S/N], a.FA_Tag, a.IT_Tag, a.Model, a.Spec, e.unit_name  " +
                    "FROM Tai_san AS a  " +
                    "INNER JOIN Loai_TS_cap1 AS b ON a.Ma_Loai_TS_cap1 = b.Ma_loai " +
                    "INNER JOIN Loai_TS_cap2 AS c ON a.Ma_Loai_TS_cap2 = c.Ma_loai " +
                    "inner join Unit as e on e.unit_id = a.Unit " +
                    "INNER JOIN Nhap_Moi AS d ON d.Ma_TS = a.Ma_TS  AND d.So_BB= '" + txtSoBB.Text.ToString() + "'", con);
                //adapterdgv.GetFillParameters
                //SqlDataAdapter loaddata = new SqlDataAdapter("SELECT * FROM Nhap_Moi");
                adapterdgv.Fill(data);
                //DataRow row = data.NewRow();
                //row["Mã Tài Sản"] = txtMaTS.Text.ToString();
                //data.Rows.Add(row);

                dataGridView1.DataSource = data;
                //dataGridView1.AutoResizeColumns();
                dataGridView1.Refresh();
                dataGridView1.Update();
                con.Close();
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

        public void LoadData()
        {
            LoadDataCBTypeLV1();
            LoadDataCBTypeLV2();
            LoadDataStatus();
            loaddata.LoadUnit(cbUnit);
            loaddata.LoadModel(cbModel);
            pnlInfo.Enabled = false;
            //cbStatus.Enabled = false;
            btnAddNew.Enabled = false;


        }

        public void LoadDataCBTypeLV1()
        {
            con.Open();
            string cmdLoaiTS1 = "SELECT * FROM Loai_TS_cap1";
            SqlCommand cmd = new SqlCommand(cmdLoaiTS1, con);
            SqlDataAdapter daLoaiTS1 = new SqlDataAdapter(cmd);
            daLoaiTS1.Fill(dtLoaiTS1);
            cbTypeLV1.DataSource = dtLoaiTS1;
            cbTypeLV1.DisplayMember = "Ten_loai";
            cbTypeLV1.ValueMember = "Ma_loai";
            cbTypeLV1.SelectedValue = "DE";
            cbTypeLV1.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void LoadDataCBTypeLV2()
        {
            con.Open();
            string cmdLoaiTS2 = "SELECT * FROM Loai_TS_cap2";
            SqlCommand cmd = new SqlCommand(cmdLoaiTS2, con);
            SqlDataAdapter daLoaiTS2 = new SqlDataAdapter(cmd);
            daLoaiTS2.Fill(dtLoaiTS2);
            cbTypeLV2.DataSource = dtLoaiTS2;
            cbTypeLV2.DisplayMember = "Ten_loai";
            cbTypeLV2.ValueMember = "Ma_loai";
            //cbTypeLV2.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void LoadDataStatus()
        {
            con.Open();
            string cmdStatus = "SELECT * FROM Status";
            SqlCommand cmd = new SqlCommand(cmdStatus, con);
            SqlDataAdapter daStatus = new SqlDataAdapter(cmd);
            daStatus.Fill(dtStatus);
            cbStatus.DataSource = dtStatus;
            cbStatus.ValueMember = "Ma_tinh_trang";
            cbStatus.DisplayMember = "Ten_tinh_trang";
            //cbStatus.SelectedIndex = 2;
            cbStatus.SelectedValue = "NE";
            cbStatus.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AutoAssetID()
        {

        }


        public AddNewItem()
        {
            InitializeComponent();
            LoadData();
            AutoComplete auto = new AutoComplete();

            string strAuto = "SELECT [S/N] FROM Tai_san";
            //txtSN.AutoCompleteCustomSource = auto.AutoCompleteData1(strAuto);
            //AutoComplete1();




        }

        public void AutoComplete1()
        {
            string strAuto = "SELECT [S/N] FROM Tai_san";
            SqlCommand cmdAuto = new SqlCommand();
            cmdAuto.CommandType = CommandType.Text;
            cmdAuto.CommandText = strAuto;
            cmdAuto.Connection = con;
            DataTable dtCollection = new DataTable();
            SqlDataAdapter daCollection = new SqlDataAdapter(cmdAuto);
            daCollection.Fill(dtCollection);
            if (dtCollection.Rows.Count > 0)
            {
                for (int i = 0; i < dtCollection.Rows.Count; i++)
                {
                    AutoCompleteString.Add(dtCollection.Rows[i]["S/N"].ToString());
                }
            }
            else
            {
                MessageBox.Show("Not Found!");
            }
            txtSN.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSN.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSN.AutoCompleteCustomSource = AutoCompleteString;
        }

        //DataSet DataSet = new DataSet();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlInfo.Enabled = false;
            btnAddNew.Enabled = false;
            btnSave.Enabled = false;
            //btnDelete.Enabled = false;

        }

        private void AddNewItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTSDataSet.Loai_TS_cap1' table. You can move, or remove it, as needed.
            //this.loai_TS_cap1TableAdapter.Fill(this.qLTSDataSet.Loai_TS_cap1);

            //this.reportViewer1.RefreshReport();


            //AutoComplete1();

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.loai_TS_cap1TableAdapter.FillBy(this.qLTSDataSet.Loai_TS_cap1);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

            if (CheckNewModel() == true)
            {
                MessageBox.Show("Choose the right model Type or input new model!!!");
                cbModel.ResetText();
            }

            else if (CheckNewModel() == false)
            {

                //Nhap gia tri vao table Bien_Ban
                //con.Open();
                SqlCommand command2 = new SqlCommand();
                command2.Connection = con;
                command2.CommandType = CommandType.Text;
                command2.CommandText = "INSERT INTO Bien_Ban (So_Bien_Ban, Ma_loai_BB, DATE, IT_OP) VALUES (@So_Bien_Ban, @Ma_loai_BB, @DATE, @ITOP)";
                command2.Parameters.AddWithValue("@So_Bien_Ban", txtSoBB.Text.ToString());
                command2.Parameters.AddWithValue("@Ma_loai_BB", "NE");
                command2.Parameters.AddWithValue("@DATE", DateTime.Now.ToString());
                command2.Parameters.AddWithValue("@ITOP", IT_OP.Get_IT_User());

                SqlDataAdapter SoBB = new SqlDataAdapter("SELECT So_Bien_ban FROM Bien_Ban", con);
                DataTable dtBB = new DataTable();
                SoBB.Fill(dtBB);
                int dtBBLastItemIndex = dtBB.Rows.Count - 1;


                if (dtBB.Rows.Count != 0)
                {
                    string LastItem = dtBB.Rows[dtBBLastItemIndex][0].ToString();

                    //kiểm tra giá trị Số Biên Bản nhập vào có bị trùng
                    if (txtSoBB.Text.ToString() != LastItem)
                    {
                        con.Open();
                        command2.ExecuteNonQuery();
                        //txtSoBB.ResetText();
                        con.Close();
                    }
                    else
                    {

                    }
                }
                else if (dtBB.Rows.Count == 0)
                {
                    con.Open();
                    command2.ExecuteNonQuery();
                    con.Close();
                }

                CheckDup.CheckModel(cbModel, cbTypeLV2);

                if (cbTypeLV1.SelectedValue.ToString().Trim() == "DE")
                {

                    string strCheck = "SELECT [S/N], FA_Tag, IT_Tag FROM Tai_san WHERE Ma_Loai_TS_cap1 = 'DE'";
                    SqlDataAdapter daCheck = new SqlDataAdapter(strCheck, con);
                    DataTable dtCheck = new DataTable();
                    daCheck.Fill(dtCheck);

                    SqlCommand cmdCheck = new SqlCommand(strCheck, con);
                    SqlDataReader rdrCheck = null;

                    con.Open();
                    rdrCheck = cmdCheck.ExecuteReader();
                    while (rdrCheck.Read())
                    {
                        if (txtFATag.Text.ToUpper() == rdrCheck["FA_Tag"].ToString() && rdrCheck["FA_Tag"].ToString() != "")
                        {
                            flag = true;
                            break;

                        }
                        if (txtITTag.Text.ToUpper() == rdrCheck["IT_Tag"].ToString() && rdrCheck["IT_Tag"].ToString() != "")
                        {
                            flag_2 = true;
                            break;
                        }
                        if (txtSN.Text.ToUpper() == rdrCheck["S/N"].ToString() && rdrCheck["S/N"].ToString() != "")
                        {
                            flag_3 = true;
                            break;
                        }
                    }
                    con.Close();

                    if (flag == true || flag_2 == true || flag_3 == true)
                    {
                        MessageBox.Show("Giá trị nhập bị trùng. Vui lòng kiểm tra lại!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFATag.ResetText();
                        txtITTag.ResetText();
                        txtSN.ResetText();
                        flag = false;
                        flag_2 = false;
                        flag_3 = false;
                    }

                    if (txtITTag.Text == "" && txtFATag.Text == "" && txtSN.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin IT_Tag, FA_Tag, S/N!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        AddItem();
                    }


                }
                else
                {

                    AddItem();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Anh chị muốn đóng biên bản?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                btnCloseBB_Click(this, new EventArgs());
                Main frm = new Main();
                this.Hide();

                this.Close();
                frm.OutStorageLoad();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AutoGenAsssetCode autoGen = new AutoGenAsssetCode();
            autoGen.AutoGenCode();
            txtMaTS.Text = autoGen.code;
            btnAddNew.Enabled = true;
            btnNewItem2.Enabled = true;
            cbTypeLV2.Enabled = false;
            loaddata.LoadModel(cbModel);
            txtFATag.ResetText();
            txtITTag.ResetText();
            txtSN.ResetText();
        }

        private void btnNewBBNo_Click(object sender, EventArgs e)
        {
            //int i = 0;
            AutoGenBB autoGen = new AutoGenBB();
            autoGen.AutoGenBBBG();
            txtSoBB.Text = autoGen.SoBBBG;
            pnlInfo.Enabled = true;
            btnNewBBNo.Enabled = false;
            txtSoBB.Enabled = false;
            cbTypeLV2.Enabled = false;
            //lblSoBB.Text = txtSoBB.Text;
        }

        private void btnCloseBB_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Anh/chị có chắc chắn?", "Warning!!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                txtSoBB.Enabled = true;
                btnNewBBNo.Enabled = true;
                pnlInfo.Enabled = false;
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            pnlInfo.Enabled = true;
            btnSave.Enabled = true;
            //txtMaTS.Enabled = false;

            int index = dataGridView1.CurrentCell.RowIndex;


            txtMaTS.Text = dataGridView1.Rows[index].Cells["Ma_TS"].Value.ToString();
            txtTenTS.Text = dataGridView1.Rows[index].Cells["Ten_TS"].Value.ToString();
            cbTypeLV1.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            cbTypeLV2.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            txtITTag.Text = dataGridView1.Rows[index].Cells["IT_Tag"].Value.ToString();
            txtFATag.Text = dataGridView1.Rows[index].Cells["FA_Tag"].Value.ToString();
            txtSN.Text = dataGridView1.Rows[index].Cells["S/N"].Value.ToString();
            txtSpec.Text = dataGridView1.Rows[index].Cells["Spec"].Value.ToString();
            cbModel.Text = dataGridView1.Rows[index].Cells["Model"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //txtMaTS.Enabled = false;
                int AsCodeIndex = dataGridView1.CurrentCell.RowIndex;
                string strAssetCode = dataGridView1.Rows[AsCodeIndex].Cells["Ma_TS"].Value.ToString();
                string strUpdate = "UPDATE Tai_san SET Ten_TS = @Ten_TS, Ma_Loai_TS_cap1 = @Ma_Loai_TS_cap1, " +
                    "Ma_Loai_TS_cap2 = @Ma_Loai_TS_cap2, [S/N] = @SN, FA_Tag = @FA_Tag, IT_Tag = @IT_Tag, Model = @Model, Spec = @Spec " +
                    "WHERE Ma_TS = '" + strAssetCode + "'";
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = con;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = strUpdate;
                cmdUpdate.Parameters.AddWithValue("@Ten_TS", txtTenTS.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@Ma_Loai_TS_cap1", cbTypeLV1.SelectedValue);
                cmdUpdate.Parameters.AddWithValue("@Ma_Loai_TS_cap2", cbTypeLV2.SelectedValue);
                cmdUpdate.Parameters.AddWithValue("@SN", txtSN.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@FA_Tag", txtFATag.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@IT_Tag", txtITTag.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@Model", cbModel.SelectedValue.ToString());
                cmdUpdate.Parameters.AddWithValue("@Spec", txtSpec.Text.ToString());
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();

                ReloadData();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int AssCodeIndex = dataGridView1.CurrentCell.RowIndex;
            string strAssCode = dataGridView1.Rows[AssCodeIndex].Cells["Ma_TS"].Value.ToString();
            string strDelete = "DELETE FROM Nhap_Moi WHERE Ma_TS = '" + strAssCode + "'";
            string strDelete1 = "DELETE FROM Luu_kho WHERE Ma_TS = '" + strAssCode + "'";

            SqlCommand del1 = new SqlCommand();
            del1.Connection = con;
            del1.CommandType = CommandType.Text;
            del1.CommandText = strDelete;

            SqlCommand del2 = new SqlCommand();
            del2.Connection = con;
            del2.CommandType = CommandType.Text;
            del2.CommandText = strDelete1;
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbTypeLV1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeLV1.SelectedValue.ToString().Trim() == "TO")
            {
                txtFATag.Enabled = false;
                txtFATag.ResetText();
                txtITTag.Enabled = false;
                txtITTag.ResetText();
                txtSN.Enabled = false;
                txtSN.ResetText();
                cbModel.Enabled = false;
                //txtModel.ResetText();
                cbModel.ResetText();

                con.Open();
                string SelectTO = "SELECT * FROM Loai_TS_cap2 WHERE Phan_loai='" + cbTypeLV1.SelectedValue.ToString().Trim() + "'";
                SqlCommand cmdLoad = new SqlCommand();
                cmdLoad.Connection = con;
                cmdLoad.CommandType = CommandType.Text;
                cmdLoad.CommandText = SelectTO;
                SqlDataAdapter adapter = new SqlDataAdapter(cmdLoad);
                DataTable dtTS = new DataTable();
                adapter.Fill(dtTS);
                cbTypeLV2.DataSource = dtTS;
                cbTypeLV2.DisplayMember = "Ten_loai";
                cbTypeLV2.ValueMember = "Ma_loai";
                cbTypeLV2.Enabled = true;
                cmdLoad.ExecuteNonQuery();
                con.Close();
            }
            else if (cbTypeLV1.SelectedValue.ToString().Trim() == "MAT")
            {
                txtSN.Enabled = false;
                txtSN.ResetText();
                cbModel.Enabled = false;
                //txtModel.ResetText();
                txtITTag.Enabled = false;
                txtITTag.ResetText();
                txtFATag.Enabled = false;
                txtFATag.ResetText();
                cbModel.ResetText();

                con.Open();
                string SelectTO = "SELECT * FROM Loai_TS_cap2 WHERE Phan_loai='" + cbTypeLV1.SelectedValue.ToString().Trim() + "'";
                SqlCommand cmdLoad = new SqlCommand();
                cmdLoad.Connection = con;
                cmdLoad.CommandType = CommandType.Text;
                cmdLoad.CommandText = SelectTO;
                SqlDataAdapter adapter = new SqlDataAdapter(cmdLoad);
                DataTable dtTS = new DataTable();
                adapter.Fill(dtTS);
                cbTypeLV2.DataSource = dtTS;
                cbTypeLV2.DisplayMember = "Ten_loai";
                cbTypeLV2.ValueMember = "Ma_loai";
                cbTypeLV2.Enabled = true;

                cmdLoad.ExecuteNonQuery();
                con.Close();
            }
            else if (cbTypeLV1.SelectedValue.ToString().Trim() == "DE")
            {
                txtFATag.Enabled = true;
                txtITTag.Enabled = true;
                txtSN.Enabled = true;
                cbModel.Enabled = true;

                con.Open();
                string SelectTO = "SELECT * FROM Loai_TS_cap2 WHERE Phan_loai='" + cbTypeLV1.SelectedValue.ToString().Trim() + "'";
                SqlCommand cmdLoad = new SqlCommand();
                cmdLoad.Connection = con;
                cmdLoad.CommandType = CommandType.Text;
                cmdLoad.CommandText = SelectTO;
                SqlDataAdapter adapter = new SqlDataAdapter(cmdLoad);
                DataTable dtTS = new DataTable();
                adapter.Fill(dtTS);
                cbTypeLV2.DataSource = dtTS;
                cbTypeLV2.DisplayMember = "Ten_loai";
                cbTypeLV2.ValueMember = "Ma_loai";
                cbTypeLV2.Enabled = true;
                cmdLoad.ExecuteNonQuery();
                con.Close();
            }

            cbTypeLV2.Enabled = true;
        }

        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            //Upload.UploadToDB(txtSoBB);
        }

        public void InputEPApproval(string varFilePath)
        {
            byte[] file;
            FileStream Stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read);

            BinaryReader reader = new BinaryReader(Stream);

            file = reader.ReadBytes((int)Stream.Length);


            SqlConnection con2 = new SqlConnection(connectionString);
            SqlCommand Sqlwrite = new SqlCommand("UPDATE Bien_Ban SET File_attach = @File WHERE So_Bien_ban = @SoBB", con2);
            Sqlwrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
            Sqlwrite.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
            con2.Open();
            Sqlwrite.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Upload successful!!");
        }

        private void cbTypeLV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string TypeLV2 = "";
                string strTypeLV2 = "select Ma_loai from Loai_TS_cap2 where Ma_loai = '" + cbTypeLV2.SelectedValue.GetHashCode() + "'";
                SqlDataAdapter daLoadTypeLV2 = new SqlDataAdapter(strTypeLV2, con);
                DataTable dtTypeLV2 = new DataTable();
                daLoadTypeLV2.Fill(dtTypeLV2);
                if (dtTypeLV2.Rows.Count == 0)
                {
                    TypeLV2 = "";
                }
                else if (dtTypeLV2.Rows.Count != 0)
                {
                    TypeLV2 = dtTypeLV2.Rows[0][0].ToString();
                }

                string strModel = "select * from Model where type_code = '" + TypeLV2 + "'";

                SqlDataAdapter daModel = new SqlDataAdapter(strModel, con);
                DataTable dtModel = new DataTable();
                daModel.Fill(dtModel);
                cbModel.DataSource = dtModel;
                cbModel.DisplayMember = "model";
                cbModel.ValueMember = "model";
                cbModel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            Upload.UploadToFileServer(txtSoBB, openFileDialog1);
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                /*
                //con2.Open();
                string strType2 = "select * from Loai_TS_cap2 where Ma_loai = '" + type_code + "'";
                //SqlCommand cmdType2 = new SqlCommand(strType2, con2);
                //SqlDataAdapter daType2 = new SqlDataAdapter(cmdType2);
                SqlDataAdapter daType2 = new SqlDataAdapter(strType2, con);
                DataTable dtType2 = new DataTable();
                daType2.Fill(dtType2);
                cbTypeLV2.DataSource = dtType2;
                cbTypeLV2.DisplayMember = "Ten_loai";
                cbTypeLV2.ValueMember = "Ma_loai";
                //cbTypeLV2.Enabled = true;
                //cmdType2.ExecuteNonQuery();
                //con2.Close();
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBack2_Click(object sender, EventArgs e)
        {

            btnCloseBB_Click(this, new EventArgs());
            //Main frm = new Main();
            this.Hide();
            //frm.ShowDialog();
            this.Close();
        }

        private void btnNewItem2_Click(object sender, EventArgs e)
        {
            btnAddNew_Click(this, new EventArgs());
            btnNewItem2.Enabled = false;
        }
        public bool CheckNewModel()
        {
            string strLoadModel = "";
            bool flagModel = false;
            string type_code = "";
            SqlDataAdapter daModelChk = new SqlDataAdapter();
            DataTable dtModelChk = new DataTable();

            if (cbModel.SelectedValue == null)
            {
                CheckDup.CheckModel(cbModel, cbTypeLV2);
                flagModel = false;
            }
            else if(cbModel.SelectedValue != null)
            {
                strLoadModel = "select type_code from Model where model = '" + cbModel.SelectedValue.ToString().Trim() + "'";
                daModelChk = new SqlDataAdapter(strLoadModel, con);
                daModelChk.Fill(dtModelChk);
                type_code = dtModelChk.Rows[0][0].ToString();
                if(cbTypeLV2.SelectedValue.ToString().Trim() == type_code)
                {
                    flagModel = false;
                }
                else if(cbTypeLV2.SelectedValue.ToString().Trim() != type_code)
                {
                    flagModel = true;
                }
            }
 
            return flagModel;

        }
    }
}

