using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.OrderLineCommands
{
    public class AddOrderLineCommand: CommandBase<OrderLine, OrderLine>
    {
        public override async Task<OrderLine> Execute(WMSDatabaseContext context)
        {
            await context.AddRecord(Parameter);
            return Parameter;
        }
    }
}