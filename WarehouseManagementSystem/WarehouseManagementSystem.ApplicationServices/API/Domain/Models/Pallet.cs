using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Pallet
    {
        public string Barcode { get; set; }
        public int? OrderId { get; set; }
        public int? DepartureId { get; set; }
        public int? DeliveryId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
