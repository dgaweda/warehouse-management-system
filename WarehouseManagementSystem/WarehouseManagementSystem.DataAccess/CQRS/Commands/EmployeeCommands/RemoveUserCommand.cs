using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands
{
    public class RemoveUserCommand : CommandBase<User, User>
    {

        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            var employee = await context.Users.FirstOrDefaultAsync(employee => employee.Id == Parameter.Id);

            context.Users.Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }
    }
}
