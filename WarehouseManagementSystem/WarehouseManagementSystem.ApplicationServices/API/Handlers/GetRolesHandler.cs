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
        private readonly IRepository<Role> roleRepository;

        public GetRolesHandler(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var roles = GetRolesFromRepository();
            var domainRoles = PrepareDomainRoles(roles);
            var response = CreateResponse(domainRoles);

            return Task.FromResult(response);
        }

        private IEnumerable<Domain.Models.Role> PrepareDomainRoles(IEnumerable<Role> roles)
        { 
            var domainRoles = roles.Select(x => new Domain.Models.Role()
            {
                Id = x.Id,
                Name = x.Name,
                Salary = x.Salary
            });

            return domainRoles;
        }

        private IEnumerable<Role> GetRolesFromRepository() => roleRepository.GetAll();

        private GetRolesResponse CreateResponse(IEnumerable<Domain.Models.Role> domainRoles)
        {
            var response = new GetRolesResponse()
            {
                Data = domainRoles.ToList()
            };

            return response;
        }

    }
}
