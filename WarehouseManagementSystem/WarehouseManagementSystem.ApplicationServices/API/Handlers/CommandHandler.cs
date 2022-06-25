﻿using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using System.Threading.Tasks;
using DataAccess.Entities.EntityBases;
using DataAccess.Repository;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class CommandHandler<TRequest, TResponse, TEntity, TDomainModel, TCommand>
        : ICommandHandler<TRequest, TResponse, TDomainModel> 
        where TResponse : ResponseBase<TDomainModel>, new()
        where TCommand : CommandBase<TEntity, TEntity>, new()
        where TEntity : class, IEntityBase
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

        public async Task<TResponse> GetResponse(TRequest request)
        {
            var entityData = _mapper.Map<TEntity>(request);
            var command = new TCommand()
            {
                Parameter = entityData
            };
            
            var entityModel = await _commandExecutor.Execute(command, _repositoryService);
            var domainModel = _mapper.Map<TDomainModel>(entityModel);
            return new TResponse()
            {
                Data = domainModel
            };
        }
    }
}
