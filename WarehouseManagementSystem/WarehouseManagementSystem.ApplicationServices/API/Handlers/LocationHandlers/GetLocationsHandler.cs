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
        QueryHandler<GetLocationsResponse, GetLocationsQuery, List<Location>, List<Domain.Models.LocationDto>>,
        IRequestHandler<GetLocationsRequest, GetLocationsResponse>
    {
        public GetLocationsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetLocationsResponse> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLocationsQuery()
            {
                LocationType = request.LocationType,
                Name = request.Name
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
