using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkUygulama.REP
{
   public interface IRepository<T> where T:class,new()
    {
        DbSet<T> Set();
        void Sil(T Entity);
        void Ekle(T Entity);
        T Bul(int id);
        void Guncelle(T Entity);
        void Save();
        List<T> Liste();
        IQueryable<T> GenelListe();
    }
}
