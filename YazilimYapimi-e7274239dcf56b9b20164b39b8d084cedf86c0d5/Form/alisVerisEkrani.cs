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
        int para;
        bool sistemkontrol = true;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-N7M3D64;Initial Catalog=MARKETLER;Integrated Security=True");
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (sistemkontrol == true) MessageBox.Show("Lütfen önce ürün seçiniz.");
            else
            {

                baglanti.Open();
                int satinAL = Convert.ToInt32(textBox1.Text), a = 0, harcananPara = 0, satinAlinan = 0;
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
                    para -= Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value);
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
                    int hold = 0;
                    if (reader.Read()) hold = Convert.ToInt32(reader["cuzdan"].ToString());
                    reader.Close();

                    guncelle = new SqlCommand("Update basvuru set cuzdan = @cuzdan Where kullaniciAdi = @KA", baglanti);
                    guncelle.Parameters.AddWithValue("@cuzdan", (hold + Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value.ToString())));
                    guncelle.Parameters.AddWithValue("@KA", dataGridView1.Rows[a].Cells[0].Value.ToString());
                    guncelle.ExecuteNonQuery();

                    delete = new SqlCommand("delete from urun where kullaniciAdiU = @KA", baglanti);
                    delete.Parameters.AddWithValue("KA", dataGridView1.Rows[a].Cells[0].Value.ToString());
                    delete.ExecuteNonQuery();


                    don--;
                    a++;
                }


                if (urunKontrol == false) MessageBox.Show("satın alındı");
                if (satirKontrol == false) MessageBox.Show("ürün yetmiyor");
                if (paraKontrol == false) MessageBox.Show("paran yetmiyor");

                string mesaj = giris.user + " kişisi; \n";
                for (int i = 0; i < a; i++) mesaj += kisiler[i, 0] + " kişisine " + kisiler[i, 1] + " ₺\n";
                MessageBox.Show(satinAlinan + " tane aldınız ve " + harcananPara + " para harcadınız");
                MessageBox.Show(harcananPara / satinAlinan + " ortalama fiyattan aldınız.");
                MessageBox.Show(mesaj + "gönderdi");


                SqlCommand sil = new SqlCommand("Update basvuru set cuzdan = @cuzdan Where kullaniciAdi = @KA", baglanti);
                sil.Parameters.AddWithValue("@cuzdan", lblPara.Text);
                sil.Parameters.AddWithValue("@KA", giris.user);
                sil.ExecuteNonQuery();

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
                para = Convert.ToInt32(reader["cuzdan"].ToString());
                lblPara.Text = para + "";
            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now + "");
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            raporForm raporform = new raporForm();
            raporform.Show();
            this.Hide();

        }
    }
}