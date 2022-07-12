﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.Queries.DeliveryQueries;
using DataAccess.Entities;
using DataAccess.Repository.DeliveryRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class GetDeliveriesHandler
        : QueryHandler<GetDeliveriesQuery, GetDeliveriesResponse, List<Delivery>, List<Domain.Models.DeliveryDto>, IDeliveryRepository>, 
            IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        public GetDeliveriesHandler(IMapper mapper, IDeliveryRepository repository)
            : base(mapper, repository)
        {
        }

        public async Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetDeliveriesQuery()
            {
                Name = request.Name
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}