using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Entities;
using DataAccess.Repository.OrderLineRepository;

namespace DataAccess.CQRS.Commands.OrderLineCommands
{
    public class AddOrderLineCommand: CommandBase<OrderLine, IOrderLineRepository>
    {
        public override async Task Execute(IOrderLineRepository orderLineRepository)
        {
            await orderLineRepository.AddAsync(Parameter);
        }
    }
}