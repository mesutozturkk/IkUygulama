using IkUygulama.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static IkUygulama.ENT.Entities;

namespace IkUygulama.Models.Views
{

    public class PersonelModel
    {
        public IEnumerable<PersonelDTO> list { get; set; }
        public Personel Personel { get; set; }
        public List<SelectListItem> IlForDropDown { get; set; }
        public List<SelectListItem> IlceForDropDown { get; set; }
        public List<SelectListItem> UnvanForDropDown { get; set; }
        public List<SelectListItem> EgitimForDropDown { get; set; }
        public List<SelectListItem> BolumForDropDown { get; set; }
    }

}