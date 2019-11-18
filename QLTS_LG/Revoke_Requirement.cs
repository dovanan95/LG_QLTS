using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace QLTS_LG
{
    public partial class Revoke_Requirement : Form
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        Excel Excel = new Excel();
        public Revoke_Requirement()
        {
            InitializeComponent();
            LoadingFromNSCBGTS();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcelUser_Click(object sender, EventArgs e)
        {
            Excel.ExportExcelFromDGV(dgvUser);
        }

        private void btnExcelDevice_Click(object sender, EventArgs e)
        {
            Excel.ExportExcelFromDGV(dgvDevice);
        }
        private void LoadingFromNSCBGTS()
        {
            string Loading =  "select distinct a.MANV, b.Name, b.Mail, b.Phone, b.Dept, a.NGAY_UPDATE from NSCBGTS a " +
                "inner join tb_user b on a.MANV = b.ID " +
                "where a.BAN_GIAO = 'N'";
            OracleDataAdapter daLoading = new OracleDataAdapter(Loading, con);
            DataTable dtLoading = new DataTable();
            daLoading.Fill(dtLoading);

            dgvUser.DataSource = dtLoading;
            dgvUser.AutoResizeColumns();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvUser.CurrentCell.RowIndex;
            string MaNV = dgvUser.Rows[index].Cells["MANV"].Value.ToString();

            string DeviceOutOfStorage = "select a.MA_TS, b.TEN_TS, c.TEN_LOAI, b.SN, b.FA_TAG, b.IT_TAG, b.MODEL, d.CL_DATE from NGOAI_KHO a " +
                "inner join TAI_SAN b on a.MA_TS = b.MA_TS " +
                "inner join LOAI_TS_CAP2 c on b.MA_LOAI_TS_CAP2 = c.MA_LOAI " +
                "inner join BIEN_BAN d on a.So_BB = d.So_Bien_Ban " +
                "where d.USER_ID = '" + MaNV + "'";
            OracleDataAdapter device = new OracleDataAdapter(DeviceOutOfStorage, con);
            DataTable dthaha = new DataTable();
            device.Fill(dthaha);
            dgvDevice.DataSource = dthaha;
            dgvDevice.AutoResizeColumns();
        }
    }
}
