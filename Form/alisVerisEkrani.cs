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
    public partial class calisan_bilgi : Form
    {
        public calisan_bilgi()
        {
            InitializeComponent();
        }
        int don;
        double para;
        bool sistemkontrol = true;
        SqlConnection baglanti = new SqlConnection(giris.baglantiC);
        DataSet daset = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            sistemkontrol = false;
            daset.Clear();
            baglanti.Open();
            string kayit = "SELECT kullaniciAdiU as 'Satıcı', grU as 'Miktar', fiyatU as 'Birim Fiyat', ToplamFiyat = grU * fiyatU  from urun where urunU = '" + comboBox1.Text + "' order by fiyatU";
            SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
            adtr.Fill(daset, "elma");
            dataGridView1.DataSource = daset.Tables["elma"];
            baglanti.Close();
        }
        int satinAL;
        private void button4_Click(object sender, EventArgs e)
        {
            if (sistemkontrol == true) MessageBox.Show("Lütfen önce ürün seçiniz.");
            else
            {
                baglanti.Open();
                satinAL = Convert.ToInt32(textBox1.Text);
                int a = 0, harcananPara = 0, satinAlinan = 0;
                string[,] kisiler = new string[50, 50];
                don = dataGridView1.RowCount - 1;

                bool satirKontrol = false;
                bool urunKontrol = true;
                bool paraKontrol = true;

                SqlDataReader reader;
                SqlCommand command;
                SqlCommand guncelle;
                SqlCommand delete;

                while (don != 0 && satinAL - Convert.ToInt32(dataGridView1.Rows[a].Cells[1].Value) >= 0 && (para - Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value)) > 0)
                {
                    satirKontrol = true;
                    satinAL -= Convert.ToInt32(dataGridView1.Rows[a].Cells[1].Value);
                    para -= Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value) + (Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value) / 100);
                    harcananPara += Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value);
                    satinAlinan += Convert.ToInt32(dataGridView1.Rows[a].Cells[1].Value);
                    kisiler[a, 0] = dataGridView1.Rows[a].Cells[0].Value.ToString();
                    kisiler[a, 1] = dataGridView1.Rows[a].Cells[3].Value.ToString();


                    lblPara.Text = para + "";

                    if (satinAL <= 0) urunKontrol = false;
                    if (don < 0) satirKontrol = false;
                    if (para - Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value) < 0) paraKontrol = false;

                    command = new SqlCommand("select *from basvuru where kullaniciAdi = @KA", baglanti);
                    command.Parameters.AddWithValue("@KA", dataGridView1.Rows[a].Cells[0].Value.ToString());
                    reader = command.ExecuteReader();

                    double hold = 0;
                    if (reader.Read()) hold = Convert.ToDouble(reader["cuzdan"].ToString());
                    reader.Close();

                    guncelle = new SqlCommand("Update basvuru set cuzdan = @cuzdan Where kullaniciAdi = @KA", baglanti);
                    guncelle.Parameters.AddWithValue("@cuzdan", (hold + Convert.ToDouble(dataGridView1.Rows[a].Cells[3].Value.ToString())));
                    guncelle.Parameters.AddWithValue("@KA", dataGridView1.Rows[a].Cells[0].Value.ToString());
                    guncelle.ExecuteNonQuery();


                    command = new SqlCommand("select *from basvuru where kullaniciAdi = @KA", baglanti);
                    command.Parameters.AddWithValue("@KA", "Muhasebe_kullanicisi");
                    reader = command.ExecuteReader();
                    hold = 0;
                    if (reader.Read()) hold = Convert.ToDouble(reader["cuzdan"].ToString());
                    reader.Close();
                    guncelle = new SqlCommand("Update basvuru set cuzdan = @cuzdan Where kullaniciAdi = @KA", baglanti);
                    guncelle.Parameters.AddWithValue("@cuzdan", ((hold + Convert.ToDouble(dataGridView1.Rows[a].Cells[3].Value) / 100).ToString()));
                    guncelle.Parameters.AddWithValue("@KA", "Muhasebe_kullanicisi");
                    guncelle.ExecuteNonQuery();

                    delete = new SqlCommand("delete from urun where kullaniciAdiU = @KA", baglanti);
                    delete.Parameters.AddWithValue("KA", dataGridView1.Rows[a].Cells[0].Value.ToString());
                    delete.ExecuteNonQuery();

                    don--;
                    a++;
                }

                if (urunKontrol == false) MessageBox.Show("satın alındı");
                if (paraKontrol == false) MessageBox.Show("paran yetmiyor");

                if (satinAL != Convert.ToInt32(textBox1.Text))
                {
                    string mesaj = "";
                    for (int i = 0; i < a; i++) mesaj += kisiler[i, 0] + ", ";
                    SqlCommand rapor = new SqlCommand("insert into rapor(alici, saticilar, miktar, fiyat, ortalamaFiyat, islemUcreti, Tarih, urun) values(@Alici, @satici, @miktar, @fiyat, @ortFiyat, @IU, @tarih, @urun)", baglanti);
                    rapor.Parameters.AddWithValue("@Alici", giris.user);
                    rapor.Parameters.AddWithValue("@satici", mesaj);
                    rapor.Parameters.AddWithValue("@miktar", satinAlinan.ToString());
                    rapor.Parameters.AddWithValue("@fiyat", harcananPara.ToString());
                    rapor.Parameters.AddWithValue("@ortFiyat", (harcananPara / satinAlinan).ToString());
                    rapor.Parameters.AddWithValue("@IU", (harcananPara / 100).ToString());
                    rapor.Parameters.AddWithValue("@tarih", DateTime.Now);
                    rapor.Parameters.AddWithValue("@urun", comboBox1.Text);
                    rapor.ExecuteNonQuery();

                }
                baglanti.Close();
                if (satinAL > 0 || !satirKontrol)
                {
                    MessageBox.Show(satinAL + " kadar eksik ürününüz var. \nBelirlediğiniz fiyattan daha sonra satılacaklar...");
                    btn_satinAl.Enabled = false;
                    comboBox1.Enabled = false;
                    button1.Enabled = false;
                    textBox1.Enabled = false;
                    btnSatEmri.Enabled = true;
                    textBox2.Enabled = true;
                }


                baglanti.Open();
                SqlCommand yeniPara = new SqlCommand("Update basvuru set cuzdan = @cuzdan Where kullaniciAdi = @KA", baglanti);
                yeniPara.Parameters.AddWithValue("@cuzdan", lblPara.Text);
                yeniPara.Parameters.AddWithValue("@KA", giris.user);
                yeniPara.ExecuteNonQuery();
                baglanti.Close();
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
            ana_sayfa mainpage = new ana_sayfa();
            mainpage.Show();
            this.Close();
        }

        private void calisan_bilgi_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("select *from basvuru where kullaniciAdi = @KA", baglanti);
            command.Parameters.AddWithValue("@KA", giris.user);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                para = Convert.ToDouble(reader["cuzdan"].ToString());
                lblPara.Text = para + "";
            }
            baglanti.Close();
        }

        private void btnSatEmri_Click(object sender, EventArgs e)
        {
            if (satinAL*Convert.ToInt32(textBox2.Text) < Convert.ToDouble(lblPara.Text))
            {
                btn_satinAl.Enabled = true;
                comboBox1.Enabled = true;
                button1.Enabled = true;
                textBox1.Enabled = true;
                btnSatEmri.Enabled = false;
                textBox2.Enabled = false;
                MessageBox.Show("Satın alınması üzere; " + satinAL + " adet " + comboBox1.Text + " ögesi " + textBox2.Text + "₺ birim fiyatıyla sisteme eklenmiştir.");
                baglanti.Open();
                SqlCommand rapor = new SqlCommand("insert into urunS(kullaniciAdiS, urunS, grS, fiyatS) values(@kullaniciAdiS, @urunS, @grS, @fiyatS)", baglanti);
                rapor.Parameters.AddWithValue("@kullaniciAdiS", giris.user);
                rapor.Parameters.AddWithValue("@urunS", comboBox1.Text);
                rapor.Parameters.AddWithValue("@grS", satinAL.ToString());
                rapor.Parameters.AddWithValue("@fiyatS", textBox2.Text);
                rapor.ExecuteNonQuery();
                baglanti.Close();
                lblPara.Text = (Convert.ToDouble(lblPara.Text) - ((satinAL * Convert.ToDouble(textBox2.Text))*1.01)).ToString();
                baglanti.Open();
                SqlCommand yeniPara = new SqlCommand("Update basvuru set cuzdan = @cuzdan Where kullaniciAdi = @KA", baglanti);
                yeniPara.Parameters.AddWithValue("@cuzdan", lblPara.Text);
                yeniPara.Parameters.AddWithValue("@KA", giris.user);
                yeniPara.ExecuteNonQuery();
                baglanti.Close();
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Bu işlemi yapmak için yeterli paranız yok");
            }
        }
    }
}