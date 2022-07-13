using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.InvoiceRepository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class AddInvoiceHandler : 
        CommandHandler<AddInvoiceCommand, Invoice, IInvoiceRepository, Invoice>,
        IRequestHandler<AddInvoiceRequest, AddInvoiceResponse>
    {
        public AddInvoiceHandler(IMapper mapper, IInvoiceRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<AddInvoiceResponse> Handle(AddInvoiceRequest request, CancellationToken cancellationToken)
        {
            var result = await HandleRequest(request);
            return new AddInvoiceResponse()
            {
                Response = result.Id
            };
        }
    }
}
