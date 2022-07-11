using AutoMapper;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Entities.EntityBases;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class CommandHandler<TCommand, TEntity, TEntityDto, TRepository> : ICommandHandler<TEntityDto>
        where TCommand : CommandBase<TEntity, TRepository>, new()
    {
        private readonly IMapper _mapper;
        private readonly TRepository _repositoryService;

        protected CommandHandler(IMapper mapper, TRepository repositoryService)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
        }

        public async Task<TResponse> HandleRequest<TRequest, TResponse>(TRequest request) 
            where TResponse : ResponseBase<TEntityDto>, new()
        {
            var entityData = _mapper.Map<TEntity>(request);
            var command = new TCommand()
            {
                Parameter = entityData
            };

            await command.Execute(_repositoryService);
        }
    }
}
