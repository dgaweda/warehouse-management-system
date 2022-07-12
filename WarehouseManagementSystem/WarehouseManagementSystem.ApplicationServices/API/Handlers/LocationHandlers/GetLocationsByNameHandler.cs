using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Query.LocationQueries;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.LocationRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class GetLocationsByNameHandler :
        QueryHandler<GetLocationsByNameRequest, GetLocationsByNameResponse, Location, Domain.Models.LocationDto, ILocationRepository>,
        IRequestHandler<GetLocationsByTypeRequest, GetLocationsByTypeResponse>
    {
        public GetLocationsHandler(IMapper mapper, ILocationRepository locationRepository) 
            : base(mapper, locationRepository)
        {
        }

        public async Task<GetLocationsByTypeResponse> Handle(GetLocationsByNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLocationsByNameQuery()
            {
                Name = request.Name
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
