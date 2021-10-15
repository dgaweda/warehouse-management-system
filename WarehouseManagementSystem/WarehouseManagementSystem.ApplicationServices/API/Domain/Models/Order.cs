using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Order
    {
        public State State { get; set; }
        public string Barcode { get; set; }
        public DateTime? PickingStart { get; set; }
        public DateTime? PickingEnd { get; set; }
    }
}
