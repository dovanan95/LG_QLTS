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
using System.Data.SqlClient;

namespace QLTS_LG
{
    public partial class UserReg : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlConnection con2 = new SqlConnection(connectionString);
        LoadComboboxData LoadCombobox = new LoadComboboxData();

        Cryptography Cryptography = new Cryptography();
        bool flag = false;
        bool flag2 = false;
        public UserReg()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
            txtPassConfirm.PasswordChar = '*';
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserReg_Load(object sender, EventArgs e)
        {
            LoadCombobox.LoadPermission(cbPermission);
            pnlReg.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main main = new Main();
            
            //main.ShowDialog();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.ResetText();
            txtPass.ResetText();
            txtPassConfirm.ResetText();
            txtID.ResetText();
            txtID.Enabled = true;
            flag2 = false;
            pnlReg.Enabled = false;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                string strCheck = "select * from Login";
                SqlCommand cmdCheck = new SqlCommand(strCheck, con2);
                SqlDataReader rdrRead = null;
                con2.Open();
                rdrRead = cmdCheck.ExecuteReader();
                while (rdrRead.Read())
                {
                    if (rdrRead["ID_User"].ToString() == txtUserName.Text.ToString())
                    {
                        flag = true;
                        break;
                    }

                }
                con2.Close();

                if (flag == true)
                {
                    MessageBox.Show("Vui lòng thử tên khác", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.ResetText();
                    txtPass.ResetText();
                    txtPassConfirm.ResetText();
                    flag = false;
                }
                else if (flag == false)
                {
                    if (txtPass.Text.ToString() == txtPassConfirm.Text.ToString())
                    {
                        string strReg = "insert into Login (ID_User, Password, permission, ID) values (@ID, @pass, @per, @ID)";
                        SqlCommand cmdReg = new SqlCommand();
                        cmdReg.Connection = con;
                        cmdReg.CommandType = CommandType.Text;
                        cmdReg.CommandText = strReg;
                        cmdReg.Parameters.AddWithValue("@ID", txtUserName.Text.ToString());
                        cmdReg.Parameters.AddWithValue("@pass", Cryptography.ComputeSha256Hash(txtPass.Text.ToString()));
                        cmdReg.Parameters.AddWithValue("@per", cbPermission.SelectedValue);
                        cmdReg.Parameters.AddWithValue("@ID", txtID.Text.ToString());
                        con.Open();
                        cmdReg.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Finished", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtPass.ResetText();
                        txtPassConfirm.ResetText();
                        txtUserName.ResetText();
                    }
                    else if (txtPass.Text.ToString() != txtPassConfirm.Text.ToString())
                    {
                        MessageBox.Show("Check password confirm!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPass.ResetText();
                        txtPassConfirm.ResetText();
                    }

                }

                /*SqlDataAdapter daCheck = new SqlDataAdapter(cmdCheck);
                DataTable dtCheck = new DataTable();
                daCheck.Fill(dtCheck);
                for (int i = 0; i < dtCheck.Rows.Count - 1; i++)
                {
                    int n = 0;
                    if (dtCheck.Rows[i]["ID_User"].ToString() == txtUserName.Text.ToString())
                    {

                        MessageBox.Show("Vui lòng thử tên khác", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUserName.ResetText();
                        txtPass.ResetText();
                        txtPassConfirm.ResetText();
                    }
                    else if (dtCheck.Rows[i]["ID_User"].ToString() != txtUserName.Text.ToString() && txtUserName.Text.ToString() != "")
                    {
                        if (txtPass.Text.ToString() == txtPassConfirm.Text.ToString())
                        {
                            string strReg = "insert into Login (ID_User, Password, permission) values (@ID, @pass, @per)";
                            SqlCommand cmdReg = new SqlCommand();
                            cmdReg.Connection = con;
                            cmdReg.CommandType = CommandType.Text;
                            cmdReg.CommandText = strReg;
                            cmdReg.Parameters.AddWithValue("@ID", txtUserName.Text.ToString());
                            cmdReg.Parameters.AddWithValue("@pass", Cryptography.ComputeSha256Hash(txtPass.Text.ToString()));
                            cmdReg.Parameters.AddWithValue("@per", cbPermission.SelectedValue);
                            con.Open();
                            cmdReg.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Finished", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtPass.ResetText();
                            txtPassConfirm.ResetText();
                            txtUserName.ResetText();
                        }
                        else if (txtPass.Text.ToString() != txtPassConfirm.Text.ToString())
                        {
                            MessageBox.Show("Check password confirm!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }

            */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string strCheckExist = "select ID from _User";
            SqlCommand cmdCE = new SqlCommand(strCheckExist, con);
            SqlDataReader rdrCE = null;

          

            con.Open();
            rdrCE = cmdCE.ExecuteReader();
            while(rdrCE.Read())
            {
                if(txtID.Text.ToUpper() == rdrCE["ID"].ToString())
                {
                    flag2 = true;
                }

            }
            con.Close();

            if (flag2 == true)
            {
                pnlReg.Enabled = true;
                txtID.Enabled = false;
            }
            else if (flag2 == false)
            {
                DialogResult dialog = MessageBox.Show("Account is not exist!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if(dialog == DialogResult.OK)
                {
                    txtID.ResetText();
                    
                }
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnCheck_Click(this, new EventArgs());
            }
        }
    }
}

