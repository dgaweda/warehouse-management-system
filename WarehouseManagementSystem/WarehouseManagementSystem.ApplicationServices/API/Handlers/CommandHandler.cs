using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Entities.EntityBases;
using DataAccess.Repository;
using FluentValidation;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class CommandHandler<TRequest, TResponse, TEntity, TEntityDto, TCommand, TRepository>
        : ICommandHandler<TRequest, TResponse, TEntityDto> 
        where TResponse : ResponseBase<TEntityDto>, new()
        where TCommand : CommandBase<TEntity, TRepository>, new()
        where TEntity : EntityBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IRepository<TEntity> _repositoryService;

        protected CommandHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<TEntity> repositoryService)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }

        public async Task<TResponse> HandleRequest(TRequest request)
        {
            var entityData = _mapper.Map<TEntity>(request);
            var command = new TCommand()
            {
                Parameter = entityData
            };
            
            var entityModel = await command.Execute()
            var dtoModel = _mapper.Map<TDtoModel>(entityModel);
            return new TResponse() { Response = dtoModel };
        }
    }
}
