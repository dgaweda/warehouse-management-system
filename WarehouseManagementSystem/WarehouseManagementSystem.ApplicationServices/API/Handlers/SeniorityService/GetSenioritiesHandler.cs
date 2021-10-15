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
    public class GetSenioritiesHandler : HandlerBase<Seniority, Domain.Models.Seniority, GetSenioritiesResponse, GetSenioritiesRequest>, IRequestHandler<GetSenioritiesRequest, GetSenioritiesResponse>, IGetAll
    {
        private IRepository<Seniority> seniorityRepository { get; set; }
        private HandlerBase<Seniority, Domain.Models.Seniority, GetSenioritiesResponse, GetSenioritiesRequest> handler = new();   
       
        public GetSenioritiesHandler(IRepository<Seniority> seniorityRepository)
        {
            this.seniorityRepository = seniorityRepository;
        }

        public Task<GetSenioritiesResponse> Handle(GetSenioritiesRequest request, CancellationToken cancellationToken)
        {
            PrepareCurrentRepositoryEntity(seniorityRepository);
            SetDomainModel();

            var response = Service(request, cancellationToken);
            return response;
        }

        public override void SetDomainModel()
        {
            domainModel = entityModel.Select(x => new Domain.Models.Seniority()
            { 
                EmployeeId = x.EmployeeId,
                EmploymentDate = x.EmploymentDate
            });
        }
    }
}
