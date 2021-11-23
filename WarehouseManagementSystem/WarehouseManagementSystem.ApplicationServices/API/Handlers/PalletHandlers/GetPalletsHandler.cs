using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.PalletQueries;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletService
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
            var data = new GetPalletsHelper()
            {
                DeliveryName = request.DeliveryName,
                DepartureCloseTime = request.DepartureCloseTime,
                DepartureName = request.DepartureName,
                EmployeeLastName = request.EmployeeLastName,
                EmployeeName = request.EmployeeName,
                PickingEnd = request.PickingEnd,
                Provider = request.Provider
            };
            return new GetPalletsQuery(data);
        }

    }
}
