using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Contex db = new Contex();
        public ActionResult Index()
        {
            var listele=  db.kategoris.ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
        
            return  View();
        
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {

            db.kategoris.Add(k);
            db.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult KategoriSil(int id)
        {

            var kat= db.kategoris.Find(id);

            db.kategoris.Remove(kat);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult  GetKategori(int id)
        {
            var kat = db.kategoris.Find(id);
            return View("GetKategori",kat);
        }
        public ActionResult KategoriGüncelle(Kategori k)
        {
            var kat = db.kategoris.Find(k.ID);
            kat.KategoriAd = k.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}