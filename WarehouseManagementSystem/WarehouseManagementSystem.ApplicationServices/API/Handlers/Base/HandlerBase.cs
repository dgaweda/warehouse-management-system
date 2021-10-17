using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Base
{
    public class HandlerBase<Query, DomainModel, Response, TResult> : IHandlerBase<Query, DomainModel, Response, TResult> where Query : QueryBase<TResult>, new() where Response : ResponseBase<List<DomainModel>>, new()
    {
        private readonly IQueryExecutor queryExecutor;
        private List<DomainModel> domainModel;
        private TResult entityModel;
        private readonly IMapper mapper;
        public HandlerBase(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<Response> PrepareResponse()
        {
            await PrepareQuery();
            var response = new Response()
            {
                Data = domainModel
            };
            return response;
        }

        public async Task PrepareQuery()
        {
            var query = new Query();
            await ExecuteQuery(query);
        }
        public async Task ExecuteQuery(Query query) 
        { 
            entityModel = await queryExecutor.Execute(query);
            MapDomainModel();
        }

        public void MapDomainModel()
        {
            domainModel = mapper.Map<List<DomainModel>>(entityModel);
        }
    }
}
