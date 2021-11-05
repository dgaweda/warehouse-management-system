using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public string Provider { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceReceiptDate { get; set; }
        public string DeliveryName { get; set; }

    }
}
