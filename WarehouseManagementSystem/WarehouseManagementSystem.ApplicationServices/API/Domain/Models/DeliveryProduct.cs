using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class DeliveryProduct
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        public string Barcode { get; set; }
        public Pallet Pallet { get; set; }
    }
}
