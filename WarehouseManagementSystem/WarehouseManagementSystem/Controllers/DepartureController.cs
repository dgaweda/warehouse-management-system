using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication.Privileges;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("/api/departure/")]
    [ApiController]
    public class DepartureController : ApiControllerBase
    {
        public DepartureController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartures([FromQuery] GetDeparturesRequest request) => await Handle<GetDeparturesRequest, GetDeparturesResponse>(request);
        
        [HttpGet]
        public async Task<IActionResult> GetDeparturesByState([FromQuery] GetDeparturesByStateRequest request) => await Handle<GetDeparturesByStateRequest, GetDeparturesByStateResponse>(request);

        [HttpPost]
        public async Task<IActionResult> AddDeparture([FromBody] AddDepartureRequest request) => await Handle<AddDepartureRequest, AddDepartureResponse>(request);

        [HttpPatch]
        [Route("departure-state")]
        public async Task<IActionResult> EditDepartureState([FromQuery] EditDepartureStateRequest request) => await Handle<EditDepartureStateRequest, EditDepartureStateResponse>(request);

        [HttpDelete]
        [Route("{DepartureId}")]
        public async Task<IActionResult> RemoveDeparture([FromRoute] RemoveDepartureRequest request) => await Handle<RemoveDepartureRequest, RemoveDepartureResponse>(request);
    }
}
