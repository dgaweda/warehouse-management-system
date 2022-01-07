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
            var users = await context.Users
                .Include(x => x.Role)
                .Include(x => x.Seniority)
                .ToListAsync();

            if (PropertiesAreEmpty())
                return users;

            if (UserId != 0 && !(UserId is null))
                users = SearchByUserId(users);

            if (!string.IsNullOrEmpty(RoleName))
                users = SearchByRoleName(users);

            if (!string.IsNullOrEmpty(PESEL))
                users = SearchByPESEL(users);

            if (Age != 0)
                users = SearchByAge(users);

            if (!string.IsNullOrEmpty(Name))
                users = SearchByName(users);

            if (!string.IsNullOrEmpty(LastName))
                users = SearchByLastName(users);

            return users;
        }

        private List<User> SearchByUserId(List<User> users) => users.Where(user => user.Id == UserId).ToList();
        private List<User> SearchByRoleName(List<User> users) => users.Where(user => user.Role.Name.Contains(RoleName)).ToList();
        private List<User> SearchByPESEL(List<User> users) => users.Where(user => user.PESEL == PESEL).ToList();
        private List<User> SearchByAge(List<User> users) => users.Where(user => user.Age == Age).ToList();
        private List<User> SearchByName(List<User> users) => users.Where(user => user.Name.Contains(Name)).ToList();
        private List<User> SearchByLastName(List<User> users) => users.Where(user => user.LastName.Contains(LastName)).ToList();
        public bool PropertiesAreEmpty() => UserId == 0 && string.IsNullOrEmpty(RoleName) && string.IsNullOrEmpty(PESEL) && Age == 0 && string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(LastName);
    }
}
