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
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjeOdevi
{
    public partial class raporForm : Form
    {
        public raporForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(giris.baglantiC);
        DataTable tablo = new DataTable();
        DataSet daset = new DataSet();

        

        private void button3_Click(object sender, EventArgs e)
        {
            daset.Clear();
            baglanti.Open();
            string kayit = ("select *from rapor where alici = '" + giris.user + "'and Tarih between @tarih1 and @tarih2");
            SqlDataAdapter adtr = new SqlDataAdapter(kayit, baglanti);
            adtr.SelectCommand.Parameters.AddWithValue("@tarih1", dateTimePicker1.Value);
            adtr.SelectCommand.Parameters.AddWithValue("@tarih2", dateTimePicker2.Value);
            adtr.Fill(daset, "elma");
            dataGridView1.DataSource = daset.Tables["elma"];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ana_sayfa mainPage = new ana_sayfa();
            mainPage.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Soru;
            Soru = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Soru == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                Excel.Application exceldosya = new Excel.Application();
                exceldosya.Visible = true;
                object Missing = Type.Missing;
                Excel.Workbook calismakitabi = exceldosya.Workbooks.Add(Missing);
                Excel.Worksheet sheet1 = (Excel.Worksheet)calismakitabi.Sheets[1];
                int sutun = 1;
                int satır = 1;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Excel.Range myrange = (Excel.Range)sheet1.Cells[satır, sutun + j];
                    myrange.Value2 = dataGridView1.Columns[j].HeaderText;
                }
                satır++;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        Excel.Range myrange = (Excel.Range)sheet1.Cells[satır + i, sutun + j];
                        myrange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        myrange.Select();
                    }
                }
            }
        }
    }
}
