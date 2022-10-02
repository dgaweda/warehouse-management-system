using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class EditLocationRequest : RequestBase, IRequest<EditLocationResponse>
    {
        public override Guid Id { get; set; }
        public int? MaxAmount { get; set; }
        public string Name { get; set; }
    }
}