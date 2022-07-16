using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.LocationQueries;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationHandlers
{
    public class GetLocationByTypeHandler :
        QueryManager<List<Location>, List<LocationDto>>,
        IRequestHandler<GetLocationsByTypeRequest, GetLocationsByTypeResponse>
    {
        private readonly ILocationRepository _locationRepository;
        public GetLocationByTypeHandler(IMapper mapper, ILocationRepository locationRepository) : base(mapper)
        {
            _locationRepository = locationRepository;
        }

        public async Task<GetLocationsByTypeResponse> Handle(GetLocationsByTypeRequest byTypeRequest, CancellationToken cancellationToken)
        {
            var queryResult = await new GetLocationsByTypeQuery(_locationRepository)
            {
                LocationType = byTypeRequest.LocationType
            }.Execute();
            var response = await CreateResponse<GetLocationsByTypeResponse>(queryResult);
            return response;
        }
    }
}
