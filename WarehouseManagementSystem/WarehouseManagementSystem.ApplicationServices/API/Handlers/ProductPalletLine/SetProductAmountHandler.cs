using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.ProductsPalletsCommands;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletsProductsHandlers
{
    public class SetProductAmountHandler :
        CommandHandler<SetProductAmountRequest, SetProductAmountResponse, ProductPalletLine, Domain.Models.ProductPalletLine, SetProductAmountCommand>,
        IRequestHandler<SetProductAmountRequest, SetProductAmountResponse>
    {
        public SetProductAmountHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {
        }

        public async Task<SetProductAmountResponse> Handle(SetProductAmountRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
