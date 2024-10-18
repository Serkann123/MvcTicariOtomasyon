using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var values1 = c.Carilers.Count().ToString();
            ViewBag.v1 = values1;

            var values2 = c.Uruns.Count().ToString();
            ViewBag.v2 = values2;

            var values3 = c.Kategoris.Count().ToString();
            ViewBag.v3 = values3;

            var values4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString(); 
            ViewBag.v4 = values4;

            var values = c.Yapilacaks.ToList();

            return View(values);
        }
    }
}