using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.OrderLineRepository;

namespace DataAccess.CQRS.Commands.OrderLineCommands
{
    public class AddOrderLineCommand: CommandBase<OrderLine, OrderLine, IOrderLineRepository>
    {
        public override async Task<OrderLine> Execute(IOrderLineRepository orderLineRepository)
        {
            return await orderLineRepository.AddAsync(Parameter);
        }
    }
}