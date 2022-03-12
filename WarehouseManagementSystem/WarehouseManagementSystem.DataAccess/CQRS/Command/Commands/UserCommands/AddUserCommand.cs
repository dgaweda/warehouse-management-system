using System;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Entities;

namespace DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            var (password, saltBytes) = Parameter.HashPassword(Parameter.Password);
            Parameter.Password = password;
            Parameter.Salt = Convert.ToBase64String(saltBytes);
            await context.AddRecord(Parameter);

            return Parameter;
        }
    }
}
