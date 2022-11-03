using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Contex DB = new Contex();
        public ActionResult Index()
        {
            //var deger = DB.uruns.Where(x => x.ID == 1).ToList();
            Class1 cs = new Class1();
            cs.Deger1 = DB.uruns.Where(x => x.ID == 1).ToList();
            cs.Deger2 = DB.detays.Where(x => x.DetayID == 1).ToList();

            return View(cs);
        }
    }
}