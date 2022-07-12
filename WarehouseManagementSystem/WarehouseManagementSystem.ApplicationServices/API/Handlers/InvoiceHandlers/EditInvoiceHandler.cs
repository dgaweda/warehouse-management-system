using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.InvoiceCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class EditInvoiceHandler
        : CommandHandler<EditInvoiceRequest, EditInvoiceResponse, Invoice, Domain.Models.InvoiceDto, EditInvoiceCommand>,
        IRequestHandler<EditInvoiceRequest, EditInvoiceResponse>
    {
        public EditInvoiceHandler(IMapper mapper, ICommandExecutor commandExecutor,
            IRepository<Invoice> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<EditInvoiceResponse> Handle(EditInvoiceRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
