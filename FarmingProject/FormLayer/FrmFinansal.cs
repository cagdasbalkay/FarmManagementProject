using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FarmingProject.FormLayer
{
    public partial class FrmFinansal : Form
    {
        public FrmFinansal()
        {
            InitializeComponent();
        }
        SVeritabani sVeritabani = new SVeritabani();
        
        private void FrmFinansal_Load(object sender, EventArgs e)
        {
            dataGridViewGiderler.DataSource = sVeritabani.GiderListele();
            if (dataGridViewGiderler.Rows.Count > 0)
            {
                dataGridViewGiderler.Columns["ExpId"].Visible = false;
            }

            dataGridViewGiderler.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(119, 82, 254);

            dataGridViewGelirler.DataSource = sVeritabani.GelirListele();
            if (dataGridViewGelirler.Rows.Count > 0)
            {
                dataGridViewGelirler.Columns["IncId"].Visible = false;
            }
            dataGridViewGelirler.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(119, 82, 254);


            dateTimePickerGiderTarih.MaxDate = DateTime.Now;
            dateTimePickerGelirTarih.MaxDate = DateTime.Now;
        }

        public string personel;
        private void buttonGiderKaydet_Click(object sender, EventArgs e)
        {
            DateTime tarih = dateTimePickerGiderTarih.Value;
            string kaynak = comboBoxGiderKaynagi.SelectedItem.ToString();
            float miktar = float.Parse(textBoxGiderMiktar.Text);
            personel = FrmAdminGiris.personel;
            sVeritabani.GiderEkle(tarih,kaynak,miktar,personel);
            dataGridViewGiderler.DataSource = sVeritabani.GiderListele();
        }

        private void buttonGelirKaydet_Click(object sender, EventArgs e)
        {
            DateTime tarih = dateTimePickerGelirTarih.Value;
            string kaynak = comboBoxGelirKaynagi.SelectedItem.ToString();
            float miktar = float.Parse(textBoxGelirMiktar.Text);
            personel = FrmAdminGiris.personel;
            sVeritabani.GelirEkle(tarih, kaynak, miktar, personel);
            dataGridViewGelirler.DataSource = sVeritabani.GelirListele();
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDashboard frm = new FrmDashboard();
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
