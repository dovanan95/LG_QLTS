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
    public partial class Search : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
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
                            DataAdapter = new SqlDataAdapter(
                                "SELECT Luu_Kho.Ma_TS, Status.Ten_tinh_trang, Luu_Kho.Ngay_update, Tai_san.Ten_TS, Loai_TS_cap1.Ten_loai, Loai_TS_cap2.Ten_loai " +
                                "FROM Luu_Kho " +
                                "INNER JOIN Tai_san ON Luu_Kho.Ma_TS=Tai_san.Ma_TS " +
                                "INNER JOIN Loai_TS_cap1 ON Tai_san.Ma_Loai_TS_cap1 = Loai_TS_cap1.Ma_loai " +
                                "INNER JOIN Loai_TS_cap2 ON Tai_san.Ma_Loai_TS_cap2 = Loai_TS_cap2.Ma_loai " +
                                "INNER JOIN Status ON Luu_Kho.Tinh_Trang=Status.Ma_tinh_trang", con);
                            Loaddata();
                        }
                        break;
                    case 2:
                        {
                            this.Text = "Tài sản ngoại kho";
                            lblTitle.Text = "Tài sản ngoại kho";
                            DataAdapter = new SqlDataAdapter(
                                "SELECT Ngoai_Kho.Ma_TS, Tai_san.Ten_TS, Loai_TS_cap1.Ten_loai, Loai_TS_cap2.Ten_loai, Ngoai_Kho.ID_User, _User.Name, _User.Phone, Ngoai_Kho.Latest_Day_Out " +
                                "FROM Ngoai_Kho " +
                                "INNER JOIN Tai_san ON Ngoai_Kho.Ma_TS = Tai_san.Ma_TS " +
                                "INNER JOIN [dbo].[_User] ON [dbo].[_User].[ID] = [dbo].[Ngoai_Kho].[ID_User] " +
                                "INNER JOIN Loai_TS_cap1 ON Tai_san.Ma_Loai_TS_cap1 = Loai_TS_cap1.Ma_loai " +
                                "INNER JOIN Loai_TS_cap2 ON Tai_san.Ma_Loai_TS_cap2 = Loai_TS_cap2.Ma_loai ", con);
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
