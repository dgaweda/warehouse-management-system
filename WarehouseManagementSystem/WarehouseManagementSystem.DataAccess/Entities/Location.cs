using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Location : EntityBase
    {
        public int? DeliveryProductId { get; set; }
        public int? MagazineProductId { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(7)]
        public string Name { get; set; }

        [Required]
        [Range(1, 999)]
        public int CurrentAmount { get; set; }

        [Required]
        [Range(1, 999)]
        public int MaxAmount { get; set; }

        [ForeignKey("DeliveryProductId")]
        public DeliveryProduct DeliveryProduct { get; set; }

        [ForeignKey("MagazineProductId")]
        public MagazineProduct MagazineProduct { get; set; }

    }

    public enum Type
    {
        NORMAL,
        SHORT_DATE,
        FRIDGE
    }
}