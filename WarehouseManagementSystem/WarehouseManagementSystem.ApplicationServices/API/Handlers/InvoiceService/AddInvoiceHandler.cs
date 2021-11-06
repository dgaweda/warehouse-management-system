using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
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
    public class AddInvoiceHandler : IRequestHandler<AddInvoiceRequest, AddInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;
        public AddInvoiceHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }

        public async Task<AddInvoiceResponse> Handle(AddInvoiceRequest request, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Invoice>(request);
            var command = new AddInvoiceCommand() { Parameter = invoice};
            var addedInvoice = await _commandExecutor.Execute(command);

            var response = new AddInvoiceResponse()
            {
                Data = addedInvoice
            };
            return response;
        }
    }
}
