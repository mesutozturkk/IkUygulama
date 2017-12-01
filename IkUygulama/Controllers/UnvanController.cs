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
    public class UnvanController : Controller
    {
        // GET: Unvan
         UnvanManager manager = new UnvanManager();
        public ActionResult Unvan()
        {
            UnvanModel model = new UnvanModel();
            model.list = manager.Liste();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(UnvanModel model)
        {
            Unvan unvan = new Unvan();
            unvan.UnvanAd = model.Unvan.UnvanAd;
            manager.Ekle(unvan);
            manager.Save();
            return RedirectToAction("Unvan");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            UnvanModel model = new UnvanModel();
            model.Unvan = manager.Bul(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(UnvanModel model, int id)
        {
            Unvan unvan = manager.Bul(id);
            unvan.UnvanAd = model.Unvan.UnvanAd;
            manager.Guncelle(unvan);
            manager.Save();
            return RedirectToAction("Unvan");
        }
        public ActionResult Sil(int id)
        {

            Unvan unvan = manager.Bul(id);
            manager.Sil(unvan);
            manager.Save();
            return RedirectToAction("Unvan");
        }
        public ActionResult Detay(int id, UnvanModel model)
        {

            Unvan unvan = manager.Bul(id);
            model.Unvan = unvan;
            return View(model);
        }
    }
}