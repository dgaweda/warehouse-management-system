using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.OrderQueries;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderHandlers
{
    public class GetOrdersHandler :
        QueryManager<List<Order>, List<OrderDto>>,
        IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrdersHandler(IMapper mapper, IOrderRepository orderRepository)
            :base(mapper)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetOrdersQuery(_orderRepository).Execute();
            var response = await CreateResponse<GetOrdersResponse>(queryResult);
            return response;
        }
    }
}
