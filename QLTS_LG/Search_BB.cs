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
    public partial class Search_BB : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        LoadComboboxData LoadCombobox = new LoadComboboxData();
        DataTable Table = new DataTable();
        Report ExportReport = new Report();

        UploadAndRetrieve FileHandler = new UploadAndRetrieve();

        public string strPublicSearch = "";
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

        string SoBB = string.Empty;
        public Search_BB()
        {
            InitializeComponent();
            //cbLoaiBB.DisplayMember = "Text";
            //cbLoaiBB.ValueMember = "Value";
            /*cbLoaiBB.Items.Add(BB_New_In);
            cbLoaiBB.Items.Add(BB_In);
            cbLoaiBB.Items.Add(BB_Out);
            cbLoaiBB.Items.Add(BB_Lend);
            cbLoaiBB.Items.Add(BB_Repair);
            cbLoaiBB.Items.Add(BB_Dis);*/
            LoadCombobox.LoadTypeOfReport(cbLoaiBB);
            
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
                string SDM =stNhan;
                switch (SDM)
                {
                    case "1":
                        {
                            this.Text = "Biên Bản Nhập Mới";
                            lblTitle.Text= "Biên Bản Nhập Mới";
                            DataAdapter = new OracleDataAdapter("SELECT * FROM Nhap_Moi", con);
                            //dataGridView1.Columns[0].HeaderText = "So_Bien_Ban";
                            Loaddata();
                            
                            dataGridView1.Columns[0].HeaderText = "So_Bien_Ban";
                        }
                        break;
                    case "2":
                        {
                            this.Text = "Biên Bản Nhập Kho";
                            lblTitle.Text = "Biên Bản Nhập Kho";
                            DataAdapter = new OracleDataAdapter("SELECT * FROM Nhan_tra_TS",con);
                            Loaddata();
                        }
                        break;
                    case "3":
                        {
                            this.Text = "Biên Bản Xuất Kho";
                            lblTitle.Text = this.Text;
                            DataAdapter = new OracleDataAdapter("SELECT * FROM Xuat_Kho",con);
                            Loaddata();
                        }
                        break;
                    case "4":
                        {
                            this.Text = "Biên Bản Cho Mượn";
                            lblTitle.Text = this.Text;
                            DataAdapter = new OracleDataAdapter("SELECT * FROM Muon_vat_tu",con);
                            Loaddata();
                        }
                        break;
                    case "5":
                        {
                            this.Text = "Biên Bản Sửa Chữa";
                            lblTitle.Text = this.Text;
                            DataAdapter = new OracleDataAdapter("SELECT * FROM Sua_chua", con);
                            Loaddata();
                        }
                        break;
                    case "6":
                        {
                            this.Text = "Biên Bản Hủy Tài Sản";
                            lblTitle.Text = this.Text;
                            DataAdapter = new OracleDataAdapter("SELECT * FROM Huy_TS", con);
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
            if(dateTimePicker1.Value > dateTimePicker2.Value)
            {
                dateTimePicker1.Value = dateTimePicker2.Value;
            }
        }

        private void cbLoaiBB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var start_date = dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm:ss");
            var end_date = dateTimePicker2.Value.ToString("yyyy/MM/dd HH:mm:ss");
            string ReportTypeCode = cbLoaiBB.SelectedValue.ToString();

            string SoBB = txtSoBB.Text.ToString();
            if(txtSoBB.Text.ToString() == "")
            {
                string strSearch = "select a.so_bien_ban, b.ten_loai, a.CL_DATE, a.file_attach, a.reason, a.user_id, a.IT_OP from bien_ban a " +
                    "inner join loai_bien_ban b on a.ma_loai_bb = b.ma_loai " +
                    "where b.ma_loai = '" + ReportTypeCode +
                    "' and a.cl_date between (to_date('" + start_date + "',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('" + end_date + "',  'yyyy/mm/dd hh24:mi:ss'))";
                OracleDataAdapter daFind = new OracleDataAdapter(strSearch, con);
                DataTable dtFind = new DataTable();
                daFind.Fill(dtFind);
                dataGridView1.DataSource = dtFind;
            }
            else if(!(txtSoBB.Text is null))
            {
                string strSearchBB = "select a.so_bien_ban, b.ten_loai, a.CL_DATE, a.file_attach, a.reason, a.user_id, a.IT_OP from bien_ban a " +
                    "inner join loai_bien_ban b on a.ma_loai_bb = b.ma_loai " +
                    "where a.so_bien_ban = '" + SoBB + "'";
                OracleDataAdapter daBB = new OracleDataAdapter(strSearchBB, con);
                DataTable dtBB = new DataTable();
                daBB.Fill(dtBB);
                dataGridView1.DataSource = dtBB;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ExportReport.TestBB(txtSoBB.Text.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            SoBB = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtSoBB.Text = SoBB;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            SoBB = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtSoBB.Text = SoBB;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileHandler.RetrieveFileFromServer(SoBB, saveFileDialog1);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker2.Value < dateTimePicker1.Value)
            {
                dateTimePicker2.Value = dateTimePicker1.Value;
            }
        }

        private void btnPrintOnline_Click(object sender, EventArgs e)
        {
            ExportReport.Print_Bien_Ban(txtSoBB.Text.ToString());
        }
    }
}
