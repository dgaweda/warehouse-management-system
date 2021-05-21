using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagemnetSystem.DataAccess.Entities
{
    public class Product : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}