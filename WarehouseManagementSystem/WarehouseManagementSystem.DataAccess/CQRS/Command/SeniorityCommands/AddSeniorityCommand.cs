using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Repository.SeniorityRepository;

namespace DataAccess.CQRS.Command.SeniorityCommands
{
    public class AddSeniorityCommand : CommandBase<Seniority, Seniority, ISeniorityRepository>
    {
        public override async Task<Seniority> Execute(ISeniorityRepository seniorityRepository)
        {
            return await seniorityRepository.AddAsync(Parameter);
        }
    }
}
