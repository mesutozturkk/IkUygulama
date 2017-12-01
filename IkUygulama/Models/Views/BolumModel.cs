using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IkUygulama.ENT.Entities;

namespace IkUygulama.Models.Views
{
    public class BolumModel
    {
        public IEnumerable<Bolum> list { get; set; }
        public Bolum Bolum { get; set; }
    }
}