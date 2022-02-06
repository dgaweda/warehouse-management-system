using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.SeniorityQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityHandlers
{
    public class GetSenioritiesHandler :
        QueryHandler<GetSenioritiesRequest, GetSenioritiesResponse, GetSenioritiesQuery, List<Seniority>, List<Domain.Models.Seniority>>,
        IRequestHandler<GetSenioritiesRequest, GetSenioritiesResponse>
    {
        public GetSenioritiesHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetSenioritiesResponse> Handle(GetSenioritiesRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetSenioritiesQuery CreateQuery(GetSenioritiesRequest request)
        {
            return new GetSenioritiesQuery()
            {
                EmploymentDate = request.EmploymentDate,
                UserLastName = request.UserLastName,
                UserFirstName = request.UserFirstName
            };
        }
    }
}
