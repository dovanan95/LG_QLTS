using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    class AutoComplete
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();

        public static string Clear = "MAITHIHONGNHUNG";

        AutoCompleteStringCollection AutoCompleteString = new AutoCompleteStringCollection();
        public AutoCompleteStringCollection AutoCompleteData1(string strAuto)
        {
            //string strAuto = "SELECT [S/N] FROM Tai_san";
            OracleCommand cmdAuto = new OracleCommand();
            cmdAuto.CommandType = CommandType.Text;
            cmdAuto.CommandText = strAuto;
            cmdAuto.Connection = con;
            DataTable dtCollection = new DataTable();
            OracleDataAdapter daCollection = new OracleDataAdapter(cmdAuto);
            daCollection.Fill(dtCollection);
            if (dtCollection.Rows.Count > 0)
            {
                for (int i = 0; i < dtCollection.Rows.Count; i++)
                {
                    AutoCompleteString.Add(dtCollection.Rows[i][0].ToString());
                }
            }
            else
            {
                MessageBox.Show("Not Found!");
            }
            //txtSN.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtSN.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtSN.AutoCompleteCustomSource = AutoCompleteString;
            return AutoCompleteString;
        }
        public void AutoSelectAll(DataGridView dataGridView, string ColumnName)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells[ColumnName].Value);
                if (CheckRow == false && row.Cells["Ma_TS"].Value != null)
                {
                    row.Cells[ColumnName].Value = true;
                }

            }

        }

        public void AutoUnselectAll(DataGridView dataGridView, string ColumnName)
        {
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                Boolean CheckRow = Convert.ToBoolean(row.Cells[ColumnName].Value);
                if(CheckRow == true)
                {
                    row.Cells[ColumnName].Value = false;
                }
            }
        }

    }
}
