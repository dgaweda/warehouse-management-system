using System;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority
{
    public class GetSenioritiesRequest : IRequest<GetSenioritiesResponse>
    {
        public DateTime EmploymentDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}