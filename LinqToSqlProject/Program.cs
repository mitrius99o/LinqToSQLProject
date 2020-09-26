using System;
using System.Collections.Generic;
using System.Data.Linq;               //нужные библиотеки 
using System.Data.Linq.Mapping;       //для работы с LinqToSql
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;     

namespace LinqToSqlProject
{
    class Program 
    {
        static void Main(string[] args)
        {
            //Подключение к базе данных
            DataContext db = new DataContext(@"Data Source=DESKTOP-IL0K9BD\SQLEXPRESS;Initial Catalog=phonesdb;User ID=sa;Password=sa");
            
            //Получить таблицу из бд
            IQueryable<User> users = db.GetTable<User>();

            //Прикрепить лог-файл для отображения сгенерированного SQL
            db.Log = Console.Out;

            //*---C о з д а н и е   з а п р о с о в   L I N Q---*//

            //Выборка 1
            IQueryable<User> usersAndrew =
                from user in users
                where user.Name == "Андрей"
                select user;

            //Выборка 2
            var users20Plus = users.Where(x => x.Age >= 20);

            //Выборка 3 - пересечение коллекций usersAndrew и users20Plus
            var rezult = users20Plus.Intersect<User>(usersAndrew);
            

            //*---В ы п о л н е н и е   з а п р о с о в   L I N Q---*//

            //Вывод выбранной коллекции на экран
            foreach(User user in usersAndrew)
            {
                Console.WriteLine("Name={0}, Age={1}", user.Name, user.Age);
            }
            Console.ReadLine();

            foreach(User user in rezult)
            {
                Console.WriteLine("Name={0}, Age={1}", user.Name, user.Age);
            }

            Console.ReadKey();


        }
    }
}
