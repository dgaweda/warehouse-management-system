using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class RemoveOrderCommand: CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(WMSDatabaseContext context)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            await context.DeleteRecord(Parameter);
            return order;
        }
    }
}