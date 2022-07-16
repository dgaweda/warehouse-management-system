using AutoMapper;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class QueryHandler<TQuery, TResponse, TEntity, TEntityDto, TRepository> : IQueryHandler
        where TResponse : ResponseBase<TEntityDto>, new()
        where TQuery : QueryBase<TEntity, TRepository>
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
