using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.PalletLineQueries;
using DataAccess.CQRS.Queries.PalletsProductsQueries;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletsProductsHandlers
{
    public class GetProductByPalletIdHandler : 
        QueryHandler<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse, GetProductsByPalletIdQuery, List<PalletLine>, List<Domain.Models.PalletLine>>,
        IRequestHandler<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>
    {
        public GetProductByPalletIdHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }
        
        public async Task<GetProductsByPalletIdResponse> Handle(GetProductsByPalletIdRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = await PrepareResponse(query);
            return response;
        }

        public override GetProductsByPalletIdQuery CreateQuery(GetProductsByPalletIdRequest request)
        {
            var requestData = new GetProductsByPalletIdHelper()
            {
                PalletId = request.PalletId
            };
            return new GetProductsByPalletIdQuery(requestData);
        }
    }
}
