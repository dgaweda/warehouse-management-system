using DataAccess.Entities.EntityBases;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class HandlerBase<Entity, DomainModel, Response, Request> : IHandlerBase<Entity, DomainModel, Response, Request> where Entity : EntityBase where DomainModel : new() where Response : ResponseBase<List<DomainModel>>, new()
    {
        public IRepository<Entity> repositoryEntity { get; set; }
        public IEnumerable<Entity> entityModel { get; set; }
        public IEnumerable<DomainModel> domainModel { get; set; }

        public void SetCurrentRepository(IRepository<Entity> repositoryEntity)
        {
            this.repositoryEntity = repositoryEntity;
        }

        public void GetRepositoryEntity()
        {
            entityModel = repositoryEntity.GetAll();
        }

        public Response PrepareResponse()
        {
            var response = new Response()
            {
                Data = domainModel.ToList()
            };
            return response;
        }

        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var response = PrepareResponse();
            return Task.FromResult(response);
        }
    }
}
