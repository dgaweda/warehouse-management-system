using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.CQRS.Command.SeniorityCommands;
using DataAccess.CQRS.Command.SeniorityCommands;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.SeniorityRepository;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Models;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.SeniorityHandlers
{
    public class AddSeniorityHandler :
        CommandHandler<AddSeniorityCommand, Seniority, ISeniorityRepository>,
        IRequestHandler<AddSeniorityRequest, AddSeniorityResponse>
    {
        public AddSeniorityHandler(IMapper mapper, ISeniorityRepository repositoryService) 
            : base(mapper, repositoryService)
        {

        }

        public async Task<AddSeniorityResponse> Handle(AddSeniorityRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request);
            return new AddSeniorityResponse()
            {
                Response = request.Id
            };
        }
    }
}
