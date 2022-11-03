using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ModMaZa.Models.DbSınıflar
{
    public class Urun
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlişFiyat { get; set; }
        public decimal SatişFiyati { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        public bool Durum { get; set; }

        public int KategoriID { get; set; }
        public virtual Kategori kategori { get; set; }
        public  ICollection <SatisHareket>satisHarekets { get; set; }



    }
}