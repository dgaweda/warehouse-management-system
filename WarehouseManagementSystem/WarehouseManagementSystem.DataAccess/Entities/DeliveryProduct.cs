using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class DeliveryProduct : ProductBase
    {
        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }
        public List<Location> Locations { get; set; }

        public List<DeliveryProductPalletLine> DeliveryProductPalletLines { get; set; }
    }
}
