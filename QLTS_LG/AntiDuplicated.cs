using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace QLTS_LG
{
    class AntiDuplicated
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlConnection con2 = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();

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
            string strClearDup = "WITH ClearDup AS" +
                "( " +
                "SELECT *, ROW_NUMBER() OVER(PARTITION BY " + fieldName + " ORDER BY " + fieldName + ") AS RowNumber " +
                "FROM " + tableName +
                ") " +
                "DELETE FROM ClearDup WHERE RowNumber > 1 ";
            SqlCommand cmdClear = new SqlCommand();
            cmdClear.Connection = con;
            cmdClear.CommandType = CommandType.Text;
            cmdClear.CommandText = strClearDup;
            //cmdClear.Parameters.AddWithValue("@fieldName", fieldName);
            // cmdClear.Parameters.AddWithValue("@tableName", tableName);
            con.Open();
            cmdClear.ExecuteNonQuery();
            con.Close();
        }
        public void CheckModel(ComboBox cbModel, ComboBox cbType2)
        {
            try
            {
                bool flag = true;

                string strInputToModel = "insert into Model(model, type_code) values (@model, @type)";
                SqlCommand cmdInput = new SqlCommand();
                cmdInput.Connection = con2;
                cmdInput.CommandType = CommandType.Text;
                cmdInput.CommandText = strInputToModel;
                cmdInput.Parameters.AddWithValue("@model", cbModel.Text.ToString().Trim());
                cmdInput.Parameters.AddWithValue("@type", Convert.ToInt32(cbType2.SelectedValue));
                string strRead = "select * from Model";
                SqlCommand cmdRead = new SqlCommand(strRead, con);
                SqlDataReader rdrRead = null;

                con.Open();
                rdrRead = cmdRead.ExecuteReader();
                while (rdrRead.Read())
                {
                    if (cbModel.Text.ToString().Trim() == rdrRead["model"].ToString())
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
    }
}
