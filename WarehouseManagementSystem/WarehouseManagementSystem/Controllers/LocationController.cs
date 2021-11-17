using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerHandler
    {
        public LocationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetLocations([FromQuery] GetLocationsRequest request) => await Handle(request);

        [HttpPut]
        [Route("Add")]
        public async Task<IActionResult> AddLocation([FromBody] AddLocationRequest request) => await Handle(request);
    }
}
