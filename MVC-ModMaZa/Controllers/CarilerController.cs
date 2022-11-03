using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Contex db = new Contex();
        public ActionResult Index()
        {
            var deger = db.carilers.Where(x=>x.Durum ==true).  ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult Yenicari()
        {
           return View();   
        }
        [HttpPost]
        public ActionResult Yenicari(Cariler c)
        {
            c.Durum = true;
            db.carilers.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {

            var ca = db.carilers.Find(id);
            ca.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var deger = db.carilers.Find(id);
            return View("CariGetir",deger);
        }

        public ActionResult CariGuncelle(Cariler p)

        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");

            }
          
            var cari=db.carilers.Find(p.CariID);

            cari.CariSoyad = p.CariSoyad;
            cari.CariAD = p.CariAD;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        public ActionResult MusteriSatis(int id)
        {
            var deger = db.satisHarekets.Where(x => x.CariID == id).ToList();
            var cr = db.carilers.Where(x => x.CariID == id).Select(y => y.CariAD + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(deger);
        }
    }
}
