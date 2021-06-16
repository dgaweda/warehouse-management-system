using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OrderLine : EntityBase
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public MagazineProduct MagazineProduct { get; set; }
    }
}
