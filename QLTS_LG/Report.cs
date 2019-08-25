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
using CrystalDecisions.CrystalReports.Engine;


namespace QLTS_LG
{
    class Report
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlConnection con2 = new SqlConnection(connectionString);
        public void BienBanXuatKho(string SoBB)
        {
            try
            {
                string strReason = "select Reason from Bien_Ban where So_Bien_ban = '" + SoBB + "'";
                SqlDataAdapter daReason = new SqlDataAdapter(strReason, con2);
                DataTable dtReason = new DataTable();
                daReason.Fill(dtReason);

                string strUser = "select * from _User as a inner join Xuat_Kho as b on a.ID = b.ID_nguoi_nhan where b.So_BB_xuat = '" + SoBB + "'";
                SqlDataAdapter daUser = new SqlDataAdapter(strUser, con);
                DataTable dtUser = new DataTable();
                daUser.Fill(dtUser);

                Bien_Ban frm = new Bien_Ban();
                CrystalReport1 crystalReport = new CrystalReport1();
                TextObject text = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text1"];
                text.Text = SoBB;
                TextObject text2 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text13"];
                //text2.Text = txtUserID2.Text;D:\Study\Project\QLTS_LG v2\QLTS_LG\Report.cs
                text2.Text = dtUser.Rows[0]["ID"].ToString();
                TextObject text3 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text12"];
                //text3.Text = txtUser_Name.Text;
                text3.Text = dtUser.Rows[0]["Name"].ToString();
                TextObject text4 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text14"];
                //text4.Text = txtMail.Text;
                text4.Text = dtUser.Rows[0]["Mail"].ToString();
                TextObject text5 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text15"];
                //text5.Text = txtDept.Text;
                text5.Text = dtUser.Rows[0]["Dept"].ToString();
                TextObject text6 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text16"];
                //text6.Text = txtPhone.Text;
                text6.Text = dtUser.Rows[0]["Phone"].ToString();

                TextObject text21 = (TextObject)crystalReport.ReportDefinition.Sections["Section4"].ReportObjects["Text21"];
                text21.Text = dtReason.Rows[0]["Reason"].ToString();

                string strGridviewTransferData = "select a.Ma_TS, b.Ten_TS, b.[S/N], b.FA_Tag, b.IT_Tag from Xuat_Kho as a " +
                    "inner join Tai_san as b on a.Ma_TS = b.Ma_TS " +
                    "where a.So_BB_xuat = '" + SoBB + "'";

                SqlDataAdapter daGTD = new SqlDataAdapter(strGridviewTransferData, con);
                DataTable dtGTD = new DataTable();
                dtGTD.TableName = "GTD";
                daGTD.Fill(dtGTD);

                DataSet ds = new DataSet();
                daGTD.Fill(ds);

                DataSet ds2 = new DataSet();
                daGTD.Fill(ds2);

                crystalReport.SetDataSource(ds.Tables[0]);
                crystalReport.Subreports["device"].SetDataSource(ds.Tables[0]);
                crystalReport.Subreports["material"].SetDataSource(ds2.Tables[0]);

                frm.crystalReportViewer1.ReportSource = crystalReport;
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
