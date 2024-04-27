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
    public partial class FrmYuklenmeEkrani : Form
    {
        public FrmYuklenmeEkrani()
        {
            InitializeComponent();
        }

        float yuzde = 0;
        private void timerYuklenmeBari_Tick(object sender, EventArgs e)
        {
            yuzde+= (1.4f);
            progressBar.Value = (int)yuzde;
            if(progressBar.Value == 100)
            {
                timerYuklenmeBari.Stop();
                FrmAnaMenu frmAnaMenu = new FrmAnaMenu();
                this.Hide();
                frmAnaMenu.Show();
            }
        }

        private void FrmYuklenmeEkrani_Load(object sender, EventArgs e)
        {
            
            timerYuklenmeBari.Start();
        }
    }
}
