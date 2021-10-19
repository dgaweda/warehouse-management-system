using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class OrderLine : EntityBase
    {
        public int MagazineProductId { get; set; }

        public int OrderId { get; set; }

        [Required]
        [Range(1, 999)]
        public int Amount { get; set; }

        public Order Order { get; set; }
        public MagazineProduct MagazineProduct { get; set; }
    }
}
