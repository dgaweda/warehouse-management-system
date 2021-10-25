using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class DeliveryProductPalletLine : EntityBase
    {
        public int DeliveryProductId { get; set; }
        public int PalletId { get; set; }

        [ForeignKey("PalletId")]
        public Pallet Pallet { get; set; }

        [ForeignKey("DeliveryProductId")]
        public DeliveryProduct DeliveryProduct { get; set; }
    }
}
