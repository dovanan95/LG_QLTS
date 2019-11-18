using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    class AutoGenAsssetCode
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();

        public string code;
        public string TypeCode;
        public string unit_id;
        public string model_code;
        public void AutoGenCode()
        {
            //code...
            int i = 1;
            con.Open();
            string SelectCode = "SELECT Ma_TS FROM (select Ma_TS from Tai_san order by Ma_TS DESC) where ROWNUM = 1";
            OracleDataAdapter sqlData = new OracleDataAdapter(SelectCode, con);
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
            con.Close();

        }
        public void AutoGenTypeCode()
        {
            con.Open();
            string strQuerryTypeDevice = "select max(to_number(Ma_loai)) from Loai_TS_cap2";
            OracleDataAdapter dataAdapter = new OracleDataAdapter(strQuerryTypeDevice, con);
            DataTable dtQTD = new DataTable();
            dataAdapter.Fill(dtQTD);

            //int RowCount = dtQTD.Rows.Count - 1;
            //string LastItem = dtQTD.Rows[RowCount][0].ToString();
            string LastItem = dtQTD.Rows[0][0].ToString();
            int Tcode = Convert.ToInt32(LastItem) + 1;
            TypeCode = Tcode.ToString();
           
            con.Close();
        }
        public void AutoGenModelCode()
        {
            con.Open();
            string strQuerryTypeDevice = "select max(to_number(model_code)) from Model";
            OracleDataAdapter dataAdapter = new OracleDataAdapter(strQuerryTypeDevice, con);
            DataTable dtQTD = new DataTable();
            dataAdapter.Fill(dtQTD);

            //int RowCount = dtQTD.Rows.Count - 1;
            //string LastItem = dtQTD.Rows[RowCount][0].ToString();
            string LastItem = dtQTD.Rows[0][0].ToString();
            int Tcode = Convert.ToInt32(LastItem) + 1;
            model_code = Tcode.ToString();

            con.Close();
        }
        public void AutoGenUnit()
        {
            con.Open();
            string strUnit = "select max(unit_id) from Unit";
            OracleDataAdapter daUnit = new OracleDataAdapter(strUnit, con);
            DataTable dtUnit = new DataTable();
            daUnit.Fill(dtUnit);
            string lastItem = dtUnit.Rows[0][0].ToString();
            int id = Convert.ToInt32(lastItem) + 1;
            unit_id = id.ToString();
            con.Close();
        }
    }
}
