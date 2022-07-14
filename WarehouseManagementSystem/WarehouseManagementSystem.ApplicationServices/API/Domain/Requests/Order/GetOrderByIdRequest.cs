using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order
{
    public class GetOrderByIdRequest : RequestBase, IRequest<GetOrderByIdResponse>
    {
        public override Guid Id { get; set; }
    }
}