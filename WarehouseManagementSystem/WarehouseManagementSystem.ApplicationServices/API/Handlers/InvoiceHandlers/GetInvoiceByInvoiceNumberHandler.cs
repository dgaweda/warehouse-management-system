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
    public class GetInvoiceByInvoiceNumberHandler : 
        QueryManager<Invoice, InvoiceDto>,
        IRequestHandler<GetInvoiceByInvoiceNumberRequest, GetInvoiceByInvoiceNumberResponse>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public GetInvoiceByInvoiceNumberHandler(IMapper mapper, IInvoiceRepository invoiceRepository) : base(mapper)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<GetInvoiceByInvoiceNumberResponse> Handle(GetInvoiceByInvoiceNumberRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetInvoiceByInvoiceNumberQuery(_invoiceRepository)
            {
                InvoiceNumber = request.InvoiceNumber
            }.Execute();
            var response = await CreateResponse<GetInvoiceByInvoiceNumberResponse>(queryResult);
            return response;
        }
    }
}
