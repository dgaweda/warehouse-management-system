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
        private IRepository<Seniority> seniorityRepository { get; set; }
        private HandlerBase<Seniority, Domain.Models.Seniority, GetSenioritiesResponse, GetSenioritiesRequest> handler = new HandlerBase<Seniority, Domain.Models.Seniority, GetSenioritiesResponse, GetSenioritiesRequest>();   
       
        public GetSenioritiesHandler(IRepository<Seniority> seniorityRepository)
        {
            this.seniorityRepository = seniorityRepository;
        }

        public new Task<GetSenioritiesResponse> Handle(GetSenioritiesRequest request, CancellationToken cancellationToken)
        {
            PrepareDomainData();
            return handler.Handle(request, cancellationToken);
        }

        private void PrepareDomainData()
        {
            handler.SetCurrentRepository(seniorityRepository);
            handler.GetAllCurrentRepositoryEntityData();
            SetDomainModel();
        }

        public override void SetDomainModel()
        {
            handler.domainModel = handler.entityModel.Select(x => new Domain.Models.Seniority()
            { 
                EmployeeId = x.EmployeeId,
                EmploymentDate = x.EmploymentDate
            });
        }
    }
}
