using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MagazineProduct : ProductBase
    {
        [DataType(DataType.Currency)]
        [Range(0.1, 999)]
        public decimal UnitPrice { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public List<Location> Locations { get; set; }
    }
}
