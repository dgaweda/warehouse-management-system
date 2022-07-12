using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.SeniorityCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityHandlers
{
    public class AddSeniorityHandler :
        CommandHandler<AddSeniorityRequest, AddSeniorityResponse, Seniority, SeniorityDto, AddSeniorityCommand>,
        IRequestHandler<AddSeniorityRequest, AddSeniorityResponse>
    {
        public AddSeniorityHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Seniority> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {

        }

        public async Task<AddSeniorityResponse> Handle(AddSeniorityRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
