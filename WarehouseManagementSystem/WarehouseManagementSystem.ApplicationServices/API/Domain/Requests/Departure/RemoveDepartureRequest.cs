using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class RemoveDepartureRequest : RequestBase, IRequest<RemoveDepartureResponse>
    {
        public override Guid Id { get; set; }
    }
}
