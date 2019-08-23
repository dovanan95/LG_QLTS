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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QLTS_LG
{
    public partial class Distribute : Form
    {
        public string strSearch = "SELECT a.Ma_TS, b.Ten_TS, b.[S/N], b.[FA_Tag], b.IT_Tag, b.Model, c.Ten_loai, d.Ten_tinh_trang " +
               "FROM Luu_kho AS a " +
               "INNER JOIN  Tai_san AS b ON a.Ma_TS = b.Ma_TS " +
               "INNER JOIN Loai_TS_cap2 AS c ON b.Ma_Loai_TS_cap2 = c.Ma_loai " +
               "INNER JOIN Status AS d ON d.Ma_tinh_trang = b.Ma_tinh_trang " +
               "INNER JOIN Loai_TS_cap2 AS e ON e.Ma_loai = b.Ma_Loai_TS_cap2 ";

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();

        Permission IT_OP = new Permission();

        UserUpdate update = new UserUpdate();

        public void LoadDataStatus()
        {
            con.Open();
            string cmdStatus = "SELECT * FROM Status";
            SqlCommand cmd = new SqlCommand(cmdStatus, con);
            DataTable dtStatus = new DataTable();
            SqlDataAdapter daStatus = new SqlDataAdapter(cmd);
            daStatus.Fill(dtStatus);
            cbStatus.DataSource = dtStatus;
            cbStatus.ValueMember = "Ma_tinh_trang";
            cbStatus.DisplayMember = "Ten_tinh_trang";
            //cbStatus.SelectedIndex = 2;
            //cbStatus.SelectedValue = "NE";
            cbStatus.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void LoadDataType()
        {
            con.Open();
            string cmdLoaiTS2 = "SELECT * FROM Loai_TS_cap2";
            SqlCommand cmd = new SqlCommand(cmdLoaiTS2, con);
            DataTable dtLoaiTS2 = new DataTable();
            SqlDataAdapter daLoaiTS2 = new SqlDataAdapter(cmd);
            daLoaiTS2.Fill(dtLoaiTS2);
            cbType.DataSource = dtLoaiTS2;
            cbType.DisplayMember = "Ten_loai";
            cbType.ValueMember = "Ma_loai";
            cbType.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Distribute()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            AutoGenBB genBB = new AutoGenBB();
            genBB.AutoGenBBBG();
            txtSoBB.Text = genBB.SoBBBG;
            pnlControl.Enabled = true;
        }

        private void Distribute_Load(object sender, EventArgs e)
        {
            LoadDataStatus();
            LoadDataType();
            btnBrowse.Enabled = false;
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.HeaderText = "Select";
            column.Name = "Select";
            column.Visible = true;

            dataGridView1.Columns.Add(column);
            dataGridView1.Columns["Select"].DisplayIndex = 0;
            pnlControl.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main frm = new Main();
            //frm.ShowDialog();
        }

        private void brnSearch_Click(object sender, EventArgs e)
        {
            if (txtSN.Text.ToString() != "")
            {
                string SN = strSearch + " where b.[S/N] = '" + txtSN.Text.ToString() + "'";
                SqlDataAdapter daSN = new SqlDataAdapter(SN, con);
                DataTable dtSN = new DataTable();
                daSN.Fill(dtSN);
                dataGridView1.DataSource = dtSN;
            }
            else if (txtFA_Tag.Text.ToString() != "")
            {
                string FA = strSearch + " where b.[FA_Tag] = '" + txtFA_Tag.Text.ToString() + "'";
                SqlDataAdapter daFA = new SqlDataAdapter(FA, con);
                DataTable dtFA = new DataTable();
                daFA.Fill(dtFA);
                dataGridView1.DataSource = dtFA;
            }
            else if(txtIT_Tag.Text.ToString() != "")
            {
                string IT = strSearch + " where b.IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";
                SqlDataAdapter daIT = new SqlDataAdapter(IT, con);
                DataTable dtIT = new DataTable();
                daIT.Fill(dtIT);
                dataGridView1.DataSource = dtIT;
            }
            else if(txtSN.Text.ToString() == "" && txtIT_Tag.Text.ToString() == "" && txtFA_Tag.Text.ToString() == "")
            {
                DataTable dtSearch = new DataTable();
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = con;
                cmdSearch.CommandType = CommandType.Text;
                cmdSearch.CommandText = strSearch;
                
                SqlDataAdapter daSearch = new SqlDataAdapter(cmdSearch);
                daSearch.Fill(dtSearch);
                dataGridView1.DataSource = dtSearch;
            }
            dataGridView1.Columns["Select"].DisplayIndex = 0;

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            //check xem bang 2 co column nao chua, neu chua co thi thuc thi lenh duoi day
            if (dataGridView2.Columns.Count == 0)
            {
                //duyet tat ca cac cot cua bang 1
                foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
                {
                    //chuyen cac cot cua bang 1 ve dang clone (khong so huu) sau do add vao bang 2
                    dataGridView2.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                }

            }
            //tao doi tuong row trong datagridviewrow
            DataGridViewRow row = new DataGridViewRow();
            //xet hang duoc chon trong bang 1
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //doi tuong row duoc gan voi row trong bang 1 duoc chon va dua ve dang clone
                row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                int intColIndex = 0; //khai bao value so column/cell
                //xet tat ca cell trong row duoc chon cua bang 1
                foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                {
                    //gan gia tri tung cell cua doi tuong row bang gia tri cua cac cell trong 1 dong của bang 1
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Select"].Value) == true)
                {
                    dataGridView2.Rows.Add(row); //add cac row da duoc check vao bang 2
                    int n = dataGridView1.Rows[i].Index; //lay so dong cua row vua duoc move sang bang 2
                    dataGridView1.Rows.RemoveAt(n); //xoa row do khỏ datagridview
                }

            }

            //Chống trùng lặp dữ liệu tại datagridview2, khi INSERT vào các bảng sẽ bị lỗi duplicated key.
            dataGridView2.AllowUserToAddRows = true;
            dataGridView2.Refresh();
            for (int j = 0; j < dataGridView2.Rows.Count; j++)
            {
                int Check = Convert.ToInt32(dataGridView2.Rows[j].Cells["Ma_TS"].Value);
                for (int k = j + 1; k < dataGridView2.Rows.Count; k++)
                {
                    int Check2 = Convert.ToInt32(dataGridView2.Rows[k].Cells["Ma_TS"].Value);
                    if (Check == Check2)
                    {
                        dataGridView2.Rows.Add();
                        int n2 = dataGridView2.Rows[k].Index;
                        dataGridView2.Rows.RemoveAt(n2);
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string strInsertBB = "INSERT INTO Bien_Ban(So_Bien_ban, Ma_loai_BB, DATE, Reason, [User ID], IT_OP) VALUES(@So_BB, @Type_Code, @DATE, @Reason, @ID, @ITOP)";
                SqlCommand cmdBB = new SqlCommand();
                cmdBB.Connection = con;
                cmdBB.CommandType = CommandType.Text;
                cmdBB.CommandText = strInsertBB;
                cmdBB.Parameters.AddWithValue("@So_BB", txtSoBB.Text.ToString());
                cmdBB.Parameters.AddWithValue("@Type_Code", "OUT");
                cmdBB.Parameters.AddWithValue("@DATE", DateTime.Now.ToString());
                cmdBB.Parameters.AddWithValue("@Reason", txtReason.Text.ToString());
                cmdBB.Parameters.AddWithValue("@ID", txtUserID2.Text.ToString());
                cmdBB.Parameters.AddWithValue("@ITOP", IT_OP.Get_IT_User());
                con.Open();
                cmdBB.ExecuteNonQuery();
                con.Close();

                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    Boolean checkRow = Convert.ToBoolean(item.Cells[0].Value);
                    if (checkRow == true)
                    {
                        string strInsert = "INSERT INTO Xuat_Kho (So_BB_xuat, Ma_TS, ID_nguoi_nhan, Approved, IT_OP) VALUES (@SoBB, @Ma_TS, @ID, @Approved, @ITOP)";
                        SqlCommand cmdInsert = new SqlCommand();
                        cmdInsert.Connection = con;
                        cmdInsert.CommandType = CommandType.Text;
                        cmdInsert.CommandText = strInsert;
                        cmdInsert.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
                        cmdInsert.Parameters.AddWithValue("@Ma_TS", Convert.ToInt32(item.Cells[1].Value));
                        cmdInsert.Parameters.AddWithValue("@ID", txtUserID2.Text.ToString());
                        cmdInsert.Parameters.AddWithValue("@Approved", false);
                        cmdInsert.Parameters.AddWithValue("@ITOP", IT_OP.Get_IT_User());
                        con.Open();
                        cmdInsert.ExecuteNonQuery();
                        con.Close();

                        string strDelete = "DELETE FROM Luu_kho WHERE Ma_TS='" + Convert.ToInt32(item.Cells[1].Value) + "'";
                        SqlCommand cmDelete = new SqlCommand();
                        cmDelete.Connection = con;
                        cmDelete.CommandType = CommandType.Text;
                        cmDelete.CommandText = strDelete;
                        con.Open();
                        cmDelete.ExecuteNonQuery();
                        con.Close();
                    }
                }

                MessageBox.Show("Successful!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowse.Enabled = true;
                dataGridView1.DataSource = null;
                dataGridView2.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUserSearch_Click(object sender, EventArgs e)
        {
            /*string Search_User = "SELECT * FROM _User WHERE _User.ID='" + txtIDSearch.Text.ToString() + "' and _User.Emp_Status = 'EMP'";
            SqlDataAdapter daSearch = new SqlDataAdapter(Search_User, con);
            DataTable dtSearch = new DataTable();
            daSearch.Fill(dtSearch);

            if (dtSearch.Rows.Count > 0)
            {
                txtUserID2.Text = dtSearch.Rows[0]["ID"].ToString();
                txtUser_Name.Text = dtSearch.Rows[0]["Name"].ToString();
                txtPhone.Text = dtSearch.Rows[0]["Phone"].ToString();
                txtMail.Text = dtSearch.Rows[0]["Mail"].ToString();
                txtDept.Text = dtSearch.Rows[0]["Dept"].ToString();
                chkOSP.Checked = Convert.ToBoolean(dtSearch.Rows[0]["OSP"]);
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Chua co du lieu hoac nguoi dung da nghi viec!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = true;
                txtIDSearch.ResetText();
                txtUserID2.ResetText();
                txtPhone.ResetText();
                txtUser_Name.ResetText();
                txtMail.ResetText();
                txtDept.ResetText();
            }*/

            update.SearchUser(txtIDSearch, txtUserID2, txtUser_Name, txtPhone, txtMail, txtDept, chkOSP, btnUpdate);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            update.UpdateUser(txtUserID2, txtUser_Name, txtPhone, txtMail, txtDept, chkOSP);
        }

        private void tnInsertUser_Click(object sender, EventArgs e)
        {
            
            update.InsertUser(txtUserID2, txtUser_Name, txtPhone, txtMail, txtDept, chkOSP);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            string columnName =  dataGridView1.Columns["Select"].Name.ToString();
            AutoComplete autoComplete = new AutoComplete();
            autoComplete.AutoSelectAll(dataGridView2, columnName);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SearchType = strSearch + " where b.Ma_Loai_TS_cap2 = @Type";
            
            SqlCommand cmdSearchType = new SqlCommand();
            cmdSearchType.Connection = con;
            cmdSearchType.CommandType = CommandType.Text;
            cmdSearchType.CommandText = SearchType;
            cmdSearchType.Parameters.AddWithValue("@Type", Convert.ToInt32(cbType.SelectedValue.GetHashCode()));
            SqlDataAdapter daType = new SqlDataAdapter(cmdSearchType);
            DataTable dtType = new DataTable();
            daType.Fill(dtType);
            dataGridView1.DataSource = dtType;

            //dataGridView1.Columns["Select"].DisplayIndex = 0;
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSearchStatus = strSearch + " where b.Ma_tinh_trang = @Status";
           
            SqlCommand cmdStatus = new SqlCommand();
            cmdStatus.Connection = con;
            cmdStatus.CommandType = CommandType.Text;
            cmdStatus.CommandText = strSearchStatus;
            cmdStatus.Parameters.AddWithValue("@Status", cbStatus.SelectedValue.ToString());
            SqlDataAdapter daStatus = new SqlDataAdapter(cmdStatus);
            DataTable dtStatus = new DataTable();
            daStatus.Fill(dtStatus);
            dataGridView1.DataSource = dtStatus;

            //dataGridView1.Columns["Select"].DisplayIndex = 0;
        }

        private void txtSN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSN_Enter(object sender, EventArgs e)
        {

        }

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                brnSearch_Click(this, new EventArgs());
            }
        }

        private void txtFA_Tag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                brnSearch_Click(this, new EventArgs());
            }
        }

        private void txtIT_Tag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                brnSearch_Click(this, new EventArgs());
            }
        }

        private void txtIDSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUserSearch_Click(this, new EventArgs());
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            UploadAndRetrieve upload = new UploadAndRetrieve();
            upload.UploadToFileServer(txtSoBB, openFileDialog1);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            /*try
            {
                string strUser = "select * from _User as a inner join Xuat_Kho as b on a.ID = b.ID_nguoi_nhan where b.So_BB_xuat = '" + txtSoBB.Text.ToString() + "'";
                SqlDataAdapter daUser = new SqlDataAdapter(strUser, con);
                DataTable dtUser = new DataTable();
                daUser.Fill(dtUser);

                Bien_Ban frm = new Bien_Ban();
                CrystalReport1 crystalReport = new CrystalReport1();
                TextObject text = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text1"];
                text.Text = txtSoBB.Text;
                TextObject text2 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text13"];
                //text2.Text = txtUserID2.Text;
                text2.Text = dtUser.Rows[0]["ID"].ToString();
                TextObject text3 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text12"];
                //text3.Text = txtUser_Name.Text;
                text3.Text = dtUser.Rows[0]["Name"].ToString();
                TextObject text4 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text14"];
                //text4.Text = txtMail.Text;
                text4.Text = dtUser.Rows[0]["Mail"].ToString();
                TextObject text5 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text15"];
                //text5.Text = txtDept.Text;
                text5.Text = dtUser.Rows[0]["Dept"].ToString();
                TextObject text6 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text16"];
                //text6.Text = txtPhone.Text;
                text6.Text = dtUser.Rows[0]["Phone"].ToString();

                string strGridviewTransferData = "select a.Ma_TS, b.Ten_TS, b.[S/N] from Xuat_Kho as a " +
                    "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                    "where So_BB_xuat = '" + txtSoBB.Text.ToString() + "'";
                SqlDataAdapter daGTD = new SqlDataAdapter(strGridviewTransferData, con);
                DataTable dtGTD = new DataTable();
                dtGTD.TableName = "GTD";
                daGTD.Fill(dtGTD);

                DataSet ds = new DataSet();
                daGTD.Fill(ds);
                crystalReport.SetDataSource(ds.Tables[0]);



                frm.crystalReportViewer1.ReportSource = crystalReport;
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            Report report = new Report();
            report.BienBanXuatKho(txtSoBB.Text.ToString());
        }
    }
}
