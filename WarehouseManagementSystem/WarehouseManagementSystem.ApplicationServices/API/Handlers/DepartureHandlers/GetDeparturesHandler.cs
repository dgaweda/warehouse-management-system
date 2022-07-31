using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.DepartureQueries;
using DataAccess.Entities;
using DataAccess.Repository.DepartureRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class GetDeparturesHandler :
        QueryManager<List<Departure>, List<DepartureDto>>,
        IRequestHandler<GetDeparturesRequest, GetDeparturesResponse>
    {
        private readonly IDepartureRepository _departureRepository;
        public GetDeparturesHandler(IMapper mapper, IDepartureRepository departureRepository) 
            : base(mapper)
        {
            _departureRepository = departureRepository;
        }

        public async Task<GetDeparturesResponse> Handle(GetDeparturesRequest request, CancellationToken cancellation)
        {
            var queryResult = await new GetDeparturesQuery(_departureRepository)
            {
                Name = request.Name,
                OpeningTime = request.OpeningTime,
            }.Execute();
            var response = await CreateResponse<GetDeparturesResponse>(queryResult);
            return response;
        }
    }
}
