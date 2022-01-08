using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
        public int? UserId { get; set; }
        public string RoleName { get; set; }
        public string PESEL { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
