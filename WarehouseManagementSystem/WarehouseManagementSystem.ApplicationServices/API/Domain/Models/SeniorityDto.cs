using System;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class SeniorityDto
    {
        public DateTime EmploymentDate { get; set; }
        public string EmploymentDuration { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
