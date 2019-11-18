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
    public partial class Search : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();
       // Form frm = new Form();

        public void Loaddata()
        {
            Table.Clear();
            DataAdapter.Fill(Table);
            dataGridView1.DataSource = Table;
            dataGridView1.AutoResizeColumns();
        }
        public Search(string text)
        {
            
            InitializeComponent();
            con.Open();
            try
            {
                //Main frm1 = new Main();

                //Form frm = new Search();
                //int SoDanhMuc = 0;
                //int SoDanhMuc = Int32.Parse(frm.Text);
                int SoDanhMuc = Int32.Parse(text);
                switch (SoDanhMuc)
                {
                    case 1:
                        {
                            this.Text = "Tài sản lưu kho";
                            lblTitle.Text = "Tài sản lưu kho";
                            DataAdapter = new OracleDataAdapter(
                                "SELECT a.Ma_TS, a.Tinh_Trang, a.Ngay_update, b.Ten_TS, c.Ten_loai, d.Ten_loai " +
                                "FROM Luu_Kho a " +
                                "INNER JOIN Tai_san b ON a.Ma_TS = b.Ma_TS " +
                                "INNER JOIN Loai_TS_cap1 c ON b.Ma_Loai_TS_cap1 = c.Ma_loai " +
                                "INNER JOIN Loai_TS_cap2 d ON b.Ma_Loai_TS_cap2 = d.Ma_loai ", con);
                            Loaddata();
                        }
                        break;
                    case 2:
                        {
                            this.Text = "Tài sản ngoại kho";
                            lblTitle.Text = "Tài sản ngoại kho";
                            DataAdapter = new OracleDataAdapter(
                                "SELECT a.Ma_TS, b.Ten_TS, d.Ten_loai, e.Ten_loai, f.USER_ID, c.Name, c.Phone, a.Latest_Day_Out " +
                                "FROM Ngoai_Kho a " +
                                "inner join Bien_Ban f on a.So_BB = f.So_Bien_Ban " +
                                "INNER JOIN Tai_san b ON a.Ma_TS = b.Ma_TS " +
                                "INNER JOIN TB_User c ON c.ID = f.USER_ID " +
                                "INNER JOIN Loai_TS_cap1 d ON b.Ma_Loai_TS_cap1 = d.Ma_loai " +
                                "INNER JOIN Loai_TS_cap2 e ON b.Ma_Loai_TS_cap2 = e.Ma_loai ", con);
                            Loaddata();
                        }
                        break;
                }
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }
    
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}
