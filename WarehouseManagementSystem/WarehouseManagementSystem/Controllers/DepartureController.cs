using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
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
        public DepartureController(IMediator mediator, IPrivilegesService privileges) 
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("get/")]
        public async Task<IActionResult> GetDepartures([FromQuery] GetDeparturesRequest request) => await Handle<GetDeparturesRequest, GetDeparturesResponse>(request);

        [HttpPost]
        [Route("add/")]
        public async Task<IActionResult> AddDeparture([FromBody] AddDepartureRequest request) => await Handle<AddDepartureRequest, AddDepartureResponse>(request);

        [HttpPatch]
        [Route("edit/")]
        public async Task<IActionResult> EditDepartureState([FromQuery] EditDepartureStateRequest request) => await Handle<EditDepartureStateRequest, EditDepartureStateResponse>(request);

        [HttpDelete]
        [Route("remove/")]
        public async Task<IActionResult> RemoveDeparture([FromBody] RemoveDepartureRequest request) => await Handle<RemoveDepartureRequest, RemoveDepartureResponse>(request);
    }
}
