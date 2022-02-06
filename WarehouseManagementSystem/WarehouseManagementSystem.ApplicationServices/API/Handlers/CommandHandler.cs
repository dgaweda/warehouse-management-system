using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class CommandHandler<TRequest, TResponse, TEntity, TDomainModel, TCommand>
        : ICommandHandler<TRequest, TResponse, TDomainModel> 
        where TResponse : ResponseBase<TDomainModel>, new()
        where TCommand : CommandBase<TEntity, TEntity>, new()
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;

        protected CommandHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }

        public async Task<TResponse> PrepareResponse(TRequest request)
        {
            var entityData = _mapper.Map<TEntity>(request);
            var command = new TCommand() { Parameter = entityData };
            
            var entityModel = await _commandExecutor.Execute(command);
            var domainModel = _mapper.Map<TDomainModel>(entityModel);
            return new TResponse()
            {
                Data = domainModel
            };
        }
    }
}
