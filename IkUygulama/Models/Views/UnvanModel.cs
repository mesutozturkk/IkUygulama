using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IkUygulama.ENT.Entities;

namespace IkUygulama.Models.Views
{
    public class UnvanModel
    {
        public IEnumerable<Unvan> list { get; set; }
        public Unvan Unvan { get; set; }
        //
    }
}