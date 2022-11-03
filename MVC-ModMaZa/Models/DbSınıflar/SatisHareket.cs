using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ModMaZa.Models.DbSınıflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisİD { get; set; }
        public DateTime Tarih { get; set; }
        public int  Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int UrunID { get; set; }
        public int CariID  { get; set; }
        public int PersonelID  { get; set; }

        public virtual Urun urun { get; set; }
        public virtual Cariler cariler  { get; set; }
        public virtual Personel personel { get; set; }

     
    }
}