using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.LocationQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class GetLocationsHandler :
        QueryHandler<GetLocationsRequest, GetLocationsResponse, GetLocationsQuery, List<Location>, List<Domain.Models.LocationDto>>,
        IRequestHandler<GetLocationsRequest, GetLocationsResponse>
    {
        public GetLocationsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetLocationsResponse> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await GetResponse(query);
            return response;
        }

        public override GetLocationsQuery CreateQuery(GetLocationsRequest request)
        {
            return new GetLocationsQuery()
            {
                LocationType = request.LocationType,
                Name = request.Name
            };
        }
    }
}
