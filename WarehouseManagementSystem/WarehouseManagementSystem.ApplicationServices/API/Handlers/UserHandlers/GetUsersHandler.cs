using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Queries;
using DataAccess.CQRS.Query.UserQueries;
using DataAccess.Entities;
using DataAccess.Repository.UserRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUsersHandler :
        QueryManager<List<User>, List<UserDto>>,
        IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersHandler(IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetUsersQuery(_userRepository)
            {
                Age = request.Age,
                UserId = request.Id,
                LastName = request.LastName,
                Name = request.Name,
                PESEL = request.PESEL,
                RoleName = request.RoleName
            }.Execute();
            var response = await CreateResponse<GetUsersResponse>(queryResult);
            return response;
        }
    }
}
