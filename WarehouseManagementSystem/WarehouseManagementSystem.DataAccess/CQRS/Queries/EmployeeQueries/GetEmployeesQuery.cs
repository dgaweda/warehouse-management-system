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
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public override async Task<List<Employee>> Execute(WMSDatabaseContext context)
        {
            var employees = await context.Employees
                .Include(entity => entity.Role)
                .Include(entity => entity.Seniority)
                .Where(employee =>
                EmployeeId != 0 && RoleName != null ? 
                    employee.Id == EmployeeId && employee.Role.Name == RoleName :
                EmployeeId == 0 && RoleName != null ? 
                    employee.Role.Name == RoleName :
                EmployeeId != 0 && RoleName == null && employee.Id == EmployeeId)
                .ToListAsync();

            if (EmployeeId == 0 && RoleName == null && PESEL == null && Age == 0 && Name == null && LastName == null)
                return await context.Employees.ToListAsync();
            return employees;
        }

    }
}