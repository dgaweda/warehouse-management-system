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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Deliveries
{
    public class GetDeliveriesHandler : HandlerBase<Delivery, Domain.Models.Delivery, GetDeliveriesResponse, GetDeliveriesRequest>, IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        private IRepository<Delivery> deliveryRepository;
        private HandlerBase<Delivery, Domain.Models.Delivery, GetDeliveriesResponse, GetDeliveriesRequest> handler = new HandlerBase<Delivery, Domain.Models.Delivery, GetDeliveriesResponse, GetDeliveriesRequest>();
       
        public GetDeliveriesHandler(IRepository<Delivery> deliveryRepository)
        {
            this.deliveryRepository = deliveryRepository;
        }
        
        public Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            PrepareDomainData();
            var response = CreateResponseFrom(request, cancellationToken);
            return response;
         }

        private void PrepareDomainData()
        {
            SetCurrentRepository(deliveryRepository);
            GetAllCurrentRepositoryEntityData();
            SetDomainModel();
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
