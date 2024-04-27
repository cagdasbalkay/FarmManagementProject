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
    public partial class FrmUrunSatislari : Form
    {
        public FrmUrunSatislari()
        {
            InitializeComponent();
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            string personel = comboBoxPersonel.SelectedItem.ToString();
            DateTime satisTarih = dateTimePickerSatisTarih.Value;
            string urun = textBoxUrun.Text;
            double ucret = double.Parse(textBoxFiyat.Text);
            string musteri = textBoxMusteri.Text;
            string musteriTel = textBoxTel.Text;
            double miktar = double.Parse(textBoxAdet.Text);
            double toplam = ucret * miktar;

            float miktarGelirler = float.Parse(textBoxAdet.Text);
            sVeritabani.SatisEkle(personel,satisTarih,urun,ucret,musteri,musteriTel,miktar,toplam);
           dataGridViewSatislar.DataSource = sVeritabani.SatisListele();

            sVeritabani.GelirEkle(satisTarih, "Satışlar", miktarGelirler , personel);

        }
        SVeritabani sVeritabani = new SVeritabani();
        private void FrmUrunSatislari_Load(object sender, EventArgs e)
        {
            dataGridViewSatislar.DataSource = sVeritabani.SatisListele();
            if(dataGridViewSatislar.Rows.Count > 0 )
            {
                dataGridViewSatislar.Columns["Sale_No"].Visible = false;
            }
            DataTable personeller = sVeritabani.PersonelGetir();

            foreach (DataRow row in personeller.Rows)
            {
                comboBoxPersonel.Items.Add(row["KULLANICI_AD"]);
            }

            

            dataGridViewSatislar.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(119, 82, 254);
        }
        int satisNo;
        private void buttonSil_Click(object sender, EventArgs e)
        {
            sVeritabani.SatisSil(satisNo);
            dataGridViewSatislar.DataSource = sVeritabani.SatisListele();
        }

        private void dataGridViewSatislar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            satisNo = int.Parse(dataGridViewSatislar.Rows[rowIndex].Cells[0].Value.ToString());
            comboBoxPersonel.Text = dataGridViewSatislar.Rows[rowIndex].Cells[1].Value.ToString();
            dateTimePickerSatisTarih.Value = (DateTime)dataGridViewSatislar.Rows[rowIndex].Cells[2].Value;
            textBoxUrun.Text = dataGridViewSatislar.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxFiyat.Text = dataGridViewSatislar.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxMusteri.Text = dataGridViewSatislar.Rows[rowIndex].Cells[5].Value.ToString();
            textBoxTel.Text = dataGridViewSatislar.Rows[rowIndex].Cells[6].Value.ToString();
            textBoxAdet.Text = dataGridViewSatislar.Rows[rowIndex].Cells[7].Value.ToString();
            textBoxToplam.Text = dataGridViewSatislar.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void buttonDuzenle_Click(object sender, EventArgs e)
        {

            string personel = comboBoxPersonel.SelectedItem.ToString();
            DateTime satisTarih = dateTimePickerSatisTarih.Value;
            string urun = textBoxUrun.Text;
            double ucret = double.Parse(textBoxFiyat.Text);
            string musteri = textBoxMusteri.Text;
            string musteriTel = textBoxTel.Text;
            double miktar = double.Parse(textBoxAdet.Text);
            double toplam = double.Parse(textBoxToplam.Text);
            sVeritabani.SatisGuncelle(personel, satisTarih, urun, ucret, musteri, musteriTel, miktar, toplam, satisNo);
            dataGridViewSatislar.DataSource = sVeritabani.SatisListele();
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            textBoxMusteri.Clear();
            textBoxFiyat.Clear();
            textBoxAdet.Clear();
            textBoxTel.Clear();
            textBoxToplam.Clear();
            textBoxUrun.Clear();
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

        private void buttonHayvanlar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHayvanlar frmHayvanlar = new FrmHayvanlar();
            frmHayvanlar.Show();
        }

        private void buttonSaglik_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSaglik frmSaglik = new FrmSaglik();
            frmSaglik.Show();
        }

        private void buttonUretim_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmUretim frmUretim = new FrmUretim();
            frmUretim.Show();
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

        private void textBoxAdet_TextChanged(object sender, EventArgs e)
        {
            if(textBoxAdet.Text != null && textBoxFiyat.Text != null)
            {
                textBoxToplam.Text = (double.Parse(textBoxAdet.Text) * double.Parse(textBoxFiyat.Text)).ToString();
            }
        }

        private void textBoxUrun_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxMusteri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
