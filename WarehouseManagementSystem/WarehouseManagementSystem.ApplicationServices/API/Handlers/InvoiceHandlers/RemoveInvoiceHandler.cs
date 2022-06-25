﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.InvoiceCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class RemoveInvoiceHandler
        : CommandHandler<RemoveInvoiceRequest, RemoveInvoiceResponse, Invoice, Domain.Models.Invoice, RemoveInvoiceCommand>,
        IRequestHandler<RemoveInvoiceRequest, RemoveInvoiceResponse>
    {
        public RemoveInvoiceHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Invoice> repositoryService)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public Task<RemoveInvoiceResponse> Handle(RemoveInvoiceRequest request, CancellationToken cancellationToken) => GetResponse(request);
    }
}
