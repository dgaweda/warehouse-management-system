using AutoMapper;
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
    public class GetRolesHandler : HandlerBase<Role, Domain.Models.Role, GetRolesResponse, GetRolesRequest>, IRequestHandler<GetRolesRequest, GetRolesResponse>
    { 
        private readonly IRepository<Role> roleRepository;
        private readonly IMapper mapper;

        public GetRolesHandler(IRepository<Role> roleRepository, IMapper mapper)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            await SetDomainModel(roleRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}

