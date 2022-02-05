using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Order;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Orders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IMapper mapper;

        public GetOrdersHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
