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

        public new Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            PrepareDomainData();
            return handler.Handle(request, cancellationToken);
        }
        private void PrepareDomainData()
        {
            handler.SetCurrentRepository(roleRepository);
            handler.GetAllCurrentRepositoryEntityData();
            SetDomainModel();
        }

        public override void SetDomainModel()
        {
            handler.domainModel = handler.entityModel.Select(x => new Domain.Models.Role()
            {
                Id = x.Id,
                Name = x.Name,
                Salary = x.Salary
            });
        }
    }
}

