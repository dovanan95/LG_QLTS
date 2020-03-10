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
using Oracle.ManagedDataAccess.Client;

namespace QLTS_LG
{
    public partial class PreviewForm : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["QLTS_LG.Properties.Settings.QLTSConnectionString"].ConnectionString;
        OracleConnection con = new OracleConnection(connectionString);
        public DataTable SummaryData { get; set; }
        public PreviewForm()
        {
            InitializeComponent();
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {

        }
        public void LoadAddingItemPreview()
        {
            dgvPreview.DataSource = SummaryData;
        }
    }
}
