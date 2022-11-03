using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Persenol
        Contex db = new Contex();
        public ActionResult Index()
        {
            var deger = db.personels.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult Personelekle()
        {
            List<SelectListItem> veri = (from x in db.departmens.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.ID.ToString()
                                         }).ToList();
            ViewBag.dgr = veri;

            return View();
        }

        [HttpPost]
        public ActionResult Personelekle (Personel p)
        {


            db.personels.Add(p);
            db.SaveChanges();
            return  RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> veri = (from x in db.departmens.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.ID.ToString()
                                         }).ToList();
            ViewBag.dgr = veri;

            var prs = db.personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn = db.personels.Find(p.ID);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGörsel = p.PersonelGörsel;
            prsn.DepartmanID = p.DepartmanID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Personellist()
        {
            var deger = db.personels.ToList();
            return View(deger);
        }
    }
}