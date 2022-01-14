using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.RoleQueries;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class GetRolesHandler : 
        QueryHandler<GetRolesRequest, GetRolesResponse, GetRolesQuery, List<Role>, List<Domain.Models.Role>>,
        IRequestHandler<GetRolesRequest, GetRolesResponse>
    { 
        public GetRolesHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
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

