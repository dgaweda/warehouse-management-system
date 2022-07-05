using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using System.Threading.Tasks;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Entities;
using DataAccess.Entities.EntityBases;
using DataAccess.Repository;
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
        private readonly TRepository _repositoryService;

        protected CommandHandler(IMapper mapper, TRepository repositoryService)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
        }

        public async Task<TResponse> HandleRequest(TRequest request)
        {
            var entityModel = _mapper.Map<TEntity>(request);
            var command = new TCommand()
            {
                Parameter = entityModel
            };

            var entityData = await command.Execute(_repositoryService);
            var dtoModel = _mapper.Map<TEntityDto>(entityData);
            return new TResponse() { Response = dtoModel };
        }
    }
}
