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
        QueryHandler<GetPalletsRequest, GetPalletsResponse, GetPalletsQuery, List<Pallet>, List<Domain.Models.Pallet>>,
        IRequestHandler<GetPalletsRequest, GetPalletsResponse>
    {
        public GetPalletsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }
        public async Task<GetPalletsResponse> Handle(GetPalletsRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }
        public override GetPalletsQuery CreateQuery(GetPalletsRequest request)
        {
            return new GetPalletsQuery()
            {
                DeliveryName = request.DeliveryName,
                DepartureCloseTime = request.DepartureCloseTime,
                DepartureName = request.DepartureName,
                UserLastName = request.UserLastName,
                UserFirstName = request.UserFirstName,
                PickingEnd = request.PickingEnd,
                Provider = request.Provider
            };
        }

    }
}
