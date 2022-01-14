﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class EditLocationRequest : UserRequestBase, IRequest<EditLocationResponse>
    {
        public int Id { get; set; }
        public int? MaxAmount { get; set; }
        public string Name { get; set; }
    }
}
