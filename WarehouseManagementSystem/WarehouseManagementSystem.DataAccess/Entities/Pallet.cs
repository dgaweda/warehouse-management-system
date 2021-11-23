using DataAccess.Entities.EntityBases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Pallet : EntityBase
    {
        [Required]
        [MaxLength(10)]
        public string Barcode { get; set; }
        public int? OrderId { get; set; }
        public int? DepartureId { get; set; }
        public int? InvoiceId { get; set; }
        public int? EmployeeId { get; set; }

        public Status PalletStatus { get; set; }

        [ForeignKey("DepartureId")]
        public Departure Departure { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice{ get; set; }

        public List<PalletLine> PalletsProducts { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }

    public enum Status
    {
        OPEN,                   // After pallet add (default), when pallet is unfolded (no products on pallet), when no Ids are filled
        DURING_ORDER_PICKING,   // when only OrderId and EmployeeId is filled and Order.State = In_Progress
        READY_FOR_DEPARTURE,    // when OrderID, EmployeeID and DepartureID is filled and order.State = Ready_fro_departure
        SENT,                   // when OrderID, EmployeeID and DepartureID is filled + DepartureState = CLOSED
        READY_TO_BE_UNFOLDED,   // when only InvoiceId is filled
    }
}
