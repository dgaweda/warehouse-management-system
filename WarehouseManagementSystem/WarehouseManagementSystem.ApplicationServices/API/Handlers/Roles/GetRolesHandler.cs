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
    public class GetRolesHandler : HandlerBase<GetRolesResponse>, IRequestHandler<GetRolesRequest, GetRolesResponse>
    {
        private readonly IRepository<Role> roleRepository;
        private IEnumerable<Role> roles;
        private IEnumerable<Domain.Models.Role> domainRoles;

        public GetRolesHandler(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var response = PrepareResponse();
            return Task.FromResult(response);
        }

        public override GetRolesResponse PrepareResponse()
        {
            PrepareDomainData();
            var response = new GetRolesResponse()
            {
                Data = domainRoles.ToList()
            };

            return response;
        }

       public override void PrepareDomainData()
        {
            GetRepositoryEntity();
            domainRoles = roles.Select(x => new Domain.Models.Role()
            {
                Id = x.Id,
                Name = x.Name,
                Salary = x.Salary
            });
        }

        public override void GetRepositoryEntity()
        {
            roles = roleRepository.GetAll();
        }
    }
}

