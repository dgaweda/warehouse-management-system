using DataAccess.Entities.EntityBases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Entities
{
    public class Location : IEntityBase
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }

        [Required]
        [Column("Typ lokalizacji")]
        public LocationType LocationType { get; set; }

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
}