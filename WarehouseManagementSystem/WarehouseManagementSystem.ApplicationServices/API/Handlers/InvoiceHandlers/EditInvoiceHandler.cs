using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.InvoiceCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.InvoiceRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class EditInvoiceHandler
        : CommandHandler<EditInvoiceCommand, Invoice, IInvoiceRepository>,
        IRequestHandler<EditInvoiceRequest, EditInvoiceResponse>
    {
        public EditInvoiceHandler(IMapper mapper, IInvoiceRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<EditInvoiceResponse> Handle(EditInvoiceRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditInvoiceResponse()
            {
                Response = request.Id
            };
        }
    }
}
