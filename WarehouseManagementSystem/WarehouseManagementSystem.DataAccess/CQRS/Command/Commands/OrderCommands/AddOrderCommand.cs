
using System.Threading.Tasks;
using DataAccess.CQRS.Commands.ProductsPalletsCommands;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class AddOrderCommand: CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(WMSDatabaseContext context)
        {
            Parameter.OrderState = OrderState.RECEIVED;
            Parameter.OrderLines.ForEach(x => x.OrderId = Parameter.Id);
            await context.OrderLines.AddRangeAsync(Parameter.OrderLines);
            await context.AddRecord(Parameter);
            return Parameter;
        }
    }
}