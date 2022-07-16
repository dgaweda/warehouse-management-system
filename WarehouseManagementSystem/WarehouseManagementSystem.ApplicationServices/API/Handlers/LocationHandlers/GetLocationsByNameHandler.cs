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
    public class GetLocationsByNameHandler :
        QueryManager<List<Location>, List<LocationDto>>,
        IRequestHandler<GetLocationsByNameRequest, GetLocationsByNameResponse>
    {
        private readonly ILocationRepository _locationRepository;
        public GetLocationsByNameHandler(IMapper mapper, ILocationRepository locationRepository) 
            : base(mapper)
        {
            _locationRepository = locationRepository;
        }

        public async Task<GetLocationsByNameResponse> Handle(GetLocationsByNameRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetLocationsByNameQuery(_locationRepository)
            {
                Name = request.Name
            }.Execute();
            var response = await CreateResponse<GetLocationsByNameResponse>(queryResult);
            return response;
        }
    }
}
