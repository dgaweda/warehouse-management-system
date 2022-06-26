using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.InvoiceQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetInvoicesHandler : 
        QueryHandler<GetInvoicesRequest, GetInvoicesResponse, GetInvoicesQuery, List<Invoice> , List<Domain.Models.InvoiceDto>>,
        IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        public GetInvoicesHandler(IQueryExecutor queryExecutor, IMapper mapper) : base(mapper, queryExecutor)
        {
        }
        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await GetResponse(query);
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
