using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.SeniorityCommands
{
    public class EditSeniorityCommand : CommandBase<Seniority, Seniority>
    {
        public override async Task<Seniority> Execute(WMSDatabaseContext context)
        {
            await context.UpdateRecord(Parameter);
            
            var updatedRecord = await context.Seniorities.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            return updatedRecord;  
        }
    }
}
