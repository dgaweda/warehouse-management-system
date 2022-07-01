using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.PalletQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class GetPalletsHandler : 
        QueryHandler<GetPalletsResponse, GetPalletsQuery, List<Pallet>, List<Domain.Models.PalletDto>>,
        IRequestHandler<GetPalletsRequest, GetPalletsResponse>
    {
        public GetPalletsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetPalletsResponse> Handle(GetPalletsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPalletsQuery()
            {
                DeliveryName = request.DeliveryName,
                DepartureCloseTime = request.DepartureCloseTime,
                DepartureName = request.DepartureName,
                UserLastName = request.UserLastName,
                UserFirstName = request.UserFirstName,
                PickingEnd = request.PickingEnd,
                Provider = request.Provider
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
