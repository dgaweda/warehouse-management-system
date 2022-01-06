using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.SeniorityQueries;
using DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Seniorities
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
            var query = new GetSenioritiesHelper()
            {
                EmploymentDate = request.EmploymentDate,
                UserLastName = request.UserLastName,
                UserFirstName = request.UserFirstName
            };
            return new GetSenioritiesQuery(query);
        }
    }
}
