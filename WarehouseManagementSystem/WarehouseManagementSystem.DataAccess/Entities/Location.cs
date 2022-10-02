using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enums;

namespace DataAccess.Entities
{
    public class Location : EntityBase.EntityBase
    {
        public Guid? ProductId { get; set; }

        [Required]
        public LocationType LocationType { get; set; }

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

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}