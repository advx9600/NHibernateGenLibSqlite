using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateGenDbSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Domain.TbApps).Assembly);

            // Get ourselves an NHibernate Session
            var sessions = cfg.BuildSessionFactory();
            var sess = sessions.OpenSession();

            var tbConfig = new Domain.TbApps
            {
                name = "abcd"
            };
            // And save it to the database
            sess.Save(tbConfig);
            sess.Flush();
        }
    }
}
