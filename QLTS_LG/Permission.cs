using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace QLTS_LG
{
    class Permission
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();

        public string CheckPermission()
        {
            string strCheck = "select a.per_name, b.permission from Permission as a " +
                "inner join[Login] as b on a.per_id = b.permission                " +
                "where b.ID_User = '" + Login.username + "'";
            SqlDataAdapter daCheck = new SqlDataAdapter(strCheck, con);
            DataTable dtCheck = new DataTable();
            daCheck.Fill(dtCheck);
            string strPer = dtCheck.Rows[0][0].ToString();
            return strPer;
        }
    }
}
