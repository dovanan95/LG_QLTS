using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace QLTS_LG
{
    class LoadComboboxData
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        DataTable Table = new DataTable();

        public void LoadDataType(ComboBox cbType)
        {
            con.Open();
            string cmdLoaiTS2 = "SELECT * FROM Loai_TS_cap2";
            SqlCommand cmd = new SqlCommand(cmdLoaiTS2, con);
            DataTable dtLoaiTS2 = new DataTable();
            SqlDataAdapter daLoaiTS2 = new SqlDataAdapter(cmd);
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
            SqlCommand cmd = new SqlCommand(cmdStatus, con);
            DataTable dtStatus = new DataTable();
            SqlDataAdapter daStatus = new SqlDataAdapter(cmd);
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
            SqlCommand cmd = new SqlCommand(cmdLoaiTS2, con);
            DataTable dtLoaiTS2 = new DataTable();
            SqlDataAdapter daLoaiTS2 = new SqlDataAdapter(cmd);
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
            SqlCommand cmd = new SqlCommand(strLoad, con);
            DataTable dtLoad = new DataTable();
            SqlDataAdapter daLoad = new SqlDataAdapter(cmd);
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
            SqlCommand cmdUnit = new SqlCommand(strUnitLoad, con);
            DataTable dtUnit = new DataTable();
            SqlDataAdapter daUnit = new SqlDataAdapter(cmdUnit);
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
            SqlCommand cmdEmpLoad = new SqlCommand(strEmpLoad, con);
            DataTable dtEmp = new DataTable();
            SqlDataAdapter daEmp = new SqlDataAdapter(cmdEmpLoad);
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
            SqlCommand cmdORG = new SqlCommand(strORG, con);
            DataTable dtORG = new DataTable();
            SqlDataAdapter daORG = new SqlDataAdapter(cmdORG);
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
            SqlCommand cmdModel = new SqlCommand(strModel, con);
            DataTable dtModel = new DataTable();
            SqlDataAdapter daModel = new SqlDataAdapter(cmdModel);
            daModel.Fill(dtModel);
            cbModel.DataSource = dtModel;
            cbModel.DisplayMember = "model";
            cbModel.ValueMember = "model";
            cbModel.Enabled = true;
            cmdModel.ExecuteNonQuery();
            con.Close();
        }
    }
}
