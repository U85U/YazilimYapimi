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
using System.Xml;

namespace ProjeOdevi
{
    public partial class kabulRed : Form
    {
        public kabulRed()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(giris.baglantiC);


        public double DovizGoster(string kur)
        {
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
                decimal sterlin = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));

                if (kur == "Dolar")
                {
                    return decimal.ToDouble(dolar);
                }
                else if (kur == "Euro")
                {
                    return decimal.ToDouble(euro);
                }
                else if (kur == "Sterlin")
                {
                    return decimal.ToDouble(sterlin);
                }
                else
                {
                    return 1;
                }
            }
            catch (XmlException xml)
            {
                MessageBox.Show(xml.ToString());
                return 0;
            }

        }


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
                ProjeOdevi.Sınıf.Kullanıcı kullanıcı = new Sınıf.Kullanıcı();
                kullanıcı.ad = dr["ad"].ToString();
                kullanıcı.soyad = dr["soyad"].ToString();
                kullanıcı.kullaniciAdi = dr["kullaniciAdi"].ToString();
                kullanıcı.parola = dr["parola"].ToString();
                kullanıcı.tc = dr["TC"].ToString();
                kullanıcı.telefon = dr["telefon"].ToString();
                kullanıcı.eposta = dr["ePosta"].ToString();
                kullanıcı.adres = dr["adres"].ToString();

                lblAd.Text = kullanıcı.ad;
                lblSoyad.Text = kullanıcı.soyad;
                lblKullaniciAdi.Text = kullanıcı.kullaniciAdi;
                lblParola.Text = kullanıcı.parola;
                lblTC.Text = kullanıcı.tc;
                lblTel.Text = kullanıcı.telefon;
                lblEPosta.Text = kullanıcı.eposta;
                lblAdres.Text = kullanıcı.adres;
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
                Urun urun = new Urun();
                urun.satici = dr["kullaniciAdiUB"].ToString();
                urun.urunAdı = dr["urunUB"].ToString();
                urun.urunMiktari = dr["istekGrUB"].ToString();
                urun.urunFiyati = dr["fiyatUB"].ToString();

                lblUserName.Text = urun.satici;
                lblUrunAdi.Text = urun.urunAdı;
                lblUrunMiktari.Text = urun.urunMiktari;
                lblFiyat.Text = urun.urunFiyati;
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
                    MessageBox.Show(lblUserName.Text+ " kullanıcısının ürünü sisteme eklendi.");
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
            //lblUserName.Text = lblUrunAdi.Text = lblUrunMiktari.Text = lblFiyat.Text = "";


            baglanti.Open();
            SqlDataReader reader2;
            SqlCommand command2 = new SqlCommand("select *from urunS where (urunS = @urun and fiyatS = @fiyat)", baglanti);
            command2.Parameters.AddWithValue("@fiyat", lblFiyat.Text);
            command2.Parameters.AddWithValue("@urun", lblUrunAdi.Text);
            reader2 = command2.ExecuteReader();
            string[,] tablo = new string[4, 100];
            int miktar = Convert.ToInt32(lblUrunMiktari.Text), dongu = 0;
            while (reader2.Read())
            {
                tablo[0, dongu] = reader2["kullaniciAdiS"].ToString();
                tablo[1, dongu] = reader2["urunS"].ToString();
                tablo[2, dongu] = reader2["grS"].ToString();
                tablo[3, dongu] = reader2["fiyatS"].ToString();
                dongu++;
            }
            reader2.Close();
            int satilan = 0;
            while(dongu>0 && Convert.ToInt32(tablo[2, dongu-1]) < miktar)
            {
                SqlCommand command = new SqlCommand("select *from basvuru where kullaniciAdi = @KA", baglanti);
                command.Parameters.AddWithValue("@KA", lblUserName.Text);
                SqlDataReader yenipara = command.ExecuteReader();

                double hold = 0;
                if (yenipara.Read()) hold = Convert.ToDouble(yenipara["cuzdan"].ToString());
                yenipara.Close();
                MessageBox.Show(hold+"");
                
                MessageBox.Show(Convert.ToDouble(tablo[2, dongu - 1]) + "");
                MessageBox.Show(Convert.ToDouble(tablo[3, dongu - 1]) + "");
                MessageBox.Show((Convert.ToDouble(tablo[2, dongu - 1]) * Convert.ToDouble(tablo[3, dongu - 1])) + "");
                MessageBox.Show(hold + (Convert.ToDouble(tablo[2, dongu - 1]) * Convert.ToDouble(tablo[3, dongu - 1]))+"asdasdsa");
                SqlCommand guncelle = new SqlCommand("Update basvuru set cuzdan = @cuzdan Where kullaniciAdi = @KA", baglanti);
                guncelle.Parameters.AddWithValue("@cuzdan", (hold + (Convert.ToDouble(tablo[2, dongu-1]) * Convert.ToDouble(tablo[3, dongu-1]))).ToString());
                guncelle.Parameters.AddWithValue("@KA", lblUserName.Text);
                guncelle.ExecuteNonQuery();

                
                SqlCommand rapor = new SqlCommand("insert into rapor(alici, saticilar, miktar, fiyat, ortalamaFiyat, islemUcreti, Tarih, urun) values(@Alici, @satici, @miktar, @fiyat, @ortFiyat, @IU, @tarih, @urun)", baglanti);
                rapor.Parameters.AddWithValue("@satici", lblUserName.Text);
                rapor.Parameters.AddWithValue("@Alici", tablo[0,dongu-1]);
                rapor.Parameters.AddWithValue("@miktar", tablo[2,dongu-1]);
                satilan += Convert.ToInt32(tablo[2, dongu - 1]);
                rapor.Parameters.AddWithValue("@fiyat", tablo[3,dongu-1]);
                rapor.Parameters.AddWithValue("@ortFiyat", tablo[3, dongu - 1]);
                rapor.Parameters.AddWithValue("@IU", ((Convert.ToInt32(tablo[3, dongu - 1]) * Convert.ToInt32(tablo[2, dongu - 1])) / 100).ToString());
                rapor.Parameters.AddWithValue("@tarih", DateTime.Now);
                rapor.Parameters.AddWithValue("@urun", lblUrunAdi.Text);
                rapor.ExecuteNonQuery();

                SqlCommand delete1 = new SqlCommand("delete from urunS where kullaniciAdiS = @KA", baglanti);
                delete1.Parameters.AddWithValue("KA", tablo[0,dongu-1]);
                delete1.ExecuteNonQuery();

                miktar -= Convert.ToInt32(tablo[2, dongu-1]);
                dongu--;
            }
            SqlCommand paraDus = new SqlCommand("select *from urun where kullaniciAdiU = @KA", baglanti);
            paraDus.Parameters.AddWithValue("@KA", lblUserName.Text);
            SqlDataReader dusurucu = paraDus.ExecuteReader();

            int holder = 0;
            if (dusurucu.Read()) holder = Convert.ToInt32(dusurucu["grU"].ToString());
            dusurucu.Close();

            SqlCommand guncelleDus = new SqlCommand("Update urun set grU = @GR Where kullaniciAdiU = @KA", baglanti);
            guncelleDus.Parameters.AddWithValue("@GR", (holder - satilan));
            guncelleDus.Parameters.AddWithValue("@KA", lblUserName.Text);
            guncelleDus.ExecuteNonQuery();
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
                    MessageBox.Show(lblUserName + " kullanıcısının ürün ekleme işlemi iptal edildi.");
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
            string kayit = "select kullaniciAdiPB as 'Kullanıcı Adı', birimPB as 'Birim' from paraB";
            SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
            adtr.Fill(daset, "paralar");
            dataGridView2.DataSource = daset.Tables["paralar"];
            baglanti.Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            baglanti.Open();
            string kayit = "select * from paraB WHERE (kullaniciAdiPB = @KA) and (birimPB = @BR)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@KA", dataGridView2.CurrentRow.Cells["Kullanıcı Adı"].Value.ToString());
            komut.Parameters.AddWithValue("@BR", dataGridView2.CurrentRow.Cells["Birim"].Value.ToString());

            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                lblParaKullanıcı.Text = dr["kullaniciAdiPB"].ToString();
                lblEkleyecek.Text = dr["istekParaPB"].ToString();
                parabirimi.Text = dr["birimPB"].ToString();
                string birim = dr["birimPB"].ToString();
                double kur = DovizGoster(birim);
                sonkur.Text = kur.ToString();
                double tutar = Convert.ToInt32(lblEkleyecek.Text) * kur;
                tutarson.Text = tutar.ToString();
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
                    SqlCommand delete = new SqlCommand("delete from paraB where kullaniciAdiPB = @KA and birimPB = @BR", baglanti);
                    delete.Parameters.AddWithValue("@KA", lblParaKullanıcı.Text);
                    delete.Parameters.AddWithValue("@BR", parabirimi.Text);
                    delete.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(lblParaKullanıcı + " kişininin para ekleme işlemi başarıyla reddedildi.");
                    DataSet daset = new DataSet();
                    daset.Clear();
                    baglanti.Open();
                    string kayit = "select kullaniciAdiPB as 'Kullanıcı Adı', birimPB as 'Birim' from paraB";
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
                        double a = Convert.ToDouble(reader["cuzdan"]);
                        reader.Close();
                        SqlCommand guncelle = new SqlCommand("Update basvuru set cuzdan = @cuzdan  Where kullaniciAdi = @KA", baglanti);
                        guncelle.Parameters.AddWithValue("@cuzdan", (Convert.ToDouble(tutarson.Text) + a).ToString());
                        guncelle.Parameters.AddWithValue("@KA", lblParaKullanıcı.Text);
                        guncelle.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    baglanti.Open();
                    SqlCommand delete = new SqlCommand("delete from paraB where kullaniciAdiPB = @KA and birimPB = @BR", baglanti);
                    delete.Parameters.AddWithValue("KA", lblParaKullanıcı.Text);
                    delete.Parameters.AddWithValue("BR", parabirimi.Text);
                    delete.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show(lblParaKullanıcı + " kullanıcısının para ekleme işlemi başarıyla onaylandı.");
                    DataSet daset = new DataSet();
                    daset.Clear();
                    baglanti.Open();
                    string kayit = "select kullaniciAdiPB as 'Kullanıcı Adı', birimPB as 'Birim' from paraB";
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

