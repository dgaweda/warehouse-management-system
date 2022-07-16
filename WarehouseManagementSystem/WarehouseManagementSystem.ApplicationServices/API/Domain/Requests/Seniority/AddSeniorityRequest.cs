using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority
{
    public class AddSeniorityRequest : RequestBase, IRequest<AddSeniorityResponse>
    {
        public DateTime EmploymentDate { get; set; }
        public Guid UserId { get; set; }
    }
}