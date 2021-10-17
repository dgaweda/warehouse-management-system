using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationService
{
    public class GetLocationsHandler :IRequestHandler<GetLocationsRequest, GetLocationsResponse>
    {
        private readonly IMapper mapper;

        public GetLocationsHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<GetLocationsResponse> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
