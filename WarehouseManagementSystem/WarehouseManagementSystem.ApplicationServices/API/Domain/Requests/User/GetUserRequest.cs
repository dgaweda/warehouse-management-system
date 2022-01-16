using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public string Username { get; set; }
    }
}
