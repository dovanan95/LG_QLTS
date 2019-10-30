using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    class Report
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleConnection con2 = new OracleConnection(connectionString);

        Bien_Ban frm = new Bien_Ban();


        private string Export = "Xuat_Kho";
        private string Repair = "Sua_chua";
        private string Borrow = "Muon_vat_tu";
        private string Revoke = "Nhan_tra_TS";

        private string Report_type = "";
        private string Report_type_private = "";

        private string strGridviewTransferData = "";
        private string strGridviewTransferDataForAdditional = "";
        private string strGridviewTransferDataforAdditionalofRepair = "";

        
        public void TestBB(string SoBB)
        {
            try
            {

                string strTypeBB = "select b.Ten_loai, a.Reason, a.CL_DATE from Loai_Bien_ban b inner join Bien_Ban a on b.Ma_loai = a.Ma_loai_BB where a.So_Bien_ban = '" + SoBB + "'";
                OracleDataAdapter daTypeBB = new OracleDataAdapter(strTypeBB, con);
                DataTable dtTypeBB = new DataTable();
                daTypeBB.Fill(dtTypeBB);

                string Receiver = "select * from TB_User a inner join Bien_Ban b on a.ID = b.User_ID where b.So_Bien_ban = '" + SoBB + "'";

                OracleDataAdapter daRcv = new OracleDataAdapter(Receiver, con);
                DataTable dtRcv = new DataTable();
                daRcv.Fill(dtRcv);

                string Deliver = "select * from TB_User a inner join Bien_Ban b on a.ID = b.IT_OP where b.So_Bien_ban = '" + SoBB + "'";
                OracleDataAdapter daDlv = new OracleDataAdapter(Deliver, con2);
                DataTable dtDlv = new DataTable();
                daDlv.Fill(dtDlv);


                string TypeReport = dtTypeBB.Rows[0]["Ten_loai"].ToString().Trim();
                if (TypeReport == "IN_STORAGE")
                {
                    Report_type = Revoke;
                    Report_type_private = "So_BB_nhan";
                }
                else if (TypeReport == "OUT_STORAGE")
                {
                    Report_type = Export;
                    Report_type_private = "So_BB_xuat";
                }
                else if (TypeReport == "REPAIR")
                {
                    Report_type = Repair;
                    Report_type_private = "BB_sua";
                    
                }
                else if (TypeReport == "TEMP_OUT_STORAGE")
                {
                    Report_type = Borrow;
                    Report_type_private = "So_BB";
                    string DueDate = "select Due_date from Muon_vat_tu where So_BB = '" + SoBB + "'";
                    OracleDataAdapter daExpired = new OracleDataAdapter(DueDate, con);
                    DataTable dtExpired = new DataTable();
                    daExpired.Fill(dtExpired);
                    string Due_date = dtExpired.Rows[0][0].ToString();
                    frm.Note = "Return Date:" + Due_date;
                }

                strGridviewTransferData =
                        "select a.Ma_TS, a.Ten_TS, c.Ten_loai, a.SN, a.FA_Tag, a.IT_Tag, a.Model, d.unit_name, e.Ten_tinh_trang " +
                        "from Tai_san a " +
                        "inner join " + Report_type + " b on a.Ma_TS = b.Ma_TS " +
                        "inner join Loai_TS_cap2 c on a.Ma_Loai_TS_cap2 = c.Ma_loai " +
                        "inner join Unit d on d.unit_id = a.Unit " +
                        "inner join Status e on e.Ma_tinh_Trang  = a.Ma_tinh_trang " +
                        "where b." + Report_type_private + "= '" + SoBB + "' and a.Ma_Loai_TS_cap1 = 'DE'";

                strGridviewTransferDataForAdditional =
                        "select a.Ma_TS, a.Ten_TS, c.Ten_loai, a.SN, a.Model, d.unit_name, e.Ten_tinh_trang " +
                        "from Tai_san a " +
                        "inner join " + Report_type + " b on a.Ma_TS = b.Ma_TS " +
                        "inner join Loai_TS_cap2 c on a.Ma_Loai_TS_cap2 = c.Ma_loai " +
                        "inner join Unit d on d.unit_id = a.Unit " +
                        "inner join Status e on e.Ma_tinh_Trang  = a.Ma_tinh_trang " +
                        "where not a.Ma_Loai_TS_cap1 = 'DE' and b." + Report_type_private + " = '" + SoBB + "'";

                strGridviewTransferDataforAdditionalofRepair =
                        "select a.Ma_TS, a.Ten_TS, c.Ten_loai, a.SN, a.Model, d.unit_name, e.Ten_tinh_trang " +
                        "from Tai_san a " +
                        "inner join " + Report_type + " b on a.Ma_TS = b.Vat_tu_xuat " +
                        "inner join Loai_TS_cap2 c on a.Ma_Loai_TS_cap2 = c.Ma_loai " +
                        "inner join Unit d on d.unit_id = a.Unit " +
                        "inner join Status e on e.Ma_tinh_Trang  = a.Ma_tinh_trang " +
                        "where not a.Ma_Loai_TS_cap1 = 'DE' and b." + Report_type_private + " = '" + SoBB + "'";

                SqlCommand cmdGTD = new SqlCommand();

                OracleDataAdapter daDevice = new OracleDataAdapter(strGridviewTransferData, con);
                DataTable dtDevice = new DataTable();
                daDevice.Fill(dtDevice);
                //DataGridView gridView = new DataGridView();
                //gridView.DataSource = dtTest;

                OracleDataAdapter daMaterial = new OracleDataAdapter();
                if(TypeReport == "REPAIR")
                {
                    daMaterial = new OracleDataAdapter(strGridviewTransferDataforAdditionalofRepair, con2);
                }
                else if(TypeReport != "REPAIR")
                {
                    daMaterial = new OracleDataAdapter(strGridviewTransferDataForAdditional, con2);
                }
                DataTable dtMaterial = new DataTable();
                daMaterial.Fill(dtMaterial);

                frm.SoBB = SoBB;
                frm.Type_BB = dtTypeBB.Rows[0]["Ten_loai"].ToString();
                frm.Reason = dtTypeBB.Rows[0]["Reason"].ToString();
                frm.DATE = dtTypeBB.Rows[0]["CL_DATE"].ToString();

                frm.dtDevice = dtDevice;
                frm.dtMaterial = dtMaterial;

                frm.ID_Dlv = dtDlv.Rows[0]["ID"].ToString();
                frm.Name_Dlv = dtDlv.Rows[0]["Name"].ToString();
                frm.Phone_Dlv = dtDlv.Rows[0]["Phone"].ToString();
                frm.Mail_Dlv = dtDlv.Rows[0]["Mail"].ToString();
                frm.Dept_Dlv = dtDlv.Rows[0]["Dept"].ToString();

                frm.ID_Rcv = dtRcv.Rows[0]["ID"].ToString();
                frm.Name_Rcv = dtRcv.Rows[0]["Name"].ToString();
                frm.Phone_Rcv = dtRcv.Rows[0]["Phone"].ToString();
                frm.Mail_Rcv = dtRcv.Rows[0]["Mail"].ToString();
                frm.Dept_Rcv = dtRcv.Rows[0]["Dept"].ToString();
                                
                frm.WindowState = FormWindowState.Maximized;
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.TopMost = true;
                frm.ShowDialog();

                //frm.gridView = gridView;
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }
    }
}
