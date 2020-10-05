using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewWinForms
{
    [Table(Name ="Last_calls")]
    public class Call
    {
        [Column(Name ="Datetime")]
        public DateTime DateTime { get; set; }
        [Column(Name = "UserId")]
        public DateTime UserId { get; set; }

    }
}