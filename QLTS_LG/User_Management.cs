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
                    DataTable dtSearch = new DataTable();
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
    }
}
