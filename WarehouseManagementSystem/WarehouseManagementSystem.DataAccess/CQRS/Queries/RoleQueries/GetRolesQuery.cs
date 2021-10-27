using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.RoleQueries
{
    public class GetRolesQuery : QueryBase<List<Role>>
    {
        private readonly IGetEntityHelper<Role> _helper;
        public GetRolesQuery(IGetEntityHelper<Role> helper)
        {
            _helper = helper;
        }

        public override async Task<List<Role>> Execute(WMSDatabaseContext context)
        {
            if (_helper.PropertiesAreEmpty())
                return await context.Roles.ToListAsync();
            else
                return await _helper.GetFilteredData(context);
        }
    }
}
