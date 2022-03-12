using System.Reflection.Metadata;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderCommands
{
    public class EditOrderCommand: CommandBase<Order, Order>
    {
        public override async Task<Order> Execute(WMSDatabaseContext context)
        {
            await context.UpdateRecord(Parameter);
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return order;
        }
    }
}