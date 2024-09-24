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
            //ilk satır
            ViewBag.v1 = c.Carilers.Count();
            ViewBag.v2 = c.Uruns.Count();
            ViewBag.v3 = c.Personels.Count();
            ViewBag.v4 = c.Kategoris.Count();

            //ilkinci satır
            ViewBag.v5 = c.Uruns.Sum(x => x.Stok);
            ViewBag.v6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.v7 = c.Uruns.Count(x => x.Stok <= 20);
            ViewBag.v8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();

            //üçüncü satır
            ViewBag.v9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.v10 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.v11 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı");
            ViewBag.v12 = c.Uruns.Count(x => x.UrunAd == "Leptop");

            //dördüncü satır

            //var degerler = c.Uruns.Where(u => u.Urunİd == (c.SatisHarekets.GroupBy(x => x.Urunİd).OrderByDescending(z => z.Count())
            //  .Select(y => y.Key).FirstOrDefault()));

            ViewBag.v13 = c.Uruns.Where(y => y.Urunİd == c.SatisHarekets.GroupBy(x => x.Urunİd).OrderByDescending(z => z.Count())
             .Select(x => x.Key).FirstOrDefault()).Select(x=>x.UrunAd).FirstOrDefault();

            ViewBag.v14 = c.SatisHarekets.Sum(x => x.ToplamTutar);
            var tarih = DateTime.Today;
            ViewBag.v15 = c.SatisHarekets.Count(x => x.Tarih == tarih);

            ViewBag.v16 = c.SatisHarekets.Where(x => x.Tarih == tarih).Sum(x=>x.ToplamTutar);

            return View();
        }
    }
}