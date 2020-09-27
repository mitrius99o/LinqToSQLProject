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
            // = new DataContext(@"Data Source=DESKTOP-IL0K9BD\SQLEXPRESS;Initial Catalog=phonesdb;User ID=sa;Password=sa");
        public void SetDbContext(string connString)
        {
            db = new DataContext(connString);
        }

        public IQueryable<User> GetUsers()
        {
            return db.GetTable<User>();
        }
    }
}
