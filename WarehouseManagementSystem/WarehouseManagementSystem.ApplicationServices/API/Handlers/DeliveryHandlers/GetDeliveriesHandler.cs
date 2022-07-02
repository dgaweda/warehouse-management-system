using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Query.Queries.DeliveryQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class GetDeliveriesHandler
        : QueryHandler<GetDeliveriesResponse, GetDeliveriesQuery, Delivery, Domain.Models.DeliveryDto>, 
            IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        public GetDeliveriesHandler(IMapper mapper, IQueryExecutor queryExecutor)
            : base(mapper, queryExecutor)
        {
        }

        public async Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetDeliveriesQuery()
            {
                Name = request.Name
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}