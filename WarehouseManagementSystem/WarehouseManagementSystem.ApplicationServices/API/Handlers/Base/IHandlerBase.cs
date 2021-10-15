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
    public interface IHandlerBase<Entity, DomainModel, Response, Request> where Entity : EntityBase where DomainModel : new() where Response : ResponseBase<List<DomainModel>>, new()
    {
        public IRepository<Entity> repositoryEntity { get; set; }
        public IEnumerable<Entity> entityModel { get; set; }
        public IEnumerable<DomainModel> domainModel { get; set; }

        public void PrepareCurrentRepositoryEntity(IRepository<Entity> repositoryEntity);

        public void SetCurrentRepository(IRepository<Entity> repositoryEntity);

        public void GetAllCurrentRepositoryEntityData();

        public Response PrepareResponse();

        public Task<Response> Service(Request request, CancellationToken cancellationToken);

        public void SetDomainModel();
    }
}
