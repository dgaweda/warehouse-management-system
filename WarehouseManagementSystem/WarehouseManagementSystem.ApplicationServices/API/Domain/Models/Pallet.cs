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
        public Order Order{ get; set; }
        public Departure Departure { get; set; }
        public Delivery Delivery { get; set; }
        public Employee Employee { get; set; }
        public string PalletStatus { get; set; }
    }
}
