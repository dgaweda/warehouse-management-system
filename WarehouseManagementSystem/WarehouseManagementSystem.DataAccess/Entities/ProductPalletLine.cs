using System;
using DataAccess.Entities.EntityBases;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class ProductPalletLine : EntityBase
    {
        public Guid ProductId { get; set; }
        public Guid PalletId { get; set; }

        [Column("Ilość danego produktu na palecie")]
        public int ProductAmount { get; set; }

        [ForeignKey("PalletId")]
        public Pallet Pallet { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
