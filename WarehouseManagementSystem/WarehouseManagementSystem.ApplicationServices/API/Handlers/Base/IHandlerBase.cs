using AutoMapper;
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
        public void SetDomainModel(IRepository<Entity> repositoryEntity, IMapper mapper);

        public void SetCurrentRepository(IRepository<Entity> repositoryEntity, IMapper mapper);
        public void GetMappedModel(IMapper mapper);

        public Task<Response> PrepareResponse();
    }
}
