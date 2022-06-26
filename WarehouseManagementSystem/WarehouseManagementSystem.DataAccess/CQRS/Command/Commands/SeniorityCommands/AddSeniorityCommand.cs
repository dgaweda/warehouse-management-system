using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.SeniorityCommands
{
    public class AddSeniorityCommand : CommandBase<Seniority, Seniority>
    {
        public override async Task<Seniority> Execute(IRepository<Seniority> seniorityRepository)
        {
            await seniorityRepository.AddAsync(Parameter);

            return Parameter;
        }
    }
}
