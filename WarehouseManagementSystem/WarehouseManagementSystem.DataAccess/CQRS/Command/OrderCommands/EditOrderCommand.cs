using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.OrderRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class EditOrderCommand: CommandBase<Order, Order, IOrderRepository>
    {
        public override async Task<Order> Execute(IOrderRepository orderRepository)
        {
            await orderRepository.UpdateAsync(Parameter);
            var order = await orderRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return order;
        }
    }
}