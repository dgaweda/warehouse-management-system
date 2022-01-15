﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetLocationsRequest : IRequest<GetLocationsResponse>
    {
        public string Name { get; set; }
        public DataAccess.Entities.Type LocationType { get; set; }

    }
}
