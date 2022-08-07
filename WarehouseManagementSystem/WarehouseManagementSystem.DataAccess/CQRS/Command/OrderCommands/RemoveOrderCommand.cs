using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.OrderRepository;

namespace DataAccess.CQRS.Command.OrderCommands
{
    public class RemoveOrderCommand: CommandBase<Order, IOrderRepository>
    {
        public override async Task Execute(IOrderRepository orderRepository)
        {
            await orderRepository.DeleteAsync(Parameter.Id);
        }
    }
}