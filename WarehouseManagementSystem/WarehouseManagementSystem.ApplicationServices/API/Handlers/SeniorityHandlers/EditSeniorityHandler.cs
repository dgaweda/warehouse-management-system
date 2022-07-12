using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Commands.SeniorityCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityHandlers
{
    public class EditSeniorityHandler : 
        CommandHandler<EditSeniorityRequest, EditSeniorityResponse, Seniority, Domain.Models.SeniorityDto, EditSeniorityCommand>,
        IRequestHandler<EditSeniorityRequest, EditSeniorityResponse>
    {
        public EditSeniorityHandler(IMapper mapper, ICommandExecutor commandExecutor, IRepository<Seniority> repositoryService) 
            : base(mapper, commandExecutor, repositoryService)
        {
        }

        public async Task<EditSeniorityResponse> Handle(EditSeniorityRequest request, CancellationToken cancellationToken) => await HandleRequest(request);
    }
}
