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
        private readonly IGetEntityHelper<Invoice> _helper;
        public GetInvoicesQuery(IGetEntityHelper<Invoice> helper)
        {
            _helper = helper;
        }
        public override async Task<List<Invoice>> Execute(WMSDatabaseContext context) => await _helper.GetFilteredData(context);
    }
}
