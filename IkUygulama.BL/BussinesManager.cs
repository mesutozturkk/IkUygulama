using IkUygulama.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IkUygulama.REP.Repositories;

namespace IkUygulama.BL
{
    public class BussinesManager
    {
        public class PersonelManager : PersonelRepositories
        {
            public List<PersonelDTO> PersonelListe()
            {
                return GenelListe().Select(x => new PersonelDTO {
                    BolumID =x.BolumId,
                    UnvanID=x.UnvanId,
                    EgitimID=x.EgitimId,
                    YoneticiID=(int)x.YoneticiId,
                    PersonelID=x.PersonelId,
                    PersonelAd=x.PersonelAd,
                    PersonelSoyad=x.PersonelSoyad,
                    IlceID=x.IlceId,
                    IlID=x.Ilce.IlId,
                    Unvan=x.Unvan.UnvanAd
                }).ToList();
            }
        }
        public class BolumManager : BolumRepositories { }
        public class EgitimManager : EgitimRepositories { }
        public class UnvanManager : UnvanRepositories { }
        public class IlManager : IlRepositories { }
        public class IlceManager : IlceRepositories { }
    }
}
