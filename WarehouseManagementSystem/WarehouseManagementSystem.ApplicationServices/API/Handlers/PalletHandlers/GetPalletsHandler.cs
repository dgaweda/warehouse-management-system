using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.PalletQueries;
using DataAccess.Entities;
using DataAccess.Repository.PalletRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class GetPalletsHandler : 
        QueryManager<List<Pallet>, List<PalletDto>>,
        IRequestHandler<GetPalletsRequest, GetPalletsResponse>
    {
        private readonly IPalletRepository _palletRepository;
        public GetPalletsHandler(IMapper mapper, IPalletRepository palletRepository) : base(mapper)
        {
            _palletRepository = palletRepository;
        }

        public async Task<GetPalletsResponse> Handle(GetPalletsRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetPalletsQuery(_palletRepository)
            {
                DeliveryName = request.DeliveryName,
                DepartureCloseTime = request.DepartureCloseTime,
                DepartureName = request.DepartureName,
                UserLastName = request.UserLastName,
                UserFirstName = request.UserFirstName,
                PickingEnd = request.PickingEnd,
                Provider = request.Provider
            }.Execute();
            var response = await CreateResponse<GetPalletsResponse>(queryResult);
            return response;
        }
    }
}
