using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PalletController : ApiControllerBase<PalletController>
    {
        public PalletController(IMediator mediator, ILogger<PalletController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("Get")]
        public Task<IActionResult> Get([FromQuery] GetPalletsRequest request) => Handle<GetPalletsRequest, GetPalletsResponse>(request);
        
        [HttpGet]
        [Route("Get/Status")]
        public Task<IActionResult> GetByStatus([FromQuery] GetPalletsByStatusRequest request) => Handle<GetPalletsByStatusRequest, GetPalletsByStatusResponse>(request);

        [HttpDelete]
        [Route("Remove")]
        public Task<IActionResult> Remove([FromQuery] RemovePalletRequest request) => Handle<RemovePalletRequest, RemovePalletResponse>(request);

        [HttpPost]
        [Route("Add")]
        public Task<IActionResult> Add([FromBody] AddPalletRequest request) => Handle<AddPalletRequest, AddPalletResponse>(request);

        [HttpPatch]
        [Route("Edit")]
        public Task<IActionResult> SetPalletDestination([FromBody] SetPalletDestinationRequest request) =>  Handle<SetPalletDestinationRequest, SetPalletDestinationResponse>(request);
    }
}
