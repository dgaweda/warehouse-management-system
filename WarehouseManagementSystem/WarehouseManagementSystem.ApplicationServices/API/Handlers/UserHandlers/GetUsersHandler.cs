using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Employees
{
    public class GetUsersHandler :
        QueryHandler<GetUsersRequest, GetUsersResponse, GetUsersQuery, List<User>, List<Domain.Models.User>>,
        IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        public GetUsersHandler(IQueryExecutor queryExecutor, IMapper mapper) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetUsersQuery CreateQuery(GetUsersRequest request)
        {
            var data = new GetUsersHelper()
            {
                Age = request.Age,
                UserId = request.UserId,
                LastName = request.LastName,
                Name = request.Name,
                PESEL = request.PESEL,
                RoleName = request.RoleName
            };
            return new GetUsersQuery(data);
        }
    }
}
