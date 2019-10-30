using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class Change_Password : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleConnection con2 = new OracleConnection(connectionString);
        Cryptography Encoding = new Cryptography();

        public Change_Password()
        {
            InitializeComponent();

            lblUser.Text = Login.username;
            txtOldPass.PasswordChar = '*';
            txtNewPass.PasswordChar = '*';
            txtConfirm.PasswordChar = '*';
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            this.Close();
            //main.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtOldPass.ResetText();
            txtNewPass.ResetText();
            txtConfirm.ResetText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string OldPass = Encoding.ComputeSha256Hash(txtOldPass.Text.ToString());
            string NewPass = Encoding.ComputeSha256Hash(txtNewPass.Text.ToString());

            string strCheck = "select * from Login where ID_User = '" + lblUser.Text.ToString() + "'";
            OracleCommand cmdCheck = new OracleCommand(strCheck, con);
            //SqlDataAdapter daCheck = new SqlDataAdapter(strCheck, con);
           // DataTable dtCheck = new DataTable();
            //daCheck.Fill(dtCheck);
            OracleDataReader rdrRead = null;
            con.Open();
            rdrRead = cmdCheck.ExecuteReader();

            while (rdrRead.Read())
            {
                if (OldPass == rdrRead["Password"].ToString())
                {
                    if (txtOldPass.Text.ToString() != txtNewPass.Text.ToString() && txtNewPass.Text.ToString() == txtConfirm.Text.ToString())
                    {
                        string strChangePass = "update Login set Password = '" + NewPass + "' where ID_User = '" + lblUser.Text.ToString() + "'";
                        OracleCommand cmdChangePass = new OracleCommand();
                        cmdChangePass.Connection = con2;
                        cmdChangePass.CommandType = CommandType.Text;
                        cmdChangePass.CommandText = strChangePass;
                        con2.Open();
                        cmdChangePass.ExecuteNonQuery();
                        con2.Close();

                        MessageBox.Show("Change password successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtOldPass.ResetText();
                        txtNewPass.ResetText();
                        txtConfirm.ResetText();
                    }
                    else if (txtOldPass.Text.ToString() == txtNewPass.Text.ToString())
                    {
                        MessageBox.Show("Duplicated Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (txtNewPass.Text.ToString() != txtConfirm.Text.ToString())
                    {
                        MessageBox.Show("Password confirm not matched!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (OldPass != rdrRead["Password"].ToString())
                {
                    MessageBox.Show("Incorrect Password!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            con.Close();

        }
    }
}
