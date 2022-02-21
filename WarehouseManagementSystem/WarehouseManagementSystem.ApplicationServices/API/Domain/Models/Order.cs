using System;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Order
    {
        public OrderState OrderState { get; set; }
        public string Barcode { get; set; }
        public DateTime? PickingStart { get; set; }
        public DateTime? PickingEnd { get; set; }
        public int LinesCount { get; set; }
    }
}
