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
    public partial class FrmHayvanlar : Form
    {
        public FrmHayvanlar()
        {
            InitializeComponent();
        }

        private void Temizle()
        {
            textBoxHayvanNo.Clear();
            textBoxHayvanAd.Clear();
            textBoxHayvanTip.Clear();
            textBoxKilo.Clear();
            textBoxRenk.Clear();
            textBoxCins.Clear();
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
            FrmUretim frmUretim = new FrmUretim();
            this.Hide();
            frmUretim.Show();
        }
        private void pictureBoxEkraniKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxEkraniKapa_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAdminGiris frmAdmin = new FrmAdminGiris();
            frmAdmin.Show();
        }

        private void textBoxHayvanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxHayvanTip_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxHayvanAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxRenk_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxCins_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxKilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        SVeritabani sVeritabani = new SVeritabani();    
        private void FrmHayvanlar_Load(object sender, EventArgs e)
        {
            dataGridViewHayvanlar.DataSource = sVeritabani.HayvanlariListele();
            if(dataGridViewHayvanlar.Rows.Count > 0)
            {
                dataGridViewHayvanlar.Columns["Animal_No"].Visible = false;
                dataGridViewHayvanlar.Columns["Operation_Date"].Visible = false;
            }

            dataGridViewHayvanlar.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(119, 82, 254);

            dateTimePickerDogumTarih.MaxDate = DateTime.Now;
        }
     
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            int hayvanNo = !string.IsNullOrEmpty(textBoxHayvanNo.Text) ? int.Parse(textBoxHayvanNo.Text) : 0 ;
            string hayvanTip = textBoxHayvanTip.Text;
            string hayvanAd = textBoxHayvanAd.Text;
            string renk = textBoxRenk.Text;
            string cins = textBoxCins.Text;
            DateTime tarih = dateTimePickerDogumTarih.Value;
            float kilo = !string.IsNullOrEmpty(textBoxKilo.Text) ? float.Parse(textBoxKilo.Text) : 0;
            bool eklenmekIstenenHayvanTablodaVarMi = sVeritabani.TablodaEklenmekIstenenHayvanVarMi(hayvanNo);
            bool kontrollerBosMu = (hayvanNo == 0 || string.IsNullOrEmpty(hayvanTip) || string.IsNullOrEmpty(hayvanAd) || string.IsNullOrEmpty(renk) || string.IsNullOrEmpty(cins) || kilo == 0);

            if(!kontrollerBosMu)
            {
                if (!eklenmekIstenenHayvanTablodaVarMi)
                {
                    sVeritabani.HayvanEkle(hayvanNo, hayvanTip, hayvanAd, renk, cins, tarih, kilo);
                    dataGridViewHayvanlar.DataSource = sVeritabani.HayvanlariListele();
                    dataGridViewHayvanlar.Columns["Animal_No"].Visible = false;
                    dataGridViewHayvanlar.Columns["Operation_Date"].Visible = false;
                    MessageBox.Show("Eklendi");

                }
                else
                    MessageBox.Show("Eklenmek istenen no'ya ait hayvan mevcut !");
            }
            else
                MessageBox.Show("Kontroller Boş");
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if(id != 0)
            {
                sVeritabani.HayvanSil(id);
                dataGridViewHayvanlar.DataSource = sVeritabani.HayvanlariListele();
                MessageBox.Show("Silindi");
                Temizle();
                id = 0;
            }
            else
                MessageBox.Show("Silinecek hayvanı tablodan seçiniz");



        }
        int id;
        private void dataGridViewHayvanlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            id = (int)dataGridViewHayvanlar.Rows[rowIndex].Cells[0].Value;
            textBoxHayvanNo.Text = id.ToString();
            textBoxHayvanTip.Text = dataGridViewHayvanlar.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxHayvanAd.Text = dataGridViewHayvanlar.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxRenk.Text = dataGridViewHayvanlar.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxCins.Text = dataGridViewHayvanlar.Rows[rowIndex].Cells[4].Value.ToString();
            dateTimePickerDogumTarih.Value = (DateTime)dataGridViewHayvanlar.Rows[rowIndex].Cells[5].Value;
            textBoxKilo.Text = dataGridViewHayvanlar.Rows[rowIndex].Cells[6].Value.ToString();

        }
        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
            int hayvanNo = id != 0 ? int.Parse(textBoxHayvanNo.Text) : 0;
            string hayvanTip = textBoxHayvanTip.Text;
            string hayvanAd = textBoxHayvanAd.Text;
            string renk = textBoxRenk.Text;
            string cins = textBoxCins.Text;
            DateTime tarih = dateTimePickerDogumTarih.Value;
            float kilo = !string.IsNullOrEmpty(textBoxKilo.Text) ? float.Parse(textBoxKilo.Text) : 0;
            
            bool kontrollerBosMu = (hayvanNo == 0 || string.IsNullOrEmpty(hayvanTip) || string.IsNullOrEmpty(hayvanAd) || string.IsNullOrEmpty(renk) || string.IsNullOrEmpty(cins) || kilo == 0);

           
            if (!kontrollerBosMu)
            {
                if(id != 0)
                {
                    sVeritabani.HayvanBilgileriDuzenle(hayvanTip, hayvanAd, renk, cins, tarih, kilo, id);
                    dataGridViewHayvanlar.DataSource = sVeritabani.HayvanlariListele();
                    MessageBox.Show("İlgili hayvanın bilgileri güncellendi");
                    Temizle();
                    id = 0;
                }

                else
                    MessageBox.Show("Güncellenecek hayvanı tablodan seçiniz");
            }
            else
                MessageBox.Show("Kontroller Boş");

            
        }
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
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
            FrmFinansal frm = new FrmFinansal();
            frm.Show();
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
        }
    }
}
