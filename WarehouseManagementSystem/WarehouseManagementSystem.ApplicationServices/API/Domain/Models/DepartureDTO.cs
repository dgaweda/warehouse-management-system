using System;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class DepartureDto
    {
        public DateTime OpeningTime { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime? CloseTime { get; set; }
    }
}
