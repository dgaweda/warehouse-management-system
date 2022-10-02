using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.UserQueries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Guid UserId { get; set; }
        public string RoleName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        

        public override async Task<List<User>> Execute()
        {
            return await _userRepository.GetAll()
                .FilterByUserId(UserId)
                .FilterByRoleName(RoleName)
                .FilterByPesel(PESEL)
                .FilterByAge(Age)
                .FilterByName(Name)
                .FilterByLastName(LastName)
                .ToListAsync();

        }
    }
}