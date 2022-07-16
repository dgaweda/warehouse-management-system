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
    public class GetLocationByIdHandler : QueryManager<Location, LocationDto>, IRequestHandler<GetLocationByIdRequest, GetLocationByIdResponse>
    {
        private ILocationRepository _locationRepository;
        public GetLocationByIdHandler(IMapper mapper, ILocationRepository locationRepository) : base(mapper)
        {
            _locationRepository = locationRepository;
        }

        public async Task<GetLocationByIdResponse> Handle(GetLocationByIdRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetLocationByIdQuery(_locationRepository)
            {
                Id = request.Id
            }.Execute();
            var response = await CreateResponse<GetLocationByIdResponse>(queryResult);
            return response;
        }
    }
}
