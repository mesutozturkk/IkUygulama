using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IkUygulama.ENT.Entities;

namespace IkUygulama.Models.Views
{
    public class EgitimModel
    {
        public IEnumerable<Egitim> list { get; set; }
        public Egitim Egitim { get; set; }
    }
}