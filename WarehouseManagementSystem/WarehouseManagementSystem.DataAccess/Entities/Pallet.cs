using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Enums;

namespace DataAccess.Entities
{
    public class Pallet : EntityBase.EntityBase
    {
        [Required]
        [MaxLength(10)]
        public string Barcode { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? DepartureId { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? UserId { get; set; }

        public PalletStatus PalletStatus { get; set; }

        [ForeignKey("DepartureId")]
        public Departure Departure { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice{ get; set; }

        public List<PalletRow> PalletsProducts { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
