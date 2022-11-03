using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class istatislikController : Controller
    {
        // GET: istatislik
        Contex db = new Contex();
        public ActionResult Index()
        {
            var car = db.carilers.Count().ToString();
            ViewBag.car = car;

            var urn = db.uruns.Count().ToString();
            ViewBag.urn = urn;

            var per = db.personels.Count().ToString();
            ViewBag.per = per;

            var kat = db.kategoris.Count().ToString();
            ViewBag.kat = kat;

            var urn1 = db.uruns.Sum(x => x.Stok).ToString();
            ViewBag.urn1 = urn1;

            var urn2 = db.uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.urn2 = urn2;

            var urn3 = (from x in db.uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.urn3 = urn3;

            var urn4 = (from x in db.uruns orderby x.SatişFiyati descending select x.UrunAd).FirstOrDefault();
            ViewBag.urn4 = urn4;

            var urn5 = (from x in db.uruns orderby x.SatişFiyati ascending select x.UrunAd).FirstOrDefault();
            ViewBag.urn5 = urn5;

            var urn6 = db.uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.urn6 = urn6;

            var urn7 = db.uruns.Count(x => x.UrunAd == "LapTop").ToString();
            ViewBag.urn7 = urn7;

            var urn8 = db.uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();

            ViewBag.urn8 = urn8;

            var sts1 = db.satisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.sts1 = sts1;

            DateTime bugun = DateTime.Today;
            var sts2 = db.satisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.sts2 = sts2;


            //var sts3 = db.satisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
            //ViewBag.sts3 = sts3;

            var sts4 = db.uruns.Where(u => u.ID == (db.satisHarekets.GroupBy(x => x.UrunID).OrderByDescending//char   
            (z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault().FirstOrDefault();
            ViewBag.sts4 = sts4;

            return View();
        }
        public ActionResult KolayTablolar()
        {
            var deger = from x in db.carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayı = g.Count()
                        };
            return View(deger.ToList());
        }
        public PartialViewResult Partial1()
        {
            var deger2 = from x in db.personels
                         group x by x.departman.DepartmanAd into g
                         select new Sinifgrup2
                         {
                             Departman = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(deger2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var deger3 = db.carilers.ToList();

            return PartialView(deger3);
        }
        public PartialViewResult Partial3()
        {
            var deger4 = db.uruns.ToList();

            return PartialView(deger4);
        }
        public PartialViewResult Partial4()
        {
            var deger4 = from x in db.uruns
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(deger4 .ToList());
        }
    }
}