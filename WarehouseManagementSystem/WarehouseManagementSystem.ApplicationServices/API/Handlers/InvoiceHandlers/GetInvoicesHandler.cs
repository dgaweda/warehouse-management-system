using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Queries.InvoiceQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetInvoicesHandler : 
        QueryHandler<GetInvoicesResponse, GetInvoicesQuery, Invoice , Domain.Models.InvoiceDto>,
        IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        public GetInvoicesHandler(IQueryExecutor queryExecutor, IMapper mapper) : base(mapper, queryExecutor)
        {
        }
        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoicesQuery()
            {
                InvoiceNumber = request.InvoiceNumber
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
