using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority
{
    public class EditSeniorityRequest : RequestBase, IRequest<EditSeniorityResponse>
    {
        public override Guid Id { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int UserId { get; set; }
    }
}