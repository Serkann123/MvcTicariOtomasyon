using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Departmen.Where(x=>x.DepartmanStatus==true).ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman p)
        {
            c.Departmen.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var degerler = c.Departmen.Find(id);
            degerler.DepartmanStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanGüncelle(int id)
        {
            var degerler = c.Departmen.Find(id);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult DepartmanGüncelle(Departman p)
        {
            var degerler = c.Departmen.Find(p.Departmanİd);
            degerler.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.departmanİd == id).ToList();

            var departmanlar = c.Departmen.Where(x => x.Departmanİd == id).Select(x => x.DepartmanAd).FirstOrDefault();

            ViewBag.v1 = departmanlar;

            return View(degerler);
        }

        public ActionResult DepartmanSatıslar(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelİd == id).ToList();
            var persoenller = c.Personels.Where(x => x.Personelİd == id).Select(x => 
            x.PersonelAd + " " + x.personelSoyad).FirstOrDefault();

            ViewBag.vdepartman = persoenller;
            return View(degerler);

        }
        
    }
}