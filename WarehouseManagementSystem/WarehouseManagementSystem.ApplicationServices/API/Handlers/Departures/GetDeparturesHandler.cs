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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Departures
{
    public class GetDeparturesHandler : HandlerBase<Departure, Domain.Models.Departure, GetDeparturesResponse, GetDeparturesRequest>, IRequestHandler<GetDeparturesRequest, GetDeparturesResponse>
    {
        private IRepository<Departure> departureRepository;
        private HandlerBase<Departure, Domain.Models.Departure, GetDeparturesResponse, GetDeparturesRequest> handler = new HandlerBase<Departure, Domain.Models.Departure, GetDeparturesResponse, GetDeparturesRequest>();

        public GetDeparturesHandler(IRepository<Departure> departureRepository)
        {
            this.departureRepository = departureRepository;
        }

        public Task<GetDeparturesResponse> Handle(GetDeparturesRequest request, CancellationToken cancellation)
        {
            PrepareDomainData();
            var response = CreateResponseFrom(request, cancellation);
            return response;
        }
        private void PrepareDomainData()
        {
            SetCurrentRepository(departureRepository);
            GetAllCurrentRepositoryEntityData();
            SetDomainModel();
        }
        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.Departure() 
            { 
                DepartureTime = x.DepartureTime
            });
        }
    }
}
