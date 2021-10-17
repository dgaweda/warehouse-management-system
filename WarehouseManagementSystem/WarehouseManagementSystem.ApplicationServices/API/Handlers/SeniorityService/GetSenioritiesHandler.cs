using AutoMapper;
using DataAccess.CQRS.Queries;
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
