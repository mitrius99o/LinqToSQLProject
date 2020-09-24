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
    [Table(Name="Users")]//составляем атрибуты для отображения базы данных в сущности класса, в нашем случае "Users"
    public class User
    {
        private int id;
        [Column(IsPrimaryKey=true, Name ="id")]
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string userName;
        [Column(Name="Name")]
        public string Name
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        private int userAge;
        [Column(Name="Age")]
        public int Age
        {
            get
            {
                return this.userAge;
            }
            set
            {
                this.userAge = value;
            }
        }
    }
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

            //Выборка из всех Customers, которые находятся в Лондоне
            IQueryable<User> usersNick =
                from user in users
                where user.Name == "Николай"
                select user;

            //*---В ы п о л н е н и е   з а п р о с о в   L I N Q---*//

            //Вывод выбранной коллекции на экран
            foreach(User user in usersNick)
            {
                Console.WriteLine("ID={0}, City={1}", user.Name, user.Age);
            }

            Console.ReadKey();


        }
    }
}
