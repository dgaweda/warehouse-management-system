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
    public class GetSenioritiesHandler : HandlerBase<GetSenioritiesResponse>, IRequestHandler<GetSenioritiesRequest, GetSenioritiesResponse>
    {
        private readonly IRepository<Seniority> seniorityRepository;
        private IEnumerable<Seniority> seniorities;
        private IEnumerable<Domain.Models.Seniority> domainSeniorities;
        public GetSenioritiesHandler(IRepository<Seniority> seniorityRepository)
        {
            this.seniorityRepository = seniorityRepository;
        }

        public Task<GetSenioritiesResponse> Handle(GetSenioritiesRequest request, CancellationToken cancellationToken)
        {
            var response = PrepareResponse();
            return Task.FromResult(response);
        }

        public override GetSenioritiesResponse PrepareResponse()
        {
            PrepareDomainData();
            var response = new GetSenioritiesResponse()
            {
                Data = domainSeniorities.ToList()
            };

            return response;
        }

        public override void PrepareDomainData()
        {
            GetRepositoryEntity();
            domainSeniorities = seniorities.Select(x => new Domain.Models.Seniority()
            { 
                EmployeeId = x.EmployeeId,
                EmploymentDate = x.EmploymentDate
            });
        }
        public override void GetRepositoryEntity()
        {
            seniorities = seniorityRepository.GetAll();
        }
    }
}
