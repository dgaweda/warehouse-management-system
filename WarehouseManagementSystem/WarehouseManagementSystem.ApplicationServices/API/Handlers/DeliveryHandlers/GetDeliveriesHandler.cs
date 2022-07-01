using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.DeliveryQueries;
using DataAccess.Entities;
using FluentValidation;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Delivery;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Delivery;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers
{
    public class GetDeliveriesHandler
        : QueryHandler<GetDeliveriesRequest, GetDeliveriesResponse, GetDeliveriesQuery, List<Delivery>, List<Domain.Models.DeliveryDto>>, 
            IRequestHandler<GetDeliveriesRequest, GetDeliveriesResponse>
    {
        private readonly IValidator<GetDeliveriesRequest> _validator;
        public GetDeliveriesHandler(IMapper mapper, IQueryExecutor queryExecutor, IValidator<GetDeliveriesRequest> validator)
            : base(mapper, queryExecutor)
        {
            _validator = validator;
        }

        public async Task<GetDeliveriesResponse> Handle(GetDeliveriesRequest request,
            CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var query = CreateQuery(request);
            var response = await GetResponse(query);
            return response;
        }

        public override GetDeliveriesQuery CreateQuery(GetDeliveriesRequest request)
        {
            return new GetDeliveriesQuery()
            {
                Name = request.Name
            };
        }
    }
}