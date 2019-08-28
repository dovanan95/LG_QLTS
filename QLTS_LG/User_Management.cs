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
    public partial class User_Management : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        LoadComboboxData LoadCombobox = new LoadComboboxData();
        public string strSearch = "select a.ID, a.Name, a.Phone, a.Mail, a.Dept, a.OSP, b.Emp_Name, c.Org_name from _User as a " +
            "inner join Emp_Status as b on b.ECode = a.Emp_Status " +
            "inner join ORG_NAME as c on c.Org_code = a.Org_code ";
        DataTable dtSearch = new DataTable();
        DataTable dtIDUser = new DataTable();

        public User_Management()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void User_Management_Load(object sender, EventArgs e)
        {
            LoadCombobox.LoadEmpStatus(cbEmpStatus);
            LoadCombobox.LoadORG(cbORG);
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.ToString() != "")
                {
                    string ID = strSearch + "where a.ID = '" + txtID.Text.ToString().Trim() + "'";
                    SqlDataAdapter daID = new SqlDataAdapter(ID, con);
                    DataTable dtID = new DataTable();
                    daID.Fill(dtID);
                    dgvHRM.DataSource = dtID;
                }
                else if (txtMail.Text.ToString() != "")
                {
                    string Mail = strSearch + "where a.Mail = '" + txtMail.Text.ToString().Trim() + "'";
                    SqlDataAdapter daMail = new SqlDataAdapter(Mail, con);
                    DataTable dtMail = new DataTable();
                    daMail.Fill(dtMail);
                    dgvHRM.DataSource = dtMail;
                }
                else if (txtID.Text.ToString() == "" && txtMail.Text.ToString() == "")
                {

                    dgvHRM.DataSource = null;
                    dgvHRM.Rows.Clear();
                    dgvHRM.Refresh();
                    dtSearch.Clear();

                    SqlCommand cmdSearch = new SqlCommand();
                    cmdSearch.Connection = con;
                    cmdSearch.CommandType = CommandType.Text;
                    cmdSearch.CommandText = strSearch;

                    SqlDataAdapter daSearch = new SqlDataAdapter(cmdSearch);
                    daSearch.Fill(dtSearch);
                    dgvHRM.DataSource = dtSearch;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string InputUser = "insert into _User(ID, Name, Phone, Mail, Dept, OSP, Emp_Status, Org_code) " +
                    "values (@ID, @Name, @Phone, @Mail, @Dept, @OSP, @Emp, @Org)";
                SqlCommand cmdInput = new SqlCommand();
                cmdInput.Connection = con;
                cmdInput.CommandType = CommandType.Text;
                cmdInput.CommandText = InputUser;
                cmdInput.Parameters.AddWithValue("@ID", txtID.Text.ToUpper());
                cmdInput.Parameters.AddWithValue("@Name", txtName.Text.ToString());
                cmdInput.Parameters.AddWithValue("@Phone", txtPhone.Text.ToString());
                cmdInput.Parameters.AddWithValue("@Mail", txtMail.Text.ToString());
                cmdInput.Parameters.AddWithValue("@Dept", txtDept.Text.ToString());
                cmdInput.Parameters.AddWithValue("@OSP", Convert.ToInt32(chkOSP.CheckState));
                cmdInput.Parameters.AddWithValue("@Emp", cbEmpStatus.SelectedValue.ToString());
                cmdInput.Parameters.AddWithValue("@Org", cbORG.SelectedValue.ToString());
                con.Open();
                cmdInput.ExecuteNonQuery();
                con.Close();

                Reload();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Data duplicated or connection down!!!");
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dgvHRM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInsert.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnInsert.Enabled = true;
            btnSave.Enabled = true;
        }

        private void dgvHRM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInsert.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            int index = dgvHRM.CurrentCell.RowIndex;
            txtID.Text = dgvHRM.Rows[index].Cells["ID"].Value.ToString();
            txtName.Text = dgvHRM.Rows[index].Cells["Name"].Value.ToString();
            txtPhone.Text = dgvHRM.Rows[index].Cells["Phone"].Value.ToString();
            txtMail.Text = dgvHRM.Rows[index].Cells["Mail"].Value.ToString();
            txtDept.Text = dgvHRM.Rows[index].Cells["Dept"].Value.ToString();
            cbEmpStatus.Text = dgvHRM.Rows[index].Cells["Emp_Name"].Value.ToString();
            cbORG.Text = dgvHRM.Rows[index].Cells["Org_name"].Value.ToString();
            chkOSP.Checked = Convert.ToBoolean(dgvHRM.Rows[index].Cells["OSP"].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = dgvHRM.CurrentCell.RowIndex;
            string ID = dgvHRM.Rows[index].Cells["ID"].Value.ToString();
            string strUpdate = "update _User set Name = @Name, Phone = @Phone, Mail = @Mail, Dept = @Dept, " +
                "OSP = @OSP, Emp_Status = @Emp, Org_code = @Org where ID = '" + ID + "'";
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = con;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = strUpdate;
            //cmdUpdate.Parameters.AddWithValue("@ID", txtID.Text.ToUpper());
            cmdUpdate.Parameters.AddWithValue("@Name", txtName.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@Phone", txtPhone.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@Mail", txtMail.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@Dept", txtDept.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@OSP", Convert.ToInt32(chkOSP.CheckState));
            cmdUpdate.Parameters.AddWithValue("@Emp", cbEmpStatus.SelectedValue.ToString());
            cmdUpdate.Parameters.AddWithValue("@Org", cbORG.SelectedValue.ToString());
            try
            {
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();

                Reload();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Reload()
        {
            dgvHRM.DataSource = null;
            dgvHRM.Rows.Clear();
            dgvHRM.Refresh();
            dtIDUser.Clear();

            string ID = strSearch + "where a.ID = '" + txtID.Text.ToString().Trim() + "'";
            SqlDataAdapter daID = new SqlDataAdapter(ID, con);
            
            daID.Fill(dtIDUser);
            dgvHRM.DataSource = dtIDUser;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strLoginDel = "delete from Login where ID = '" + txtID.Text.ToString() + "'";
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = con;
            cmdLogin.CommandType = CommandType.Text;
            cmdLogin.CommandText = strLoginDel;


            string strDelete = "delete from _User where ID = '" + txtID.Text.ToString() + "'";
            SqlCommand cmdXoa = new SqlCommand();
            cmdXoa.Connection = con;
            cmdXoa.CommandType = CommandType.Text;
            cmdXoa.CommandText = strDelete;
            try
            {
                DialogResult dialog = MessageBox.Show("Are you sure???", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    con.Open();
                    cmdLogin.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmdXoa.ExecuteNonQuery();
                    con.Close();

                    Reload();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

           
        }
    }
}
