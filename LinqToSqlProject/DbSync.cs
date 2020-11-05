using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlProject
{
    public class DbSync
    {
        public static DataContext db;

        //---Коллекции, в которых будут храниться выборки---//
        public IQueryable<User> selectedGroup1;
        public static void SetDbContext(string connString)
        {
            db = new DataContext(connString);
        }
    }
}
