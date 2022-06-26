using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.OrderLineCommands
{
    public class AddOrderLineCommand: CommandBase<OrderLine, OrderLine>
    {
        public override async Task<OrderLine> Execute(IRepository<OrderLine> orderLineRepository)
        {
            return await orderLineRepository.AddAsync(Parameter);
        }
    }
}