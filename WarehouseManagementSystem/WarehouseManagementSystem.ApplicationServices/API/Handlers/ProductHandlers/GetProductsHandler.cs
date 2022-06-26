using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DeliveryProductQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductsHandler :
        QueryHandler<GetProductsRequest, GetProductsResponse, GetProductsQuery, List<Product>, List<Domain.Models.ProductDto>>,
        IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = GetResponse(query);
            return response;
        }
        public override GetProductsQuery CreateQuery(GetProductsRequest request)
        {
            return new GetProductsQuery()
            {
                Barcode = request.Barcode,
                Id = request.Id,
                Name = request.Name
            };
        }
    }
}
