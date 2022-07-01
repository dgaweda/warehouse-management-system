using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.PalletsProductsQueries;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductPalletLine
{
    public class GetProductByPalletIdHandler :
        QueryHandler<GetProductsByPalletIdResponse, GetProductsByPalletIdQuery, List<DataAccess.Entities.ProductPalletLine>, List<Domain.Models.ProductPalletLineDto>>,
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
