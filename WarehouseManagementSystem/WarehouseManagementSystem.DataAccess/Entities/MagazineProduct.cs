using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MagazineProduct : ProductBase
    {
        public decimal UnitPrice { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public List<Location> Locations { get; set; }
    }
}
