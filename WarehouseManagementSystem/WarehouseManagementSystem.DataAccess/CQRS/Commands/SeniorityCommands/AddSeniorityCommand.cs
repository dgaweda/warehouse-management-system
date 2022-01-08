using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.SeniorityCommands
{
    public class AddSeniorityCommand : CommandBase<Seniority, Seniority>
    {
        public override async Task<Seniority> Execute(WMSDatabaseContext context)
        {
            await context.Seniorities.AddAsync(Parameter);
            await context.SaveChangesAsync();

            var addedRecord = await context.Seniorities.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            return addedRecord;
        }
    }
}
