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


namespace QLTS_LG
{
    class UploadAndRetrieve
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
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


                    SqlConnection con2 = new SqlConnection(connectionString);
                    SqlCommand Sqlwrite = new SqlCommand("UPDATE Bien_Ban SET File_attach = @File WHERE So_Bien_ban = @SoBB", con2);
                    Sqlwrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
                    Sqlwrite.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
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


            SqlConnection con2 = new SqlConnection(connectionString);
            SqlCommand Sqlwrite = new SqlCommand("UPDATE Bien_Ban SET File_attach = @File WHERE So_Bien_ban = @SoBB", con2);
            Sqlwrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
            Sqlwrite.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
            con2.Open();
            Sqlwrite.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("Upload successful!!");
        }
        public void UploadToFileServer(TextBox txtSoBB, OpenFileDialog openFileDialog1)
        {
            try
            {

                //Save file path
                string folderPath = "D:\\EP Approval\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string strInsertFile = "UPDATE Bien_Ban SET File_attach = @Path WHERE So_Bien_ban = @SoBB";
                SqlCommand cmdUpdateFile = new SqlCommand();
                cmdUpdateFile.Connection = con;
                cmdUpdateFile.CommandType = CommandType.Text;
                cmdUpdateFile.CommandText = strInsertFile;
                cmdUpdateFile.Parameters.AddWithValue("@Path", folderPath + Path.GetFileName(openFileDialog1.FileName));
                cmdUpdateFile.Parameters.AddWithValue("@SoBB", txtSoBB.Text.ToString());
                con.Open();
                cmdUpdateFile.ExecuteNonQuery();
                con.Close();

                //Upload file to server
                string filelocation = openFileDialog1.FileName;
                File.Copy(filelocation, Path.Combine("D:\\EP Approval\\", Path.GetFileName(filelocation)), true);

                MessageBox.Show("Finished!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
