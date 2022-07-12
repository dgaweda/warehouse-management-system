using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.Queries.UsersQueries;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        public AuthenticateUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        
        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new AuthenticateUserQuery()
            {
                Username = request.Username,
                Password = request.Password
            };
            var entity = await _queryExecutor.Execute(query);
            var dto = _mapper.Map<UserDto>(entity);
            return new AuthenticateUserResponse()
            {
                Response = dto
            };
        }
    }
}
