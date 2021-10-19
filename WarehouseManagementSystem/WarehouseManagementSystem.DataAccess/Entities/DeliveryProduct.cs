using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class DeliveryProduct : ProductBase
    {
        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }
        public int PalletId { get; set; }
        public List<Location> Locations { get; set; }
        public Pallet Pallet { get; set; }
    }
}
