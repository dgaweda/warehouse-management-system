﻿using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class GetLocationsByNameRequest : RequestBase, IRequest<GetLocationsByNameResponse>
    {
        public string Name { get; set; }
    }
}