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
            this.SuspendLayout();
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.BackColor = System.Drawing.Color.Transparent;
            this.lblSifre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifre.ForeColor = System.Drawing.Color.White;
            this.lblSifre.Location = new System.Drawing.Point(556, 215);
            this.lblSifre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(37, 17);
            this.lblSifre.TabIndex = 1;
            this.lblSifre.Text = "Şifre";
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.Transparent;
            this.btnGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiris.FlatAppearance.BorderSize = 0;
            this.btnGiris.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGiris.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.ForeColor = System.Drawing.Color.GreenYellow;
            this.btnGiris.Location = new System.Drawing.Point(629, 269);
            this.btnGiris.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(56, 27);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click_1);
            // 
            // txtBoxSifre
            // 
            this.txtBoxSifre.Location = new System.Drawing.Point(679, 214);
            this.txtBoxSifre.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxSifre.Name = "txtBoxSifre";
            this.txtBoxSifre.PasswordChar = '*';
            this.txtBoxSifre.Size = new System.Drawing.Size(76, 20);
            this.txtBoxSifre.TabIndex = 4;
            // 
            // btnBasvur
            // 
            this.btnBasvur.BackColor = System.Drawing.Color.Transparent;
            this.btnBasvur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBasvur.FlatAppearance.BorderSize = 0;
            this.btnBasvur.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBasvur.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBasvur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasvur.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBasvur.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnBasvur.Location = new System.Drawing.Point(721, 358);
            this.btnBasvur.Margin = new System.Windows.Forms.Padding(2);
            this.btnBasvur.Name = "btnBasvur";
            this.btnBasvur.Size = new System.Drawing.Size(56, 31);
            this.btnBasvur.TabIndex = 5;
            this.btnBasvur.Text = "Başvur";
            this.btnBasvur.UseVisualStyleBackColor = false;
            this.btnBasvur.Click += new System.EventHandler(this.btnBasvur_Click);
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.BackColor = System.Drawing.Color.Transparent;
            this.lblKullanici.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullanici.ForeColor = System.Drawing.Color.White;
            this.lblKullanici.Location = new System.Drawing.Point(556, 162);
            this.lblKullanici.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(84, 17);
            this.lblKullanici.TabIndex = 0;
            this.lblKullanici.Text = "Kullanıcı Adı";
            // 
            // txtBoxKullanici
            // 
            this.txtBoxKullanici.Location = new System.Drawing.Point(679, 159);
            this.txtBoxKullanici.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxKullanici.Name = "txtBoxKullanici";
            this.txtBoxKullanici.Size = new System.Drawing.Size(76, 20);
            this.txtBoxKullanici.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(750, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjeOdevi.Properties.Resources.giris21;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.lblKullanici);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBasvur);
            this.Controls.Add(this.txtBoxSifre);
            this.Controls.Add(this.txtBoxKullanici);
            this.Controls.Add(this.btnGiris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.TextBox txtBoxSifre;
        private System.Windows.Forms.Button btnBasvur;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.TextBox txtBoxKullanici;
        private System.Windows.Forms.Button button1;
    }
}

