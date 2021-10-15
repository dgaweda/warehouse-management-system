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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Deliveries
{
    public class GetDeliveriesHandler : HandlerBase<Delivery, Domain.Models.Delivery, GetDeliveriesResponse, GetDeliveriesRequest>, IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>, IGetAll
    {
        private readonly IRepository<Delivery> deliveryRepository;
       
        public GetDeliveriesHandler(IRepository<Delivery> deliveryRepository)
        {
            this.deliveryRepository = deliveryRepository;
        }
        
        public Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(deliveryRepository);
            SetDomainModel();
            var response = Service(request, cancellationToken);
            return response;
         }

        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.Delivery() 
            { 
                Id = x.Id,
                ArrivalTime = x.Arrival,
                CompanyName = x.CompanyName
            });
        }
    }
}
