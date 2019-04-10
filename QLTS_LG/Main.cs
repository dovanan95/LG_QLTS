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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        static string connectionString= ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        public void Search_Item(int SoDanhMuc)
        {
            this.Hide();
            string text = SoDanhMuc.ToString();
            Form frm = new Search(text);
            //frm.Text = "Danh Mục";
            frm.ShowDialog();
            
            
        }
        public void SearchBB(int DMBB)
        {
            Search_BB _BB = new Search_BB();
            _BB.stNhan = DMBB.ToString();
            _BB.strNhan = DMBB.ToString();
            this.Hide();
            _BB.ShowDialog();

        }
        private void Main_Load(object sender, EventArgs e)
        {
           
        }

        private void addNewMenu_Click(object sender, EventArgs e)
        {

        }

        private void menuChangePass_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuInStorage_Click(object sender, EventArgs e)
        {
            this.Hide();
            //int SoDanhMuc = 1;
            Search_Item(1);
        }

        private void menuOutStorage_Click(object sender, EventArgs e)
        {
            this.Hide();
            //int SoDanhMuc = 2;
            Search_Item(2);
        }

        private void menuAddNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewItem frm = new AddNewItem();
            frm.ShowDialog();
            //this.Hide();
        }

        private void nhâpMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBB(1);
        }

        private void menuInStorageBB_Click(object sender, EventArgs e)
        {
            SearchBB(2);
        }

        private void menuOutStorageBB_Click(object sender, EventArgs e)
        {
            SearchBB(3);
        }

        private void menuLendingBB_Click(object sender, EventArgs e)
        {
            SearchBB(4);
        }

        private void menuRepairBB_Click(object sender, EventArgs e)
        {
            SearchBB(5);
        }

        private void menuDisposeBB_Click(object sender, EventArgs e)
        {
            SearchBB(6);
        }

        private void menuHist_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void menuReCall_Click(object sender, EventArgs e)
        {
            this.Hide();
            Revoke frm = new Revoke();
            frm.ShowDialog();
        }
    }
}
