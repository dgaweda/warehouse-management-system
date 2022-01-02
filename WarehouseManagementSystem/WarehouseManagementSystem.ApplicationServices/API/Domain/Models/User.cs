using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
    }
}
