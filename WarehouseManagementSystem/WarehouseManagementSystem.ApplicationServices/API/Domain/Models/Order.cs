using DataAccess.Entities;
using System;

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
