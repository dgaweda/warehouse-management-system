using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Query.LocationQueries;
using DataAccess.Entities;
using DataAccess.Repository.LocationRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.InvoiceHandlers
{
    public class GetLocationByIdHandler : 
        QueryHandler<GetLocationByIdQuery, GetLocationByIdResponse, Invoice ,Domain.Models.InvoiceDto, ILocationRepository>,
        IRequestHandler<GetLocationByIdRequest, GetLocationByIdResponse>
    {
        public GetInvoiceByInvoiceNumberHandler(IMapper mapper, ILocationRepository repositoryService) 
            : base(mapper, repositoryService)
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
