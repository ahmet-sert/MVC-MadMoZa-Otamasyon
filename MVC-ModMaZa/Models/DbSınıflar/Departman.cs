using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ModMaZa.Models.DbSınıflar
{
    public class Departman
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection <Personel>personels { get; set; }
    }
}