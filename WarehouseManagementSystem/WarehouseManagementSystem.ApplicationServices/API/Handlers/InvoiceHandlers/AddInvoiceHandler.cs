using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class AddInvoiceHandler : 
        CommandHandler<AddInvoiceRequest, AddInvoiceResponse, Invoice, Domain.Models.Invoice, AddInvoiceCommand>,
        IRequestHandler<AddInvoiceRequest, AddInvoiceResponse>
    {
        public AddInvoiceHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<AddInvoiceResponse> Handle(AddInvoiceRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
