using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class RemoveOrderCommand: CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(IRepository<Order> orderRepository)
        {
            var order = await orderRepository.Entity.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await orderRepository.Delete(Parameter.Id);
            return order;
        }
    }
}