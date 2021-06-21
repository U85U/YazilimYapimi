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
    
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();

        }
        public static string user;

        public static string baglantiC = ("Data Source=DESKTOP-N7M3D64;Initial Catalog=MARKETLER;Integrated Security=True");
        SqlConnection baglanti = new SqlConnection(giris.baglantiC);
        SqlDataReader reader;
        bool parola = false;
       

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("select *from basvuru where kullaniciAdi = @KA and parola = @PW and durum = @D", baglanti);
            command.Parameters.AddWithValue("@KA", txtBoxKullanici.Text);
            command.Parameters.AddWithValue("@PW", txtBoxSifre.Text);
            command.Parameters.AddWithValue("@D", "Kabul Edildiniz.");
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                user = reader["kullaniciAdi"].ToString();
                MessageBox.Show("Hoş geldiniz " + user + ". Keyifli alışverişler.");
                ana_sayfa anaSayfa = new ana_sayfa();
                anaSayfa.Show();
                this.Hide();
            }
            else if (txtBoxKullanici.Text == "Admin" && txtBoxSifre.Text == "Admin")
            {
                user = "Admin";
                MessageBox.Show("Hoşgeldiniz sayın Yönetici.");
                ana_sayfa anaSayfa = new ana_sayfa();
                anaSayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı. Lütfen tekrar deneyin.");
                txtBoxKullanici.Text = txtBoxSifre.Text = "";
            }
            baglanti.Close();
        }

        private void btnBasvur_Click(object sender, EventArgs e)
        {
            basvuru basvuru = new basvuru();
            basvuru.Show();
            this.Hide();
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
            if (parola == true)
            {
                txtBoxSifre.PasswordChar = '*';
                parola = false;
            }
            else if (parola == false)
            {
                txtBoxSifre.PasswordChar = '\0';
                parola = true;
            }
        }
    }
}
