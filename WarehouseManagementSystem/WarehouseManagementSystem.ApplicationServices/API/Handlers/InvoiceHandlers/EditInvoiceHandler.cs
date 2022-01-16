using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.InvoiceCommands;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceService
{
    public class EditInvoiceHandler
        : CommandHandler<EditInvoiceRequest, EditInvoiceResponse, Invoice, Domain.Models.Invoice, EditInvoiceCommand>,
        IRequestHandler<EditInvoiceRequest, EditInvoiceResponse>
    {
        public EditInvoiceHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<EditInvoiceResponse> Handle(EditInvoiceRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
