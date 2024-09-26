using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ÜrünDetayController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Uruns.Where(x => x.Urunİd == 1).ToList();
            return View(degerler);
        }
    }
}