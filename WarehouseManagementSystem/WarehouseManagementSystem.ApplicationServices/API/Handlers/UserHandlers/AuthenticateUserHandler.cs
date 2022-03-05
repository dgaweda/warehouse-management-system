using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.AuthenticateUserService;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class AuthenticateUserHandler :
        QueryHandler<AuthenticateUserRequest, AuthenticateUserResponse, AuthenticateUserQuery, DataAccess.Entities.User, User>,
        IRequestHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        public AuthenticateUserHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }
        
        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override AuthenticateUserQuery CreateQuery(AuthenticateUserRequest request)
        {
            return new AuthenticateUserQuery()
            {
                Username = request.Username,
                Password = request.Password
            };
        }

        
    }
}
