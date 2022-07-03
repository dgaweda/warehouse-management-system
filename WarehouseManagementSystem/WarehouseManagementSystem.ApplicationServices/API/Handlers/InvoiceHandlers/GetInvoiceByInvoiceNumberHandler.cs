using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.InvoiceQueries;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetInvoiceByInvoiceNumberHandler : 
        QueryHandler<GetInvoiceByInvoiceNumberRequest, GetInvoiceByInvoiceNumberQuery, Invoice , Domain.Models.InvoiceDto>,
        IRequestHandler<GetInvoiceByInvoiceNumberRequest, GetInvoiceByInvoiceNumberResponse>
    {
        public GetInvoiceByInvoiceNumberHandler(IMapper mapper) : base(mapper)
        {
        }
        public async Task<GetInvoiceByInvoiceNumberResponse> Handle(GetInvoiceByInvoiceNumberRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInvoiceByInvoiceNumberQuery()
            {
                InvoiceNumber = request.InvoiceNumber
            };
            var response = await HandleQuery(query);
            return response;
        }
    }
}
