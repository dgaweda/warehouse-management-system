using DataAccess.Entities.EntityBases;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Entities
{
    public class Pallet : EntityBase
    {
        [Required]
        [MaxLength(10)]
        [Column("Kod kreskowy")]
        public string Barcode { get; set; }
        public int? OrderId { get; set; }
        public int? DepartureId { get; set; }
        public int? InvoiceId { get; set; }
        public int? UserId { get; set; }

        [Column("Aktualny status palety")]
        public PalletEnum.Status PalletStatus { get; set; }

        [ForeignKey("DepartureId")]
        public Departure Departure { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice{ get; set; }

        public List<ProductPalletLine> PalletsProducts { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
