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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Deliveries
{
    public class GetDeliveriesHandler : HandlerBase<Delivery, Domain.Models.Delivery, GetDeliveriesResponse, GetDeliveriesRequest>, IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        private readonly IRepository<Delivery> deliveryRepository;
        private readonly IMapper mapper;
       
        public GetDeliveriesHandler(IRepository<Delivery> deliveryRepository, IMapper mapper)
        {
            this.deliveryRepository = deliveryRepository;
            this.mapper = mapper;
        }
        
        public Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            SetDomainModel(deliveryRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}
