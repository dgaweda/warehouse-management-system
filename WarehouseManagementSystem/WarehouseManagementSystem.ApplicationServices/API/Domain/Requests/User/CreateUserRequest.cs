using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Users;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string Email { get; set; }
    }
}
