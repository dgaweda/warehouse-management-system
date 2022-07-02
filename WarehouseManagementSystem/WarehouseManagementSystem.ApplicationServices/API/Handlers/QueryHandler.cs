using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public abstract class QueryHandler<TResponse, TQuery, TEntity, TDtoModel> : IQueryHandler<TQuery, TResponse>
        where TQuery : QueryBase<List<TEntity>>
        where TResponse : ResponseBase<List<TDtoModel>>, new()
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
            if (entity.Any())
            {
                var dto = _mapper.Map<List<TDtoModel>>(entity);
                return new TResponse()
                {
                    Response = dto
                };
            }

            throw new NotFoundException(typeof(TEntity).Name + " doesn't exist.");
        }
    }
}
