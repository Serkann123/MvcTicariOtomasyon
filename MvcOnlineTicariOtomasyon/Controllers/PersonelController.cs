using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> degerler = (from x in c.Departmen.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.Departmanİd.ToString()
                                             }).ToList();
            ViewBag.v1 = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult PersonelGüncelle(int id)
        {
            List<SelectListItem> personel = (from x in c.Departmen.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.Departmanİd.ToString()
                                             }).ToList();
            ViewBag.v1 = personel;

            var degerler = c.Personels.Find(id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult PersonelGüncelle(Personel p)
        {
            var degerler = c.Personels.Find(p.Personelİd);
            degerler.PersonelAd = p.PersonelAd;
            degerler.personelSoyad = p.personelSoyad;
            degerler.personelGorsel = p.personelGorsel;
            degerler.departmanİd = p.departmanİd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}