using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Query.Queries.RoleQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.RoleHandlers
{
    public class GetRolesHandler : 
        QueryHandler<GetRolesResponse, GetRolesQuery, Role, RoleDto>,
        IRequestHandler<GetRolesRequest, GetRolesResponse>
    { 
        public GetRolesHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRolesQuery()
            {
                RoleId = request.RoleId,
                RoleName = request.RoleName
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}

