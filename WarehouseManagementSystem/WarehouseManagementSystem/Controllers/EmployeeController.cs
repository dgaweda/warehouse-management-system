using DataAccess.Repository;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Employee;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace warehouse_management_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ApiControllerBase
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request) => await Handle<AddEmployeeRequest, AddEmployeeResponse>(request);

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetEmployees([FromQuery] GetEmployeesRequest request) => await Handle<GetEmployeesRequest, GetEmployeesResponse>(request);

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditEmployee([FromBody] EditEmployeeRequest request) => await Handle<EditEmployeeRequest, EditEmployeeResponse>(request);

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> RemoveEmployee([FromQuery] RemoveEmployeeRequest request) => await Handle<RemoveEmployeeRequest, RemoveEmployeeResponse>(request);
    }
}
