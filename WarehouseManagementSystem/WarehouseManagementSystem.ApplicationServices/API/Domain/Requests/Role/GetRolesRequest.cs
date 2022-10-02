using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role
{
    public class GetRolesRequest : RequestBase, IRequest<GetRolesResponse>
    {
        public string RoleName { get; set; }
        public override Guid Id { get; set; }
    }
}