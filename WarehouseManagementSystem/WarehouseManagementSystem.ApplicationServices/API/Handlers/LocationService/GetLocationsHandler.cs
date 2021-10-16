using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Handlers.Base;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationService
{
    public class GetLocationsHandler : HandlerBase<Location, Domain.Models.Location, GetLocationsResponse, GetLocationsRequest>, IRequestHandler<GetLocationsRequest, GetLocationsResponse>, IGetAll
    {
        private readonly IRepository<Location> locationRepository;

        public GetLocationsHandler(IRepository<Location> locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        public Task<GetLocationsResponse> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(locationRepository);
            SetDomainModel();
            var response = Service(request, cancellationToken);

            return response;
        }
        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.Location() 
            { 
                Name = x.Name,
                CurrentAmount = x.CurrentAmount,
                MaxAmount = x.MaxAmount,
                Type = x.Type
            });
        }
    }
}
