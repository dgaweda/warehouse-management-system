using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.PalletQueries;
using DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class GetPalletsByStatusHandler : 
        QueryHandler<GetPalletsByStatusResponse, GetPalletsByStatusQuery, List<Pallet>, List<Domain.Models.PalletDto>>,
        IRequestHandler<GetPalletsByStatusRequest, GetPalletsByStatusResponse>
    {
        public GetPalletsByStatusHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetPalletsByStatusResponse> Handle(GetPalletsByStatusRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPalletsByStatusQuery()
            {
                PalletStatus = request.PalletStatus
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
