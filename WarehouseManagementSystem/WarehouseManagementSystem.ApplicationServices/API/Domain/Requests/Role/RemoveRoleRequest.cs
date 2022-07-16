﻿using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Role;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Role
{
    public class RemoveRoleRequest : RequestBase, IRequest<RemoveRoleResponse>
    {
        public Guid RoleId { get; set; }
    }
}