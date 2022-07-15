using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class EditOrderCommand: CommandBase<Order, IOrderRepository>
    {
        public override async Task Execute(IOrderRepository orderRepository)
        {
            await orderRepository.UpdateAsync(Parameter);
        }
    }
}