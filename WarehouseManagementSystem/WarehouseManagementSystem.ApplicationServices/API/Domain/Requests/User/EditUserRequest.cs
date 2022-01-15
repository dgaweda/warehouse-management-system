using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee
{
    public class EditUserRequest : IRequest<EditUserResponse>
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Keys.Role RoleId { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
    }
}
