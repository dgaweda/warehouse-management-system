using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.SeniorityRepository;

namespace DataAccess.CQRS.Command.SeniorityCommands
{
    public class EditSeniorityCommand : CommandBase<Seniority, ISeniorityRepository>
    {
        public override async Task Execute(ISeniorityRepository seniorityRepository)
        {
            await seniorityRepository.UpdateAsync(Parameter);
        }
    }
}
