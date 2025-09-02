using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturalarController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar p)
        {
            c.Faturalars.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FaturaGetir(int id)
        {
            var degerler = c.Faturalars.Find(id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult FaturaGetir(Faturalar p)
        {
            var values = c.Faturalars.Find(p.Faturaİd);
            values.FaturaSeriNo = p.FaturaSeriNo;
            values.Saat = p.Saat;
            values.FaturaTarih = p.FaturaTarih;
            values.TeslimAlan = p.TeslimAlan;
            values.TeslimEden = p.TeslimEden;
            values.VergiDairesi = p.VergiDairesi;
            values.FaturaSıraNo = p.FaturaSıraNo;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaİd == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Dinamik()
        {
          var values= c.Faturalars.ToList();
          return View(values);
        }

        [HttpPost]
        public ActionResult Dinamik(FaturaViewModel model)
        {
            Faturalar f = new Faturalar();

            f.FaturaSeriNo = model.FaturaSeriNo;
            f.FaturaSıraNo = model.FaturaSıraNo;
            f.FaturaTarih = model.FaturaTarih;
            f.Saat = model.Saat;
            f.VergiDairesi = model.VergiDairesi;
            f.TeslimEden = model.TeslimEden;
            f.TeslimAlan = model.TeslimAlan;
            f.Toplam = model.Toplam;

            c.Faturalars.Add(f);
            foreach (var x in model.Kalemler)
            {
                FaturaKalem fk = new FaturaKalem
                {
                    Acıklama = x.Acıklama,
                    BirimFiyat = x.BirimFiyat,
                    Miktar = x.Miktar,
                    Tutar = x.Tutar,
                    Faturaİd = f.Faturaİd
                };
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Gerçekleşti: " + JsonRequestBehavior.AllowGet);
        }
    }
}