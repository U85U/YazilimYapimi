namespace ProjeOdevi
{
    partial class ana_sayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buton_KullaniciPaneli = new System.Windows.Forms.Button();
            this.buton_Alisveris = new System.Windows.Forms.Button();
            this.buton_AdminPaneli = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buton_KullaniciPaneli
            // 
            this.buton_KullaniciPaneli.Location = new System.Drawing.Point(15, 13);
            this.buton_KullaniciPaneli.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buton_KullaniciPaneli.Name = "buton_KullaniciPaneli";
            this.buton_KullaniciPaneli.Size = new System.Drawing.Size(91, 65);
            this.buton_KullaniciPaneli.TabIndex = 0;
            this.buton_KullaniciPaneli.Text = "Kullanıcı Paneli";
            this.buton_KullaniciPaneli.UseVisualStyleBackColor = true;
            this.buton_KullaniciPaneli.Click += new System.EventHandler(this.btnIzinler_Click_1);
            // 
            // buton_Alisveris
            // 
            this.buton_Alisveris.Location = new System.Drawing.Point(209, 13);
            this.buton_Alisveris.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buton_Alisveris.Name = "buton_Alisveris";
            this.buton_Alisveris.Size = new System.Drawing.Size(91, 65);
            this.buton_Alisveris.TabIndex = 4;
            this.buton_Alisveris.Text = "Alışveriş";
            this.buton_Alisveris.UseVisualStyleBackColor = true;
            this.buton_Alisveris.Click += new System.EventHandler(this.btnCalisanBilgi_Click_1);
            // 
            // buton_AdminPaneli
            // 
            this.buton_AdminPaneli.Location = new System.Drawing.Point(112, 13);
            this.buton_AdminPaneli.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buton_AdminPaneli.Name = "buton_AdminPaneli";
            this.buton_AdminPaneli.Size = new System.Drawing.Size(91, 65);
            this.buton_AdminPaneli.TabIndex = 5;
            this.buton_AdminPaneli.Text = "Başvurular";
            this.buton_AdminPaneli.UseVisualStyleBackColor = true;
            this.buton_AdminPaneli.Click += new System.EventHandler(this.btnBasvuru_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Çıkış";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "Geri";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ana_sayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 95);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buton_AdminPaneli);
            this.Controls.Add(this.buton_Alisveris);
            this.Controls.Add(this.buton_KullaniciPaneli);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ana_sayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ana_sayfa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buton_KullaniciPaneli;
        private System.Windows.Forms.Button buton_Alisveris;
        private System.Windows.Forms.Button buton_AdminPaneli;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}