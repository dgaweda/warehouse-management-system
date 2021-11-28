﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Seniority;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Seniority
{
    public class EditSeniorityRequest : IRequest<EditSeniorityResponse>
    {
        public int Id { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int EmployeeId { get; set; }
    }
}