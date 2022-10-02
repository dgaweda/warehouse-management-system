using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess.Repository.OrderRepository;

namespace DataAccess.CQRS.Command.OrderCommands
{
    public class AddOrderCommand: CommandBase<Order, IOrderRepository>
    {
        public override async Task Execute(IOrderRepository orderRepository)
        {
            Parameter.OrderState = OrderState.RECEIVED;
            Parameter.OrderRows.ForEach(x => x.OrderId = Parameter.Id);
            await orderRepository.GetDbContext().Set<OrderRow>().AddRangeAsync(Parameter.OrderRows);
            await orderRepository.AddAsync(Parameter);
            await orderRepository.GetDbContext().SaveChangesAsync();
        }
    }
}