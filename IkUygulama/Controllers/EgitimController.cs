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
    public class EgitimController : Controller
    {
        // GET: Egitim
        EgitimManager manager = new EgitimManager();
        public ActionResult Egitim()
        {
            EgitimModel model = new EgitimModel();
            model.list = manager.Liste();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(EgitimModel model)
        {
            Egitim egitim = new Egitim();
            egitim.EgitimAd = model.Egitim.EgitimAd;
            manager.Ekle(egitim);
            manager.Save();
            return RedirectToAction("Egitim");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            EgitimModel model = new EgitimModel();
            model.Egitim = manager.Bul(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(EgitimModel model, int id)
        {
            Egitim egitim = manager.Bul(id);
            egitim.EgitimAd = model.Egitim.EgitimAd;
            manager.Guncelle(egitim);
            manager.Save();
            return RedirectToAction("Egitim");
        }
        public ActionResult Sil(int id)
        {

            Egitim egitim = manager.Bul(id);
            manager.Sil(egitim);
            manager.Save();
            return RedirectToAction("Egitim");
        }
        public ActionResult Detay(int id, EgitimModel model)
        {

            Egitim egitim = manager.Bul(id);
            model.Egitim = egitim;
            return View(model);
        }
    }
}