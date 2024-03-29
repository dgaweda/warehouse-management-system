﻿using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class AddDepartureRequest : RequestBase, IRequest<AddDepartureResponse>
    {
        public string Name { get; set; }
    }
}