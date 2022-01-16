using DataAccess.Entities;
using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetDeparturesRequest : CurrentUserContext, IRequest<GetDeparturesResponse>
    {
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }
        public StateType State { get; set; }
    }
}
