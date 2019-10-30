using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;


namespace QLTS_LG
{
    class UploadAndRetrieve
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        //OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public void UploadToDB(TextBox txtSoBB)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string pathFile = "";
            string[] pathFiles;
            fileDialog.FileName = "All Files";
            fileDialog.FilterIndex = 1;
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pathFile = fileDialog.FileName;
                pathFiles = fileDialog.FileNames;
                try
                {
                    //InputEPApproval(pathFile);
                    byte[] file;
                    FileStream Stream = new FileStream(pathFile, FileMode.Open, FileAccess.Read);

                    BinaryReader reader = new BinaryReader(Stream);

                    file = reader.ReadBytes((int)Stream.Length);


                    OracleConnection con2 = new OracleConnection(connectionString);
                    OracleCommand Sqlwrite = new OracleCommand("UPDATE Bien_Ban SET File_attach = @File WHERE So_Bien_ban = @SoBB", con2);
                    Sqlwrite.Parameters.Add("@File", OracleDbType.Raw, file.Length).Value = file;
                    Sqlwrite.Parameters.Add("@SoBB", txtSoBB.Text.ToString());
                    con2.Open();
                    Sqlwrite.ExecuteNonQuery();
                    con2.Close();
                    MessageBox.Show("Upload successful!!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void InputEPApproval(string varFilePath, TextBox txtSoBB)
        {
            byte[] file;
            FileStream Stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read);

            BinaryReader reader = new BinaryReader(Stream);

            file = reader.ReadBytes((int)Stream.Length);


            OracleConnection con2 = new OracleConnection(connectionString);
            OracleCommand Sqlwrite = new OracleCommand("UPDATE Bien_Ban SET File_attach = @File WHERE So_Bien_ban = @SoBB", con2);
            Sqlwrite.Parameters.Add("@File", OracleDbType.Raw, file.Length).Value = file;
            Sqlwrite.Parameters.Add("@SoBB", txtSoBB.Text.ToString());
            con2.Open();
            Sqlwrite.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Upload successful!!");
        }
        public void UploadToFileServer(TextBox txtSoBB, OpenFileDialog openFileDialog1)
        {
            try
            {
                //openFileDialog1.FileName = txtSoBB.Text.ToString();
                //Save file path
                string folderPath = @"\\10.224.50.222\\qlts\\Document\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string strInsertFile = "UPDATE Bien_Ban SET File_attach = :Path WHERE So_Bien_ban = :SoBB";
                OracleCommand cmdUpdateFile = new OracleCommand();
                cmdUpdateFile.Connection = con;
                cmdUpdateFile.CommandType = CommandType.Text;
                cmdUpdateFile.CommandText = strInsertFile;
                cmdUpdateFile.Parameters.Add("Path", folderPath + Path.GetFileName(openFileDialog1.FileName));
                cmdUpdateFile.Parameters.Add("SoBB", txtSoBB.Text.ToString());
                con.Open();
                cmdUpdateFile.ExecuteNonQuery();
                con.Close();

                //Upload file to server
                string filelocation = openFileDialog1.FileName;
                File.Copy(filelocation, Path.Combine(@"\\10.224.50.222\\qlts\\Document\\", Path.GetFileName(filelocation)), true);

                MessageBox.Show("Finished!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RetrieveFileFromServer(string SoBB, SaveFileDialog saveFile)
        {
            try
            {
                string EP_Approval = "EP Approval";
                string EP_Path = "select file_attach from bien_ban where so_bien_ban = '" + SoBB + "'";
                OracleDataAdapter daATT = new OracleDataAdapter(EP_Path, con);
                DataTable dtATT = new DataTable();
                daATT.Fill(dtATT);
                string ATT_PATH = dtATT.Rows[0]["FILE_ATTACH"].ToString();

                saveFile.FileName = EP_Approval;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string FilePath = Path.GetDirectoryName(saveFile.FileName);
                    File.Copy(ATT_PATH, Path.Combine(FilePath, EP_Approval), true);
                }
                MessageBox.Show("Download 100%");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
