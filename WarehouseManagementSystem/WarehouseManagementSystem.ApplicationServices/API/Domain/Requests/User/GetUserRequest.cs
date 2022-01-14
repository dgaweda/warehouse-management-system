using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User
{
    public class GetUserRequest : UserRequestBase, IRequest<GetUserResponse>
    {
        public string Username { get; set; }
    }
}
