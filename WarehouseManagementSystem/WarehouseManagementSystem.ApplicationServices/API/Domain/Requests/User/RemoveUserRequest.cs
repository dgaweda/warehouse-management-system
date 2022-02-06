using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public int UserId { get; set; }
    }
}