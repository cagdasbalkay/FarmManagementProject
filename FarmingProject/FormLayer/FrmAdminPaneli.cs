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
    public partial class FrmAdminPaneli : Form
    {
        public FrmAdminPaneli()
        {
            InitializeComponent();
        }

        private void pictureBoxEkraniKapa_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAdminGiris frmAdminGiris = new FrmAdminGiris();
            frmAdminGiris.Show();
        }

        private void pictureBoxEkraniKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonHayvanlar_Click(object sender, EventArgs e)
        {
            FrmHayvanlar frmHayvanlar = new FrmHayvanlar();
            this.Hide();
            frmHayvanlar.Show();
            
        }
        private void buttonSaglik_Click(object sender, EventArgs e)
        {
            FrmSaglik frmSaglik = new FrmSaglik();
            this.Hide();
            frmSaglik.Show();
            
        }
        private void buttonUretim_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUretim frmUretim = new FrmUretim();
            frmUretim.Show();
        }

        private void FrmAdminPaneli_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonUrunSatislari_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUrunSatislari frmUrunSatislari = new FrmUrunSatislari();
            frmUrunSatislari.Show();
        }

        private void buttonFinansal_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmFinansal frmFinansal = new FrmFinansal();
            frmFinansal.Show();

        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
        }
    }
}
