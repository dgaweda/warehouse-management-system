using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Enums.RoleEnum.Roles RoleId { get; set; }
        public string RoleName { get; set; }
        public string EmploymentDuration { get; set; }

    }
}
