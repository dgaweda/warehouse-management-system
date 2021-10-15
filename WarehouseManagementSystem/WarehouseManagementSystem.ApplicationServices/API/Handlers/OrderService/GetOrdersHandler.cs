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
using WarehouseManagementSystem.ApplicationServices.API.Handlers.Base;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Orders
{
    public class GetOrdersHandler : HandlerBase<Order, Domain.Models.Order, GetOrdersResponse, GetOrdersRequest>,IRequestHandler<GetOrdersRequest, GetOrdersResponse>, IGetAll
    {
        private readonly IRepository<Order> orderRepository;

        public GetOrdersHandler(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(orderRepository);
            SetDomainModel();
            var response = Service(request, cancellationToken);

            return response;
        }
        
        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.Order() 
            { 
                State = x.State,
                Barcode = x.Barcode,
                PickingStart = x.PickingStart,
                PickingEnd = x.PickingEnd
            });
        }
    }
}
