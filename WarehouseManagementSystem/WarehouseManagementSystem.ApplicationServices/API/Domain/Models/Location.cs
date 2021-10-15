using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Location
    {
        public DataAccess.Entities.Type Type { get; set; }
        public string Name { get; set; }
        public int CurrentAmount { get; set; }
        public int MaxAmount { get; set; }
    }
}
