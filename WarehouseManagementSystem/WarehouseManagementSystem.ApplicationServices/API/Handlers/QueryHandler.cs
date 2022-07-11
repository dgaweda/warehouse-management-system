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
    public abstract class QueryHandler<TResponse, TQuery, TResult, TResultDto, TRepository> : IQueryHandler<TQuery, TResponse>
        where TResponse : ResponseBase<TResultDto>, new()
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
            var entity = await query.Execute();
            if (entity.Any())
            {
                var dto = _mapper.Map<TResultDto>(entity);
                return new TResponse()
                {
                    Response = dto
                };
            }

            throw new NotFoundException(typeof(TEntity).Name + " doesn't exist.");
        }
    }
}
