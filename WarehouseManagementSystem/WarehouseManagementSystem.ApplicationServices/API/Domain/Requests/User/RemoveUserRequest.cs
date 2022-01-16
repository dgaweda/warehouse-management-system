using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public int UserId { get; set; }
    }
}
