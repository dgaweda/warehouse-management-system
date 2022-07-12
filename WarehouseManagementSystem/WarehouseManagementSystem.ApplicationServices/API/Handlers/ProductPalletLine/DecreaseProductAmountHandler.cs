using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.ProductPalletLineCommands;
using DataAccess.Repository;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductPalletLine
{
    public class DecreaseProductAmountHandler :
        CommandHandler<DecreaseProductAmountRequest, DecreaseProductAmountResponse, DataAccess.Entities.ProductPalletLine, Domain.Models.ProductPalletLineDto, DecreaseProductAmountCommand>,
        IRequestHandler<DecreaseProductAmountRequest, DecreaseProductAmountResponse>
    {
        public DecreaseProductAmountHandler(
            IMapper mapper, 
            ICommandExecutor commandExecutor, 
            IRepository<DataAccess.Entities.ProductPalletLine> repositoryService, 
            IValidator<DecreaseProductAmountRequest> validator)
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<DecreaseProductAmountResponse> Handle(DecreaseProductAmountRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
