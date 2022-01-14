using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Departure;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Departure;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DepartureController : ApiControllerBase<DepartureController>
    {
        public DepartureController(IMediator mediator, ILogger<DepartureController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetDepartures([FromQuery] GetDeparturesRequest request) => await Handle<GetDeparturesRequest, GetDeparturesResponse>(request);

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddDeparture([FromBody] AddDepartureRequest request) => await Handle<AddDepartureRequest, AddDepartureResponse>(request);

        [HttpPatch]
        [Route("Edit")]
        public async Task<IActionResult> EditDepartureState([FromQuery] EditDepartureStateRequest request) => await Handle<EditDepartureStateRequest, EditDepartureStateResponse>(request);

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> RemoveDeparture([FromBody] RemoveDepartureRequest request) => await Handle<RemoveDepartureRequest, RemoveDepartureResponse>(request);
    }
}
