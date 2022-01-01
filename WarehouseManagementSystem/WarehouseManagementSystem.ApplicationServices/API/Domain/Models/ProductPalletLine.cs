using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class ProductPalletLine 
    {
        public string PalletBarcode { get; set; }
        public string ProductName { get; set; }
        public int ProductAmount { get; set; }
        public string OrderBarcode { get; set; }
        public string DepartureName { get; set; }
        public string InvoiceNumber { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}
