using AutoMapper;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class QueryManager<TEntity, TEntityDto>
    {
        private readonly IMapper _mapper;

        protected QueryManager(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        protected async Task<TResponse> CreateResponse<TResponse>(TEntity entity) where TResponse : ResponseBase<TEntityDto>, new()
        {
            return new TResponse()
            {
                Response = await ToDto(entity)
            };
        }

        private Task<TEntityDto> ToDto(TEntity entity)
        {
            var dto = _mapper.Map<TEntityDto>(entity);
            return Task.FromResult(dto);
        }
    }
}
