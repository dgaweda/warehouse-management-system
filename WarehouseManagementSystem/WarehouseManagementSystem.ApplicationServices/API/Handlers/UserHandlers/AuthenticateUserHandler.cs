using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.Queries.UsersQueries;
using DataAccess.Entities;
using DataAccess.Repository.UserRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class AuthenticateUserHandler : QueryManager<User, User>, IRequestHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public AuthenticateUserHandler(IMapper mapper, IUserRepository userRepository) 
            : base(mapper)
        {
            _userRepository = userRepository;
        }
        
        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new AuthenticateUserQuery(_userRepository)
            {
                Username = request.Username,
                Password = request.Password
            }.Execute();
            var response = await CreateResponse<AuthenticateUserResponse>(queryResult);
            return response;
        }
    }
}
