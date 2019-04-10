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
    public partial class Search_BB : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        private string _message;
        public string stNhan
        {
            get { return _message; }
            set { _message = value; }
        }
        public string strNhan;
        public string BB_New_In = "Biên Bản Nhập Mới";
        public string BB_In = "Biên Bản Nhập Kho";
        public string BB_Out = "Biên Bản Xuất Kho";
        public string BB_Lend = "Biên Bản Cho Mượn";
        public string BB_Repair = "Biên Bản Sửa Chữa";
        public string BB_Dis = "Biên Bản Hủy Tài Sản";

        public Search_BB()
        {
            InitializeComponent();
            //cbLoaiBB.DisplayMember = "Text";
            //cbLoaiBB.ValueMember = "Value";
            cbLoaiBB.Items.Add(BB_New_In);
            cbLoaiBB.Items.Add(BB_In);
            cbLoaiBB.Items.Add(BB_Out);
            cbLoaiBB.Items.Add(BB_Lend);
            cbLoaiBB.Items.Add(BB_Repair);
            cbLoaiBB.Items.Add(BB_Dis);
            
        }
        public void Loaddata()
        {
            Table.Clear();
            DataAdapter.Fill(Table);
            dataGridView1.DataSource = Table;
            dataGridView1.AutoResizeColumns();
        }

        

        private void Search_BB_Load(object sender, EventArgs e)
        {
            try
            {
                int SDM = Int32.Parse(stNhan);
                switch (SDM)
                {
                    case 1:
                        {
                            this.Text = "Biên Bản Nhập Mới";
                            lblTitle.Text= "Biên Bản Nhập Mới";
                            DataAdapter = new SqlDataAdapter("SELECT * FROM Nhap_Moi", con);
                            //dataGridView1.Columns[0].HeaderText = "So_Bien_Ban";
                            Loaddata();
                            dataGridView1.Columns[0].HeaderText = "So_Bien_Ban";
                        }
                        break;
                    case 2:
                        {
                            this.Text = "Biên Bản Nhập Kho";
                            lblTitle.Text = "Biên Bản Nhập Kho";
                            DataAdapter = new SqlDataAdapter("SELECT * FROM Nhan_tra_TS",con);
                            Loaddata();
                        }
                        break;
                    case 3:
                        {
                            this.Text = "Biên Bản Xuất Kho";
                            lblTitle.Text = this.Text;
                            DataAdapter = new SqlDataAdapter("SELECT * FROM Xuat_Kho",con);
                            Loaddata();
                        }
                        break;
                    case 4:
                        {
                            this.Text = "Biên Bản Cho Mượn";
                            lblTitle.Text = this.Text;
                            DataAdapter = new SqlDataAdapter("SELECT * FROM Muon_vat_tu",con);
                            Loaddata();
                        }
                        break;
                    case 5:
                        {
                            this.Text = "Biên Bản Sửa Chữa";
                            lblTitle.Text = this.Text;
                            DataAdapter = new SqlDataAdapter("SELECT * FROM Sua_chua", con);
                            Loaddata();
                        }
                        break;
                    case 6:
                        {
                            this.Text = "Biên Bản Hủy Tài Sản";
                            lblTitle.Text = this.Text;
                            DataAdapter = new SqlDataAdapter("SELECT * FROM Huy_TS", con);
                            Loaddata();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Table.Clear();
           // DataAdapter.Fill(Table);
           // dataGridView1.DataSource = Table;
           // dataGridView1.AutoResizeColumns();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            this.Hide();
            frm.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbLoaiBB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if(cbLoaiBB.SelectedText="")
        }
    }
}
