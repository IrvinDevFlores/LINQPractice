using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1LinQ.DataContext
{
    public class Package
    {
        public int pack_id { get; set; }
        public string speed { get; set; }
        public DateTime strt_date { get; set; }
        public int monthly_payment { get; set; }
        public int sector_id { get; set; }
    }
}
