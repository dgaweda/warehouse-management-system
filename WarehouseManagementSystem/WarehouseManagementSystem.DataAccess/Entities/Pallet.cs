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
        public int? DeliveryId { get; set; }
        public int? EmployeeId { get; set; }

        [ForeignKey("DepartureId")]
        public Departure Departure { get; set; }

        [ForeignKey("DeliveryId")]
        public Delivery Delivery { get; set; }

        public List<DeliveryProductPalletLine> DeliveryProductPalletLines { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
