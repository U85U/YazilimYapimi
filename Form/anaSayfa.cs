using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeOdevi
{
    public partial class ana_sayfa : Form
    {
        public ana_sayfa()
        {
            InitializeComponent();
        }

        private void btnCalisanBilgi_Click_1(object sender, EventArgs e)
        {
            calisan_bilgi calisan = new calisan_bilgi();
            calisan.Show();
            this.Close();
        }

        private void btnIzinler_Click_1(object sender, EventArgs e)
        {
            if (giris.user == "Admin") MessageBox.Show("Bu kısım kullanıcılar içindir.");
            else
            {
                izinler izin = new izinler();
                izin.Show();
                this.Close();
            }
        }

        private void btnBasvuru_Click_1(object sender, EventArgs e)
        {
            if (giris.user == "Admin")
            {
                kabulRed karar = new kabulRed();
                karar.Show();
                this.Close();
            }

            else MessageBox.Show("Bu kısma sadece yönetici girebilir.");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Soru;
            Soru = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Soru == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Soru;
            Soru = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Soru == DialogResult.Yes)
            {
                giris girisEkani = new giris();
                girisEkani.Show();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            raporForm rapor = new raporForm();
            rapor.Show();
            this.Hide();
        }

        private void ana_sayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
