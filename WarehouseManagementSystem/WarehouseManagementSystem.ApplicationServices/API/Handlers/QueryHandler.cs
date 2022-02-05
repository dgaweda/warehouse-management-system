using System.Security.Claims;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WarehouseManagementSystem.ApplicationServices.API.Domain;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

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
            var entityModel = await _queryExecutor.Execute(query);
            var domainModel = _mapper.Map<TDomainModelList>(entityModel);
            return new TResponse()
            {
                Data = domainModel
            };
        }
        public abstract TQuery CreateQuery(TRequest request);
    }
}
