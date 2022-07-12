using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        [Route("{Id}")]
        public async Task<IActionResult> GetLocationById([FromRoute] GetLocationByIdRequest request) => await Handle<GetLocationByIdRequest, GetLocationByIdResponse>(request);
        
        [HttpGet]
        public async Task<IActionResult> GetLocationsByName([FromQuery] GetLocationsByNameRequest request) => await Handle<GetLocationsByNameRequest, GetLocationsByNameResponse>(request);

        [HttpGet]
        public async Task<IActionResult> GetLocationsByType([FromQuery] GetLocationsByTypeRequest request) => await Handle<GetLocationsByTypeRequest, GetLocationsByTypeResponse>(request);

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddLocationRequest request) => await Handle<AddLocationRequest, AddLocationResponse>(request);

        [HttpPatch]
        public async Task<IActionResult> Edit([FromBody] EditLocationRequest request) => await Handle<EditLocationRequest, EditLocationResponse>(request);

        [HttpPatch]
        [Route("current-amount")]
        public async Task<IActionResult> EditCurrentAmount([FromQuery] EditLocationCurrentAmountRequest request) => await Handle<EditLocationCurrentAmountRequest, EditLocationCurrentAmountResponse>(request);

        [HttpPatch]
        [Route("product-location")]
        public async Task<IActionResult> SetProductLocation([FromBody] SetProductLocationRequest request) => await Handle<SetProductLocationRequest, SetProductLocationResponse>(request);

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveLocationRequest request) => await Handle<RemoveLocationRequest, RemoveLocationResponse>(request);
    }
}
