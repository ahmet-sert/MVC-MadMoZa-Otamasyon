using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ModMaZa.Models.DbSınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Açiklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyatı { get; set; }
        public decimal Tutar { get; set; }
        public int FaturaID { get; set; }
        public virtual Faturalar Faturalar { get; set; }

    }
}