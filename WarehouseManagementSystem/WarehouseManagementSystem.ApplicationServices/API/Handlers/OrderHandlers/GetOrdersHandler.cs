using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.OrderQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Order;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.OrderHandlers
{
    public class GetOrdersHandler :
        QueryHandler<GetOrdersResponse, GetOrdersQuery, List<Order>, List<Domain.Models.OrderDto>>,
        IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        public GetOrdersHandler(IMapper mapper, IQueryExecutor queryExecutor)
            :base(mapper, queryExecutor)
        {
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
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
