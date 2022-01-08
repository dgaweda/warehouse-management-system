using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Location : IEntityBase
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }

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

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }

    public enum Type
    {
        NORMAL,
        SHORT_DATE,
        FRIDGE
    }
}