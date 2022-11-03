using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class departmanController : Controller
    {
        Contex db = new Contex();
        public ActionResult Index()
        {
            var deger = db.departmens.Where(x=>x.Durum==true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        { 
           return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            db.departmens.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
  
        public ActionResult DepartmanSil(int id)
        {

            var dep = db.departmens.Find(id);
            dep.Durum = false;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public  ActionResult DepartmanGetir(int id)
        {

            var deger = db.departmens.Find(id);
            return View("DepartmanGetir", deger);
        }


        public ActionResult Departmangüncelle(Departman d)
        {
            var deger=db.departmens.Find(d.ID);
            deger.DepartmanAd = d.DepartmanAd;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult DepartmanDetay(int id)
        {
            var deger = db.personels.Where(x => x.ID == id).ToList();
            var dpt = db.departmens.Where(x => x.ID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.disim = dpt;
            return View(deger);
        }


        public ActionResult DepartmanPersonelSatıs(int id)
        {
            var degerler=db.satisHarekets.Where(x=>x.PersonelID==id).ToList();
            var per = db.personels.Where(x => x.ID == id).Select(y => y.PersonelAd+" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.pisim = per;
            return View(degerler);
        }
        public ActionResult MusteriSatis(int id)
        {
            var deger = db.satisHarekets.Where(x => x.CariID == id).ToList();
            return View(deger);
        }
    }
}