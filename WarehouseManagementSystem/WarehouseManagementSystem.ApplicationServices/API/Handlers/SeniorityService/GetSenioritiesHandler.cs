using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Seniorities
{
    public class GetSenioritiesHandler : IRequestHandler<GetSenioritiesRequest, GetSenioritiesResponse>
    {
        private readonly IMapper mapper;

        public GetSenioritiesHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<GetSenioritiesResponse> Handle(GetSenioritiesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
