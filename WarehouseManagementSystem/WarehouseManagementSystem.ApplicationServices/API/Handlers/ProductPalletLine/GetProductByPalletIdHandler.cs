using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.PalletsProductsQueries;
using DataAccess.Repository.ProductPalletLineRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductPalletLine
{
    public class GetProductByPalletIdHandler :
        QueryManager<List<DataAccess.Entities.ProductPalletLine>, List<ProductPalletLineDto>>,
        IRequestHandler<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>
    {
        private readonly IProductPalletLineRepository _productPalletLineRepository;
        public GetProductByPalletIdHandler(IMapper mapper, IProductPalletLineRepository productPalletLineRepository) : base(mapper)
        {
            _productPalletLineRepository = productPalletLineRepository;
        }

        public async Task<GetProductsByPalletIdResponse> Handle(GetProductsByPalletIdRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetProductsByPalletIdQuery(_productPalletLineRepository)
            {
                PalletId = request.PalletId
            }.Execute();
            var response = await CreateResponse<GetProductsByPalletIdResponse>(queryResult);
            return response;
        }
    }
}
