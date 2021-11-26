using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class PalletLine 
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public Order Order { get; set; }
        public Departure Departure { get; set; }
        public Invoice Invoice { get; set; }
        public Employee Employee { get; set; }
        public int ProductAmount { get; set; }
    }
}
