using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class SetPalletDestinationCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(WMSDatabaseContext context)
        {
            var pallet = await context.Pallets.FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            SetPalletProperties(pallet);

            context.Entry(pallet).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var updatedRecord = await context.Pallets
                .Include(x => x.Departure)
                .Include(x => x.Order)
                .Include(x => x.Invoice.Delivery)
                .Include(x => x.Employee)
                .FirstOrDefaultAsync(x => x.Id == Parameter.Id);
            return updatedRecord;
        }

        private void SetPalletProperties(Pallet pallet)
        {
            if (Parameter.OrderId != null)
                pallet.OrderId = Parameter.OrderId;

            if (Parameter.DepartureId != null)
                pallet.DepartureId = Parameter.DepartureId;

            if (Parameter.InvoiceId != null)
                pallet.InvoiceId = Parameter.InvoiceId;

            if (Parameter.EmployeeId != null)
                pallet.EmployeeId = Parameter.EmployeeId;
        }
    }
}
