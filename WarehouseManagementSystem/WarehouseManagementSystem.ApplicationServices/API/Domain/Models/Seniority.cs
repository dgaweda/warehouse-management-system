using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Seniority
    {
        public DateTime EmploymentDate { get; set; }
        public DateTime EmploymentDuration { get; set; }
        public int EmployeeId { get; set; }
    }
}
