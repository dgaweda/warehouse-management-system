using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DeliveryQueries;
using DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class GetDeliveriesHandler 
        : QueryHandler<GetDeliveriesRequest, GetDeliveriesResponse, GetDeliveriesQuery, List<Delivery>, List<Domain.Models.Delivery>>, 
        IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetDeliveriesHandler(IMapper mapper, IQueryExecutor queryExecutor, IHttpContextAccessor httpContextAccessor) 
            : base(mapper, queryExecutor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            if (request.UserIsPermitted(nameof(GetDeliveriesRequest), _httpContextAccessor))
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
