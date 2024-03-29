﻿using AutoMapper;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public class CommandHandler<TCommand, TEntity, TRepository> : ICommandHandler
        where TCommand : CommandBase<TEntity, TRepository>, new()
    {
        private readonly IMapper _mapper;
        private readonly TRepository _repositoryService;

        protected CommandHandler(IMapper mapper, TRepository repositoryService)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
        }

        public async Task HandleRequest<TRequest>(TRequest request)
        {
            var entityModel = _mapper.Map<TEntity>(request);
            var command = new TCommand()
            {
                Parameter = entityModel
            };

            await command.Execute(_repositoryService);
        }
    }
}
