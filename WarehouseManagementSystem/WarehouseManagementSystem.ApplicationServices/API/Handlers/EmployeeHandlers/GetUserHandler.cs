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
    public class GetUserHandler :
        QueryHandler<GetUserRequest, GetUserResponse, GetUsersQuery, List<User>, List<Domain.Models.User>>,
        IRequestHandler<GetUserRequest, GetUserResponse>
    {
        public GetUserHandler(IQueryExecutor queryExecutor, IMapper mapper) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetUsersQuery CreateQuery(GetUserRequest request)
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
