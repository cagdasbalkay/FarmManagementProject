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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        SVeritabani sVeritabani = new SVeritabani();
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            labelGelir.Text = sVeritabani.GelirGetir().ToString();
            labelGider.Text = sVeritabani.GiderGetir().ToString();
            labelBakiye.Text = (float.Parse(labelGelir.Text) - float.Parse(labelGider.Text)).ToString();

            labelHayvanSayisi.Text = sVeritabani.HayvanSayisi().ToString();
            labelCalisanSayisi.Text = sVeritabani.CalisanSayisi().ToString();
            labelEnYuksekSatis.Text = sVeritabani.EnYuksekSatis().ToString();
            labelEnFazlaHarcama.Text = sVeritabani.EnFazlaHarcama().ToString();
           
        }

        private void buttonFinansal_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmFinansal frm = new FrmFinansal();
            frm.Show();
        }

        private void buttonHayvanlar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHayvanlar frm = new FrmHayvanlar();
            frm.Show();
        }

        private void buttonSaglik_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSaglik frm = new FrmSaglik();
            frm.Show();
        }

        private void buttonUretim_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUretim frm = new FrmUretim();
            frm.Show();
        }

        private void buttonUrunSatislari_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUrunSatislari frm = new FrmUrunSatislari();
            frm.Show();
        }

        private void pictureBoxEkraniKapa_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAdminGiris frmAdmin = new FrmAdminGiris();
            frmAdmin.Show();
        }

        private void pictureBoxEkraniKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
