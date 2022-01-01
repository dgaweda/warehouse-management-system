using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ProductPalletLine : EntityBase
    {
        public int ProductId { get; set; }
        public int PalletId { get; set; }

        public int ProductAmount { get; set; }

        [ForeignKey("PalletId")]
        public Pallet Pallet { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
