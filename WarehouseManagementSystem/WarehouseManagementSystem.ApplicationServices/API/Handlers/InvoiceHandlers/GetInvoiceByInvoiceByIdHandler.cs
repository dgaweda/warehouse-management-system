using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.InvoiceQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetLocationByIdHandler : 
        QueryHandler<GetLocationByIdRequest, GetLocationByIdQuery, Invoice , Domain.Models.InvoiceDto>,
        IRequestHandler<GetLocationByIdRequest, GetLocationByIdResponse>
    {
        public GetInvoiceByInvoiceNumberHandler(IMapper mapper) : base(mapper)
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
