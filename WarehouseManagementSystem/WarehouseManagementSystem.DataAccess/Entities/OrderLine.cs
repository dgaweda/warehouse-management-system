using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class OrderLine : EntityBase
    {
        public int MagazineProductId { get; set; }

        public int OrderId { get; set; }

        [Required]
        [Range(1, 999)]
        public int Amount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("MagazineProductId")]
        public MagazineProduct MagazineProduct { get; set; }
    }
}
