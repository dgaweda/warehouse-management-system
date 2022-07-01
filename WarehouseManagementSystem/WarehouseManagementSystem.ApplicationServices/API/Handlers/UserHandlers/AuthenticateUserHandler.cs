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
        QueryHandler<AuthenticateUserResponse, AuthenticateUserQuery, DataAccess.Entities.User, UserDto>,
        IRequestHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        public AuthenticateUserHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }
        
        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new AuthenticateUserQuery()
            {
                Username = request.Username,
                Password = request.Password
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
