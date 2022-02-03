using System;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Seniority
    {
        public DateTime EmploymentDate { get; set; }
        public string EmploymentDuration { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
