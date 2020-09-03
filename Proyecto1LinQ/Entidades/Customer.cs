using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1LinQ.DataContext
{
    public class Customer
    {
        public int Customer_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Birth_Date { get; set; }
        public DateTime Join_Date { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string main_phone_num { get; set; }
        public string secondary_phone_num { get; set; }
        public string fax { get; set; }
        public Decimal monthly_discount { get; set; }
        public int pack_id { get; set; }
    }
}
