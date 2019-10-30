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
    public partial class ORG_NAME : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        DataTable dtSearch = new DataTable();
        string strSearch = "select * from ORG_NAME ";

        public ORG_NAME()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void ORG_NAME_Load(object sender, EventArgs e)
        {
            Search(strSearch);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtCode.Text.ToString() != "")
            {
                string strCode = strSearch + " where Org_code = '" + txtCode.Text.ToString() + "'";
                Search(strCode);
            }
            else if(txtCode.Text.ToString() == "")
            {
                Search(strSearch);
            }
        }
        public void Search(string strSearching)
        {
            dtSearch.Clear();
            OracleDataAdapter daSearch = new OracleDataAdapter(strSearching, con);
            
            daSearch.Fill(dtSearch);
            dgvORG.DataSource = dtSearch;
            dgvORG.AutoResizeColumns();
        }

        private void dgvORG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvORG.CurrentCell.RowIndex;
            //string code = dgvORG.Rows[index].Cells["Org_code"].Value.ToString();

            txtCode.Text = dgvORG.Rows[index].Cells["Org_code"].Value.ToString();
            txtName.Text = dgvORG.Rows[index].Cells["Org_name"].Value.ToString();

            btnDelete.Enabled = false;
            btnInsert.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnInsert.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string Insert = "insert into ORG_NAME(Org_code, Org_name) values (:code, :name)";
            OracleCommand cmdInput = new OracleCommand();
            cmdInput.Connection = con;
            cmdInput.CommandType = CommandType.Text;
            cmdInput.CommandText = Insert;
            cmdInput.Parameters.Add(":code", txtCode.Text.ToString());
            cmdInput.Parameters.Add(":name", txtName.Text.ToString());
            try
            {
                con.Open();
                cmdInput.ExecuteNonQuery();
                con.Close();
                Search(strSearch);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = dgvORG.CurrentCell.RowIndex;
            string code = dgvORG.Rows[index].Cells["Org_code"].Value.ToString();

            string Update = "update ORG_NAME set Org_code = :code, Org_name = :name where Org_code = '" + code + "'";
            OracleCommand cmdUpdate = new OracleCommand();
            cmdUpdate.Connection = con;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = Update;
            cmdUpdate.Parameters.Add("code", txtCode.Text.ToString());
            cmdUpdate.Parameters.Add("name", txtName.Text.ToString());
            try
            {
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();
                Search(strSearch);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WS_ORG_DOWN webservice = new WS_ORG_DOWN();
            webservice.ShowDialog();
            //this.Close();
        }
    }
}
