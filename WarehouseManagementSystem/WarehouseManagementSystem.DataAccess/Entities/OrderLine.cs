using DataAccess.Entities.EntityBases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class OrderLine : EntityBase
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        [Required]
        [Range(1, 999)]
        [Column("Ilość")]
        public int Amount { get; set; }

        [DataType(DataType.Currency)]
        [Column("Cena", TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
