using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManage.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int ShipVia { get; set; }
        //public string ShippedDate { get; set; }
        //public string OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
    }
}
