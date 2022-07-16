using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.Queries;
using DataAccess.CQRS.Query.Queries.DeliveryQueries;
using DataAccess.Entities;
using DataAccess.Repository.DeliveryRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class GetDeliveriesHandler : QueryManager<List<Delivery>, List<DeliveryDto>>, IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public GetDeliveriesHandler(IMapper mapper, IDeliveryRepository deliveryRepository)
            : base(mapper)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            var query = await new GetDeliveriesQuery(_deliveryRepository) { Name = request.Name }.Execute();
            var response = await CreateResponse<GetDeliveriesResponse>(query);
            return response;
        }
    }
}