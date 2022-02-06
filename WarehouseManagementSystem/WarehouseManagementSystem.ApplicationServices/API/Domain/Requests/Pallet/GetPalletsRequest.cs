using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet
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