using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static IkUygulama.ENT.Entities;

namespace IkUygulama.Models.Views
{
    public class IlceModel
    {
        public IEnumerable<Ilce> list { get; set; }
        public Ilce Ilce { get; set; }
        //Dropdownda göstermek için selectlistitem tanımladık
        public List<SelectListItem> ilForDropdown { get; set; }
    }
}