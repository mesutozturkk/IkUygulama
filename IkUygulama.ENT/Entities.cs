using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkUygulama.ENT
{
   public class Entities
    {
        [Table("Personel")]
        public class Personel
        {
            public int PersonelId { get; set; }
            [Required(ErrorMessage ="Personel Ad Boş Olmaz"),DisplayName("Personel Adı")]
            public string PersonelAd { get; set; }
            [Required(ErrorMessage = "Personel Soyad Boş Olmaz"), DisplayName("Personel Soyadı")]
            public string PersonelSoyad { get; set; }
            [Required(ErrorMessage = "Maaş Ad Boş Olmaz"), Range(5000,35000,ErrorMessage ="Maaş en az 5000 en fazla 35000 olmalıdır.")]
            public decimal Maas { get; set; }
            [Required(ErrorMessage ="Email boş olamaz"),DataType(DataType.EmailAddress,ErrorMessage ="Mail formatını yanlış girdiniz.")]
            public string Email { get; set; }
            public int TelNo { get; set; }
            [DataType(DataType.Date), DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
            public DateTime DogumTarihi { get; set; }
            public int IlceId { get; set; }
            public int BolumId { get; set; }
            public int UnvanId { get; set; }
            public int EgitimId { get; set; }
            public int? YoneticiId { get; set; }
            public bool YoneticiMi { get; set; }
            [ForeignKey("YoneticiId")]
            public virtual Personel Yonetici { get; set; }
            public virtual ICollection<Personel> Eleman { get; set; }
            [ForeignKey("BolumId")]
            public virtual Bolum Bolum { get; set; }
            [ForeignKey("UnvanId")]
            public virtual Unvan Unvan { get; set; }
            [ForeignKey("EgitimId")]
            public virtual Egitim Egitim { get; set; }
            [ForeignKey("IlceId")]
            public virtual Ilce Ilce { get; set; }

        }
        [Table("Bolum")]
        public class Bolum
        {
            public Bolum()
            {
                this.Personel = new HashSet<Personel>();
            }
            public int BolumId { get; set; }
            public string BolumAd { get; set; }
            public virtual ICollection<Personel> Personel { get; set; }
        }
        [Table("Unvan")]
        public class Unvan
        {
            public Unvan()
            {
                this.Personel = new HashSet<Personel>();
            }
            public int UnvanId { get; set; }
            public string UnvanAd { get; set; }
            public virtual ICollection<Personel> Personel { get; set; }
        }
        [Table("Egitim")]
        public class Egitim
        {
            public Egitim()
            {
                this.Personel = new HashSet<Personel>();
            }
            public int EgitimId { get; set; }
            public string EgitimAd { get; set; }
            public virtual ICollection<Personel> Personel { get; set; }
        }
        [Table("Ilce")]
        public class Ilce
        {
            public Ilce()
            {
                this.Personel = new HashSet<Personel>();
            }
            public int IlceId { get; set; }
            public string IlceAd { get; set; }
            public int IlId { get; set; }
            public virtual ICollection<Personel> Personel { get; set; }
            public virtual Il Il { get; set; }

        }
        [Table("Il")]
        public class Il
        {
            public Il()
            {
                this.Ilce = new HashSet<Ilce>();

            }
            public int IlId { get; set; }
            public string IlAd { get; set; }
            public virtual ICollection<Ilce> Ilce { get; set; }
        }
    }
}
