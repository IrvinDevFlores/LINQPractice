using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1LinQ.DataContext
{
    public class PackGrade
    {
        public int grade_id { get; set; }
        public string grade_name { get; set; }
        public int min_price { get; set; }
        public int max_price { get; set; }
    }
}
