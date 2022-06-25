using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ApiControllerBase<LocationController>
    {

        public LocationController(IMediator mediator, ILogger<LocationController> logger) 
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("get")]
        public Task<IActionResult> Get([FromQuery] GetLocationsRequest request) => Handle<GetLocationsRequest, GetLocationsResponse>(request);

        [HttpPost]
        [Route("Add/")]
        public Task<IActionResult> Add([FromBody] AddLocationRequest request) => Handle<AddLocationRequest, AddLocationResponse>(request);

        [HttpPatch]
        [Route("Edit/")]
        public Task<IActionResult> Edit([FromBody] EditLocationRequest request) => Handle<EditLocationRequest, EditLocationResponse>(request);

        [HttpPatch]
        [Route("Edit/CurrentAmount")]
        public Task<IActionResult> EditCurrentAmount([FromQuery] EditLocationCurrentAmountRequest request) => Handle<EditLocationCurrentAmountRequest, EditLocationCurrentAmountResponse>(request);

        [HttpPatch]
        [Route("Set/Location/")]
        public Task<IActionResult> SetProductLocation([FromBody] SetProductLocationRequest request) => Handle<SetProductLocationRequest, SetProductLocationResponse>(request);

        [HttpDelete]
        [Route("Remove/")]
        public Task<IActionResult> Remove([FromQuery] RemoveLocationRequest request) =>  Handle<RemoveLocationRequest, RemoveLocationResponse>(request);
    }
}
