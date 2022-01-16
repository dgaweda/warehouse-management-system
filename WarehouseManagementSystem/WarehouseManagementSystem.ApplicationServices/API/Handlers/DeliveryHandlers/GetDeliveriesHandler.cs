using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DeliveryQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
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
            if (request.UserIsPermitted(nameof(GetDeliveriesRequest)))
            {
                var query = CreateQuery(request);
                var response = await PrepareResponse(query);
                return response;
            }

            return new GetDeliveriesResponse()
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }

        public override GetDeliveriesQuery CreateQuery(GetDeliveriesRequest request)
        {
            return new GetDeliveriesQuery()
            {
                Name = request.Name
            };
        }
    }
}
