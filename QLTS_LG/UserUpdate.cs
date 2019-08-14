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
    class UserUpdate
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();

        public void UpdateUser(TextBox txtUserID, TextBox txtUserName, TextBox txtPhone, TextBox txtMail, TextBox txtDept, CheckBox chkOSP)
        {
            string strUpdate = "UPDATE _User SET ID=@ID, Name=@Name, Phone=@Phone, Mail=@Mail, Dept=@Dept, OSP=@OSP WHERE ID= '" + txtUserID + "'";
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = con;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = strUpdate;
            cmdUpdate.Parameters.AddWithValue("@ID", txtUserID.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@Name", txtUserName.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@Phone", txtPhone.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@Mail", txtMail.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@Dept", txtDept.Text.ToString());
            cmdUpdate.Parameters.AddWithValue("@OSP", Convert.ToInt32(chkOSP.CheckState));
            if (chkOSP.Checked == true && (txtPhone.Text == "" || txtMail.Text == "" || txtUserName.Text == ""))
            {
                MessageBox.Show("Vui long nhap day du thong tin", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                cmdUpdate.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchUser(TextBox txtIDSearch, TextBox txtUserID,  TextBox txtUserName, TextBox txtPhone, TextBox txtMail, TextBox txtDept, CheckBox chkOSP, Button btnUpdate)
        {
            string Search_User = "SELECT * FROM _User WHERE _User.ID='" + txtIDSearch.Text.ToString() + "'";
            SqlDataAdapter daSearch = new SqlDataAdapter(Search_User, con);
            DataTable dtSearch = new DataTable();
            daSearch.Fill(dtSearch);

            if (dtSearch.Rows.Count > 0)
            {
                txtUserID.Text = dtSearch.Rows[0]["ID"].ToString();
                txtUserName.Text = dtSearch.Rows[0]["Name"].ToString();
                txtPhone.Text = dtSearch.Rows[0]["Phone"].ToString();
                txtMail.Text = dtSearch.Rows[0]["Mail"].ToString();
                txtDept.Text = dtSearch.Rows[0]["Dept"].ToString();
                chkOSP.Checked = Convert.ToBoolean(dtSearch.Rows[0]["OSP"]);
                btnUpdate.Enabled = false;
            }
            else
            {
                MessageBox.Show("Khong co thong tin!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = true;
            }
        }
        public void InsertUser(TextBox txtUserID, TextBox txtUserName, TextBox txtPhone, TextBox txtMail, TextBox txtDept, CheckBox chkOSP)
        {
            try
            {
                string strUpdate = "INSERT INTO _User(ID, Name, Phone, Mail, Dept, OSP) VALUES (@ID, @Name, @Phone, @Mail, @Dept, @OSP)";
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = con;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = strUpdate;
                cmdUpdate.Parameters.AddWithValue("@ID", txtUserID.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@Name", txtUserName.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@Phone", txtPhone.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@Mail", txtMail.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@Dept", txtDept.Text.ToString());
                cmdUpdate.Parameters.AddWithValue("@OSP", Convert.ToInt32(chkOSP.CheckState));
                if (chkOSP.Checked == true && (txtPhone.Text == "" || txtMail.Text == "" || txtUserName.Text == ""))
                {
                    MessageBox.Show("Vui long nhap day du thong tin", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    con.Open();
                    cmdUpdate.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Update thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
