using IkUygulama.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkUygulama.REP
{
    static public class DbSingleTone
    {
       private static IkContext db;
        public static IkContext GetInstance()
        {
            if (db == null)
            {
                db = new IkContext();
            }
            return db;
        }
    }
}
