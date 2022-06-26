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
    [Route("/api/location/")]
    [ApiController]
    public class LocationController : ApiControllerBase
    {

        public LocationController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetLocationsRequest request) => await Handle<GetLocationsRequest, GetLocationsResponse>(request);

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] AddLocationRequest request) => await Handle<AddLocationRequest, AddLocationResponse>(request);

        [HttpPatch]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] EditLocationRequest request) => await Handle<EditLocationRequest, EditLocationResponse>(request);

        [HttpPatch]
        [Route("edit/current-amount")]
        public async Task<IActionResult> EditCurrentAmount([FromQuery] EditLocationCurrentAmountRequest request) => await Handle<EditLocationCurrentAmountRequest, EditLocationCurrentAmountResponse>(request);

        [HttpPatch]
        [Route("edit/product-location")]
        public async Task<IActionResult> SetProductLocation([FromBody] SetProductLocationRequest request) => await Handle<SetProductLocationRequest, SetProductLocationResponse>(request);

        [HttpDelete]
        [Route("remove/{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveLocationRequest request) => await Handle<RemoveLocationRequest, RemoveLocationResponse>(request);
    }
}
