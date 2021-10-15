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
using WarehouseManagementSystem.ApplicationServices.API.Handlers.Base;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class GetRolesHandler : HandlerBase<Role, Domain.Models.Role, GetRolesResponse, GetRolesRequest>, IRequestHandler<GetRolesRequest, GetRolesResponse>, IGetAll
    {
        private readonly IRepository<Role> roleRepository;

        public GetRolesHandler(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(roleRepository);
            SetDomainModel();
            var response = Service(request, cancellationToken);
            return response;
         }

        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.Role()
            {
                Id = x.Id,
                Name = x.Name,
                Salary = x.Salary
            });
        }
    }
}

