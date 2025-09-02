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

        public ActionResult Index(int? id)
        {
            int UrunId = id ?? 1;
        
            Class1 cs = new Class1();

            cs.Deger1 = c.Uruns.Where(x => x.Urunİd == UrunId).ToList();
            cs.Deger2 = c.Detays.Where(x => x.DetayId == UrunId).ToList();
            return View(cs);
        }
    }
}