using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IMediator mediator;
        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetRolesRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
