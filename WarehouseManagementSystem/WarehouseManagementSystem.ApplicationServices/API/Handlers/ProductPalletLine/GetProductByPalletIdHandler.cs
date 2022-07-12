using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Query.PalletsProductsQueries;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductPalletLine
{
    public class GetProductByPalletIdHandler :
        QueryHandler<GetProductsByPalletIdResponse, GetProductsByPalletIdQuery, DataAccess.Entities.ProductPalletLine, ProductPalletLineDto>,
        IRequestHandler<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>
    {
        public GetProductByPalletIdHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public async Task<GetProductsByPalletIdResponse> Handle(GetProductsByPalletIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsByPalletIdQuery()
            {
                PalletId = request.PalletId
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
