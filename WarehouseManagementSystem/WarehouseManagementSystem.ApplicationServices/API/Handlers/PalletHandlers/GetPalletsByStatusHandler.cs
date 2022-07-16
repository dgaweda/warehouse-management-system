using System.Collections.Generic;
using AutoMapper;
using DataAccess.CQRS.Queries.PalletQueries;
using DataAccess.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Repository.PalletRepository;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class GetPalletsByStatusHandler : 
        QueryManager<List<Pallet>, List<PalletDto>>,
        IRequestHandler<GetPalletsByStatusRequest, GetPalletsByStatusResponse>
    {
        private IPalletRepository _palletRepository;
        public GetPalletsByStatusHandler(IMapper mapper, IPalletRepository palletRepository) : base(mapper)
        {
            _palletRepository = palletRepository;
        }

        public async Task<GetPalletsByStatusResponse> Handle(GetPalletsByStatusRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetPalletsByStatusQuery(_palletRepository)
            {
                PalletStatus = request.PalletStatus
            }.Execute();
            var response = await CreateResponse<GetPalletsByStatusResponse>(queryResult);
            return response;
        }
    }
}
