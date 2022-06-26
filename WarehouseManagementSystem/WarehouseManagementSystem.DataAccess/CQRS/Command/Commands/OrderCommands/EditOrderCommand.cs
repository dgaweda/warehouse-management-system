using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class EditOrderCommand: CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(IRepository<Order> orderRepository)
        {
            await orderRepository.UpdateAsync(Parameter);
            var order = await orderRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return order;
        }
    }
}