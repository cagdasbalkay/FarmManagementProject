using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmingProject.FormLayer
{
    public partial class FrmAnaMenu : Form
    {
        public FrmAnaMenu()
        {
            InitializeComponent();
        }

        private void pictureBoxAdminGirisi_Click(object sender, EventArgs e)
        {
            FrmAdminGiris frmAdminGiris = new FrmAdminGiris();
            this.Hide();
            frmAdminGiris.Show();
        }

        private void pictureBoxCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
