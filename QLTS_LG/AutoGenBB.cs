using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace QLTS_LG
{
    class AutoGenBB
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        public string SoBBBG;

        public void AutoGenBBBG()
        {
            //DateTime date_BB = new DateTime();
            int i = 1;
            //string LastNumOfBB;
            var date_BBBG = DateTime.Now.ToString("yyyyMMdd");
            SqlCommand cmd = new SqlCommand("SELECT So_Bien_ban FROM Bien_Ban", con); //lấy dữ liệu số biên bản bàn giao từ bảng Bien_Ban
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtSoBB = new DataTable();
            da.Fill(dtSoBB); //đổ dữ liệu vào table dtSoBB
            if (dtSoBB.Rows.Count == 0) //kiểm tra trường hợp chưa có data trong bảng
            {
                DataRow dr = dtSoBB.NewRow(); //tạo hàng dữ liệu dr trong dtSoBB
                dr["So_Bien_ban"] = date_BBBG + "-" + i.ToString();
                dtSoBB.Rows.Add(dr); //thêm hàng dữ liệu vừa được tạo vào dtSoBB
                SoBBBG = dr["So_Bien_ban"].ToString();
            }
            else if (dtSoBB.Rows.Count > 0)
            {
                //get data...
                int LastRowIndex = dtSoBB.Rows.Count - 1;
                string LastNumOfBB = dtSoBB.Rows[LastRowIndex][0].ToString(); //lay ra gia tri o hang cuoi cung
                int dateBBLen = date_BBBG.Length; //lay gia tri chieu dai cua phan ngay thang
                int LastNumLen = LastNumOfBB.Length; //lay gia tri toan bo chuoi
                string DateTimeString = LastNumOfBB.Substring(0, dateBBLen); //cắt ra phần ngày tháng


                string iNumber = LastNumOfBB.Substring(LastNumLen - (LastNumLen - dateBBLen) + 1); //cắt ra phần số thứ tự
                int iNum = Convert.ToInt32(iNumber);
                // string DateTimeString = LastNumOfBB.Substring(0, 8);
                if (DateTimeString.Equals(date_BBBG) == true)
                {
                    iNum++;
                    SoBBBG = date_BBBG + "-" + iNum.ToString();
                }
                else if (DateTimeString.Equals(date_BBBG) == false)
                {
                    SoBBBG = date_BBBG + "-" + i.ToString();
                }
            }



        }
    }
}
