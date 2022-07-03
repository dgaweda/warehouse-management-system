using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.OrderRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class RemoveOrderCommand: CommandBase<Order, Order, IOrderRepository>
    {
        public override async Task<Order> Execute(IOrderRepository orderRepository)
        {
            var order = await orderRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await orderRepository.DeleteAsync(Parameter.Id);
            return order;
        }
    }
}