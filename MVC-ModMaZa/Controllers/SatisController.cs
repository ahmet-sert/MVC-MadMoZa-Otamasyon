using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Contex db = new Contex();
        public ActionResult Index()
        {
            var deger = db.satisHarekets.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniSatiş()
        {
            List<SelectListItem> deger = (from x in db.uruns.ToList()
                                          select new SelectListItem
                                          {

                                              Text = x.UrunAd,
                                              Value = x.ID.ToString()

                                          }).ToList();
            List<SelectListItem> deger1 = (from x in db.carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAD + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in db.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.ID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatiş(SatisHareket s)
        {
            s.Tarih =DateTime.Parse (DateTime.Now.ToShortDateString());
            db.satisHarekets.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {

            List<SelectListItem> deger = (from x in db.uruns.ToList()
                                          select new SelectListItem
                                          {

                                              Text = x.UrunAd,
                                              Value = x.ID.ToString()

                                          }).ToList();
            List<SelectListItem> deger1 = (from x in db.carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAD + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in db.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.ID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr = deger;
            var veri = db.satisHarekets.Find(id);
            return View("SatisGetir",veri);
        }
        public ActionResult Satisguncelle(SatisHareket p)
        {
            var deger = db.satisHarekets.Find(p.SatisİD);
            deger.CariID= p.CariID;
            deger.Adet= p.Adet;
            deger.Fiyat= p.Fiyat;
            deger.PersonelID= p.PersonelID;
            deger.Tarih= p.Tarih;
            deger.ToplamTutar= p.ToplamTutar;
            deger.UrunID= p.UrunID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var deger = db.satisHarekets.Where(x => x.SatisİD == id).ToList();

            return View(deger);
        }
    }
}