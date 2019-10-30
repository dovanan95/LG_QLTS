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
    public partial class Transaction : Form
    {
        Excel excel = new Excel();
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
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
            dtTransaction.Clear();

            var start_date = dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm:ss");
            var end_date = dateTimePicker2.Value.ToString("yyyy/MM/dd HH:mm:ss");
            string MTS = txtID.Text.ToString();
            string strSearch =
                "select a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.CL_DATE, d.User_ID " +
                "from Nhap_Moi a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban d on d.So_Bien_ban = a.So_BB " +
                "inner join Loai_TS_cap2 e on e.Ma_loai = b.Ma_loai_TS_cap2 " +
                "inner join Loai_Bien_ban c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = :MTS and d.CL_DATE Between  (to_date('"+ start_date +"',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('"+ end_date +"',  'yyyy/mm/dd hh24:mi:ss')) " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.CL_DATE, d.User_ID " +
                "from Sua_chua a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_Ban d on d.So_Bien_ban = a.BB_sua " +
                "inner join Loai_TS_cap2 e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = :MTS and d.CL_DATE Between (to_date('"+ start_date +"',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('"+ end_date +"',  'yyyy/mm/dd hh24:mi:ss')) " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.CL_DATE, d.User_ID " +
                "from Xuat_Kho a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban d on d.So_Bien_ban =  a.So_BB_xuat " +
                "inner join Loai_TS_cap2 e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = :MTS and d.CL_DATE Between (to_date('"+ start_date +"',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('"+ end_date +"',  'yyyy/mm/dd hh24:mi:ss')) " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.CL_DATE, d.User_ID " +
                "from Nhan_tra_TS a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban d on d.So_Bien_ban = a.So_BB_nhan " +
                "inner join Loai_TS_cap2 e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = :MTS and d.CL_DATE Between (to_date('"+ start_date +"',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('"+ end_date +"',  'yyyy/mm/dd hh24:mi:ss')) " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.CL_DATE, d.User_ID " +
                "from Muon_vat_tu a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban d on d.So_Bien_ban = a.So_BB " +
                "inner join Loai_TS_cap2 e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = :MTS and d.CL_DATE Between (to_date('"+ start_date +"',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('"+ end_date +"',  'yyyy/mm/dd hh24:mi:ss')) " +
                "union all " +
                "select a.Ma_TS, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.CL_DATE, d.User_ID " +
                "from Huy_TS a " +
                "inner join Tai_san b on a.Ma_TS = b.Ma_TS " +
                "inner join Bien_ban d on d.So_Bien_ban = a.BB_Huy " +
                "inner join Loai_TS_cap2 e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Ma_TS = :MTS and d.Cl_DATE Between (to_date('"+ start_date +"',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('"+ end_date +"',  'yyyy/mm/dd hh24:mi:ss')) " +
                "union all " +
                "select a.Vat_tu_xuat, b.Ten_TS, b.SN, b.FA_Tag, b.IT_Tag, b.Model, e.Ten_loai, d.So_Bien_ban, c.Ten_loai, d.CL_DATE, d.User_ID " +
                "from Sua_chua a " +
                "inner join Tai_san b on a.Vat_tu_xuat = b.Ma_TS " +
                "inner join Bien_ban d on d.So_Bien_ban = a.BB_sua " +
                "inner join Loai_TS_cap2 e on e.Ma_loai = b.Ma_Loai_TS_cap2 " +
                "inner join Loai_Bien_ban c on c.Ma_loai = d.Ma_loai_BB " +
                "where a.Vat_tu_xuat = :MTS and d.CL_DATE Between (to_date('"+ start_date +"',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('"+ end_date +"',  'yyyy/mm/dd hh24:mi:ss')) order by so_bien_ban asc ";
            OracleCommand cmdTransaction = new OracleCommand(strSearch, con);
            cmdTransaction.CommandType = CommandType.Text;
            cmdTransaction.CommandText = strSearch;
            //cmdTransaction.Parameters.Add(new OracleParameter("start_date", start_date));
            //cmdTransaction.Parameters.Add(new OracleParameter("end_date", end_date));
            cmdTransaction.Parameters.Add(new OracleParameter("MTS", MTS));
            OracleDataAdapter daTransaction = new OracleDataAdapter(cmdTransaction);

            daTransaction.Fill(dtTransaction);
            dgvTransaction.DataSource = dtTransaction;


        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string strSN = "select * from Tai_san where SN = '" + txtSN.Text.ToString() + "'";
            string strFA = "select * from Tai_san where FA_Tag =  '" + txtFA_Tag.Text.ToString() + "'";
            string strIT = "select * from Tai_san where IT_Tag = '" + txtIT_Tag.Text.ToString() + "'";

            OracleDataAdapter daSN = new OracleDataAdapter(strSN, con);
            DataTable dtSN = new DataTable();
            daSN.Fill(dtSN);

            OracleDataAdapter daFA = new OracleDataAdapter(strFA, con);
            DataTable dtFA = new DataTable();
            daFA.Fill(dtFA);

            OracleDataAdapter daIT = new OracleDataAdapter(strIT, con);
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
                MessageBox.Show("No Information!!!", "Transaction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //excel.Export_Excel(saveFileDialog1, dgvTransaction);
            excel.Export_Excel(dtTransaction);
        }
    }
}
