using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUsersHandler :
        QueryHandler<GetUsersRequest, GetUsersResponse, GetUsersQuery, List<User>, List<Domain.Models.UserDTO>>,
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
            return new GetUsersQuery()
            {
                Age = request.Age,
                UserId = request.UserId,
                LastName = request.LastName,
                Name = request.Name,
                PESEL = request.PESEL,
                RoleName = request.RoleName
            };
        }
    }
}
