using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.LocationQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class GetLocationByTypeHandler :
        QueryHandler<GetLocationsByTypeResponse, GetLocationsByTypeQuery, Location, Domain.Models.LocationDto>,
        IRequestHandler<GetLocationsByTypeRequest, GetLocationsByTypeResponse>
    {
        public GetLocationsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetLocationsByTypeResponse> Handle(GetLocationsByTypeRequest byTypeRequest, CancellationToken cancellationToken)
        {
            var query = new GetLocationsByTypeQuery()
            {
                LocationType = byTypeRequest.LocationType
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
