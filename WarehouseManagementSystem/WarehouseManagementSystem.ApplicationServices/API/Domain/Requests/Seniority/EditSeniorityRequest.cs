﻿using MediatR;
using System;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority
{
    public class EditSeniorityRequest : CurrentUserContext, IRequest<EditSeniorityResponse>
    {
        public int Id { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int UserId { get; set; }
    }
}
