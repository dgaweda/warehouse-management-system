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
    public class GetRolesHandler : IRequestHandler<GetRolesRequest, GetRolesResponse>
    { 
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetRolesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var data = new GetRolesHelper()
            {
                RoleId = request.RoleId,
                RoleName = request.RoleName
            };

            var query = new GetRolesQuery(data);
            var roles = await _queryExecutor.Execute(query);
            var domainRolesModel = _mapper.Map<List<Domain.Models.Role>>(roles);
            var response = new GetRolesResponse()
            {
                Data = domainRolesModel
            };
            return response;
        }
    }
}

