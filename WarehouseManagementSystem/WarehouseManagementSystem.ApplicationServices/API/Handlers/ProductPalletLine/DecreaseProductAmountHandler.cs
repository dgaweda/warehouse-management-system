﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.ProductPalletLineCommands;
using DataAccess.Repository.ProductPalletLineRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductPalletLine
{
    public class DecreaseProductAmountHandler :
        CommandHandler<DecreaseProductAmountCommand, DataAccess.Entities.PalletRow, IProductPalletLineRepository>,
        IRequestHandler<DecreaseProductAmountRequest, DecreaseProductAmountResponse>
    {
        public DecreaseProductAmountHandler(IMapper mapper, IProductPalletLineRepository repositoryService)
            : base(mapper, repositoryService)
        {
        }

        public async Task<DecreaseProductAmountResponse> Handle(DecreaseProductAmountRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new DecreaseProductAmountResponse()
            {
                Response = request.Id
            };
        }
    }
}
