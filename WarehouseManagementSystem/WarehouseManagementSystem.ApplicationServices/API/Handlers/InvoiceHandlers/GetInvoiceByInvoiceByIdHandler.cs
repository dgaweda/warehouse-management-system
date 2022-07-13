using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.InvoiceQueries;
using DataAccess.CQRS.Query.LocationQueries;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetLocationByIdHandler : 
        QueryHandler<GetLocationByIdQuery, GetLocationByIdResponse, Invoice ,Domain.Models.InvoiceDto, ILocationRepository>,
        IRequestHandler<GetLocationByIdRequest, GetLocationByIdResponse>
    {
        public GetInvoiceByInvoiceNumberHandler(IMapper mapper, ) : base(mapper)
        {
        }
        public async Task<GetLocationByIdResponse> Handle(GetLocationByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetLocationByIdQuery()
            {
                Id = request.Id
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
