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

namespace QLTS_LG
{
    public partial class Login : Form
    {
               
        public Login()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
        }
        static string connectstring = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;

        Cryptography encode = new Cryptography();

        public static string username { get; set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == null && txtPass.Text == null)
            {
                MessageBox.Show("Vui lòng nhap ID và mat khau!!!", "Error");
            }
            else
            {
                // var loaddata = "SELECT * FROM Login WHERE ID_User='" + txtUser.Text + "'AND Password='" +  txtPass.Text + "'";
                SqlConnection con = new SqlConnection(connectstring);
                //SqlCommand command = new SqlCommand(loaddata, con);
                //command.ExecuteNonQuery();
                string password = encode.ComputeSha256Hash(txtPass.Text.ToString());
                
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Login WHERE ID_User='" + txtUser.Text + "'AND Password='" + password + "'", con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Dang Nhap Thanh Cong!");
                    this.Hide();
                    
                    username = txtUser.Text.ToString().Trim();
                    Main frm = new Main();
                    frm.Show();
                    
                }
                else
                {
                    MessageBox.Show("Vui long kiem tra lai ID, Mat khau", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.ResetText();
                    txtPass.ResetText();
                }
                //username = txtUser.Text.ToString().Trim();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSelectOut_Click(object sender, EventArgs e)
        {

        }

        private void btnApproveOut_Click(object sender, EventArgs e)
        {

        }
    }
}

