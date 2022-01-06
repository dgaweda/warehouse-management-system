using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class AddPalletCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(WMSDatabaseContext context)
        {
            SetNulls();

            await context.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }

        private void SetNulls()
        {
            if (Parameter.OrderId == 0)
                Parameter.OrderId = null;

            if (Parameter.DepartureId == 0)
                Parameter.DepartureId = null;

            if (Parameter.UserId == 0)
                Parameter.UserId = null;

            if (Parameter.InvoiceId == 0)
                Parameter.InvoiceId = null;
        }
    }
}
