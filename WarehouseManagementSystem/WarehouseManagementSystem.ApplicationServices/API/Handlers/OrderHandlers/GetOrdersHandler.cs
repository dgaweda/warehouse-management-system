using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.Queries.OrderQueries;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderHandlers
{
    public class GetOrdersHandler :
        QueryHandler<GetOrderByIdResponse, GetOrdersQuery, Order, Domain.Models.OrderDto, IOrderRepository>,
        IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
    {
        public GetOrdersHandler(IMapper mapper, IQueryExecutor<IOrderRepository> queryExecutor, IOrderRepository orderRepository)
            :base(mapper, queryExecutor, orderRepository)
        {
        }

        public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrdersQuery()
            {
                Id = request.Id
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
