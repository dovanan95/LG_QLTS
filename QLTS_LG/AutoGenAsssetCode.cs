using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace QLTS_LG
{
    class AutoGenAsssetCode
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();

        public string code;
        public void AutoGenCode()
        {
            //code...
            int i = 1;
            string SelectCode = "SELECT Ma_TS FROM Tai_san ";
            SqlDataAdapter sqlData = new SqlDataAdapter(SelectCode, con);
            DataTable table = new DataTable();
            sqlData.Fill(table);
            if (table.Rows.Count == 0)
            {
                DataRow dr = table.NewRow();
                dr["Ma_TS"] = i.ToString();
                table.Rows.Add(dr);
                code = dr["Ma_TS"].ToString();
            }
            else if (table.Rows.Count > 0)
            {
                //Get data
                int RowCount = table.Rows.Count - 1;
                string LastItem = table.Rows[RowCount][0].ToString();
                int tempCode = Int32.Parse(LastItem) + 1;
                code = tempCode.ToString();
            }


        }
    }
}
