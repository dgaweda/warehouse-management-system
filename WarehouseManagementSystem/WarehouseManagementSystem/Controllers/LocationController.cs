using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;

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
        public async Task<IActionResult> Get([FromQuery] GetLocationsRequest request) => await Handle(request);

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddLocationRequest request) => await Handle(request);

        [HttpPatch]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditLocationRequest request) => await Handle(request);

        [HttpPatch]
        [Route("Edit/CurrentAmount")]
        public async Task<IActionResult> EditCurrentAmount([FromQuery] EditLocationCurrentAmountRequest request) => await Handle(request);

        [HttpPatch]
        [Route("Set/Location")]
        public async Task<IActionResult> SetProductLocation([FromBody] SetProductLocationRequest request) => await Handle(request);

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromQuery] RemoveLocationRequest request) => await Handle(request);
    }
}
