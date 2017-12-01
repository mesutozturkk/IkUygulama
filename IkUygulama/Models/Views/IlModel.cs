using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IkUygulama.ENT.Entities;

namespace IkUygulama.Models.Views
{
    public class IlModel
    {
        public IEnumerable<Il> list { get; set; }
        public Il Il { get; set; }
        
    }
}