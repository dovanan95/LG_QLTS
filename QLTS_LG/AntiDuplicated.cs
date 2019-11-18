using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    class AntiDuplicated
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleConnection con2 = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();
        AutoGenAsssetCode AutoGenAsssetCode = new AutoGenAsssetCode();

        public DataGridView AntiColumnDuplicate(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count - 1; i++)
            {
                for (int j = i + 1; j <= dataGridView.Columns.Count - 1; j++)
                {
                    if (dataGridView.Columns[i].Name == dataGridView.Columns[j].Name)
                    {
                        dataGridView.Columns.RemoveAt(j);
                    }
                }
            }

            return dataGridView;
        }
        public void DeleteDuplicatedRow(string tableName, string fieldName)
        {
            //string strClearDup = "DELETE FROM " + tableName + " WHERE " + fieldName
            //+ " IN (SELECT " + fieldName + " FROM " + tableName + " GROUP BY " + fieldName + " HAVING COUNT (*) > 1)";
            /*string strClearDup = "WITH ClearDup AS" +
                "( " +
                "SELECT *, ROW_NUMBER() OVER(PARTITION BY " + fieldName + " ORDER BY " + fieldName + ") AS RowNumber " +
                "FROM " + tableName +
                ") " +
                "DELETE FROM ClearDup WHERE RowNumber > 1 ";*/
            string strClearDup = "delete from " + tableName + " a where ROWID > (select min(ROWID) from " + tableName + " b where b." + fieldName + " = a." + fieldName + ")";
            OracleCommand cmdClear = new OracleCommand();
            cmdClear.Connection = con;
            cmdClear.CommandType = CommandType.Text;
            cmdClear.CommandText = strClearDup;
            //cmdClear.Parameters.Add(new OracleParameter("tableName", tableName));
            //cmdClear.Parameters.Add(new OracleParameter("fieldName", fieldName));

            con.Open();
            cmdClear.ExecuteNonQuery();
            con.Close();
        }
        public void CheckModel(ComboBox cbModel, ComboBox cbType2)
        {
            try
            {
                bool flag = true;
                AutoGenAsssetCode.AutoGenModelCode();
                string model_code = AutoGenAsssetCode.model_code;
                string strInputToModel = "insert into Model(model_code, model, type_code) values (:model_code, :model, :type)";
                OracleCommand cmdInput = new OracleCommand();
                cmdInput.Connection = con2;
                cmdInput.CommandType = CommandType.Text;
                cmdInput.CommandText = strInputToModel;
                cmdInput.Parameters.Add(new OracleParameter("model_code", model_code));
                cmdInput.Parameters.Add(new OracleParameter("model", cbModel.Text.ToString().Trim()));
                cmdInput.Parameters.Add(new OracleParameter("type", Convert.ToInt32(cbType2.SelectedValue)));
                string strRead = "select * from Model";
                OracleCommand cmdRead = new OracleCommand(strRead, con);
                OracleDataReader rdrRead = null;

                con.Open();
                rdrRead = cmdRead.ExecuteReader();
                while (rdrRead.Read())
                {
                    if (cbModel.Text.ToString().Trim() == rdrRead["model"].ToString() && Convert.ToInt32(cbType2.SelectedValue) == Convert.ToInt32(rdrRead["Type_code"]))
                    {
                        flag = false;

                    }
                }
                con.Close();


                if (flag == true)
                {
                    con2.Open();
                    cmdInput.ExecuteNonQuery();
                    con2.Close();
                    flag = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void CheckModel2(string model, int Type)
        {
            try
            {
                bool flag = true;

                AutoGenAsssetCode.AutoGenModelCode();
                string model_code = AutoGenAsssetCode.model_code;
                string strInputToModel = "insert into Model(model_code, model, type_code) values (:model_code, :model, :type)";
                OracleCommand cmdInput = new OracleCommand();
                cmdInput.Connection = con2;
                cmdInput.CommandType = CommandType.Text;
                cmdInput.CommandText = strInputToModel;
                cmdInput.Parameters.Add(new OracleParameter("model_code", model_code));
                cmdInput.Parameters.Add(new OracleParameter("model", model));
                cmdInput.Parameters.Add(new OracleParameter("type", Type));
                string strRead = "select * from Model";
                OracleCommand cmdRead = new OracleCommand(strRead, con);
                OracleDataReader rdrRead = null;

                con.Open();
                rdrRead = cmdRead.ExecuteReader();
                while (rdrRead.Read())
                {
                    if (model == rdrRead["model"].ToString() && Type == Convert.ToInt32(rdrRead["Type_code"]))
                    {
                        flag = false;
                        MessageBox.Show("Trùng!!!");
                    }
                }
                con.Close();


                if (flag == true)
                {
                    con2.Open();
                    cmdInput.ExecuteNonQuery();
                    con2.Close();
                    flag = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool CheckTypeLevel2(string Ten_loai, string Phan_loai)
        {
            bool flag = true;

            string SelectType2 = "select * from Loai_TS_cap2 where Ten_loai = '" + Ten_loai + "' and Phan_loai = '" + Phan_loai + "'";
            OracleDataAdapter datype2 = new OracleDataAdapter(SelectType2, con);
            DataTable dttype2 = new DataTable();
            datype2.Fill(dttype2);
            if (dttype2.Rows.Count > 0)
            {
                flag = false;
            }
            else if (dttype2.Rows.Count == 0)
            {
                flag = true;
            }
            return flag;
        }
        public bool TypeModify(string Ma_loai)
        {
            bool flag = true;
            string Querry = "select * from tai_san where ma_loai_ts_cap2 = '" + Ma_loai + "'";
            OracleDataAdapter daCount = new OracleDataAdapter(Querry, con);
            DataTable dtCount = new DataTable();
            daCount.Fill(dtCount);
            if (dtCount.Rows.Count > 0)
            {
                flag = false;
            }
            else if (dtCount.Rows.Count == 0)
            {
                flag = true;
            }
            return flag;
        }
        public bool ModelModify(string model, int type)
        {
            bool flag = true;
            string Querry = "select a.* from tai_san a " +
                        "inner join model b on a.model = b.model  " +
                        "where b.type_code = " + type + " and a.model = '" + model + "' ";
            OracleDataAdapter daCount = new OracleDataAdapter(Querry, con);
            DataTable dtCount = new DataTable();
            daCount.Fill(dtCount);
            if (dtCount.Rows.Count > 0)
            {
                flag = false;
            }
            else if (dtCount.Rows.Count == 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}
