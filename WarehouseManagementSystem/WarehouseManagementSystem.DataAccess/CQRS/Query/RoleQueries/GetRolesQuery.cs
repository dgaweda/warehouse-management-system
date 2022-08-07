using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.RoleRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.RoleQueries
{
    public class GetRolesQuery : QueryBase<List<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRolesQuery(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public override async Task<List<Role>> Execute()
        {
            return await _roleRepository.GetAll()
                .FilterById(RoleId)
                .FilterByRoleName(RoleName)
                .ToListAsync();
        }
    }
}
