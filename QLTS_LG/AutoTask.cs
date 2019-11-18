using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace QLTS_LG
{
    class AutoTask
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection connect = new OracleConnection(connectionString);

        public string SoTaiSanDaBanGiao(string MaNV)
        {
            string SoLuongTaiSan = "select * from Ngoai_kho a " +
                "inner join tai_san b on a.ma_ts = b.ma_ts " +
                " where a.ID_USER = '" + MaNV + "' and b.Ma_loai_TS_cap1 = 'DE' ";
            OracleDataAdapter daSoLuong = new OracleDataAdapter(SoLuongTaiSan, connect);
            DataTable dtSoLuong = new DataTable();
            daSoLuong.Fill(dtSoLuong);

            string DeviceQuantity = dtSoLuong.Rows.Count.ToString();
            return DeviceQuantity;
        }
        public DataTable LoadFromNSCBGTS()
        {
            string load = "select * from NSCBGTS where  BAN_GIAO = 'N'";
            OracleDataAdapter daload = new OracleDataAdapter(load, connect);
            DataTable dtload = new DataTable();
            daload.Fill(dtload);

            return dtload;
        }
        public void UpdateApprovedOfBB(string SoBB)
        {
            string SQL = "update BIEN_BAN set APPROVED = 'Y' where So_Bien_Ban = :SoBB";
            OracleCommand cmdUpdate = new OracleCommand(SQL, connect);
            cmdUpdate.Parameters.Add(new OracleParameter("SoBB", SoBB));
            connect.Open();
            cmdUpdate.ExecuteNonQuery();
            connect.Close();
        }
        public bool CheckApproved(string SoBB)
        {
            bool flag = true;
            string CheckApp = "select APPROVED from BIEN_BAN where so_bien_ban = '" + SoBB + "'";
            OracleDataAdapter daCheckApp = new OracleDataAdapter(CheckApp, connect);
            DataTable dtcheck = new DataTable();
            daCheckApp.Fill(dtcheck);
            if (dtcheck.Rows[0][0].ToString() == "N")
            {
                flag = false;
            }
            else if (dtcheck.Rows[0][0].ToString() == "Y")
            {
                flag = true;
            }

            return flag;
        }
        public void ToBufferIN(int Ma_TS)
        {
            string collect = "select ma_ts, so_bb from ngoai_kho where ma_ts = " + Ma_TS;
            OracleDataAdapter dacollect = new OracleDataAdapter(collect, connect);
            DataTable dtcol = new DataTable();
            dacollect.Fill(dtcol);
            foreach (DataRow row in dtcol.Rows)
            {
                string inputbufferin = "insert into BUFFER_STATE(MA_TS, SO_BB, UPDATE_DATE) VALUES (:mts, :sobb, CURRENT_DATE)";
                OracleCommand cmdbufferin = new OracleCommand(inputbufferin, connect);
                cmdbufferin.Parameters.Add(new OracleParameter("mts", Convert.ToInt32(row["MA_TS"])));
                cmdbufferin.Parameters.Add(new OracleParameter("sobb", row["SO_BB"].ToString()));
                connect.Open();
                cmdbufferin.ExecuteNonQuery();
                connect.Close();
            }
        }
        public void ToBufferOut(int Ma_TS)
        {
            string collect = "select ma_ts, so_bb from luu_kho where ma_ts = " + Ma_TS;
            OracleDataAdapter dacollect = new OracleDataAdapter(collect, connect);
            DataTable dtcol = new DataTable();
            dacollect.Fill(dtcol);
            foreach (DataRow row in dtcol.Rows)
            {
                string inputbufferin = "insert into BUFFER_STATE(MA_TS, SO_BB, UPDATE_DATE) VALUES (:mts, :sobb, CURRENT_DATE)";
                OracleCommand cmdbufferin = new OracleCommand(inputbufferin, connect);
                cmdbufferin.Parameters.Add(new OracleParameter("mts", Convert.ToInt32(row["MA_TS"])));
                cmdbufferin.Parameters.Add(new OracleParameter("sobb", row["SO_BB"].ToString()));
                connect.Open();
                cmdbufferin.ExecuteNonQuery();
                connect.Close();
            }
        }
        public void BUFFERtoLuuKho(int Ma_TS)
        {
            string collect = "select ma_ts, so_bb from buffer_state where ma_ts = " + Ma_TS;
            OracleDataAdapter dacollect = new OracleDataAdapter(collect, connect);
            DataTable dtcol = new DataTable();
            dacollect.Fill(dtcol);

            foreach (DataRow row in dtcol.Rows)
            {
                string inputLuuKho = "insert into luu_kho(MA_TS, SO_BB) VALUES (:mts, :sobb)";
                OracleCommand cmdinputLuukho = new OracleCommand(inputLuuKho, connect);
                cmdinputLuukho.Parameters.Add(new OracleParameter("mts", Convert.ToInt32(row["MA_TS"])));
                cmdinputLuukho.Parameters.Add(new OracleParameter("sobb", row["SO_BB"].ToString()));
                connect.Open();
                cmdinputLuukho.ExecuteNonQuery();
                connect.Close();

                BufferClear(Convert.ToInt32(row["MA_TS"]));
            }

           
        }
        public void BUFFERtoNgoaiKho(int Ma_TS)
        {
            string collect = "select ma_ts, so_bb from buffer_state where ma_ts = " + Ma_TS;
            OracleDataAdapter dacollect = new OracleDataAdapter(collect, connect);
            DataTable dtcol = new DataTable();
            dacollect.Fill(dtcol);

            foreach (DataRow row in dtcol.Rows)
            {
                string inputNgoaiKho = "insert into ngoai_kho(MA_TS, SO_BB) VALUES (:mts, :sobb)";
                OracleCommand cmdinputNgoaikho = new OracleCommand(inputNgoaiKho, connect);
                cmdinputNgoaikho.Parameters.Add(new OracleParameter("mts", Convert.ToInt32(row["MA_TS"])));
                cmdinputNgoaikho.Parameters.Add(new OracleParameter("sobb", row["SO_BB"].ToString()));
                connect.Open();
                cmdinputNgoaikho.ExecuteNonQuery();
                connect.Close();

                BufferClear(Convert.ToInt32(row["MA_TS"]));
            }
        }
        public void BufferClear(int Ma_TS)
        {
            string clear = "delete from buffer_state where ma_ts = " + Ma_TS;
            OracleCommand cmdclear = new OracleCommand(clear, connect);
            connect.Open();
            cmdclear.ExecuteNonQuery();
            connect.Close();
        }
    }
}
