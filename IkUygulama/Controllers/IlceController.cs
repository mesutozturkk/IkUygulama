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
    public class IlceController : Controller
    {
        // GET: Ilce
        IlManager manager = new IlManager();
        IlceManager manager2 = new IlceManager();
        public ActionResult Ilce()
        {
            IlceModel model = new IlceModel();
            model.list = manager2.Liste();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            //Dropdown içim aşağıdaki kodları yazmamız gerekir
            IlceModel m = new IlceModel();
            m.ilForDropdown = DropDownDoldurIl();
            return View(m);
        }

        private List<SelectListItem> DropDownDoldurIl()
        {
            return manager.Set().Select(x => new SelectListItem()
            {
                Text = x.IlAd,
                Value = x.IlId.ToString()
            }).ToList();
        }

        [HttpPost]
        public ActionResult Ekle(IlceModel model)
        {
            Ilce ilce = new Ilce();
            ilce.IlceAd = model.Ilce.IlceAd;
            ilce.IlId = model.Ilce.IlId;
            manager2.Ekle(ilce);
            manager2.Save();
            return RedirectToAction("Ilce");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            IlceModel model = new IlceModel();
            model.Ilce = manager2.Bul(id);
            model.ilForDropdown = DropDownDoldurIl();
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(IlceModel model, int id)
        {
            Ilce ilce = manager2.Bul(id);
            ilce.IlceAd = model.Ilce.IlceAd;
            ilce.IlId = model.Ilce.IlId;
            manager2.Guncelle(ilce);
            manager2.Save();
            return RedirectToAction("Ilce");
        }
        public ActionResult Sil(int id)
        {

            Ilce ilce = manager2.Bul(id);
            manager2.Sil(ilce);
            manager2.Save();
            return RedirectToAction("Ilce");
        }
        public ActionResult Detay(int id, IlceModel model)
        {

            Ilce ilce = manager2.Bul(id);
            model.Ilce = ilce;
            return View(model);
        }
    }
}