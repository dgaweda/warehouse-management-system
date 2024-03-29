﻿using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class GetDeparturesRequest : RequestBase, IRequest<GetDeparturesResponse>
    {
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }
    }
}