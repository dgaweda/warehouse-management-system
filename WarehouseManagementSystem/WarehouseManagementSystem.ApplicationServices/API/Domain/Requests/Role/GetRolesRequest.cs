﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain
{
    public class GetRolesRequest : UserRequestBase, IRequest<GetRolesResponse>
    {
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}
