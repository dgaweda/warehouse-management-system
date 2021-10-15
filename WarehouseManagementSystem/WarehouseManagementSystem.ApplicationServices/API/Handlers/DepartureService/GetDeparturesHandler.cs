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
using WarehouseManagementSystem.ApplicationServices.API.Handlers.Base;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Departures
{
    public class GetDeparturesHandler : HandlerBase<Departure, Domain.Models.Departure, GetDeparturesResponse, GetDeparturesRequest>, IRequestHandler<GetDeparturesRequest, GetDeparturesResponse>, IGetAll
    {
        private readonly IRepository<Departure> departureRepository;

        public GetDeparturesHandler(IRepository<Departure> departureRepository)
        {
            this.departureRepository = departureRepository;
        }

        public Task<GetDeparturesResponse> Handle(GetDeparturesRequest request, CancellationToken cancellation)
        {
            PrepareCurrentRepositoryEntity(departureRepository);
            SetDomainModel();

            var response = Service(request, cancellation);
            return response;
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
