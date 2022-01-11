using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.PalletsProductsQueries;
using DataAccess.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.PalletsProductsHandlers
{
    public class GetProductByPalletIdHandler :
        QueryHandler<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse, GetProductsByPalletIdQuery, List<ProductPalletLine>, List<Domain.Models.ProductPalletLine>>,
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
            return new GetProductsByPalletIdQuery()
            {
                PalletId = request.PalletId
            };
        }
    }
}
