using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.EmployeeQueries
{
    public class GetEmployeesHelper : IGetEntityHelper<Employee>
    {
        public int EmployeeId { get; set; }
        public string RoleName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public async Task<List<Employee>> GetFilteredData(WMSDatabaseContext context)
        {
            var employees = await context.Employees.Include(x => x.Role).ToListAsync();

            if (EmployeeId != 0)
                employees = await SearchByEmployeeId(context);

            if (!string.IsNullOrEmpty(RoleName)) 
                employees = await SearchByRoleName(context);

            if (!string.IsNullOrEmpty(PESEL))
                employees = await SearchByPESEL(context);

            if (Age != 0)
                employees = await SearchByAge(context);

            if (!string.IsNullOrEmpty(Name))
                employees = await SearchByName(context);

            if (!string.IsNullOrEmpty(LastName))
                employees = await SearchByLastName(context);

            var filteredEmployees = employees.ToList();
            return filteredEmployees;
        }

        private async Task<List<Employee>> SearchByEmployeeId(WMSDatabaseContext context) => await context.Employees.Where(employee => employee.Id == EmployeeId).ToListAsync();
        private async Task<List<Employee>> SearchByRoleName(WMSDatabaseContext context) => await context.Employees.Include(x => x.Role).Where(employee => employee.Role.Name.Contains(RoleName)).ToListAsync();
        private async Task<List<Employee>> SearchByPESEL(WMSDatabaseContext context) => await context.Employees.Where(employee => employee.PESEL == PESEL).ToListAsync();
        private async Task<List<Employee>> SearchByAge(WMSDatabaseContext context) => await context.Employees.Where(employee => employee.Age == Age).ToListAsync();
        private async Task<List<Employee>> SearchByName(WMSDatabaseContext context) => await context.Employees.Where(employee => employee.Name.Contains(Name)).ToListAsync();
        private async Task<List<Employee>> SearchByLastName(WMSDatabaseContext context) => await context.Employees.Where(employee => employee.LastName.Contains(LastName)).ToListAsync();
        public bool PropertiesAreEmpty() => EmployeeId == 0 && string.IsNullOrEmpty(RoleName) && string.IsNullOrEmpty(PESEL) && Age == 0 && string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(LastName);
    }
}
