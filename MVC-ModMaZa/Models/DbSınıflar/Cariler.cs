using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ModMaZa.Models.DbSınıflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter olmalıdır")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string CariAD { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]

        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
       
        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
    }
}