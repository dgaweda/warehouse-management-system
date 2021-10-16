﻿using AutoMapper;
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
    public class GetDeliveryProductsHandler : HandlerBase<DeliveryProduct, Domain.Models.DeliveryProduct, GetDeliveryProductsResponse, GetDeliveryProductsRequest>, IRequestHandler<GetDeliveryProductsRequest, GetDeliveryProductsResponse>
    {
        private readonly IRepository<DeliveryProduct> deliveryProductRepository;
        private readonly IMapper mapper;

        public GetDeliveryProductsHandler(IRepository<DeliveryProduct> deliveryProductRepository, IMapper mapper)
        {
            this.deliveryProductRepository = deliveryProductRepository;
            this.mapper = mapper;
        }

        public async Task<GetDeliveryProductsResponse> Handle(GetDeliveryProductsRequest request, CancellationToken cancellationToken)
        {
            await SetDomainModel(deliveryProductRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}
