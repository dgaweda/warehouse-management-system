using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.SeniorityRepository;

namespace DataAccess.CQRS.Commands.SeniorityCommands
{
    public class EditSeniorityCommand : CommandBase<Seniority, ISeniorityRepository>
    {
        public override async Task Execute(ISeniorityRepository seniorityRepository)
        {
            await seniorityRepository.UpdateAsync(Parameter);
        }
    }
}
