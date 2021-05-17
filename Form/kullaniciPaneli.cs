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
    public partial class izinler : Form
    {
        public izinler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-P128UV7\\SQLEXPRESS;Initial Catalog=MARKETLER;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand command = new SqlCommand("select *from urunB where kullaniciAdiUB = @KA and urunUB = @urun ", baglanti);
            command.Parameters.AddWithValue("@KA", giris.user);
            command.Parameters.AddWithValue("@urun", cmbTur.Text);

            DialogResult Soru;
            Soru = MessageBox.Show("Kg fiyatı " + txtFiyat.Text + "₺ olmak üzere " + txtMiktar.Text + " Kg " + cmbTur.Text + " ürününü satış işlemine eklemek istediğinize emin misiniz?", "Uyarı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Soru == DialogResult.Yes)
            {

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DialogResult Soru2;
                    Soru2 = MessageBox.Show(cmbTur.Text + " ürünü eklemek üzere henüz admin onayı almamış başka bir başvurunuz olduğunu görüyoruz.\nYeni eklemek istediğiniz ürün miktarı ile eski miktar toplanacaktır kabul ediyor musunuz?\n(Eğer kg fiyatını farklı girdiyseniz fiyat bilgisi şu an giriş yapmak istediğiniz şekilde güncellenecektir!)", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);


                    if (Soru2 == DialogResult.Yes)
                    {

                        int a = Convert.ToInt32(reader["istekGrUB"]);
                        reader.Close();
                        SqlCommand guncelle = new SqlCommand("Update urunB set istekGrUB = @istek, fiyatUB = @fiyat  Where kullaniciAdiUB = @KA and urunUB = @urun", baglanti);
                        guncelle.Parameters.AddWithValue("@istek", Convert.ToInt32(txtMiktar.Text) + a);
                        guncelle.Parameters.AddWithValue("@KA", giris.user);
                        guncelle.Parameters.AddWithValue("@urun", cmbTur.Text);
                        guncelle.Parameters.AddWithValue("@fiyat", txtFiyat.Text);
                        guncelle.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("İşleminiz başarıyla gerçekleştirildi.");
                    }

                    else if (Soru2 == DialogResult.No)
                    {
                        MessageBox.Show("İşleminiz iptal edildi!");
                    }

                }
                else
                {
                    reader.Close();
                    SqlCommand komut = new SqlCommand("insert into urunB(kullaniciAdiUB, urunUB, istekGrUB, fiyatUB) values(@KA, @urun, @istek, @fiyat)", baglanti);
                    komut.Parameters.AddWithValue("@KA", giris.user);
                    komut.Parameters.AddWithValue("@urun", cmbTur.Text);
                    komut.Parameters.AddWithValue("@istek", txtMiktar.Text);
                    komut.Parameters.AddWithValue("@fiyat", txtFiyat.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("İşleminiz başarıyla gerçekleştirildi.");
                }
            }
            else if (Soru == DialogResult.No)
            {
                MessageBox.Show("İşleminiz iptal edildi!");
            }
            cmbTur.Text = txtMiktar.Text = txtFiyat.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("select *from paraB where kullaniciAdiPB = @KA", baglanti);
            command.Parameters.AddWithValue("@KA", giris.user);
            SqlDataReader reader = command.ExecuteReader();


            DialogResult Soru;
            Soru = MessageBox.Show(txtCuzdan.Text + "₺ bakiyeyi cüzdanınıza eklemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Soru == DialogResult.Yes)
            {

                if (reader.Read())
                {
                    DialogResult Soru2;
                    Soru2 = MessageBox.Show("Henüz yönetici onayı almamış bir bakiye yüklemesi işleminiz olduğunu görüyoruz.\nYeni girdiğiniz bakiye eskisi ile toplamak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Soru2 == DialogResult.Yes)
                    {
                        int a = Convert.ToInt32(reader["istekParaPB"]);
                        reader.Close();
                        SqlCommand guncelle = new SqlCommand("Update paraB set istekParaPB = @istek Where kullaniciAdiPB = @KA", baglanti);
                        guncelle.Parameters.AddWithValue("@istek", (Convert.ToInt32(txtCuzdan.Text) + a).ToString());
                        guncelle.Parameters.AddWithValue("@KA", giris.user);
                        guncelle.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    else if (Soru2 == DialogResult.No) MessageBox.Show("İşleminiz iptal edildi!");
                   

                    
                }
                else
                {
                    reader.Close();
                    SqlCommand komut = new SqlCommand("insert into paraB(kullaniciAdiPB, istekParaPB) values(@KA, @istek)", baglanti);
                    komut.Parameters.AddWithValue("@KA", giris.user);
                    komut.Parameters.AddWithValue("@istek", txtCuzdan.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            else if (Soru == DialogResult.No) MessageBox.Show("İşleminiz iptal edildi!");
            baglanti.Close();
            txtCuzdan.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Soru;
            Soru = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Soru == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ana_sayfa mainPage = new ana_sayfa();
            mainPage.Show();
            this.Close();
        }
    }
}