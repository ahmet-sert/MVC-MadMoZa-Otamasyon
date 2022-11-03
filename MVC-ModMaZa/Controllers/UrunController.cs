using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Contex db = new Contex();
        public ActionResult Index()
        {
            var urunler = db.uruns.Where(x=>x.Durum==true). ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> veri = (from x in db.kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.ID.ToString()
                                         }).ToList();
         ViewBag.dgr=veri;
                                   
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun( Urun u)
        {
            db.uruns.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var veri = db.uruns.Find(id);
            veri.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {         
                List<SelectListItem> veri = (from x in db.kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.ID.ToString()
                                             }).ToList();
                ViewBag.dgr = veri;

              var veri2 = db.uruns.Find(id);
            return View("UrunGetir", veri2);
        }
         public ActionResult UrunGuncelle(Urun p)
        {
            var değer = db.uruns.Find(p.ID);
            değer.AlişFiyat = p.AlişFiyat;
            değer.SatişFiyati = p.SatişFiyati;
            değer.Durum = p.Durum;
            değer.Stok = p.Stok;
            değer.Marka = p.Marka;
            değer.UrunAd = p.UrunAd;
            değer.UrunGorsel = p.UrunGorsel;
            değer.KategoriID = p.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunListesi()
        {
            var deger = db.uruns.ToList();
            return View(deger);
        }
    }
}