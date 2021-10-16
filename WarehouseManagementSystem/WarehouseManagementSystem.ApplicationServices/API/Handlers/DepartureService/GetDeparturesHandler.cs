using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Departures
{
    public class GetDeparturesHandler : HandlerBase<Departure, Domain.Models.Departure, GetDeparturesResponse, GetDeparturesRequest>, IRequestHandler<GetDeparturesRequest, GetDeparturesResponse>
    {
        private readonly IRepository<Departure> departureRepository;
        private readonly IMapper mapper;

        public GetDeparturesHandler(IRepository<Departure> departureRepository, IMapper mapper)
        {
            this.departureRepository = departureRepository;
            this.mapper = mapper;
        }

        public Task<GetDeparturesResponse> Handle(GetDeparturesRequest request, CancellationToken cancellation)
        {
            SetDomainModel(departureRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}
