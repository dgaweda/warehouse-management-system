using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.EmployeeQueries
{
    public class GetUsersHelper : IGetEntityHelper<User>
    {
        public int? UserId { get; set; }
        public string RoleName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


        public async Task<List<User>> GetFilteredData(WMSDatabaseContext context)
        {
            var employees = await context.Users
                .Include(x => x.Role)
                .Include(x => x.Seniority)
                .ToListAsync();

            if (PropertiesAreEmpty())
                return employees;

            if (UserId != 0 && !(UserId is null))
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

        private List<User> SearchByEmployeeId(List<User> employees) => employees.Where(employee => employee.Id == UserId).ToList();
        private List<User> SearchByRoleName(List<User> employees) => employees.Where(employee => employee.Role.Name.Contains(RoleName)).ToList();
        private List<User> SearchByPESEL(List<User> employees) => employees.Where(employee => employee.PESEL == PESEL).ToList();
        private List<User> SearchByAge(List<User> employees) => employees.Where(employee => employee.Age == Age).ToList();
        private List<User> SearchByName(List<User> employees) => employees.Where(employee => employee.Name.Contains(Name)).ToList();
        private List<User> SearchByLastName(List<User> employees) => employees.Where(employee => employee.LastName.Contains(LastName)).ToList();
        public bool PropertiesAreEmpty() => UserId == 0 && string.IsNullOrEmpty(RoleName) && string.IsNullOrEmpty(PESEL) && Age == 0 && string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(LastName);
    }
}
