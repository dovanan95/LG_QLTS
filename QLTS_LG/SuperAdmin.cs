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
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class SuperAdmin : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleConnection con2 = new OracleConnection(connectionString);
       
        Excel excel = new Excel();

        public SuperAdmin()
        {
            InitializeComponent();
        }

        private void btnQuerry_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtQuerry = new DataTable();
                dtQuerry.Clear();
                string strQuerry = txtQuerry.Text.ToString();
                OracleDataAdapter daQuerry = new OracleDataAdapter(strQuerry, con);
                
                daQuerry.Fill(dtQuerry);
                dgvQuerry.DataSource = dtQuerry;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Main frm = new Main();
            
            frm.ShowDialog();
            
        }

        private void txtQuerry_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnQuerry_Click(this, new EventArgs());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtQuerry.ResetText();
                
                //dtQuerry.Clear();
                //dtQuerry.Dispose();
                dgvQuerry.DataSource = null;
                dgvQuerry.Rows.Clear();
                dgvQuerry.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                string strExe = txtQuerry.Text.ToString();
                OracleCommand cmdExe = new OracleCommand();
                cmdExe.Connection = con2;
                cmdExe.CommandType = CommandType.Text;
                cmdExe.CommandText = strExe;
                con2.Open();
                cmdExe.ExecuteNonQuery();
                con2.Close();

                MessageBox.Show("Execute Successfully", "SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con2.Close();
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //excel.Export_Excel(dtQuerry);
            excel.ExportExcelFromDGV(dgvQuerry);
        }
    }
}
