using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DeliveryProductQueries;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryProductService
{
    public class GetProductsHandler :
        QueryHandler<GetProductsRequest, GetProductsResponse, GetProductsQuery, List<Product>, List<Domain.Models.Product>>,
        IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = PrepareResponse(query);
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
