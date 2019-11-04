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
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class WS_ORG_DOWN : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        public WS_ORG_DOWN()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {

                WS_ORG.QLTS_ORG ORG_HR = new WS_ORG.QLTS_ORG(); //webservice help connect to HR database
                DataSet dsORG = new DataSet();
                DataTable dtORG = new DataTable();
                //dsORG.ReadXml(ORG_HR.HR_ORG());
                dtORG = ORG_HR.HR_ORG();
                dgvHR.DataSource = dtORG;
                dgvHR.AutoResizeColumns();
                dgvHR.AutoResizeRows();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WS_ORG_DOWN_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.Name = "Select";
            column.HeaderText = "Select";
            dgvHR.Columns.Add(column);
            dgvHR.Columns["Select"].DisplayIndex = 0;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
             
                string CheckBoxString = dgvHR.Columns["Select"].Name;
                string Key = dgvHR.Columns["ORGANIZATION_ID"].Name;
                CopyGridView copyGrid = new CopyGridView();
                copyGrid.CopyDataGridViewComplexible(dgvHR, dgvQLTS, CheckBoxString, Key);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            CheckOrgID();

            foreach (DataGridViewRow row in dgvQLTS.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                if(CheckRow)
                {
                    string Import = "insert into ORG_NAME(ORG_CODE, ORG_NAME) values (:code, :name)";
                    OracleCommand cmdImport = new OracleCommand(Import, con);
                    cmdImport.Parameters.Add(new OracleParameter("code", row.Cells["ORGANIZATION_ID"].Value.ToString()));
                    cmdImport.Parameters.Add(new OracleParameter("name", row.Cells["ORG_NAME_ENG"].Value.ToString()));
                    con.Open();
                    cmdImport.ExecuteNonQuery();
                    con.Close();
                }
            }
            
        }
        /*/
         * Check if new organization input from HR database is available in QLTS or not.
         * If it's available in QLTS, this function will reject that organization automatically.
        /*/ 
        public void CheckOrgID()
        {
            try
            {
                string Org_search = "select * from ORG_NAME";
                OracleCommand cmdOrg = new OracleCommand(Org_search, con);
                OracleDataReader drOrg = null;
                con.Open();
                drOrg = cmdOrg.ExecuteReader();
                while (drOrg.Read())
                {
                    foreach(DataGridViewRow row in dgvQLTS.Rows)
                    {
                        Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (CheckRow)
                        {
                            if(row.Cells["ORGANIZATION_ID"].Value.ToString() == drOrg["ORG_CODE"].ToString())
                            {
                                dgvQLTS.Rows.RemoveAt(row.Index);
                            }
                        }
                    }
                    
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDrawBack_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvQLTS.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells["Select"].Value);
                if (CheckRow)
                {
                    dgvQLTS.Rows.RemoveAt(row.Index);
                }

            }
        }
    }
}
