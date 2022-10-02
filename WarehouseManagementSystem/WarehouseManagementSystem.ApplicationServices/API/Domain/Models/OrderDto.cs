using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class OrderDto
    {
        public List<OrderLineDto> OrderRowsDto { get; set; }
        public string OrderState { get; set; }
        public string Barcode { get; set; }
        public DateTime? PickingStart { get; set; }
        public DateTime? PickingEnd { get; set; }
        public int LinesCount { get; set; }
    }
}
