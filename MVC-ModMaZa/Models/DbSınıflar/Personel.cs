using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ModMaZa.Models.DbSınıflar
{
    public class Personel
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        public string PersonelSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(3000)]
        public string PersonelGörsel { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
        public virtual Departman departman { get; set; }
        public int DepartmanID { get; set; }
    }
}