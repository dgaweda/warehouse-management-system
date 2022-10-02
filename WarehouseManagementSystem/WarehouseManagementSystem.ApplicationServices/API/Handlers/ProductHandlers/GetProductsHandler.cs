using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.ProductQueries;
using DataAccess.Entities;
using DataAccess.Repository.ProductRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductsHandler :
        QueryManager<List<Product>, List<ProductDto>>,
        IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsHandler(IMapper mapper, IProductRepository productRepository) : base(mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var queryResult = await new GetProductsQuery(_productRepository)
            {
                Barcode = request.Barcode,
                Id = request.Id,
                Name = request.Name
            }.Execute();
            var response = await CreateResponse<GetProductsResponse>(queryResult);
            return response;
        }
    }
}
