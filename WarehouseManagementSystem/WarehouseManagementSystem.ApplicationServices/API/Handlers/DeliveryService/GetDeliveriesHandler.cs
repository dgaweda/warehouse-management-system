using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DeliveryQueries;
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
    public class GetDeliveriesHandler : IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
       
        public GetDeliveriesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        
        public async Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request, CancellationToken cancellationToken)
        {
            var data = new GetDeliveriesHelper()
            {
                Name = request.Name
            };
            var query = new GetDeliveriesQuery(data);
            var entityModel = await _queryExecutor.Execute(query);
            var domainModel = _mapper.Map<List<Domain.Models.Delivery>>(entityModel);
            var response = new GetDeliveriesResponse()
            {
                Data = domainModel
            };
            return response;
        }
    }
}
