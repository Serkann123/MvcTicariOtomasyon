using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ÜrünController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Uruns.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult ÜrünEkle()
        {
            List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.İD.ToString()
                                             }).ToList();
            ViewBag.v1 = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult ÜrünEkle(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Ürün");
        }

        public ActionResult ÜrünSil(int id)
        {
            var degerler=c.Uruns.Find(id);
            degerler.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index","Ürün");
        }

        [HttpGet]
        public ActionResult ÜrünGüncelle(int id)
        {
            List<SelectListItem> kategoris = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.İD.ToString()
                                             }).ToList();
            ViewBag.v1 = kategoris;

            var degerler = c.Uruns.Find(id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult ÜrünGüncelle(Urun p)
        {
            var degerler = c.Uruns.Find(p.Urunİd);
            degerler.UrunAd = p.UrunAd;
            degerler.Durum = p.Durum;
            degerler.kategoriİd = p.kategoriİd;
            degerler.SatisFiyat = p.SatisFiyat;
            degerler.AlisFiyat = p.AlisFiyat;
            degerler.Marka = p.Marka;
            degerler.Stok = p.Stok;
            degerler.UrunGorsel = p.UrunGorsel;

            c.SaveChanges();
            return RedirectToAction("Index","Ürün");
        }
    
    }
}