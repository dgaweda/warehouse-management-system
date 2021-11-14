using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetPalletsRequest : IRequest<GetPalletsResponse>
    {
        public DateTime PickingEnd { get; set; }
        public string Provider { get; set; }
        public string DeliveryName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public string DepartureName { get; set; }
        public DateTime DepartureCloseTime { get; set; }
    }
}
