using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.SeniorityCommands
{
    public class EditSeniorityCommand : CommandBase<Seniority, Seniority>
    {
        public override async Task<Seniority> Execute(IRepository<Seniority> seniorityRepository)
        {
            await seniorityRepository.UpdateAsync(Parameter);
            
            var updatedRecord = await seniorityRepository.Entity
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);

            return updatedRecord;  
        }
    }
}
