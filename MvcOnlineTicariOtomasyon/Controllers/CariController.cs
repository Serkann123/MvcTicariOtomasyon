using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.CariDurum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var degerler=c.Carilers.Find(id);
            degerler.CariDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public  ActionResult CariGetir(int id)
        {
            var degerler = c.Carilers.Find(id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult CariGetir(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var degerler = c.Carilers.Find(p.Cariİd);
            degerler.CariAdı = p.CariAdı;
            degerler.CariSoyad = p.CariSoyad;
            degerler.CariMail = p.CariMail;
            degerler.CariSehir = p.CariSehir;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x=>x.Cariİd==id).ToList();
            var cr = c.Carilers.Where(x => x.Cariİd == id).Select(x => x.CariAdı + " " + x.CariSoyad).FirstOrDefault();
            ViewBag.Cari = cr;
            return View(degerler);
        }

    }
}