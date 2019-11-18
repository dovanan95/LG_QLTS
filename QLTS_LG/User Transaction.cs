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
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class User_Transaction : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        Excel Excel = new Excel();
        
       
        public User_Transaction()
        {
            InitializeComponent();
            //tabDevice.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            this.Hide();
            this.Close();
            //frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                HRLOADING();

                var start_date = dtpUserStart.Value.ToString("yyyy/MM/dd HH:mm:ss");
                var end_date = dtpUserEnd.Value.ToString("yyyy/MM/dd HH:mm:ss");

                string Tai_san_dang_so_huu = "select a.MA_TS, b.TEN_TS, c.TEN_LOAI, b.SN, b.FA_TAG, b.IT_TAG, b.MODEL, e.ten_loai, d.cl_date from nhap_moi a " +
                    "inner join tai_san b on a.MA_TS = b.MA_TS " +
                    "inner join loai_ts_cap2 c on b.MA_LOAI_TS_CAP2 = c.MA_LOAI " +
                    "inner join bien_ban d on d.So_BIen_Ban = a.So_BB " +
                    "inner join loai_bien_ban e on e.ma_loai = d.ma_loai_BB " +
                    "where d.USER_ID = '" + txtUserID.Text.ToString().ToUpper() + "' " +
                    "and d.cl_date Between (to_date('" + start_date + "',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('" + end_date + "',  'yyyy/mm/dd hh24:mi:ss')) " +
                    "union all " +
                    "select a.MA_TS, b.TEN_TS, c.TEN_LOAI, b.SN, b.FA_TAG, b.IT_TAG, b.MODEL, e.ten_loai, d.cl_date from xuat_kho a " +
                    "inner join tai_san b on a.MA_TS = b.MA_TS " +
                    "inner join loai_ts_cap2 c on b.MA_LOAI_TS_CAP2 = c.MA_LOAI " +
                    "inner join bien_ban d on d.So_BIen_Ban = a.So_BB_xuat " +
                    "inner join loai_bien_ban e on e.ma_loai = d.ma_loai_BB " +
                    "where d.USER_ID = '" + txtUserID.Text.ToString().ToUpper() + "' " +
                    "and d.cl_date Between (to_date('" + start_date + "',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('" + end_date + "',  'yyyy/mm/dd hh24:mi:ss')) " +
                    "union all " +
                    "select a.MA_TS, b.TEN_TS, c.TEN_LOAI, b.SN, b.FA_TAG, b.IT_TAG, b.MODEL, e.ten_loai, d.cl_date from nhan_tra_TS a " +
                    "inner join tai_san b on a.MA_TS = b.MA_TS " +
                    "inner join loai_ts_cap2 c on b.MA_LOAI_TS_CAP2 = c.MA_LOAI " +
                    "inner join bien_ban d on d.So_BIen_Ban = a.So_BB_Nhan " +
                    "inner join loai_bien_ban e on e.ma_loai = d.ma_loai_BB " +
                    "where d.USER_ID = '" + txtUserID.Text.ToString().ToUpper() + "' " +
                    "and d.cl_date Between (to_date('" + start_date + "',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('" + end_date + "',  'yyyy/mm/dd hh24:mi:ss')) " +
                    "union all " +
                    "select a.MA_TS, b.TEN_TS, c.TEN_LOAI, b.SN, b.FA_TAG, b.IT_TAG, b.MODEL, e.ten_loai, d.cl_date from muon_vat_tu a " +
                    "inner join tai_san b on a.MA_TS = b.MA_TS " +
                    "inner join loai_ts_cap2 c on b.MA_LOAI_TS_CAP2 = c.MA_LOAI " +
                    "inner join bien_ban d on d.So_BIen_Ban = a.So_BB " +
                    "inner join loai_bien_ban e on e.ma_loai = d.ma_loai_BB " +
                    "where d.USER_ID = '" + txtUserID.Text.ToString().ToUpper() + "' " +
                    "and d.cl_date Between (to_date('" + start_date + "',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('" + end_date + "',  'yyyy/mm/dd hh24:mi:ss')) " +
                    "union all " +
                    "select a.MA_TS, b.TEN_TS, c.TEN_LOAI, b.SN, b.FA_TAG, b.IT_TAG, b.MODEL, e.ten_loai, d.cl_date from sua_chua a " +
                    "inner join tai_san b on a.MA_TS = b.MA_TS " +
                    "inner join loai_ts_cap2 c on b.MA_LOAI_TS_CAP2 = c.MA_LOAI " +
                    "inner join bien_ban d on d.So_BIen_Ban = a.BB_Sua " +
                    "inner join loai_bien_ban e on e.ma_loai = d.ma_loai_BB " +
                    "where d.USER_ID = '" + txtUserID.Text.ToString().ToUpper() + "' " +
                    "and d.cl_date Between (to_date('" + start_date + "',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('" + end_date + "',  'yyyy/mm/dd hh24:mi:ss')) " +
                    "union all " +
                    "select a.VAT_TU_XUAT, b.TEN_TS, c.TEN_LOAI, b.SN, b.FA_TAG, b.IT_TAG, b.MODEL, e.ten_loai, d.cl_date from sua_chua a " +
                    "inner join tai_san b on a.VAT_TU_XUAT = b.MA_TS " +
                    "inner join loai_ts_cap2 c on b.MA_LOAI_TS_CAP2 = c.MA_LOAI " +
                    "inner join bien_ban d on d.So_BIen_Ban = a.BB_Sua " +
                    "inner join loai_bien_ban e on e.ma_loai = d.ma_loai_BB " +
                    "where d.USER_ID = '" + txtUserID.Text.ToString().ToUpper() + "' " +
                    "and d.cl_date Between (to_date('" + start_date + "',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('" + end_date + "',  'yyyy/mm/dd hh24:mi:ss')) " +
                    "union all " +
                    "select a.ma_TS, b.TEN_TS, c.TEN_LOAI, b.SN, b.FA_TAG, b.IT_TAG, b.MODEL, e.ten_loai, d.cl_date from huy_ts a " +
                    "inner join tai_san b on a.ma_ts = b.MA_TS " +
                    "inner join loai_ts_cap2 c on b.MA_LOAI_TS_CAP2 = c.MA_LOAI " +
                    "inner join bien_ban d on d.So_BIen_Ban = a.BB_Huy " +
                    "inner join loai_bien_ban e on e.ma_loai = d.ma_loai_BB " +
                    "where d.USER_ID = '" + txtUserID.Text.ToString().ToUpper() + "' " +
                    "and d.cl_date Between (to_date('" + start_date + "',  'yyyy/mm/dd hh24:mi:ss')) and (to_date('" + end_date + "',  'yyyy/mm/dd hh24:mi:ss')) " +
                    "order by cl_date";

                OracleDataAdapter daOUT = new OracleDataAdapter(Tai_san_dang_so_huu, con);
                DataTable dtOUT = new DataTable();
                daOUT.Fill(dtOUT);
                dgvUser.DataSource = dtOUT;
                dgvUser.Columns["TEN_LOAI1"].HeaderText = "Loại Giao Dịch";
                dgvUser.AutoResizeRows();
                dgvUser.AutoResizeColumns();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcel1_Click(object sender, EventArgs e)
        {
            Excel.ExportExcelFromDGV(dgvUser);
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }
        private void HRLOADING()
        {
            try
            {
                string HR = "select * from tb_user where ID = '" + txtUserID.Text.ToString().ToUpper() + "'";
                OracleDataAdapter daHR = new OracleDataAdapter(HR, con);
                DataTable dtHR = new DataTable();
                daHR.Fill(dtHR);

                lblName.Text = dtHR.Rows[0]["Name"].ToString();
                lblMail.Text = dtHR.Rows[0]["Mail"].ToString();
                lblPhone.Text = dtHR.Rows[0]["Phone"].ToString();
                lblDept.Text = dtHR.Rows[0]["Dept"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
