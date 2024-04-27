using FarmingProject.FormLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmingProject
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
        SVeritabani sVeriTabani = new SVeritabani();

        public static string personel;
        private void buttonGirisYap_Click(object sender, EventArgs e)
        {
            sVeriTabani.VeritabaninaBaglan();
            bool girisKontrol = sVeriTabani.GirisYap(textBoxKullaniciAd.Text, textBoxSifre.Text);

            if (girisKontrol)
            {
                personel = textBoxKullaniciAd.Text;
                FrmAdminPaneli frmAdminPaneli = new FrmAdminPaneli();
                this.Hide();
                frmAdminPaneli.Show();
            }
            else
                MessageBox.Show("Kullanıcı adı veya şifre hatalı olduğundan giriş yapılamadı.","Hatalı Giriş Bilgileri",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            
            sVeriTabani.VeritabaniBaglantisiKapa();
        }

        private void labelAnaMenuyeDon_Click(object sender, EventArgs e)
        {
            FrmAnaMenu frmMenu = new FrmAnaMenu();
            this.Hide();
            frmMenu.Show();
        }
    }
}
