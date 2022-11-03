using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MVC_ModMaZa.Models.DbSınıflar
{
    public class Contex:DbContext
    {
        public DbSet<Admin> admins { get; set; }
        public DbSet<Cariler> carilers { get; set; }
        public DbSet<Departman> departmens { get; set; }
        public DbSet<FaturaKalem> faturaKalems { get; set; }
        public DbSet<Faturalar> faturalars { get; set; }
        public DbSet<Kategori> kategoris { get; set; }
        public DbSet<Giderler> giderlers { get; set; }
        public DbSet<Personel> personels { get; set; }
        public DbSet<Urun> uruns { get; set; }
        public DbSet<SatisHareket> satisHarekets { get; set; }
        public DbSet<Detay> detays { get; set; }


    }
}