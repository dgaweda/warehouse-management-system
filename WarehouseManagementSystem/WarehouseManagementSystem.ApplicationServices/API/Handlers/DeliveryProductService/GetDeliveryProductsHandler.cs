using AutoMapper;
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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryProductService
{
    public class GetDeliveryProductsHandler : IRequestHandler<GetDeliveryProductsRequest, GetDeliveryProductsResponse>
    {
        private readonly IMapper mapper;

        public GetDeliveryProductsHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<GetDeliveryProductsResponse> Handle(GetDeliveryProductsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
