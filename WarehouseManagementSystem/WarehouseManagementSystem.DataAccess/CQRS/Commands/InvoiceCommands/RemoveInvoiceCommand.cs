using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class RemoveInvoiceCommand : CommandBase<Invoice, Invoice>
    {
        public override async Task<Invoice> Execute(WMSDatabaseContext context)
        {
            var deletedInvoice = await context.DeleteRecord(Parameter);
            return deletedInvoice;
        }
    }
}
