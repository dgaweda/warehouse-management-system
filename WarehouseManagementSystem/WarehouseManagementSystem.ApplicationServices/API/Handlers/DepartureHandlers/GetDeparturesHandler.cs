using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DepartureQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DepartureHandlers
{
    public class GetDeparturesHandler :
        QueryHandler<GetDeparturesRequest, GetDeparturesResponse, GetDeparturesQuery, List<Departure>, List<Domain.Models.DepartureDTO>>,
        IRequestHandler<GetDeparturesRequest, GetDeparturesResponse>
    {
        public GetDeparturesHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetDeparturesResponse> Handle(GetDeparturesRequest request, CancellationToken cancellation)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetDeparturesQuery CreateQuery(GetDeparturesRequest request)
        {
            return new GetDeparturesQuery()
            {
                Name = request.Name,
                OpeningTime = request.OpeningTime,
                State = request.State
            };
        }
    }
}
