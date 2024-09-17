using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAd,
                                                 Value = x.Urunİd.ToString()
                                             }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAdı+" "+x.CariSoyad,
                                                 Value = x.Cariİd.ToString()
                                             }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd+" "+x.personelSoyad,
                                                 Value = x.Personelİd.ToString()
                                             }).ToList();
            ViewBag.v1 = deger1;
            ViewBag.v2 = deger2;
            ViewBag.v3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunİd.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAdı + " " + x.CariSoyad,
                                               Value = x.Cariİd.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.personelSoyad,
                                               Value = x.Personelİd.ToString()
                                           }).ToList();
            ViewBag.v1 = deger1;
            ViewBag.v2 = deger2;
            ViewBag.v3 = deger3;

            var degerler = c.SatisHarekets.Find(id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult SatisGetir(SatisHareket p)
        {
            var degerler = c.SatisHarekets.Find(p.Satısİd);
            degerler.Cariİd = p.Cariİd;
            degerler.Personelİd = p.Cariİd;
            degerler.Urunİd= p.Urunİd;
            degerler.Tarih = p.Tarih;
            degerler.Fiyat = p.Fiyat;
            degerler.Adet = p.Adet;
            degerler.ToplamTutar = p.ToplamTutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Satısİd == id).ToList();
            return View(degerler);
        }

    }
}