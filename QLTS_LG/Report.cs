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

        CrystalReport1 crystalReport = new CrystalReport1();
        device rptDevice = new device();
        material rptMaterial = new material();

        ReportDocument rpObj = new ReportDocument();

        Bien_Ban frm = new Bien_Ban();

        public void BienBanXuatKho(string SoBB)
        {
            try
            {
                string strReason = "select Reason, Ma_loai_BB from Bien_Ban where So_Bien_ban = '" + SoBB + "'";
                SqlDataAdapter daReason = new SqlDataAdapter(strReason, con2);
                DataTable dtReason = new DataTable();
                daReason.Fill(dtReason);

                string strUser = "select * from _User as a inner join Xuat_Kho as b on a.ID = b.ID_nguoi_nhan where b.So_BB_xuat = '" + SoBB + "'";
                SqlDataAdapter daUser = new SqlDataAdapter(strUser, con);
                DataTable dtUser = new DataTable();
                daUser.Fill(dtUser);

                

                TextObject text = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text1"];
                text.Text = SoBB;
                TextObject text2 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text13"];
                //text2.Text = txtUserID2.Text;
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

                TextObject text17 = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text17"];
                string Type = dtReason.Rows[0]["Ma_loai_BB"].ToString();

                text17.Text = Type;
                con.Open();
                string strGridviewTransferData = 
                    "select a.Ma_TS, a.Ten_TS, c.Ten_loai, a.[S/N], a.FA_Tag, a.IT_Tag, a.Model, d.unit_name, e.Ten_tinh_trang " +
                    "from Tai_san as a " +
                    "inner join Xuat_Kho as b on a.Ma_TS = b.Ma_TS " +
                    "inner join Loai_TS_cap2 as c on a.Ma_Loai_TS_cap2 = c.Ma_loai " +
                    "inner join Unit as d on d.unit_id = a.Unit " +
                    "inner join Status as e on e.Ma_tinh_Trang  = a.Ma_tinh_trang " +
                    "where b.So_BB_xuat = '" + SoBB + "' and a.Ma_Loai_TS_cap1 = 'DE'";
                SqlCommand cmdGTD = new SqlCommand();
                cmdGTD.Connection = con;
                cmdGTD.CommandType = CommandType.Text;
                cmdGTD.CommandText = strGridviewTransferData;
                cmdGTD.ExecuteNonQuery();
                SqlDataAdapter daGTD = new SqlDataAdapter(cmdGTD);
                DataTable dtGTD = new DataTable();
                dtGTD.TableName = "GTD";
                daGTD.Fill(dtGTD);

                DataSet ds = new DataSet();
                daGTD.Fill(ds, "device");
                con.Close();

                con2.Open();
                string strGridviewTransferDataForAdditional = 
                    "select a.Ma_TS, a.Ten_TS, c.Ten_loai, a.[S/N], a.FA_Tag, a.IT_Tag, a.Model, d.unit_name, e.Ten_tinh_trang " +
                    "from Tai_san as a " +
                    "inner join Xuat_Kho as b on a.Ma_TS = b.Ma_TS " +
                    "inner join Loai_TS_cap2 as c on a.Ma_Loai_TS_cap2 = c.Ma_loai " +
                    "inner join Unit as d on d.unit_id = a.Unit " +
                    "inner join Status as e on e.Ma_tinh_Trang  = a.Ma_tinh_trang " +
                    "where not a.Ma_Loai_TS_cap1 = 'DE' and b.So_BB_xuat = '" + SoBB + "'";

                SqlCommand cmdGTD2 = new SqlCommand();
                cmdGTD2.Connection = con2;
                cmdGTD2.CommandType = CommandType.Text;
                cmdGTD2.CommandText = strGridviewTransferDataForAdditional;
                cmdGTD2.ExecuteNonQuery();
                SqlDataAdapter daGTD2 = new SqlDataAdapter(cmdGTD2);
                
                DataSet ds2 = new DataSet();
                daGTD2.Fill(ds2, "material");
                con2.Close();
                //crystalReport.SetDataSource(ds.Tables[0]);
                //crystalReport.SetDataSource(ds2.Tables[0]);

             
                if(ds.Tables[0].Rows.Count == 0 || ds2.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No data!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }

                //device.SetDataSource(ds.Tables["device"]);
                //material.SetDataSource(ds2.Tables["material"]);
                rptDevice.SetDataSource(ds.Tables["device"]);
                rptMaterial.SetDataSource(ds2.Tables["material"]);
                

                rpObj.Load(@"D:\Study\Project\QLTS_LG v2\QLTS_LG\CrystalReport1.rpt");
                

                //crystalReport.Subreports["device.rpt"].SetDataSource(ds.Tables[0]);
                //crystalReport.Subreports["material.rpt"].SetDataSource(ds2.Tables[0]);
                /*SubreportObject subreport = (SubreportObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["device"];
                SubreportObject subreport2 = (SubreportObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["material"];

                crystalReport.Subreports[subreport.Name].SetDataSource(ds.Tables[1]);
                crystalReport.Subreports[subreport2.Name].SetDataSource(ds2.Tables[1]);*/

                //crystalReport.Subreports["device"].SetDataSource(ds.Tables[0]);
                //crystalReport.Subreports["material"].SetDataSource(ds2.Tables[0]);

                //crystalReport.Database.Tables["device"].SetDataSource(ds.Tables[0]);
                //crystalReport.Database.Tables["material"].SetDataSource(ds2.Tables[0]);
                frm.crystalReportViewer1.ReportSource = rpObj;
                frm.crystalReportViewer1.ReportSource = crystalReport;
                frm.crystalReportViewer1.Refresh();
                                                
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
