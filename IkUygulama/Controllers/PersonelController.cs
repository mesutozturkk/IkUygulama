using IkUygulama.Models;
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
    public class PersonelController : Controller
    {
        // GET: Personel
        PersonelManager perManager = new PersonelManager();
        UnvanManager unManager = new UnvanManager();
        EgitimManager egManager = new EgitimManager();
        IlManager ilManager = new IlManager();
        BolumManager bolumManager = new BolumManager();
        IlceManager ilceManager = new IlceManager();

        public ActionResult Personel()
        {
            PersonelModel model = new PersonelModel();
            model.list = perManager.PersonelListe();
            return View(model);
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            PersonelModel model = new PersonelModel();
            model.Personel = perManager.Bul(id);
            DropDownDoldur(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(PersonelModel model, int id)
        {
            Personel personel = perManager.Bul(id);
            personel.PersonelAd = model.Personel.PersonelAd;
            personel.PersonelSoyad = model.Personel.PersonelSoyad;
            personel.Maas = model.Personel.Maas;
            personel.UnvanId = model.Personel.UnvanId;
            personel.BolumId = model.Personel.BolumId;
            personel.DogumTarihi = model.Personel.DogumTarihi;
            personel.Email = model.Personel.Email;
            personel.TelNo = model.Personel.TelNo;
            personel.EgitimId = model.Personel.EgitimId;
            personel.Ilce.IlId = model.Personel.Ilce.IlId;
            personel.IlceId = model.Personel.IlceId;
            perManager.Guncelle(personel);
            perManager.Save();
            return RedirectToAction("Personel");
        }
        public string TarihAl()
        {
            return DateTime.Now.ToLongDateString();
        }
        public void DropDownDoldur(PersonelModel model)
        {
            model.BolumForDropDown = bolumManager.Set().Select(x => new SelectListItem()
            {
                Text = x.BolumAd,
                Value = x.BolumId.ToString()
            }).ToList();
            model.EgitimForDropDown = egManager.Set().Select(x => new SelectListItem()
            {
                Text = x.EgitimAd,
                Value = x.EgitimId.ToString()
            }).ToList();
            model.UnvanForDropDown = unManager.Set().Select(x => new SelectListItem()
            {
                Text = x.UnvanAd,
                Value = x.UnvanId.ToString()
            }).ToList();
            model.IlceForDropDown = ilceManager.Set().Select(x => new SelectListItem()
            {
                Text = x.IlceAd,
                Value = x.IlceId.ToString()
            }).ToList();
            model.IlForDropDown = ilManager.Set().Select(x => new SelectListItem()
            {
                Text = x.IlAd,
                Value = x.IlId.ToString()
            }).ToList();
        }
        public PartialViewResult GetIlceler(int id)
        {
            IlceModel model = new IlceModel();
            model.list = ilceManager.GenelListe().Where(x => x.IlId == id).ToList();
            return PartialView("IlcelerPartial", model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            PersonelModel model = new PersonelModel();
            DropDownDoldur(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Ekle(PersonelModel model)
        {
            Personel personel = new Personel();
            personel.PersonelAd = model.Personel.PersonelAd;
            personel.PersonelSoyad= model.Personel.PersonelSoyad;
            personel.Maas= model.Personel.Maas;
            personel.Email = model.Personel.Email;
            personel.TelNo= model.Personel.TelNo;
            personel.UnvanId= model.Personel.UnvanId;
            personel.BolumId= model.Personel.BolumId;
            personel.DogumTarihi= model.Personel.DogumTarihi;
            personel.EgitimId = model.Personel.EgitimId;
            personel.IlceId= model.Personel.IlceId;
            //personel.Ilce.Ilid = model.Personel.Ilce.Ilid;
           perManager.Ekle(personel);
            perManager.Save();
            return RedirectToAction("Personel");

        }
       
        public ActionResult Sil(int id)
        {
            Personel personel = perManager.Bul(id);
            perManager.Sil(personel);
            perManager.Save();
            return RedirectToAction("Personel");
        }
        public ActionResult Detay(int id , PersonelModel model)
        {
            Personel personel = perManager.Bul(id);
            model.Personel = personel;
            return View(model);
        }

    }

}