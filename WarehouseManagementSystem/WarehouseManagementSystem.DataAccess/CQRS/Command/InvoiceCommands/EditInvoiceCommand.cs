﻿using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Extensions;
using DataAccess.Repository;
using DataAccess.Repository.InvoiceRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class EditInvoiceCommand : CommandBase<Invoice, IInvoiceRepository>
    {
        public override async Task<Invoice> Execute(IInvoiceRepository invoiceRepository)
        {
            var invoices = await invoiceRepository.Entity.ToListAsync();
            Parameter.SetInvoiceNumber(invoices);
            
            return await invoiceRepository.UpdateAsync(Parameter);
        }
    }
}
