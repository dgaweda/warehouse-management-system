using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Query.Queries.SeniorityQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityHandlers
{
    public class GetSenioritiesHandler :
        QueryHandler<GetSenioritiesResponse, GetSenioritiesQuery, Seniority, SeniorityDto>,
        IRequestHandler<GetSenioritiesRequest, GetSenioritiesResponse>
    {
        public GetSenioritiesHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetSenioritiesResponse> Handle(GetSenioritiesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSenioritiesQuery()
            {
                EmploymentDate = request.EmploymentDate,
                UserLastName = request.UserLastName,
                UserFirstName = request.UserFirstName
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
