using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public abstract class QueryHandler<TResponse, TQuery, TEntityList, TDtoModelList> : IQueryHandler<TQuery, TResponse>
        where TQuery : QueryBase<TEntityList>
        where TResponse : ResponseBase<TDtoModelList>, new()
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        protected QueryHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<TResponse> HandleQuery(TQuery query)
        {
            var entity = await _queryExecutor.Execute(query);
            var dto = _mapper.Map<TDtoModelList>(entity);
            return new TResponse()
            {
                Response = dto
            };
        }
    }
}
