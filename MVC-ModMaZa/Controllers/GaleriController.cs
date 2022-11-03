using MVC_ModMaZa.Models.DbSınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ModMaZa.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Contex db = new Contex();
        public ActionResult Index()
        {
            var deger = db.uruns.ToList();
            return View(deger);
        }
    }
}