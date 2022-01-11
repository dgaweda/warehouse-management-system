using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.LocationQueries;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.LocationService
{
    public class GetLocationsHandler :
        QueryHandler<GetLocationsRequest, GetLocationsResponse, GetLocationsQuery, List<Location>, List<Domain.Models.Location>>,
        IRequestHandler<GetLocationsRequest, GetLocationsResponse>
    {
        public GetLocationsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetLocationsResponse> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
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
