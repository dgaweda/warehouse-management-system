using DataAccess.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Departure Departure { get; set; }
        public Delivery Delivery { get; set; }
        public List<DeliveryProduct> Products { get; set; }

    }
}
