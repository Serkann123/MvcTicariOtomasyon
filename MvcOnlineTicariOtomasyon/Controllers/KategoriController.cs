using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context c = new Context();

        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriAdd(Kategori p)
        {
            c.Kategoris.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index","Kategori");
        }

        public ActionResult KategoriDelete(int id)
        {
            var degerler=c.Kategoris.Find(id);
            c.Kategoris.Remove(degerler);
            c.SaveChanges();

            return RedirectToAction("Index","Kategori");
        }

        public ActionResult kategoriGetir(int id)
        {
            var degerler = c.Kategoris.Find(id);
            return View("kategoriGetir",degerler);
        }

        public ActionResult kategoriGüncelle(Kategori k)
        {
            var degerler = c.Kategoris.Find(k.İD);
            degerler.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deneme()
        {
            Class3 cs = new Class3();
            cs.Kategoriler = new SelectList(c.Kategoris, "İD", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "Urunİd", "UrunAd");
            return View(cs);
        }

        public JsonResult UrunGetir(int p)
        {
            var urunListesi = (from x in c.Uruns
                               join y in c.Kategoris
                               on x.Kategori.İD equals
                               y.İD
                               where x.Kategori.İD == p
                               select new
                               {
                                   Text = x.UrunAd,
                                   value = x.Urunİd.ToString()
                               }).ToList();
            return Json(urunListesi,JsonRequestBehavior.AllowGet);
        }

    }
}