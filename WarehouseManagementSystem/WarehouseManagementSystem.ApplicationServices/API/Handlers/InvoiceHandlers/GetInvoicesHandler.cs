using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Queries.InvoiceQueries;
using DataAccess.Entities;
using DataAccess.Repository.InvoiceRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetInvoicesHandler : 
        QueryManager<List<Invoice>, List<InvoiceDto>>,
        IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public GetInvoicesHandler(IMapper mapper, IInvoiceRepository invoiceRepository) : base(mapper)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var invoices = await new GetInvoicesQuery(_invoiceRepository).Execute();
            var response = await CreateResponse<GetInvoicesResponse>(invoices);
            return response;
        }
    }
}
