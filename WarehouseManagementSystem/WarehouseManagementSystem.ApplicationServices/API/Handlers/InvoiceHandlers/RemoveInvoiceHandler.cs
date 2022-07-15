using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.InvoiceCommands;
using DataAccess.Entities;
using DataAccess.Repository.InvoiceRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class RemoveInvoiceHandler
        : CommandHandler<RemoveInvoiceCommand, Invoice, IInvoiceRepository>,
        IRequestHandler<RemoveInvoiceRequest, RemoveInvoiceResponse>
    {
        public RemoveInvoiceHandler(IMapper mapper, IInvoiceRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<RemoveInvoiceResponse> Handle(RemoveInvoiceRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new RemoveInvoiceResponse();
        }
    }
}
