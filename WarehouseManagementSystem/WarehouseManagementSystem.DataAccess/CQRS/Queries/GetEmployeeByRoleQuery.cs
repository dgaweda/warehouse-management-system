using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries
{
    public class GetEmployeeByRoleQuery : QueryBase<List<Employee>>
    {
        public string RoleName { get; set; }
        public override async Task<List<Employee>> Execute(WMSDatabaseContext context)
        {
            var employees = await context.Employees.Where(x => x.Role.Name == RoleName).ToListAsync();
            return employees;
        }
    }
}
