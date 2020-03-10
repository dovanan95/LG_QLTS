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
    public partial class User_Management : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleConnection con2 = new OracleConnection(connectionString);
        OracleConnection con3 = new OracleConnection(connectionString);

        LoadComboboxData LoadCombobox = new LoadComboboxData();

        WS_ORG.QLTS_ORG HR = new WS_ORG.QLTS_ORG(); //webservice to transfer data from HR database
        DataTable dtHuman = new DataTable();
        DataTable dtORG_HR = new DataTable();

        public string strSearch = "select a.ID, a.Name, a.Phone, a.Mail, a.Dept, a.OSP, b.Emp_Name, c.Org_name from TB_User a " +
            "inner join Emp_Status b on b.ECode = a.Emp_Status " +
            "inner join ORG_NAME c on c.Org_code = a.Org_code ";
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
            if (e.KeyCode == Keys.Enter)
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
                    string ID = strSearch + "where a.ID = '" + txtID.Text.ToString().ToUpper() + "'";
                    OracleDataAdapter daID = new OracleDataAdapter(ID, con);
                    DataTable dtID = new DataTable();
                    daID.Fill(dtID);
                    dgvHRM.DataSource = dtID;
                }
                else if (txtMail.Text.ToString() != "")
                {
                    string Mail = strSearch + "where a.Mail = '" + txtMail.Text.ToString() + "'";
                    OracleDataAdapter daMail = new OracleDataAdapter(Mail, con);
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

                    OracleCommand cmdSearch = new OracleCommand();
                    cmdSearch.Connection = con;
                    cmdSearch.CommandType = CommandType.Text;
                    cmdSearch.CommandText = strSearch;

                    OracleDataAdapter daSearch = new OracleDataAdapter(cmdSearch);
                    daSearch.Fill(dtSearch);
                    dgvHRM.DataSource = dtSearch;
                }
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
                string InputUser = "insert into TB_User(ID, Name, Phone, Mail, Dept, OSP, Emp_Status, Org_code) " +
                    "values (:ID, :Name, :Phone, :Mail, :Dept, :OSP, :Emp, :Org)";
                OracleCommand cmdInput = new OracleCommand();
                cmdInput.Connection = con;
                cmdInput.CommandType = CommandType.Text;
                cmdInput.CommandText = InputUser;
                cmdInput.Parameters.Add("ID", txtID.Text.ToUpper());
                cmdInput.Parameters.Add("Name", txtName.Text.ToString());
                cmdInput.Parameters.Add("Phone", txtPhone.Text.ToString());
                cmdInput.Parameters.Add("Mail", txtMail.Text.ToString());
                cmdInput.Parameters.Add("Dept", txtDept.Text.ToString());
                cmdInput.Parameters.Add("OSP", Convert.ToInt32(chkOSP.CheckState));
                cmdInput.Parameters.Add("Emp", cbEmpStatus.SelectedValue.ToString());
                cmdInput.Parameters.Add("Org", cbORG.SelectedValue.ToString());
                con.Open();
                cmdInput.ExecuteNonQuery();
                con.Close();

                Reload();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Data duplicated or connection down!!!");
                MessageBox.Show(ex.Message);
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
            string strUpdate = "update TB_User set Name = :Name, Phone = :Phone, Mail = :Mail, Dept = :Dept, " +
                "OSP = :OSP, Emp_Status = :Emp, Org_code = :Org where ID = '" + ID + "'";
            OracleCommand cmdUpdate = new OracleCommand();
            cmdUpdate.Connection = con;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = strUpdate;
            //cmdUpdate.Parameters.Add("@ID", txtID.Text.ToUpper());
            cmdUpdate.Parameters.Add("Name", txtName.Text.ToString());
            cmdUpdate.Parameters.Add("Phone", txtPhone.Text.ToString());
            cmdUpdate.Parameters.Add("Mail", txtMail.Text.ToString());
            cmdUpdate.Parameters.Add("Dept", txtDept.Text.ToString());
            cmdUpdate.Parameters.Add("OSP", Convert.ToInt32(chkOSP.CheckState));
            cmdUpdate.Parameters.Add("Emp", cbEmpStatus.SelectedValue.ToString());
            cmdUpdate.Parameters.Add("Org", cbORG.SelectedValue.ToString());
            try
            {
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();

                Reload();
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
        public void Reload()
        {
            dgvHRM.DataSource = null;
            dgvHRM.Rows.Clear();
            dgvHRM.Refresh();
            dtIDUser.Clear();

            string ID = strSearch + "where a.ID = '" + txtID.Text.ToString().Trim() + "'";
            OracleDataAdapter daID = new OracleDataAdapter(ID, con);

            daID.Fill(dtIDUser);
            dgvHRM.DataSource = dtIDUser;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strLoginDel = "delete from Login where ID = '" + txtID.Text.ToString().ToUpper() + "'";
            OracleCommand cmdLogin = new OracleCommand();
            cmdLogin.Connection = con;
            cmdLogin.CommandType = CommandType.Text;
            cmdLogin.CommandText = strLoginDel;


            string strDelete = "delete from TB_User where ID = '" + txtID.Text.ToString().ToUpper() + "'";
            OracleCommand cmdXoa = new OracleCommand();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void chkOSP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOSP.Checked == true)
            {
                cbORG.SelectedValue = "000001";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string EmpID = txtID.Text.ToString().ToUpper();
                dtHuman = HR.HR_INFOR(EmpID);

                string ID = dtHuman.Rows[0]["EMPLOYEE_NUMBER"].ToString();
                string Name = dtHuman.Rows[0]["FULLNAME_ENGLISH"].ToString();
                string Phone = dtHuman.Rows[0]["MOBILE_NUMBER"].ToString();
                string Mail = dtHuman.Rows[0]["EMAIL_ADDRESS"].ToString();
                string Dept = dtHuman.Rows[0]["JOB_FAMILY"].ToString();
                int OSP = 0;
                string Org_code = dtHuman.Rows[0]["ORGANIZATION_ID"].ToString();
                string Emp_Status = dtHuman.Rows[0]["STATUS"].ToString();


                string strUpdateHR = "insert into tb_user(ID, NAME, PHONE, MAIL, DEPT, OSP, EMP_STATUS, ORG_CODE) " +
                                     "values (:id, :name, :phone, :mail, :dept, :osp, :emp_status, :org_code)";
                OracleCommand cmdUpdateHR = new OracleCommand(strUpdateHR, con);
                cmdUpdateHR.Parameters.Add(new OracleParameter("id", ID));
                cmdUpdateHR.Parameters.Add(new OracleParameter("name", Name));
                cmdUpdateHR.Parameters.Add(new OracleParameter("phone", Phone));
                cmdUpdateHR.Parameters.Add(new OracleParameter("mail", Mail));
                cmdUpdateHR.Parameters.Add(new OracleParameter("dept", Dept));
                cmdUpdateHR.Parameters.Add(new OracleParameter("osp", OSP));
                if (Emp_Status == "Employment")
                {
                    cmdUpdateHR.Parameters.Add(new OracleParameter("emp_status", "EMP"));
                }
                else if (Emp_Status == "Resignation")
                {
                    cmdUpdateHR.Parameters.Add(new OracleParameter("emp_status", "REG"));
                }
                cmdUpdateHR.Parameters.Add(new OracleParameter("org_code", Org_code));

                con.Open();
                cmdUpdateHR.ExecuteNonQuery();
                con.Close();

                CheckOrgExist();

                btnSearch_Click(this, new EventArgs());
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

        /*/
         * Check if the organization of new person input from HR database is available on QLTS or not.
         * If it's unavailable, this function can check and update new organization code and organization name
        /*/
        public void CheckOrgExist()
        {
            string Check_org = "select a.org_code from org_name a " +
                "inner join tb_user b on b.ORG_CODE = a.ORG_CODE " +
                "where b.ID = '" + txtID.Text.ToString().ToUpper() + "'";
            dtORG_HR = HR.HR_ORG();
            string Org_code_HR = dtHuman.Rows[0]["ORGANIZATION_ID"].ToString();

            OracleDataAdapter daCheckOrg = new OracleDataAdapter(Check_org, con2);
            DataTable dtCheckOrg = new DataTable();

            daCheckOrg.Fill(dtCheckOrg);
            if (dtCheckOrg.Rows.Count == 0)
            {
                //DataTable dtUpdateORG = new DataTable();
                DataRow[] drUpdateORG = dtORG_HR.Select("ORGANIZATION_ID = '" + Org_code_HR + "'");
                string strNew_Org = drUpdateORG[0]["ORG_NAME_ENGLISH"].ToString();
                string UpdateNewORG = "insert into org_name(org_code, org_name) values (:code, :name)";
                OracleCommand cmdNewORG = new OracleCommand(UpdateNewORG, con3);
                cmdNewORG.Parameters.Add(new OracleParameter("code", Org_code_HR));
                cmdNewORG.Parameters.Add(new OracleParameter("name", strNew_Org));
                con3.Open();
                cmdNewORG.ExecuteNonQuery();
                con3.Close();
            }
            else if(dtCheckOrg.Rows.Count != 0)
            {
                
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
