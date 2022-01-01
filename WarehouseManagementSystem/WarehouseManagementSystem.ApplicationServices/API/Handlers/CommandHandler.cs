using AutoMapper;
using DataAccess;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands;
using DataAccess.CQRS.Commands.InvoiceCommands;
using DataAccess.Entities.EntityBases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            var mappedEntityWithRequestData = Map(request);
            var command = CreateCommand(mappedEntityWithRequestData);
            var entityModel = await Execute(command);
            var domainModel = MapDomainModel(entityModel);
            var response = CreateResponse(domainModel);
            return response;
        }
        private TEntity Map(TRequest request) => _mapper.Map<TEntity>(request);

        private static TCommand CreateCommand(TEntity entityWithRequestData) => new() { Parameter = entityWithRequestData };

        private async Task<TEntity> Execute(TCommand command) => await _commandExecutor.Execute(command);

        private TDomainModel MapDomainModel(TEntity entityModel) => _mapper.Map<TDomainModel>(entityModel);

        private static TResponse CreateResponse(TDomainModel domainModel) => new() { Data = domainModel };
    }
}
