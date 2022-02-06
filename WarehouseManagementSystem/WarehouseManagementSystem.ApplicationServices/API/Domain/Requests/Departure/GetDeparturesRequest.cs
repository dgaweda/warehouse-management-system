using System;
using DataAccess.Entities;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure
{
    public class GetDeparturesRequest : IRequest<GetDeparturesResponse>
    {
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }
        public StateType State { get; set; }
    }
}