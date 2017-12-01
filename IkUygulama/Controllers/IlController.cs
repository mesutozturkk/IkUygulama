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
    public class IlController : Controller
    {
        // GET: Il
        IlManager manager = new IlManager();
        public ActionResult Il()
        {
            IlModel model = new IlModel();
            model.list = manager.Liste();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(IlModel model)
        {
            Il il = new Il();
           
            il.IlAd = model.Il.IlAd;
            manager.Ekle(il);
            manager.Save();
            return RedirectToAction("Il");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            IlModel model = new IlModel();
            model.Il = manager.Bul(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(IlModel model, int id)
        {
            Il il = manager.Bul(id);
            il.IlAd = model.Il.IlAd;
            manager.Guncelle(il);
            manager.Save();
            return RedirectToAction("Il");
        }
        public ActionResult Sil(int id)
        {

            Il il = manager.Bul(id);
            manager.Sil(il);
            manager.Save();
            return RedirectToAction("Il");
        }
        public ActionResult Detay(int id, IlModel model)
        {

            Il il = manager.Bul(id);
            model.Il = il;
            return View(model);
        }
    }
}