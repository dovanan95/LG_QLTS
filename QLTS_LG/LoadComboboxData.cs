using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    class LoadComboboxData
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        OracleDataAdapter DataAdapter = new OracleDataAdapter();
        DataTable Table = new DataTable();

        public void LoadDataType(ComboBox cbType)
        {
            con.Open();
            string cmdLoaiTS2 = "SELECT * FROM Loai_TS_cap2";
            OracleCommand cmd = new OracleCommand(cmdLoaiTS2, con);
            DataTable dtLoaiTS2 = new DataTable();
            OracleDataAdapter daLoaiTS2 = new OracleDataAdapter(cmd);
            daLoaiTS2.Fill(dtLoaiTS2);
            cbType.DataSource = dtLoaiTS2;
            cbType.DisplayMember = "Ten_loai";
            cbType.ValueMember = "Ma_loai";
            cbType.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void LoadDataStatus(ComboBox cbStatus)
        {
            con.Open();
            string cmdStatus = "SELECT * FROM Status";
            OracleCommand cmd = new OracleCommand(cmdStatus, con);
            DataTable dtStatus = new DataTable();
            OracleDataAdapter daStatus = new OracleDataAdapter(cmd);
            daStatus.Fill(dtStatus);
            cbStatus.DataSource = dtStatus;
            cbStatus.ValueMember = "Ma_tinh_trang";
            cbStatus.DisplayMember = "Ten_tinh_trang";
            //cbStatus.SelectedIndex = 2;
            //cbStatus.SelectedValue = "NE";
            cbStatus.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void LoadDataType1(ComboBox cbType)
        {
            con.Open();
            string cmdLoaiTS2 = "SELECT * FROM Loai_TS_cap1";
            OracleCommand cmd = new OracleCommand(cmdLoaiTS2, con);
            DataTable dtLoaiTS2 = new DataTable();
            OracleDataAdapter daLoaiTS2 = new OracleDataAdapter(cmd);
            daLoaiTS2.Fill(dtLoaiTS2);
            cbType.DataSource = dtLoaiTS2;
            cbType.DisplayMember = "Ten_loai";
            cbType.ValueMember = "Ma_loai";
            cbType.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void LoadPermission(ComboBox cbPermission)
        {
            con.Open();
            string strLoad = "select * from Permission";
            OracleCommand cmd = new OracleCommand(strLoad, con);
            DataTable dtLoad = new DataTable();
            OracleDataAdapter daLoad = new OracleDataAdapter(cmd);
            daLoad.Fill(dtLoad);
            cbPermission.DataSource = dtLoad;
            cbPermission.DisplayMember = "per_name";
            cbPermission.ValueMember = "per_id";
            cbPermission.Enabled = true;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void LoadUnit(ComboBox cbUnit)
        {
            con.Open();
            string strUnitLoad = "select * from Unit";
            OracleCommand cmdUnit = new OracleCommand(strUnitLoad, con);
            DataTable dtUnit = new DataTable();
            OracleDataAdapter daUnit = new OracleDataAdapter(cmdUnit);
            daUnit.Fill(dtUnit);
            cbUnit.DataSource = dtUnit;
            cbUnit.DisplayMember = "unit_name";
            cbUnit.ValueMember = "unit_id";
            cbUnit.Enabled = true;
            cmdUnit.ExecuteNonQuery();
            con.Close();
        }
        public void LoadEmpStatus(ComboBox cbEmpStatus)
        {
            con.Open();
            string strEmpLoad = "select * from Emp_Status";
            OracleCommand cmdEmpLoad = new OracleCommand(strEmpLoad, con);
            DataTable dtEmp = new DataTable();
            OracleDataAdapter daEmp = new OracleDataAdapter(cmdEmpLoad);
            daEmp.Fill(dtEmp);
            cbEmpStatus.DataSource = dtEmp;
            cbEmpStatus.DisplayMember = "Emp_Name";
            cbEmpStatus.ValueMember = "ECode";
            cbEmpStatus.Enabled = true;
            cmdEmpLoad.ExecuteNonQuery();
            con.Close();
        }
        public void LoadORG(ComboBox cbORG)
        {
            con.Open();
            string strORG = "select * from ORG_NAME";
            OracleCommand cmdORG = new OracleCommand(strORG, con);
            DataTable dtORG = new DataTable();
            OracleDataAdapter daORG = new OracleDataAdapter(cmdORG);
            daORG.Fill(dtORG);
            cbORG.DataSource = dtORG;
            cbORG.DisplayMember = "Org_name";
            cbORG.ValueMember = "Org_code";
            cbORG.Enabled = true;
            cmdORG.ExecuteNonQuery();
            con.Close();
        }
        public void LoadModel(ComboBox cbModel)
        {
            con.Open();
            string strModel = "select * from Model";
            OracleCommand cmdModel = new OracleCommand(strModel, con);
            DataTable dtModel = new DataTable();
            OracleDataAdapter daModel = new OracleDataAdapter(cmdModel);
            daModel.Fill(dtModel);
            cbModel.DataSource = dtModel;
            cbModel.DisplayMember = "model";
            cbModel.ValueMember = "model";
            cbModel.Enabled = true;
            cmdModel.ExecuteNonQuery();
            con.Close();
        }
        public void LoadTypeOfReport(ComboBox cbTypeBB)
        {
            con.Open();
            string strTypeBB = "select * from loai_bien_ban";
            OracleCommand cmdTypeBB = new OracleCommand(strTypeBB, con);
            DataTable dtTypeBB = new DataTable();
            OracleDataAdapter daTypeBB = new OracleDataAdapter(cmdTypeBB);
            daTypeBB.Fill(dtTypeBB);
            cbTypeBB.DataSource = dtTypeBB;
            cbTypeBB.DisplayMember = "TEN_LOAI";
            cbTypeBB.ValueMember = "MA_LOAI";
            cbTypeBB.Enabled = true;
            cmdTypeBB.ExecuteNonQuery();
            con.Close();
        }
    }
}
