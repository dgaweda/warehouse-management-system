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
        private HandlerBase<Role, Domain.Models.Role, GetRolesResponse, GetRolesRequest> handler = new HandlerBase<Role, Domain.Models.Role, GetRolesResponse, GetRolesRequest>();

        public GetRolesHandler(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            PrepareDomainData();
            var response = CreateResponseFrom(request, cancellationToken);
            return response;
         }
        private void PrepareDomainData()
        {
            SetCurrentRepository(roleRepository);
            GetAllCurrentRepositoryEntityData();
            SetDomainModel();
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

