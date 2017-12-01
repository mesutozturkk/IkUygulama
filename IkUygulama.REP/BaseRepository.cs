using IkUygulama.DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkUygulama.REP
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        IkContext db = DbSingleTone.GetInstance();
        public T Bul(int id)
        {
            return Set().Find(id);
            //return db.Set<T>().Find(id);
        }

        public void Ekle(T Entity)
        {
            db.Entry(Entity).State = EntityState.Added;
        }

        public IQueryable<T> GenelListe()
        {
            return Set().AsQueryable();
        }

        public void Guncelle(T Entity)
        {
            db.Entry(Entity).State = EntityState.Modified;
        }

        public List<T> Liste()
        {
            return Set().ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public DbSet<T> Set()
        {
            return db.Set<T>();
        }

        public void Sil(T Entity)
        {
            db.Entry(Entity).State = EntityState.Deleted;
        }
    }
}
