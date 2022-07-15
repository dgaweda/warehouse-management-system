using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.RoleRepository;

namespace DataAccess.CQRS.Query.Queries.RoleQueries
{
    public class GetRolesQuery : QueryBase<List<Role>, IRoleRepository>
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public override async Task<List<Role>> Execute(IRoleRepository roleRepository)
        {
            var roles = await roleRepository.GetAllAsync();

            return roles
                .FilterById(RoleId)
                .FilterByRoleName(RoleName);
        }
    }
}
