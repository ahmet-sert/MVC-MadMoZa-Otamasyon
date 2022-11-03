using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ModMaZa.Models.DbSınıflar
{
    public class Kategori
    {

        [Key]
        public int ID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection <Urun>uruns { get; set; }
    }
}