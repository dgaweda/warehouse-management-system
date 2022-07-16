using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class AddLocationRequest : RequestBase, IRequest<AddLocationResponse>
    {
        public Guid? ProductId { get; set; }
        public LocationType LocationType { get; set; }
        public string Name { get; set; }
        public int MaxAmount { get; set; }
    }
}