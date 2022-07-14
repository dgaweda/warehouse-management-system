using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class EditLocationCurrentAmountRequest : RequestBase, IRequest<EditLocationCurrentAmountResponse>
    {
        public override Guid Id { get; set; }
        public int CurrentAmount { get; set; }
    }
}