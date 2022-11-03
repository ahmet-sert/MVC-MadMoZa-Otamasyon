using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class FaturalarController : Controller
    {
        // GET: Faturalar
        Contex db = new Contex();
        public ActionResult Index()
        {
            var deger = db.faturalars.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {

            return View();
        }
                                 

        [HttpPost]
       public ActionResult FaturaEkle( Faturalar f)
        {
            db.faturalars.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var faturalar = db.faturalars.Find(id);
            return View("FaturaGetir", faturalar);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fat = db.faturalars.Find(f.FaturaID);
            fat.FaturaSeriNo = f.FaturaSeriNo;
            fat.FaturaSıraNo = f.FaturaSıraNo;
            fat.Saat = f.Saat;
            fat.Tarih = f.Tarih;
            fat.TeslimAlan = f.TeslimAlan;
            fat.TeslimEden = f.TeslimEden;
            fat.VergiDairesi = f.VergiDairesi;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var deger = db.faturaKalems.Where(x => x.FaturaID == id).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
           db.faturaKalems.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}