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
    public partial class ORG_NAME : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

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
            SqlDataAdapter daSearch = new SqlDataAdapter(strSearching, con);
            DataTable dtSearch = new DataTable();
            daSearch.Fill(dtSearch);
            dgvORG.DataSource = dtSearch;
            dgvORG.AutoResizeColumns();
        }

    }
}
