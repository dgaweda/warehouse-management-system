using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.UserCommands
{
    public class CreateUserCommand : CommandBase<User, User>
    {
        public  override async Task<User> Execute(WMSDatabaseContext context)
        {
            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            var addedUser = await context.Users.FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            return addedUser;
        }
    }
}
