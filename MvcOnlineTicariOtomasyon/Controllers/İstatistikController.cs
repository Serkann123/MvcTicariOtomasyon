using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class İstatistikController : Controller
    {

        Context c = new Context();

        public ActionResult Index()
        {
            ViewBag.v1 = c.Carilers.Count();
            ViewBag.v2 = c.Uruns.Count();
            ViewBag.v3 = c.Personels.Count();
            ViewBag.v4 = c.Kategoris.Count();
            return View();
        }
    }
}