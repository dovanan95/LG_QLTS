using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class Bien_Ban : Form
    {
        public Bien_Ban()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            dgvDevice.AutoResizeColumns();
            dgvDevice.AutoResizeRows();
            dgvMaterial.AutoResizeColumns();
            dgvMaterial.AutoResizeRows();

            //this.AutoScroll = true;
        }

        //Bitmap bitmap;

        public string SoBB { get; set; }
        public DataTable dtDevice { get; set; }
        public DataTable dtMaterial { get; set; }
        
        public DataGridView gridView { get; set; }
        public string Name_Rcv { get; set; }
        public string ID_Rcv { get; set; }
        public string Mail_Rcv { get; set; }
        public string Dept_Rcv { get; set; }
        public string Phone_Rcv { get; set; }
        public string ID_Dlv { get; set; }
        public string Name_Dlv { get; set; }
        public string Mail_Dlv { get; set; }
        public string Dept_Dlv { get; set; }
        public string Phone_Dlv { get; set; }

        public string Type_BB { get; set; }
        public string DATE { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }

        Bitmap memoryImage;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void CrystalReport11_InitReport(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(bitmap, 0, 0);
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void CaptureScreen()
        {
            /*Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);*/

            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage( memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        public void Print()
        {
 
            try
            {
                
                CaptureScreen();
                printPreviewDialog1.Document = printDocument1;
                printDialog1.Document = printDocument1;
                //this.Close();
                //printPreviewDialog1.Show();
                //printPreviewDialog1.BringToFront();
                //printPreviewDialog1.Focus();

                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bien_Ban_Load(object sender, EventArgs e)
        {
            lblSoBB.Text = SoBB;
            lblTypeBB.Text = Type_BB;
            lblDatetime.Text = DATE;
            lblReason.Text = Reason;
            lblNote.Text = Note;
            
            lblIDRecv.Text = ID_Rcv;
            lblDept_Rcv.Text = Dept_Rcv;
            lblMail_Rcv.Text = Mail_Rcv;
            lblPhone_RCV.Text = Phone_Rcv;
            lblName_Rcv.Text = Name_Rcv;

            lblID_Deliver.Text = ID_Dlv;
            lblName_Deliver.Text = Name_Dlv;
            lblMail_Deliver.Text = Mail_Dlv;
            lblPhone_Deliver.Text = Phone_Dlv;
            lblDept_Deliver.Text = Dept_Dlv;

            dgvDevice.DataSource = dtDevice;
            dgvDevice.AutoResizeColumns();
            dgvDevice.RowHeadersVisible = false;

            dgvMaterial.DataSource = dtMaterial;
            dgvMaterial.RowHeadersVisible = false;
            AutoScroll = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Print();
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
