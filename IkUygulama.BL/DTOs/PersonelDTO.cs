using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkUygulama.BL.DTOs
{
    public class PersonelDTO
    {
        public int PersonelID { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public int EgitimID { get; set; }
        public int UnvanID { get; set; }
        public int IlID { get; set; }
        public int IlceID { get; set; }
        public int BolumID { get; set; }
        public int? YoneticiID { get; set; }
        public string Unvan { get; set; }
    }
}