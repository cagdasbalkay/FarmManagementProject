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
    public partial class FrmUretim : Form
    {
        public FrmUretim()
        {
            InitializeComponent();
        }
        SVeritabani sVeritabani = new SVeritabani();
        private void FrmUretim_Load(object sender, EventArgs e)
        {
            dataGridViewUretim.DataSource = sVeritabani.UretimListele();

            
            DataTable hayvanNolari = sVeritabani.HayvanNolariGetir();

            foreach (DataRow row in hayvanNolari.Rows)
            {
                comboBoxHayvanNo.Items.Add(row["Animal_No"]);
            }
            
            dataGridViewUretim.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(119, 82, 254);
        }
        private void Temizle()
        {
            textBoxHayvanAd.Clear();
            textBoxSabahUretim.Clear();
            textBoxOgleUretim.Clear();
            textBoxOsUretim.Clear();
            textBoxTopUretim.Clear();
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

        private void pictureBoxEkraniKucult_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxEkraniKapa_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FrmAdminGiris frmAdmin = new FrmAdminGiris();
            frmAdmin.Show();
        }


        private void comboBoxHayvanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int hayvanNo = int.Parse(comboBoxHayvanNo.SelectedItem.ToString());
            string hayvanAd = sVeritabani.HayvanAdiGetir(hayvanNo);
            textBoxHayvanAd.Text = hayvanAd;
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            
            int hayvanNo = int.Parse(comboBoxHayvanNo.SelectedItem.ToString());
            string hayvanAd = textBoxHayvanAd.Text;
            double sabahUretim = double.Parse(textBoxSabahUretim.Text);
            double ogleUretim = double.Parse(textBoxOgleUretim.Text);
            double osUretim = double.Parse(textBoxOsUretim.Text);
            double toplamUretim = double.Parse(textBoxTopUretim.Text);
            DateTime uretimTarih = dateTimePickerUretimTarih.Value;
            bool kontrollerBosMu = (hayvanNo == 0 ||  sabahUretim < 0 || ogleUretim < 0 || osUretim < 0 || toplamUretim < 0 );
            bool eklenmekIstenenUretimTablodaVarMi = sVeritabani.TablodaEklenmekIstenenUretimVarMi(hayvanNo);
            
            if(!kontrollerBosMu)
            {

            
            if(!eklenmekIstenenUretimTablodaVarMi)
            {
                sVeritabani.UretimEkle(hayvanNo, hayvanAd, sabahUretim, ogleUretim, osUretim, toplamUretim, uretimTarih);
                dataGridViewUretim.DataSource = sVeritabani.UretimListele();
                MessageBox.Show("Eklendi");
            }
            else
                MessageBox.Show("Eklenemedi");
            }

        }
        int id;
        private void buttonSil_Click(object sender, EventArgs e)
        {
            sVeritabani.UretimSil(id);
            dataGridViewUretim.DataSource = sVeritabani.UretimListele();
        }

        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
          
            string hayvanAd = textBoxHayvanAd.Text;
            double sabahUretim = double.Parse(textBoxSabahUretim.Text);
            double ogleUretim = double.Parse(textBoxOgleUretim.Text);
            double osUretim = double.Parse(textBoxOsUretim.Text);
            double toplamUretim = double.Parse(textBoxTopUretim.Text);
            DateTime uretimTarih = dateTimePickerUretimTarih.Value;
            sVeritabani.UretimGuncelle(id, hayvanAd, sabahUretim, ogleUretim, osUretim, toplamUretim,uretimTarih);
            dataGridViewUretim.DataSource = sVeritabani.UretimListele();
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridViewUretim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            id = (int)dataGridViewUretim.Rows[rowIndex].Cells[0].Value;
            comboBoxHayvanNo.Text = id.ToString();
            textBoxHayvanAd.Text = dataGridViewUretim.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxSabahUretim.Text = dataGridViewUretim.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxOgleUretim.Text = dataGridViewUretim.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxOsUretim.Text = dataGridViewUretim.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxTopUretim.Text = dataGridViewUretim.Rows[rowIndex].Cells[5].Value.ToString();
            dateTimePickerUretimTarih.Value = (DateTime)dataGridViewUretim.Rows[rowIndex].Cells[6].Value;




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

        private void textBoxOsUretim_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSabahUretim.Text) && !string.IsNullOrEmpty(textBoxOgleUretim.Text) && !string.IsNullOrEmpty(textBoxOsUretim.Text))
            {
                double sabahUretim, ogleUretim, osUretim;

                if (double.TryParse(textBoxSabahUretim.Text, out sabahUretim) &&
                    double.TryParse(textBoxOgleUretim.Text, out ogleUretim) &&
                    double.TryParse(textBoxOsUretim.Text, out osUretim))
                {
                    textBoxTopUretim.Text = (sabahUretim + ogleUretim + osUretim).ToString();
                }
                else
                {
                    
                    MessageBox.Show("Geçersiz sayı formatı.");
                }
            }
            else
            {
                
                MessageBox.Show("Boş alan bırakmayınız.");
            }

        }

        private void textBoxSabahUretim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBoxOgleUretim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBoxOsUretim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBoxTopUretim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
