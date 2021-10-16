using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationService
{
    public class GetLocationsHandler : HandlerBase<Location, Domain.Models.Location, GetLocationsResponse, GetLocationsRequest>, IRequestHandler<GetLocationsRequest, GetLocationsResponse>
    {
        private readonly IRepository<Location> locationRepository;
        private readonly IMapper mapper;

        public GetLocationsHandler(IRepository<Location> locationRepository, IMapper mapper)
        {
            this.locationRepository = locationRepository;
            this.mapper = mapper;
        }
        public async Task<GetLocationsResponse> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
        {
            await SetDomainModel(locationRepository, mapper);
            var response = PrepareResponse();

            return response;
        }
    }
}
