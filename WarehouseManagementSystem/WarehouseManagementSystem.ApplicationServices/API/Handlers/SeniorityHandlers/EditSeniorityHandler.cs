using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.SeniorityCommands;
using DataAccess.Entities;
using DataAccess.Repository.SeniorityRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityHandlers
{
    public class EditSeniorityHandler : 
        CommandHandler<EditSeniorityCommand, Seniority, ISeniorityRepository>,
        IRequestHandler<EditSeniorityRequest, EditSeniorityResponse>
    {
        public EditSeniorityHandler(IMapper mapper, ISeniorityRepository repositoryService) 
            : base(mapper, repositoryService)
        {
        }

        public async Task<EditSeniorityResponse> Handle(EditSeniorityRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new EditSeniorityResponse()
            {
                Response = request.Id
            };
        }
    }
}
