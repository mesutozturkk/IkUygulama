using IkUygulama.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static IkUygulama.BL.BussinesManager;
using static IkUygulama.ENT.Entities;

namespace IkUygulama.Controllers
{
    public class BolumController : Controller
    {
        // GET: Bolum
        BolumManager manager = new BolumManager();
        public ActionResult Bolum()
        {
            BolumModel model= new BolumModel();
            model.list = manager.Liste();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(BolumModel model)
        {
            Bolum bolum = new Bolum();
            bolum.BolumAd = model.Bolum.BolumAd;
            manager.Ekle(bolum);
            manager.Save();
            return RedirectToAction("Bolum");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            BolumModel model = new BolumModel();
            model.Bolum = manager.Bul(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(BolumModel model, int id)
        {
            Bolum bolum = manager.Bul(id);
            bolum.BolumAd = model.Bolum.BolumAd;
            manager.Guncelle (bolum);
            manager.Save();
            return RedirectToAction("Bolum");
        }
        public ActionResult Sil(int id)
        {
           
            Bolum bolum = manager.Bul(id);
            manager.Sil(bolum);
            manager.Save();
            return RedirectToAction("Bolum");
        }
        public ActionResult Detay(int id,BolumModel model)
        {

            Bolum bolum = manager.Bul(id);
            model.Bolum = bolum;
            return View(model);
        }
    }
}