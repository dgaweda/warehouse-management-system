using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.RoleQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class GetRolesHandler : 
        QueryHandler<GetRolesRequest, GetRolesResponse, GetRolesQuery, List<Role>, List<Domain.Models.RoleDto>>,
        IRequestHandler<GetRolesRequest, GetRolesResponse>
    { 
        public GetRolesHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await GetResponse(query);
            return response;
        }

        public override GetRolesQuery CreateQuery(GetRolesRequest request)
        {
            return new GetRolesQuery()
            {
                RoleId = request.RoleId,
                RoleName = request.RoleName
            };
        }

    }
}

