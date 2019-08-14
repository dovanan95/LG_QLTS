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
    public partial class Transaction : Form
    {
        Excel excel = new Excel();
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        CopyGridView CopyGrid = new CopyGridView();
        AutoComplete AutoComplete = new AutoComplete();

        DataTable dtTransaction = new DataTable();

        public Transaction()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            this.Close();
            //main.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string start_date = dateTimePicker1.Value.ToString();
            string end_date = dateTimePicker2.Value.ToString();
            string MTS = txtID.Text.ToString();
            string strSearch =
                "select a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.DATE, d.[User ID] " +
                "from Nhap_Moi as a " +
                "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban as d on d.So_Bien_ban = a.So_BB " +
                "inner join Loai_TS_cap2 as e on e.Ma_loai = b.Ma_loai_TS_cap2 " +
                "inner join Loai_Bien_ban as c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = '" + MTS + "' and d.DATE Between '" + start_date + "' and '" + end_date + "' " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.DATE, d.[User ID] " +
                "from Sua_chua as a " +
                "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_Ban as d on d.So_Bien_ban = a.BB_sua " +
                "inner join Loai_TS_cap2 as e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban as c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = '" + MTS + "' and d.DATE Between '" + start_date + "' and '" + end_date + "' " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.DATE, d.[User ID] " +
                "from Xuat_Kho as a " +
                "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban as d on d.So_Bien_ban =  a.So_BB_xuat " +
                "inner join Loai_TS_cap2 as e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban as c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = '" + MTS + "' and d.DATE Between '" + start_date + "' and '" + end_date + "' " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.DATE, d.[User ID] " +
                "from Nhan_tra_TS as a " +
                "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban as d on d.So_Bien_ban = a.So_BB_nhan " +
                "inner join Loai_TS_cap2 as e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban as c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = '" + MTS + "' and d.DATE Between '" + start_date + "' and '" + end_date + "' " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.DATE, d.[User ID] " +
                "from Muon_vat_tu as a " +
                "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban as d on d.So_Bien_ban = a.So_BB " +
                "inner join Loai_TS_cap2 as e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban as c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = '" + MTS + "' and d.DATE Between '" + start_date + "' and '" + end_date + "' " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.DATE, d.[User ID] " +
                "from Huy_TS as a " +
                "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban as d on d.So_Bien_ban = a.BB_Huy " +
                "inner join Loai_TS_cap2 as e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban as c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = '" + MTS + "' and d.DATE Between '" + start_date + "' and '" + end_date + "' " +
                "union all " +
                "select a.Vat_tu_xuat, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.DATE, d.[User ID] " +
                "from Sua_chua as a " +
                "inner join Tai_san as b on a.Vat_tu_xuat = b.Ma_TS " +
                "inner join Bien_ban as d on d.So_Bien_ban = a.BB_sua " +
                "inner join Loai_TS_cap2 as e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban as c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Vat_tu_xuat = '" + MTS + "' and d.DATE Between '" + start_date + "' and '" + end_date + "' " +
                "order by d.So_Bien_ban asc";

            SqlDataAdapter daTransaction = new SqlDataAdapter(strSearch, con);
            
            daTransaction.Fill(dtTransaction);
            dgvTransaction.DataSource = dtTransaction;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string strSN = "select * from Tai_san where [S/N] = '" + txtSN.Text.ToString() + "'";
            string strFA = "select * from Tai_san where FA_Tag =  '" + txtFA_Tag.Text.ToString() + "'";
            string strIT = "select * from Tai_san where IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";

            SqlDataAdapter daSN = new SqlDataAdapter(strSN, con);
            DataTable dtSN = new DataTable();
            daSN.Fill(dtSN);

            SqlDataAdapter daFA = new SqlDataAdapter(strFA, con);
            DataTable dtFA = new DataTable();
            daFA.Fill(dtFA);

            SqlDataAdapter daIT = new SqlDataAdapter(strIT, con);
            DataTable dtIT = new DataTable();
            daIT.Fill(dtIT);

            try
            {
                if (txtFA_Tag.Text.ToString() != "")
                {
                    string FA = dtFA.Rows[0]["Ma_TS"].ToString();
                    txtID.Text = FA;
                }
                else if (txtSN.Text.ToString() != "")
                {
                    string SN = dtSN.Rows[0]["Ma_TS"].ToString();
                    txtID.Text = SN;
                }
                else if (txtIT_Tag.Text.ToString() != "")
                {
                    string IT = dtIT.Rows[0]["Ma_TS"].ToString();
                    txtID.Text = IT;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //excel.Export_Excel(saveFileDialog1, dgvTransaction);
            excel.Export_Excel3(dtTransaction);
        }
    }
}
