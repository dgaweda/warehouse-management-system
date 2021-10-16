using AutoMapper;
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

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Seniorities
{
    public class GetSenioritiesHandler : HandlerBase<Seniority, Domain.Models.Seniority, GetSenioritiesResponse, GetSenioritiesRequest>, IRequestHandler<GetSenioritiesRequest, GetSenioritiesResponse>
    {
        private readonly IRepository<Seniority> seniorityRepository;
        private readonly IMapper mapper;
       
        public GetSenioritiesHandler(IRepository<Seniority> seniorityRepository, IMapper mapper)
        {
            this.seniorityRepository = seniorityRepository;
            this.mapper = mapper;
        }

        public async Task<GetSenioritiesResponse> Handle(GetSenioritiesRequest request, CancellationToken cancellationToken)
        {
            await SetDomainModel(seniorityRepository, mapper);
            var response = PrepareResponse();
            return response;
        }
    }
}
