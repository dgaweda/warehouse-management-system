using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.PalletQueries;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletHandlers
{
    public class GetPalletsByStatusHandler : 
        QueryHandler<GetPalletsByStatusRequest, GetPalletsByStatusResponse, GetPalletsByStatusQuery, List<Pallet>, List<Domain.Models.Pallet>>,
        IRequestHandler<GetPalletsByStatusRequest, GetPalletsByStatusResponse>
    {
        public GetPalletsByStatusHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetPalletsByStatusResponse> Handle(GetPalletsByStatusRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetPalletsByStatusQuery CreateQuery(GetPalletsByStatusRequest request)
        {
            return new GetPalletsByStatusQuery()
            {
                PalletStatus = request.PalletStatus
            };
        }
    }
}
