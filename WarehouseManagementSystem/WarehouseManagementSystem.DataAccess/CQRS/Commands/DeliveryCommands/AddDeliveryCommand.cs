using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class AddDeliveryCommand : CommandBase<Delivery, Delivery>
    {
        public override async Task<Delivery> Execute(WMSDatabaseContext context)
        {
            var deliveries = await context.Deliveries.ToListAsync();
            Parameter
                .SetDeliveryNumber(deliveries)
                .SetDeliveryName(Parameter);

            await context.AddRecord(Parameter);
            return Parameter;
        }
    }
}
