using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.UsersQueries;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUserHandler :
        QueryHandler<GetUserRequest, GetUserResponse, GetUserQuery, DataAccess.Entities.User, User>,
        IRequestHandler<GetUserRequest, GetUserResponse>
    {
        public GetUserHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {

        }
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetUserQuery CreateQuery(GetUserRequest request)
        {
            return new GetUserQuery()
            {
                UserName = request.Username
            };
        }

        
    }
}
