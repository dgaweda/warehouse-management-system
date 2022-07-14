using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.User;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.User
{
    public class RemoveUserRequest : RequestBase, IRequest<RemoveUserResponse>
    {
        public override Guid Id { get; set; }
    }
}