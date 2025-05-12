using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{

    public class CariPanelController : Controller
    {
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.ma = mail;
            var mailId = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.Cariİd).FirstOrDefault();
            ViewBag.mailİd = mailId;
            var toplamSatis = c.SatisHarekets.Where(x => x.Cariİd == mailId).Count();
            ViewBag.ToplamSatis = toplamSatis;
            var toplamTutar = c.SatisHarekets.Where(x => x.Cariİd == mailId).Sum(x =>(decimal?) x.ToplamTutar) ?? 0;
            ViewBag.ToplamTutar = toplamTutar;

            var toplamÜrünSayisi = c.SatisHarekets.Where(x => x.Cariİd == mailId).Sum(x=>(decimal?) x.Adet) ?? 0;
            ViewBag.ToplamÜrünSayisi = toplamÜrünSayisi;

            var adSoyad = c.Carilers.Where(x => x.Cariİd == mailId).Select(y => y.CariAdı + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adSoyad = adSoyad;

            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var values = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajId).ToList();
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(values);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var values = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajId).ToList();
            var gidenSayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;

            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            return View(values);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var mail = (string)Session["CariMail"];

            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;

            var gidenSayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;

            var degerler = c.Mesajlars.Where(x => x.MesajId == id).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var values = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            var gelenSayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;

            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar p)
        {
            var mail = (string)Session["CariMail"];
            p.Gönderici = mail;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Mesajlars.Add(p);
            c.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            var k = c.KargoDetays.Where(x => x.TakipKodu.Contains(p)).ToList();
            return View(k);
        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(x => x.Cariİd).FirstOrDefault();
            var cariBul = c.Carilers.Find(id);
            return PartialView("Partial1", cariBul);
        }

        public PartialViewResult Partial2()
        {
            var values = c.Mesajlars.Where(x => x.Gönderici == "Admin").ToList();
            return PartialView(values);
        }

        public ActionResult CariBilgiGüncelle(Cariler cariler)
        {
            var cari = c.Carilers.Find(cariler.Cariİd);
            cari.CariAdı = cariler.CariAdı;
            cari.CariSoyad = cariler.CariSoyad;
            cari.CariSifre = cariler.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}