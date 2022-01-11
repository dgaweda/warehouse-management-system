using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.InvoiceQueries;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceService
{
    public class GetInvoicesHandler : 
        QueryHandler<GetInvoicesRequest, GetInvoicesResponse, GetInvoicesQuery, List<Invoice> , List<Domain.Models.Invoice>>,
        IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        public GetInvoicesHandler(IQueryExecutor queryExecutor, IMapper mapper) : base(mapper, queryExecutor)
        {
        }
        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetInvoicesQuery CreateQuery(GetInvoicesRequest request)
        {
            return new GetInvoicesQuery()
            {
                InvoiceNumber = request.InvoiceNumber
            };
        }

    }
}
