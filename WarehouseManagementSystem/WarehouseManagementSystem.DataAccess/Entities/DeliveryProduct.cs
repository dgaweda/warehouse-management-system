using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class DeliveryProduct : ProductBase
    {
        public int? PalletId { get; set; }

        [Required]
        [Range(1, 999)]
        public int Amount { get; set; }

        public Pallet Pallet { get; set; }
        public List<Location> Locations { get; set; }

    }
}
