using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DeliveryQueries;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Deliveries
{
    public class GetDeliveriesHandler 
        : QueryHandler<GetDeliveriesRequest, GetDeliveriesResponse, GetDeliveriesQuery, List<Delivery>, List<Domain.Models.Delivery>>, 
        IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {      
        public GetDeliveriesHandler(IMapper mapper, IQueryExecutor queryExecutor) 
            : base(mapper, queryExecutor)
        {
        }

        public async Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            return await Response(query);
        }

        public override GetDeliveriesQuery CreateQuery(GetDeliveriesRequest request)
        {
            var data = new GetDeliveriesHelper()
            {
                Name = request.Name
            };
            return new GetDeliveriesQuery(data);
        }
    }
}
