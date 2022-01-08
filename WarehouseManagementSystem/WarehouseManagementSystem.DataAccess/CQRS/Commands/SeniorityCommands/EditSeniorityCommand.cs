using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.SeniorityCommands
{
    public class EditSeniorityCommand : CommandBase<Seniority, Seniority>
    {
        public override async Task<Seniority> Execute(WMSDatabaseContext context)
        {
            var seniorities = await context.Seniorities.Include(x => x.User).ToListAsync();
            var seniorityToDetach = seniorities.FirstOrDefault(x => x.Id == Parameter.Id);

            context.Entry(seniorityToDetach).State = EntityState.Detached;
            context.Entry(Parameter).State = EntityState.Modified;
            await context.SaveChangesAsync();
            
            var updatedRecord = await context.Seniorities.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            return updatedRecord;  
        }
    }
}
