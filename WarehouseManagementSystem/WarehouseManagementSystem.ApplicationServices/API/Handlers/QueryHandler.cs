using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public abstract class QueryHandler<TRequest, TResponse, TQuery, TEntityList, TDomainModelList>
        : IQueryHandler<TRequest, TResponse, TQuery, TEntityList, TDomainModelList>
        where TQuery : QueryBase<TEntityList>
        where TResponse : ResponseBase<TDomainModelList>, new()
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        public QueryHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<TResponse> PrepareResponse(TQuery query)
        {
            var entityModel = await GetQueryResult(query);
            var domainModel = MapDomainModelBy(entityModel);
            var response = CreateResponse(domainModel);
            return response;
        }
        private async Task<TEntityList> GetQueryResult(TQuery query) => await _queryExecutor.Execute(query);

        private TDomainModelList MapDomainModelBy(TEntityList entityModel) => _mapper.Map<TDomainModelList>(entityModel);

        private TResponse CreateResponse(TDomainModelList domainModel) => new() { Data = domainModel };

        public abstract TQuery CreateQuery(TRequest request);
    }
}
