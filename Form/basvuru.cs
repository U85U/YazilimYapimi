using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProjeOdevi
{
    public partial class basvuru : Form
    {
        public basvuru()
        {
            InitializeComponent();
        }


          SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-N7M3D64;Initial Catalog=MARKETLER;Integrated Security=True");
        bool parola = false;
        private void btnBasvur_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into basvuru(ad, soyad, kullaniciAdi, parola, TC, Telefon, ePosta, adres) values(@ad, @soyad, @kullaniciAdi, @parola, @TC, @Telefon, @ePosta, @adres)", baglanti);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@parola", txtParola.Text);
            komut.Parameters.AddWithValue("@TC", txtTC.Text);
            komut.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@ePosta", txtEPosta.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başvurunuz başarıyle işleme alınmıştır. \n\"Başvuru Sorgula\" kısmına belirlediğiniz kulanıcı adını girerek durumunuzu öğrenbilirsiniz.");


            txtAd.Text = txtSoyad.Text =  txtKullaniciAdi.Text = txtParola.Text = txtTelefon.Text = txtTC.Text = txtEPosta.Text = txtAdres.Text = "";
            
        }
        

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT * from basvuru where kullaniciAdi = @kullaniciAdi";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@kullaniciAdi", txtSorgu.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) MessageBox.Show(dr["durum"].ToString());
            baglanti.Close();
            txtSorgu.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (parola == true)
            {
                txtParola.PasswordChar = '*';
                parola = false;
            }
            else if (parola == false) 
            {
                txtParola.PasswordChar = '\0';
                parola = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Soru;
            Soru = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Soru == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            giris mainPage = new giris();
            mainPage.Show();
            this.Close();
        }
    }
}
