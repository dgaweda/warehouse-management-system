using DataAccess.Entities.EntityBases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class MagazineProduct : ProductBase
    {
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal UnitPrice { get; set; }

        public List<OrderLine> OrderLines { get; set; }
        public List<Location> Locations { get; set; }
    }
}
