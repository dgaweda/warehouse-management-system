using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User
{
    public class AuthenticateUserRequest : IRequest<AuthenticateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}