using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.UserQueries;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Users;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUserHandler :
        QueryHandler<GetUsersRequest, GetUsersResponse, GetUsersQuery, User, Domain.Models.User>,
        IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        public GetUserHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
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
                UserName = request.UserName
            };
        }
    }
}
