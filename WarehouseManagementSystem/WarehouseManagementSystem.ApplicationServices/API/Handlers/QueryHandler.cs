using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public abstract class QueryHandler<TRequest, TResponse, TQuery, TResult, TDomainModel>
        : IQueryHandler<TRequest, TResponse, TQuery, TResult, TDomainModel>
        where TQuery : QueryBase<TResult>
        where TResponse : ResponseBase<TDomainModel>, new()
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        public QueryHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<TResponse> Response(TQuery query)
        {
            var entityModel = await GetQueryResult(query);
            var domainModel = MapDomainModelBy(entityModel);
            var response = CreateResponse(domainModel);
            return response;
        }

        private async Task<TResult> GetQueryResult(TQuery query) => await _queryExecutor.Execute(query);

        private TDomainModel MapDomainModelBy(TResult entityModel) => _mapper.Map<TDomainModel>(entityModel);

        private TResponse CreateResponse(TDomainModel domainModel) => new() { Data = domainModel };

        public abstract TQuery CreateQuery(TRequest request);
    }
}
