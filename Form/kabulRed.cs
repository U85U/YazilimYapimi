﻿using System;
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
    public partial class kabulRed : Form
    {
        public kabulRed()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-P128UV7\\SQLEXPRESS;Initial Catalog=MARKETLER;Integrated Security=True");





        private void btnBasvurulariGoruntule_Click(object sender, EventArgs e)
        {
            DataSet daset = new DataSet();
            daset.Clear();
            baglanti.Open();

            string kayit = "select kullaniciAdi as 'Kullanıcı Adı' from basvuru where durum = 'Bekliyor'";
            SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
            adtr.Fill(daset, "basvuru");
            dataGridViewGoruntule.DataSource = daset.Tables["basvuru"];
            baglanti.Close();
        }

        private void dataGridViewGoruntule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            baglanti.Open();
            string kayit = "select * from basvuru WHERE kullaniciAdi = @KA ";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@KA", dataGridViewGoruntule.CurrentRow.Cells["Kullanıcı Adı"].Value.ToString());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                lblAd.Text = dr["ad"].ToString();
                lblSoyad.Text = dr["soyad"].ToString();
                lblKullaniciAdi.Text = dr["kullaniciAdi"].ToString();
                lblParola.Text = dr["parola"].ToString();
                lblTC.Text = dr["TC"].ToString();
                lblTel.Text = dr["telefon"].ToString();
                lblEPosta.Text = dr["ePosta"].ToString();
                lblAdres.Text = dr["adres"].ToString();
            }
            baglanti.Close();
        }

        private void btnKabul_Click_1(object sender, EventArgs e)
        {

            if (lblKullaniciAdi.Text != "")
            {
                DialogResult Soru;
                Soru = MessageBox.Show(lblKullaniciAdi.Text + " kullanıcı adına sahip kişinin kayıt işlemini onaylamak istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Soru == DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("Update basvuru set durum = @durum Where kullaniciAdi = @kullaniciAdi", baglanti);
                    guncelle.Parameters.AddWithValue("@durum", "Kabul Edildiniz.");
                    guncelle.Parameters.AddWithValue("@kullaniciAdi", lblKullaniciAdi.Text);
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(lblKullaniciAdi.Text + " kullanıcısı sisteme eklendi.");
                }
                else if (Soru == DialogResult.No) MessageBox.Show("İşlem iptal edildi. Daha sonra tekrar onaylayabilir ya da iptal edebilirsiniz.");
                lblAd.Text = lblSoyad.Text = lblKullaniciAdi.Text = lblParola.Text = lblAdres.Text = lblTel.Text = lblEPosta.Text = lblTC.Text = "";
                DataSet daset = new DataSet();

                daset.Clear();
                baglanti.Open();

                string kayit = "select kullaniciAdi as 'Kullanıcı Adı' from basvuru where durum = 'Bekliyor'";
                SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
                adtr.Fill(daset, "basvuru");
                dataGridViewGoruntule.DataSource = daset.Tables["basvuru"];
                baglanti.Close();
            }
            else MessageBox.Show("Lütfen ilk önce seçim yapınız.");

        }

        private void btnRed_Click(object sender, EventArgs e)
        {

            if (lblKullaniciAdi.Text != "")
            {
                DialogResult Soru;
                Soru = MessageBox.Show(lblKullaniciAdi.Text + " kullanıcı adına sahip kişinin kayıt reddetmek onaylamak istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Soru == DialogResult.Yes)
                {

                    baglanti.Open();
                    SqlCommand guncelle = new SqlCommand("Update basvuru set durum = @durum Where kullaniciAdi = @kullaniciAdi", baglanti);
                    guncelle.Parameters.AddWithValue("@durum", "Maalesef işe kabul edilmediniz.");
                    guncelle.Parameters.AddWithValue("@kullaniciAdi", lblKullaniciAdi.Text);
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(lblKullaniciAdi.Text + " kullanıcısı üye olarak seçilmedi.");
                }
                else if (Soru == DialogResult.No) MessageBox.Show("İşlem iptal edildi. Daha sonra tekrar onaylayabilir ya da iptal edebilirsiniz.");
                lblAd.Text = lblSoyad.Text = lblKullaniciAdi.Text = lblParola.Text = lblAdres.Text = lblTel.Text = lblEPosta.Text = lblTC.Text = "";

                DataSet daset = new DataSet();
                daset.Clear();
                baglanti.Open();
                string kayit = "select kullaniciAdi as 'Kullanıcı Adı' from basvuru where durum = 'Bekliyor'";
                SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
                adtr.Fill(daset, "basvuru");
                dataGridViewGoruntule.DataSource = daset.Tables["basvuru"];
                baglanti.Close();
            }
            else MessageBox.Show("Lütfen ilk önce seçim yapınız.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet daset = new DataSet();
            daset.Clear();
            baglanti.Open();
            string kayit = "select kullaniciAdiUB as 'Kullanıcı Adı', urunUB as 'Ürün' from urunB";
            SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
            adtr.Fill(daset, "urunler");
            dataGridView1.DataSource = daset.Tables["urunler"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            baglanti.Open();
            string kayit = "select * from urunB WHERE (kullaniciAdiUB = @KA and urunUB = @urun)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@KA", dataGridView1.CurrentRow.Cells["Kullanıcı Adı"].Value.ToString());
            komut.Parameters.AddWithValue("@urun", dataGridView1.CurrentRow.Cells["Ürün"].Value.ToString());

            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                lblUserName.Text = dr["kullaniciAdiUB"].ToString();
                lblUrunAdi.Text = dr["urunUB"].ToString();
                lblUrunMiktari.Text = dr["istekGrUB"].ToString();
                lblFiyat.Text = dr["fiyatUB"].ToString();
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblUserName.Text != "")
            {
                DialogResult Soru;
                Soru = MessageBox.Show(lblUserName.Text + " kullanıcı adına sahip kişinin ürün ekleme işlemini onaylamak istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Soru == DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand command = new SqlCommand("select *from urun where kullaniciAdiU = @KA and urunU = @urun ", baglanti);
                    command.Parameters.AddWithValue("@KA", lblUserName.Text);
                    command.Parameters.AddWithValue("@urun", lblUrunAdi.Text);


                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int a = Convert.ToInt32(reader["grU"]);
                        reader.Close();
                        SqlCommand guncelle = new SqlCommand("Update urun set grU = @gr, fiyatU = @fiyat  Where kullaniciAdiU = @KA and urunU = @urun", baglanti);
                        guncelle.Parameters.AddWithValue("@gr", Convert.ToInt32(lblUrunMiktari.Text) + a);
                        guncelle.Parameters.AddWithValue("@KA", lblUserName.Text);
                        guncelle.Parameters.AddWithValue("@urun", lblUrunAdi.Text);
                        guncelle.Parameters.AddWithValue("@fiyat", lblFiyat.Text);
                        guncelle.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    else
                    {
                        reader.Close();
                        SqlCommand komut = new SqlCommand("insert into urun(kullaniciAdiU, urunU, grU, fiyatU) values(@KA, @urun, @istek, @fiyat)", baglanti);
                        komut.Parameters.AddWithValue("@KA", lblUserName.Text);
                        komut.Parameters.AddWithValue("@urun", lblUrunAdi.Text);
                        komut.Parameters.AddWithValue("@istek", lblUrunMiktari.Text);
                        komut.Parameters.AddWithValue("@fiyat", lblFiyat.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    baglanti.Open();
                    SqlCommand delete = new SqlCommand("delete from urunB where kullaniciAdiUB = @KA and urunUB = @urun", baglanti);
                    delete.Parameters.AddWithValue("KA", lblUserName.Text);
                    delete.Parameters.AddWithValue("urun", lblUrunAdi.Text);
                    delete.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(lblUserName+" kullanıcısının ürünü sisteme eklendi.");
                    DataSet daset = new DataSet();
                    daset.Clear();
                    baglanti.Open();
                    string kayit = "select kullaniciAdiUB as 'Kullanıcı Adı', urunUB as 'Ürün' from urunB";
                    SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
                    adtr.Fill(daset, "urunler");
                    dataGridView1.DataSource = daset.Tables["urunler"];
                    baglanti.Close();

                }
                else MessageBox.Show("İşlem iptal edildi. İstediğiniz zaman onaylayabilir ya da reddebilirsiniz.");

            }
            else MessageBox.Show("Lütfen önce seçim yapınız.");
            lblUserName.Text = lblUrunAdi.Text = lblUrunMiktari.Text = lblFiyat.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblUserName.Text != "")
            {
                DialogResult Soru;
                Soru = MessageBox.Show(lblUserName.Text + " kullanıcı adına sahip kişinin kayıt işlemini reddetmek istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Soru == DialogResult.Yes)
                {


                    baglanti.Open();
                    SqlCommand delete = new SqlCommand("delete from urunB where kullaniciAdiUB = @KA and urunUB = @urun", baglanti);
                    delete.Parameters.AddWithValue("KA", lblUserName.Text);
                    delete.Parameters.AddWithValue("urun", lblUrunAdi.Text);
                    delete.ExecuteNonQuery();
                    baglanti.Close();


                    DataSet daset = new DataSet();
                    daset.Clear();
                    baglanti.Open();
                    string kayit = "select kullaniciAdiUB as 'Kullanıcı Adı', urunUB as 'Ürün' from urunB";
                    SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
                    adtr.Fill(daset, "urunler");
                    dataGridView1.DataSource = daset.Tables["urunler"];
                    MessageBox.Show(lblUserName+" kullanıcısının ürün ekleme işlemi iptal edildi.");
                    baglanti.Close();

                }
                else MessageBox.Show("İşlem iptal edildi. İstediğiniz zaman onaylayabilir ya da reddebilirsiniz.");

            }
            else MessageBox.Show("Lütfen önce seçim yapınız.");
            lblUserName.Text = lblUrunAdi.Text = lblUrunMiktari.Text = lblFiyat.Text = "";
        }
    

        private void button6_Click(object sender, EventArgs e)
        {
            DataSet daset = new DataSet();
            daset.Clear();
            baglanti.Open();
            string kayit = "select kullaniciAdiPB as 'Kullanıcı Adı' from paraB";
            SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
            adtr.Fill(daset, "paralar");
            dataGridView2.DataSource = daset.Tables["paralar"];
            baglanti.Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            baglanti.Open();
            string kayit = "select * from paraB WHERE (kullaniciAdiPB = @KA)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@KA", dataGridView2.CurrentRow.Cells["Kullanıcı Adı"].Value.ToString());
            
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                lblParaKullanıcı.Text = dr["kullaniciAdiPB"].ToString();
                lblEkleyecek.Text = dr["istekParaPB"].ToString();
            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (lblParaKullanıcı.Text != "")
            {
                DialogResult Soru;
                Soru = MessageBox.Show(lblParaKullanıcı.Text + " kullanıcı adına sahip kişinin para ekeleme işlemini reddetmek istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Soru == DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand delete = new SqlCommand("delete from paraB where kullaniciAdiPB = @KA", baglanti);
                    delete.Parameters.AddWithValue("@KA", lblParaKullanıcı.Text);
                    delete.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(lblParaKullanıcı + " kişininin para ekleme işlemi başarıyla reddedildi.");
                    DataSet daset = new DataSet();
                    daset.Clear();
                    baglanti.Open();
                    string kayit = "select kullaniciAdiPB as 'Kullanıcı Adı' from paraB";
                    SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
                    adtr.Fill(daset, "paralar");
                    dataGridView2.DataSource = daset.Tables["paralar"];
                    baglanti.Close();
                }
                else MessageBox.Show("İşlem iptal edildi. İstediğiniz zaman onaylayabilir ya da reddebilirsiniz.");

            }
            else MessageBox.Show("Lütfen önce seçim yapınız.");
            lblParaKullanıcı.Text = lblEkleyecek.Text = lblFiyat.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lblParaKullanıcı.Text != "")
            {
                DialogResult Soru;
                Soru = MessageBox.Show(lblParaKullanıcı.Text + " kullanıcı adına sahip kişinin para ekeleme işlemini onaylamak istediğinize emin misiniz?", "Uyarı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Soru == DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand command = new SqlCommand("select *from basvuru where kullaniciAdi = @KA", baglanti);
                    command.Parameters.AddWithValue("@KA", lblParaKullanıcı.Text);
                    command.Parameters.AddWithValue("@urun", lblEkleyecek.Text);


                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int a = Convert.ToInt32(reader["cuzdan"]);
                        reader.Close();
                        SqlCommand guncelle = new SqlCommand("Update basvuru set cuzdan = @cuzdan  Where kullaniciAdi = @KA", baglanti);
                        guncelle.Parameters.AddWithValue("@cuzdan", (Convert.ToInt32(lblEkleyecek.Text) + a).ToString());
                        guncelle.Parameters.AddWithValue("@KA", lblParaKullanıcı.Text);
                        guncelle.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    baglanti.Open();
                    SqlCommand delete = new SqlCommand("delete from paraB where kullaniciAdiPB = @KA", baglanti);
                    delete.Parameters.AddWithValue("KA", lblParaKullanıcı.Text);
                    delete.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(lblParaKullanıcı+" kullanıcısının para ekleme işlemi başarıyla onaylandı.");
                    DataSet daset = new DataSet();
                    daset.Clear();
                    baglanti.Open();
                    string kayit = "select kullaniciAdiPB as 'Kullanıcı Adı' from paraB";
                    SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
                    adtr.Fill(daset, "paralar");
                    dataGridView2.DataSource = daset.Tables["paralar"];
                    baglanti.Close();


                }
                else MessageBox.Show("İşlem iptal edildi. İstediğiniz zaman onaylayabilir ya da reddebilirsiniz.");

            }
            else MessageBox.Show("Lütfen önce seçim yapınız.");
            lblParaKullanıcı.Text = lblEkleyecek.Text = lblFiyat.Text = "";


        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult Soru;
            Soru = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Soru == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ana_sayfa mainPage = new ana_sayfa();
            mainPage.Show();
            this.Close();
        }
    }
}
