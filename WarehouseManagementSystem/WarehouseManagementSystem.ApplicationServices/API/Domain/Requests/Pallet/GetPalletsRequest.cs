using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetPalletsRequest : IRequest<GetPalletsResponse>
    {
        public DateTime PickingEnd { get; set; }
        public string Provider { get; set; }
        public string DeliveryName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string DepartureName { get; set; }
        public DateTime DepartureCloseTime { get; set; }
    }
}
