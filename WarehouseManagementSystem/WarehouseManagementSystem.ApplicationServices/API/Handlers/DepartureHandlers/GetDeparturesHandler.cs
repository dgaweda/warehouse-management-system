using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Queries.DepartureQueries;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class GetDeparturesHandler :
        QueryHandler<GetDeparturesQuery,GetDeparturesResponse, List<Departure>, List<DepartureDto>, IDepartureRepository>,
        IRequestHandler<GetDeparturesRequest, GetDeparturesResponse>
    {
        public GetDeparturesHandler(IMapper mapper, IDepartureRepository departureRepository) : base(mapper, departureRepository)
        {
        }

        public async Task<GetDeparturesResponse> Handle(GetDeparturesRequest request, CancellationToken cancellation)
        {
            var query = new GetDeparturesQuery()
            {
                Name = request.Name,
                OpeningTime = request.OpeningTime,
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
