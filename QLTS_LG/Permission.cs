using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    class Permission
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();

        //public static string ITOP { get; set; }

        public string CheckPermission()
        {
            string strCheck = "select a.per_name, b.permission from Permission a " +
                "inner join Login b on a.per_id = b.permission                " +
                "where b.ID_User = '" + Login.username + "'";
            OracleDataAdapter daCheck = new OracleDataAdapter(strCheck, con);
            DataTable dtCheck = new DataTable();
            daCheck.Fill(dtCheck);
            string strPer = dtCheck.Rows[0][0].ToString();
            return strPer;
        }
        public string Get_IT_User()
        {
            string strCheck = "select ID from Login where ID_User = '" + Login.username + "'";
            OracleDataAdapter daIT = new OracleDataAdapter(strCheck, con);
            DataTable dtIT = new DataTable();
            daIT.Fill(dtIT);
            string IT_User = dtIT.Rows[0][0].ToString();
            //ITOP = IT_User;
            return IT_User;
        }
    }
}
