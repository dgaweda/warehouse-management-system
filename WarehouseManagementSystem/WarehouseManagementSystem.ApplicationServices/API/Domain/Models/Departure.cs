using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Departure
    {
        public DateTime OpeningTime { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
