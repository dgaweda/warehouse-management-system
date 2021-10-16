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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Orders
{
    public class GetOrdersHandler : HandlerBase<Order, Domain.Models.Order, GetOrdersResponse, GetOrdersRequest>,IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IMapper mapper;

        public GetOrdersHandler(IRepository<Order> orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            SetDomainModel(orderRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}
