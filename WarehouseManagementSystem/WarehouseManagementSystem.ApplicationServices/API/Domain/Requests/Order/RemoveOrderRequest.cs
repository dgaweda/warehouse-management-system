using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class RemoveOrderRequest: RequestBase, IRequest<RemoveOrderResponse>
    {
        public override Guid Id { get; set; }
    }
}