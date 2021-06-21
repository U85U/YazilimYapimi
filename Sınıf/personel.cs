using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOdevi
{
    public class personel
    {
            public string AdSoyad { get; set; }
          
            public string Adres { get; set; }
            public int PersonelID { get; set; }
            public string mevki { get; set; }
            public Izin izin { get; set; }
            public Sube sube { get; set; }
            public string maas { get; set; }
            public string ymaas;
            public string Ymaas
            {
              get
              {
                return ymaas;
              }
              set
              {
                
               if (Convert.ToInt32(maas) <Convert.ToInt32(value))
                  ymaas = "1";
                else
                  ymaas = "0";
                   
              }
            }
        private string gyetki;
        public string gYetki
        {
            get
            {
                return gyetki;
            }
            set
            {
                if ("Müdür" == value)
                    gyetki = "1";
                else if ("Müdür Yardımcısı" == value)
                    gyetki = "2";
                else if ("Kasiyer" == value)
                    gyetki = "3";
                else 
                    gyetki = "0";
                

            }
        }
        private string yadres;
        public string yAdres
        {
            get
            {
                return yadres;
            }
            set
            {
                if (value == "")
                    yadres= "Maalesef işe kabul edilmediniz.";
                else 
                    yadres="Bekleniyor";
            }
        }
       
        


           
       

       
        
            
    }
}
