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
    public partial class FrmSaglik : Form
    {
        public FrmSaglik()
        {
            InitializeComponent();
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
        private void Temizle()
        {
            textBoxHayvanAd.Clear();
            textBoxHastalik.Clear();
            textBoxTedavi.Clear();
            textBoxTedaviUcreti.Clear();
            textBoxTeshis.Clear();
            textBoxVeterinerAdi.Clear();
        }

        SVeritabani sVeritabani = new SVeritabani();
        private void FrmSaglik_Load(object sender, EventArgs e)
        {
            dataGridViewSaglik.DataSource = sVeritabani.SaglikBilgileriniListele();
            if (dataGridViewSaglik.Rows.Count > 0)
            {
                dataGridViewSaglik.Columns["Health_No"].Visible = false;
            }
            DataTable hayvanNolari = sVeritabani.HayvanNolariGetir();

            foreach (DataRow row in hayvanNolari.Rows)
            {
                comboBoxHayvanNo.Items.Add(row["Animal_No"]);
            }
            

            dataGridViewSaglik.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(119, 82, 254);
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {

            int hayvanNo = !string.IsNullOrEmpty(comboBoxHayvanNo.Text) ? int.Parse(comboBoxHayvanNo.Text) : 0;
            string hayvanAd = textBoxHayvanAd.Text;
            string hastalik = textBoxHastalik.Text;
            string teshis = textBoxTeshis.Text;
            DateTime teshisTarih = dateTimePickerTeshisTarih.Value;
            string tedavi = textBoxTedavi.Text;
            float tedaviUcreti = !string.IsNullOrEmpty(textBoxTedaviUcreti.Text) ? float.Parse(textBoxTedaviUcreti.Text) : 0;
            string veterinerAdi = textBoxVeterinerAdi.Text;
            bool kontrollerBosMu = (hayvanNo == 0 ||  string.IsNullOrEmpty(hayvanAd) || string.IsNullOrEmpty(hastalik) || string.IsNullOrEmpty(teshis) || string.IsNullOrEmpty(tedavi) || tedaviUcreti < 0 || string.IsNullOrEmpty(veterinerAdi));
            if(!kontrollerBosMu)
            {
                sVeritabani.SaglikBilgisiEkle(hayvanNo, hayvanAd, hastalik, teshis, teshisTarih, tedavi, tedaviUcreti, veterinerAdi);
                dataGridViewSaglik.DataSource = sVeritabani.SaglikBilgileriniListele();
                MessageBox.Show("Sağlık bilgisi eklendi");
                Temizle();
                
            }
            else
                MessageBox.Show("Kontroller boş");
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if(saglikNo != 0)
            {
                sVeritabani.SaglikBilgisiSil(saglikNo);
                dataGridViewSaglik.DataSource = sVeritabani.SaglikBilgileriniListele();
                MessageBox.Show("Silindi");
                saglikNo = 0;
                Temizle();
            }
            else
                MessageBox.Show("Tablodan güncellenecek sağlık bilgisi seçiniz");


        }
        int saglikNo;
        private void dataGridViewSaglik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            saglikNo = (int)dataGridViewSaglik.Rows[rowIndex].Cells[0].Value;
            comboBoxHayvanNo.Text = dataGridViewSaglik.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxHayvanAd.Text = dataGridViewSaglik.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxHastalik.Text = dataGridViewSaglik.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxTeshis.Text = dataGridViewSaglik.Rows[rowIndex].Cells[4].Value.ToString();
            dateTimePickerTeshisTarih.Value = (DateTime)dataGridViewSaglik.Rows[rowIndex].Cells[5].Value;
            textBoxTedavi.Text = dataGridViewSaglik.Rows[rowIndex].Cells[6].Value.ToString();
            textBoxTedaviUcreti.Text = dataGridViewSaglik.Rows[rowIndex].Cells[7].Value.ToString();
            textBoxVeterinerAdi.Text = dataGridViewSaglik.Rows[rowIndex].Cells[8].Value.ToString();

        }

        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
            string hayvanAd = textBoxHayvanAd.Text;
            int hayvanNo = int.Parse(comboBoxHayvanNo.SelectedItem.ToString());
            string hastalik = textBoxHastalik.Text;
            string teshis = textBoxTeshis.Text;
            DateTime teshisTarih = dateTimePickerTeshisTarih.Value;
            string tedavi = textBoxTedavi.Text;
            float tedaviUcreti = !string.IsNullOrEmpty(textBoxTedaviUcreti.Text) ? float.Parse(textBoxTedaviUcreti.Text) : 0;
            string veterinerAdi = textBoxVeterinerAdi.Text;
            if(saglikNo != 0)
            {
                sVeritabani.SaglikBilgisiGuncelle(saglikNo, hastalik, teshis, teshisTarih, tedavi, tedaviUcreti, veterinerAdi);
                dataGridViewSaglik.DataSource = sVeritabani.SaglikBilgileriniListele();
                MessageBox.Show("Güncellendi");
                saglikNo = 0;
            }
            else
                MessageBox.Show("Tablodan güncellenecek sağlık bilgisi seçiniz");



        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
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

        private void textBoxHayvanAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxHastalik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxTeshis_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxTedavi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void textBoxTedaviUcreti_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxVeterinerAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void comboBoxHayvanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hayvanNoo = int.Parse(comboBoxHayvanNo.SelectedItem.ToString());
            string hayvanAd = sVeritabani.HayvanAdiGetir(hayvanNoo);
            textBoxHayvanAd.Text = hayvanAd;
        }
    }
}
