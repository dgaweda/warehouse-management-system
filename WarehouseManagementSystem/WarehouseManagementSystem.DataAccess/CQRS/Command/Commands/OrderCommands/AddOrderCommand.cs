
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class AddOrderCommand: CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(IRepository<Order> orderRepository)
        {
            Parameter.OrderState = OrderState.RECEIVED;
            Parameter.OrderLines.ForEach(x => x.OrderId = Parameter.Id);
            await orderRepository.GetDbContext().Set<OrderLine>().AddRangeAsync(Parameter.OrderLines);
            await orderRepository.AddAsync(Parameter);
            await orderRepository.GetDbContext().SaveChangesAsync();
            return Parameter;
        }
    }
}