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
    public class HandlerBase<Entity, DomainModel, Response, Request> : IHandlerBase<Entity, DomainModel, Response, Request> where Entity : EntityBase where DomainModel : new() where Response : ResponseBase<List<DomainModel>>, new()
    {
        public IRepository<Entity> repositoryEntity;
        public IEnumerable<Entity> entityModel;
        public List<DomainModel> domainModel;

        public void SetDomainModel(IRepository<Entity> repositoryEntity, IMapper mapper)
        {
            SetCurrentRepository(repositoryEntity, mapper);
        }

        public void SetCurrentRepository(IRepository<Entity> repositoryEntity, IMapper mapper)
        {
            this.repositoryEntity = repositoryEntity;
            GetMappedModel(mapper);
        }
        public void GetMappedModel(IMapper mapper)
        {
            entityModel = repositoryEntity.GetAll();
            domainModel = mapper.Map<List<DomainModel>>(entityModel);
        }

        public Task<Response> PrepareResponse()
        {
            var response = new Response()
            {
                Data = domainModel
            };
            return Task.FromResult(response);
        }
    }
}
