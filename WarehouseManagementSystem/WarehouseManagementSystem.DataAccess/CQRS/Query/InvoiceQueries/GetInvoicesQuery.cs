﻿using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Repository.InvoiceRepository;

namespace DataAccess.CQRS.Queries.InvoiceQueries
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>, IInvoiceRepository>
    {
        public override async Task<List<Invoice>> Execute(IInvoiceRepository invoiceRepository)
        {
            return await invoiceRepository.GetAllAsync();
        }
    }
}
