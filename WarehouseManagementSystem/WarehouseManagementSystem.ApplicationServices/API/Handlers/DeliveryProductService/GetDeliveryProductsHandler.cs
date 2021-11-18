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
    public class GetDeliveryProductsHandler :
        QueryHandler<GetDeliveryProductsRequest, GetDeliveryProductsResponse, GetDeliveryProductsQuery, List<DeliveryProduct>, List<Domain.Models.DeliveryProduct>>,
        IRequestHandler<GetDeliveryProductsRequest, GetDeliveryProductsResponse>
    {
        public GetDeliveryProductsHandler(IMapper mapper, IQueryExecutor queryExecutor) : base(mapper, queryExecutor)
        {
        }

        public Task<GetDeliveryProductsResponse> Handle(GetDeliveryProductsRequest request, CancellationToken cancellationToken)
        {
            var query = CreateQuery(request);
            var response = PrepareResponse(query);
            return response;
        }
        public override GetDeliveryProductsQuery CreateQuery(GetDeliveryProductsRequest request)
        {
            var dataFromRequest = new GetDeliveryProductsHelper()
            {
                Barcode = request.Barcode,
                Id = request.Id,
                Name = request.Name
            };
            return new GetDeliveryProductsQuery(dataFromRequest);
        }
    }
}
