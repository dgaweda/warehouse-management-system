using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS;
using DataAccess.CQRS.Commands.SeniorityCommands;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityHandlers
{
    public class AddSeniorityHandler :
        CommandHandler<AddSeniorityRequest, AddSeniorityResponse, Seniority, Domain.Models.Seniority, AddSeniorityCommand>,
        IRequestHandler<AddSeniorityRequest, AddSeniorityResponse>
    {
        public AddSeniorityHandler(IMapper mapper, ICommandExecutor commandExecutor) : base(mapper, commandExecutor)
        {

        }

        public async Task<AddSeniorityResponse> Handle(AddSeniorityRequest request, CancellationToken cancellationToken) => await PrepareResponse(request);
    }
}
