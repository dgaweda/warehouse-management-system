using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string CompanyName { get; set; }

    }
}
