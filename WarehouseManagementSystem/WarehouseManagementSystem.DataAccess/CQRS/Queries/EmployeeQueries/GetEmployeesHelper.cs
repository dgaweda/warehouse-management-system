using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.EmployeeQueries
{
    public class GetEmployeesHelper : IGetEntityHelper<Employee>
    {
        public int? EmployeeId { get; set; }
        public string RoleName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        public async Task<List<Employee>> GetFilteredData(WMSDatabaseContext context)
        {
            var employees = await context.Employees
                .Include(x => x.Role)
                .Include(x => x.Seniority)
                .ToListAsync();

            if (PropertiesAreEmpty())
                return employees;

            if (EmployeeId != 0 && !(EmployeeId is null))
                employees = SearchByEmployeeId(employees);

            if (!string.IsNullOrEmpty(RoleName))
                employees = SearchByRoleName(employees);

            if (!string.IsNullOrEmpty(PESEL))
                employees = SearchByPESEL(employees);

            if (Age != 0)
                employees = SearchByAge(employees);

            if (!string.IsNullOrEmpty(Name))
                employees = SearchByName(employees);

            if (!string.IsNullOrEmpty(LastName))
                employees = SearchByLastName(employees);

            return employees;
        }

        private List<Employee> SearchByEmployeeId(List<Employee> employees) => employees.Where(employee => employee.Id == EmployeeId).ToList();
        private List<Employee> SearchByRoleName(List<Employee> employees) => employees.Where(employee => employee.Role.Name.Contains(RoleName)).ToList();
        private List<Employee> SearchByPESEL(List<Employee> employees) => employees.Where(employee => employee.PESEL == PESEL).ToList();
        private List<Employee> SearchByAge(List<Employee> employees) => employees.Where(employee => employee.Age == Age).ToList();
        private List<Employee> SearchByName(List<Employee> employees) => employees.Where(employee => employee.Name.Contains(Name)).ToList();
        private List<Employee> SearchByLastName(List<Employee> employees) => employees.Where(employee => employee.LastName.Contains(LastName)).ToList();
        public bool PropertiesAreEmpty() => EmployeeId == 0 && string.IsNullOrEmpty(RoleName) && string.IsNullOrEmpty(PESEL) && Age == 0 && string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(LastName);
    }
}
