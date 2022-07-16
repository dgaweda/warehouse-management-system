using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class SetProductLocationRequest : RequestBase, IRequest<SetProductLocationResponse>
    {
        public Guid LocationId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }
}