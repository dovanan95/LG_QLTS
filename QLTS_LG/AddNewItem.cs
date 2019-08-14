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
    public partial class AddNewItem : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        DataTable dtLoaiTS1 = new DataTable();
        DataTable dtLoaiTS2 = new DataTable();
        DataTable dtStatus = new DataTable();

        bool flag = false;

        bool flag_2 = false;

        bool flag_3 = false;

        UploadAndRetrieve Upload = new UploadAndRetrieve();

        LoadComboboxData loaddata = new LoadComboboxData();

        AutoCompleteStringCollection AutoCompleteString = new AutoCompleteStringCollection();

        public void AddItem()
        {
            con.Open();
            try
            {
                //con.Open();
                string InsertCMD = "INSERT INTO Tai_san (Ma_TS, Ten_TS, Ma_Loai_TS_cap1, Ma_Loai_TS_cap2,[dbo].[Tai_san].[S/N], FA_Tag, IT_Tag, Model, Spec, Ma_tinh_trang, Unit)"
                                  + "VALUES(@Ma_TS, @Ten_TS, @Ma_Loai_TS_cap1, @Ma_Loai_TS_cap2, @SN, @FA_Tag, @IT_Tag, @Model, @Spec, @Ma_tinh_trang, @Unit)";
                using (SqlCommand command = new SqlCommand(InsertCMD, con))
                {
                    // command.CommandType = Text;
                    command.Parameters.AddWithValue("@Ma_TS", txtMaTS.Text.ToString());
                    command.Parameters.AddWithValue("@Ten_TS", txtTenTS.Text.ToString());
                    command.Parameters.AddWithValue("@Ma_Loai_TS_cap1", cbTypeLV1.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@Ma_Loai_TS_cap2", cbTypeLV2.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@SN", txtSN.Text.ToString());
                    command.Parameters.AddWithValue("@FA_Tag", txtFATag.Text.ToString());
                    command.Parameters.AddWithValue("@IT_Tag", txtITTag.Text.ToString());
                    command.Parameters.AddWithValue("@Model", txtModel.Text.ToString());
                    command.Parameters.AddWithValue("@Spec", txtSpec.Text.ToString());
                    command.Parameters.AddWithValue("@Ma_tinh_trang", cbStatus.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@Unit", cbUnit.SelectedValue.ToString());
                    command.ExecuteNonQuery();
                    //txtSoBB.ResetText();
                    //ReloadData();
                }
                // con.Close();
                // command.Connection = con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();



            con.Open();
            SqlCommand input = new SqlCommand();
            input.Connection = con;
            input.CommandType = CommandType.Text;
            input.CommandText = "INSERT INTO Nhap_Moi (So_BB, Ma_TS) " +
                                "VALUES(@So_BB, @Ma_TS)";
            input.Parameters.AddWithValue("@So_BB", txtSoBB.Text.ToString());
            input.Parameters.AddWithValue("@Ma_TS", txtMaTS.Text.ToString());
            input.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand Save = new SqlCommand();
            Save.Connection = con;
            Save.CommandType = CommandType.Text;
            Save.CommandText = "INSERT INTO Luu_kho (Ma_TS, Tinh_Trang, Ngay_update) VALUES (@Ma_TS, @Tinh_Trang, @Ngay_update)";
            Save.Parameters.AddWithValue("@Ma_TS", txtMaTS.Text.ToString());
            Save.Parameters.AddWithValue("@Tinh_Trang", "NE");
            Save.Parameters.AddWithValue("@Ngay_update", DateTime.Now.ToString());
            Save.ExecuteNonQuery();
            con.Close();

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
        }

        public void LoadData()
        {
            LoadDataCBTypeLV1();
            LoadDataCBTypeLV2();
            LoadDataStatus();
            loaddata.LoadUnit(cbUnit);
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
            cbTypeLV2.Enabled = true;
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
            this.loai_TS_cap1TableAdapter.Fill(this.qLTSDataSet.Loai_TS_cap1);

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
            //Nhap gia tri vao table Bien_Ban
            //con.Open();
            SqlCommand command2 = new SqlCommand();
            command2.Connection = con;
            command2.CommandType = CommandType.Text;
            command2.CommandText = "INSERT INTO Bien_Ban (So_Bien_Ban, Ma_loai_BB, DATE) VALUES (@So_Bien_Ban, @Ma_loai_BB, @DATE)";
            command2.Parameters.AddWithValue("@So_Bien_Ban", txtSoBB.Text.ToString());
            command2.Parameters.AddWithValue("@Ma_loai_BB", "NE");
            command2.Parameters.AddWithValue("@DATE", DateTime.Now.ToString());

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
                    if (txtFATag.Text.ToString() == rdrCheck["FA_Tag"].ToString() && rdrCheck["FA_Tag"].ToString() != "")
                    {
                        flag = true;
                        break;
                       
                    }
                    if(txtITTag.Text.ToString() == rdrCheck["IT_Tag"].ToString() && rdrCheck["IT_Tag"].ToString() != "")
                    {
                        flag_2 = true;
                        break;
                    }
                    if(txtSN.Text.ToString() == rdrCheck["S/N"].ToString() && rdrCheck["S/N"].ToString() != "")
                    {
                        flag_3 = true;
                        break;
                    }
                }
                con.Close();

                if(flag == true || flag_2 == true || flag_3 == true)
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Anh chị muốn đóng biên bản?", "Cảnh báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                btnCloseBB_Click(this, new EventArgs());
                Main frm = new Main();
                this.Hide();
                //frm.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AutoGenAsssetCode autoGen = new AutoGenAsssetCode();
            autoGen.AutoGenCode();
            txtMaTS.Text = autoGen.code;
            btnAddNew.Enabled = true;
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
            txtModel.Text = dataGridView1.Rows[index].Cells["Model"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            cmdUpdate.Parameters.AddWithValue("@Model", txtModel.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@Spec", txtSpec.Text.ToString());
            con.Open();
            cmdUpdate.ExecuteNonQuery();
            con.Close();

            ReloadData();
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
                txtModel.Enabled = true;
                txtModel.ResetText();

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
                txtModel.Enabled = false;
                txtModel.ResetText();
                txtITTag.Enabled = false;
                txtITTag.ResetText();
                txtFATag.Enabled = false;
                txtFATag.ResetText();

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
                txtModel.Enabled = true;

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

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            /*try
            {

                //Save file path
                string folderPath = @"\\10.224.50.100\\Share_all\\EP Approval\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string strInsertFile = "UPDATE Bien_Ban SET File_attach = @Path WHERE So_Bien_ban = @SoBB";
                SqlCommand cmdUpdateFile = new SqlCommand();
                cmdUpdateFile.Connection = con;
                cmdUpdateFile.CommandType = CommandType.Text;
                cmdUpdateFile.CommandText = strInsertFile;
                cmdUpdateFile.Parameters.AddWithValue("@Path", folderPath + Path.GetFileName(this.openFileDialog1.FileName));
                cmdUpdateFile.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
                con.Open();
                cmdUpdateFile.ExecuteNonQuery();
                con.Close();

                //Upload file to server
                string filelocation = openFileDialog1.FileName;
                File.Copy(filelocation, Path.Combine(@"\\10.224.50.100\\Share_all\\EP Approval\\", Path.GetFileName(filelocation)), true);

                MessageBox.Show("Finished!!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            Upload.UploadToFileServer(txtSoBB, openFileDialog1);
        }
    }
}

