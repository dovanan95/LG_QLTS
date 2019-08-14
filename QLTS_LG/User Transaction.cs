using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTS_LG
{
    public partial class User_Transaction : Form
    {
        public User_Transaction()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            this.Hide();
            this.Close();
            //frm.ShowDialog();
        }
    }
}
