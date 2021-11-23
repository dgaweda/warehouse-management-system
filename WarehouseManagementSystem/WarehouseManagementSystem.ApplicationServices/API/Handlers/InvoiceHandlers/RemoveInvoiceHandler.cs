using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.InvoiceCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceService
{
    public class RemoveInvoiceHandler
        : CommandHandler<RemoveInvoiceRequest, RemoveInvoiceResponse, Invoice, Domain.Models.Invoice, RemoveInvoiceCommand>,
        IRequestHandler<RemoveInvoiceRequest, RemoveInvoiceResponse>
    {
        public RemoveInvoiceHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public Task<RemoveInvoiceResponse> Handle(RemoveInvoiceRequest request, CancellationToken cancellationToken) => PrepareResponse(request);
    }
}
