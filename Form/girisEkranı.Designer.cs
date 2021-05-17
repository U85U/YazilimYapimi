namespace ProjeOdevi
{
    partial class giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSifre = new System.Windows.Forms.Label();
            this.btnGiris = new System.Windows.Forms.Button();
            this.txtBoxSifre = new System.Windows.Forms.TextBox();
            this.btnBasvur = new System.Windows.Forms.Button();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.txtBoxKullanici = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new System.Drawing.Point(6, 64);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(37, 17);
            this.lblSifre.TabIndex = 1;
            this.lblSifre.Text = "Şifre";
            // 
            // btnGiris
            // 
            this.btnGiris.Location = new System.Drawing.Point(16, 106);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(75, 33);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click_1);
            // 
            // txtBoxSifre
            // 
            this.txtBoxSifre.Location = new System.Drawing.Point(96, 56);
            this.txtBoxSifre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxSifre.Name = "txtBoxSifre";
            this.txtBoxSifre.PasswordChar = '*';
            this.txtBoxSifre.Size = new System.Drawing.Size(100, 22);
            this.txtBoxSifre.TabIndex = 4;
            this.txtBoxSifre.Text = "Admin";
            // 
            // btnBasvur
            // 
            this.btnBasvur.Location = new System.Drawing.Point(110, 106);
            this.btnBasvur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBasvur.Name = "btnBasvur";
            this.btnBasvur.Size = new System.Drawing.Size(75, 33);
            this.btnBasvur.TabIndex = 5;
            this.btnBasvur.Text = "Başvur";
            this.btnBasvur.UseVisualStyleBackColor = true;
            this.btnBasvur.Click += new System.EventHandler(this.btnBasvur_Click);
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.Location = new System.Drawing.Point(6, 29);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(84, 17);
            this.lblKullanici.TabIndex = 0;
            this.lblKullanici.Text = "Kullanıcı Adı";
            // 
            // txtBoxKullanici
            // 
            this.txtBoxKullanici.Location = new System.Drawing.Point(96, 26);
            this.txtBoxKullanici.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxKullanici.Name = "txtBoxKullanici";
            this.txtBoxKullanici.Size = new System.Drawing.Size(100, 22);
            this.txtBoxKullanici.TabIndex = 3;
            this.txtBoxKullanici.Text = "Admin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Çıkış";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 22);
            this.button2.TabIndex = 13;
            this.button2.Text = "*";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblKullanici);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.lblSifre);
            this.groupBox1.Controls.Add(this.btnGiris);
            this.groupBox1.Controls.Add(this.btnBasvur);
            this.groupBox1.Controls.Add(this.txtBoxKullanici);
            this.groupBox1.Controls.Add(this.txtBoxSifre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 156);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giriş";
            // 
            // giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 187);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.TextBox txtBoxSifre;
        private System.Windows.Forms.Button btnBasvur;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.TextBox txtBoxKullanici;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

