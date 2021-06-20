using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace ProjeOdevi
{
    public partial class raporForm : Form
    {
        public raporForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            calisan_bilgi calisan = new calisan_bilgi();
            calisan.Show();
            this.Close();
        }
    }
}
