using DataAccess.CQRS.Queries.EmployeeQueries;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.InvoiceQueries
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>>
    {
        private readonly IGetEntityHelper<Invoice> _invoice;
        public GetInvoicesQuery(IGetEntityHelper<Invoice> helper)
        {
            _invoice = helper;
        }
        public override async Task<List<Invoice>> Execute(WMSDatabaseContext context) => await _invoice.GetFilteredData(context);
    }
}
