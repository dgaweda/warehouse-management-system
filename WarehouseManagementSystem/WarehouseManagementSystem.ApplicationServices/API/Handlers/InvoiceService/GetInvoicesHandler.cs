using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries.InvoiceQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceService
{
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        public GetInvoicesHandler(IQueryExecutor queryExecutor, IMapper automapper)
        {
            _mapper = automapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var data = new GetInvoicesHelper()
            {
                InvoiceNumber = request.InvoiceNumber.ToUpper()
            };

            var query = new GetInvoicesQuery(data);

            var entityModel = await _queryExecutor.Execute(query);
            var domianModel = _mapper.Map<List<Domain.Models.Invoice>>(entityModel);
            var response = new GetInvoicesResponse()
            {
                Data = domianModel
            };
            return response;
        }
    }
}
