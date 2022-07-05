using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Exceptions;
using DataAccess.Repository;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public abstract class QueryHandler<TResponse, TQuery, TEntity, TEntityDto, TRepository> : IQueryHandler<TQuery, TResponse>
        where TQuery : QueryBase<TEntity, TRepository>
        where TResponse : ResponseBase<TEntityDto>, new()
    {
        private readonly IMapper _mapper;
        private readonly TRepository _repository;

        protected QueryHandler(IMapper mapper, TRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TResponse> HandleQuery(TQuery query)
        {
            var entity = await query.Execute(_repository);
            var dto = _mapper.Map<TEntityDto>(entity);
            return new TResponse()
            {
                Response = dto
            };
        }
    }
}
