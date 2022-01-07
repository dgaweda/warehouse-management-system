using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands
{
    public class EditUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(WMSDatabaseContext context)
        {
            if (Parameter == null)
                throw new ArgumentNullException();

            var invoices = await context.Invoices.ToListAsync();
            
            context.Entry(Parameter).State = EntityState.Modified;
            await context.SaveChangesAsync();
            var updatedRecord = await context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(user => user.Id == Parameter.Id);

            return updatedRecord;
        }
    }
}
