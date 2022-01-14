using DataAccess.Entities.EntityBases;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Location : IEntityBase
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }

        [Required]
        [Column("Typ lokalizacji")]
        public Type Type { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(7)]
        [Column("Nazwa lokalizacji")]
        public string Name { get; set; }

        [Required]
        [Range(1, 999)]
        [Column("Aktualna ilość")]
        public int CurrentAmount { get; set; }

        [Required]
        [Range(1, 999)]
        [Column("Maksymalna ilość")]
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