using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Users;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
        public string UserName { get; set; }
    }
}
