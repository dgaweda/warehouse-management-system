using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataAccess.CQRS.Queries
{
    public class GetEmployeesQuery : QueryBase<List<Employee>>
    {
        public int EmployeeId { get; set; }
        public string RoleName { get; set; }
        public override async Task<List<Employee>> Execute(WMSDatabaseContext context)
        {
            return await context.Employees
                .Include(entity => entity.Role)
                .Include(entity => entity.Seniority)
                .Where(employee =>
                (EmployeeId != 0) && (RoleName != null) ? (employee.Id == EmployeeId) && (employee.Role.Name == RoleName) :
                (EmployeeId == 0) && (RoleName != null) ? (employee.Role.Name == RoleName) :
                (EmployeeId != 0) && (RoleName == null) && (employee.Id == EmployeeId))
                .ToListAsync();
        }
    }
}