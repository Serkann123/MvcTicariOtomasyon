using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.IO;
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
            var values = c.Personels.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
             List<SelectListItem> values = (from x in c.Departmen.ToList()
                     select new SelectListItem
                      {
                         Text = x.DepartmanAd,
                         Value = x.Departmanİd.ToString()
                      }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelGorsel= "/Image/" + dosyaAdi + uzanti;
            }

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
            var values = c.Personels.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult PersonelGüncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelGorsel = "/Image/" + dosyaAdi + uzanti;
            }
            var values = c.Personels.Find(p.Personelİd);
            values.PersonelAd = p.PersonelAd;
            values.personelSoyad = p.personelSoyad;
            values.personelGorsel = p.personelGorsel;
            values.departmanİd = p.departmanİd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelListesi()
        {
            var query = c.Personels.ToList();
            return View(query);
        }
    }
}