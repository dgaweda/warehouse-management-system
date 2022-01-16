using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public class GetSenioritiesRequest : IRequest<GetSenioritiesResponse>
    {
        public DateTime EmploymentDate { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

    }
}
