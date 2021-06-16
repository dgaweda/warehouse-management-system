using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Location : EntityBase
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int MaxAmount { get; set; }
        public bool Special { get; set; }

        public MagazineProduct MagazineProduct { get; set; }
        public DeliveryProduct DeliveryProduct { get; set; }

    }
}