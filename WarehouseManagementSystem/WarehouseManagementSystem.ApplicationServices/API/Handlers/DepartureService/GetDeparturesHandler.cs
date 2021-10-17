using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Departures
{
    public class GetDeparturesHandler : IRequestHandler<GetDeparturesRequest, GetDeparturesResponse>
    {
        private readonly IMapper mapper;

        public GetDeparturesHandler(IRepository<Departure> departureRepository, IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<GetDeparturesResponse> Handle(GetDeparturesRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
