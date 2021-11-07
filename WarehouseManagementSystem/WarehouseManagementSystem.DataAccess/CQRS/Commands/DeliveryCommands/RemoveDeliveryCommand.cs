using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.DeliveryCommands
{
    public class RemoveDeliveryCommand : CommandBase<int, Delivery>
    {
        public override Task<Delivery> Execute(WMSDatabaseContext context)
        {
            throw new NotImplementedException();
        }
    }
}
