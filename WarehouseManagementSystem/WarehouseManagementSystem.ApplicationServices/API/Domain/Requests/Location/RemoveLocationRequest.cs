using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class RemoveLocationRequest : RequestBase, IRequest<RemoveLocationResponse>
    {
        public override Guid Id { get; set; }
    }
}