using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.SeniorityRepository;
using Microsoft.EntityFrameworkCore;

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
