using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Extensions;
using DataAccess.Repository;
using DataAccess.Repository.UserRepository;

namespace DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>, IUserRepository>
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        

        public override async Task<List<User>> Execute(IUserRepository userRepository)
        {
            var users = await userRepository.GetAllAsync();
            
            return users
                .FilterByUserId(UserId)
                .FilterByRoleName(RoleName)
                .FilterByPesel(PESEL)
                .FilterByAge(Age)
                .FilterByName(Name)
                .FilterByLastName(LastName);

        }
    }
}