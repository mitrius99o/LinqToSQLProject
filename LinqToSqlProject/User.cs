using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlProject
{
    /*--Хранение таблиц в представлении сущностей классов--*/

    [Table(Name = "Users")]//составляем атрибуты для отображения базы данных в сущности класса, в нашем случае "Users"
    class User
    {
        [Column(IsPrimaryKey = true, Name = "id")]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Age")]
        public int Age { get; set; }
    }
}
