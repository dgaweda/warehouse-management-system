using AutoMapper;
using DataAccess;
using DataAccess.CQRS.Queries;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling.Exceptions;

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
            var entityModel = await _queryExecutor.Execute(query);
            if (entityModel is null)
                throw new NotFoundException();

            var domainModel = _mapper.Map<TDtoModelList>(entityModel);
            return new TResponse()
            {
                Response = domainModel
            };
        }
    }
}
