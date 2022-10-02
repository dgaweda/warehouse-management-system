using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class GetLocationByIdRequest : RequestBase, IRequest<GetLocationByIdResponse>
    {
        public override Guid Id { get; set; }
    }
}