using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Invoice : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Provider { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime ReceiptDateTime { get; set; }
        
        public Guid? DeliveryId { get; set; }

        public Delivery Delivery { get; set; }
        public List<Pallet> Pallets { get; set; }
    }
}
