using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public abstract class QueryHandler<TRequest, TResponse, TQuery, TEntityList, TDomainModelList>
        : IQueryHandler<TRequest, TResponse, TQuery, TEntityList, TDomainModelList>
        where TQuery : QueryBase<TEntityList>
        where TResponse : ResponseBase<TDomainModelList>, new()
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        protected QueryHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<TResponse> PrepareResponse(TQuery query)
        {
            var entityModel = await GetQueryResult(query);
            CheckIfExist(entityModel);
            var domainModel = MapDomainModelBy(entityModel);
            var response = CreateResponse(domainModel);
            return response;
        }

        private async Task<TEntityList> GetQueryResult(TQuery query)
        {
            return await _queryExecutor.Execute(query);
        }

        private static TResponse CheckIfExist(TEntityList entityModel)
        {
            return new TResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        private TDomainModelList MapDomainModelBy(TEntityList entityModel)
        {
            return _mapper.Map<TDomainModelList>(entityModel);
        }

        private static TResponse CreateResponse(TDomainModelList domainModel)
        {
            return new() { Data = domainModel };
        }

        public abstract TQuery CreateQuery(TRequest request);
    }
}
