using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.Queries.RoleQueries;
using DataAccess.Entities;
using DataAccess.Repository.RoleRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class GetRolesHandler : 
        QueryManager<List<Role>, List<RoleDto>>,
        IRequestHandler<GetRolesRequest, GetRolesResponse>
    {
        private readonly IRoleRepository _roleRepository;
        public GetRolesHandler(IMapper mapper, IRoleRepository roleRepository) : base(mapper)
        {
            _roleRepository = roleRepository;
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetRolesQuery(_roleRepository)
            {
                RoleId = request.Id,
                RoleName = request.RoleName
            }.Execute();
            var response = await CreateResponse<GetRolesResponse>(queryResult);
            return response;
        }
    }
}

