using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class DeliveryProduct : ProductBase
    {
        public int PalletId { get; set; }
        public int Amount { get; set; }

        public Pallet Pallet { get; set; }
        public List<Location> Locations { get; set; }

    }
}
