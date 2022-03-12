using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(WMSDatabaseContext context)
        {
            await context.DeleteRecord(Parameter);
            var delivery = await context.Deliveries.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return delivery;
        }
    }
}
