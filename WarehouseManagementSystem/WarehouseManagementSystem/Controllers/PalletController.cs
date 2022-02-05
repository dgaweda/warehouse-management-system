using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PalletController : ApiControllerBase<PalletController>
    {
        public PalletController(IMediator mediator, ILogger<PalletController> logger, IPrivilegesService privileges) 
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("get")]
        public Task<IActionResult> Get([FromQuery] GetPalletsRequest request) => Handle<GetPalletsRequest, GetPalletsResponse>(request);
        
        [HttpGet]
        [Route("get/status/{request.PalletStatus}")]
        public Task<IActionResult> GetByStatus([FromQuery] GetPalletsByStatusRequest request) => Handle<GetPalletsByStatusRequest, GetPalletsByStatusResponse>(request);

        [HttpDelete]
        [Route("remove/{request.PalletId}")]
        public Task<IActionResult> Remove([FromQuery] RemovePalletRequest request) => Handle<RemovePalletRequest, RemovePalletResponse>(request);

        [HttpPost]
        [Route("add")]
        public Task<IActionResult> Add([FromBody] AddPalletRequest request) => Handle<AddPalletRequest, AddPalletResponse>(request);

        [HttpPatch]
        [Route("edit/{request.Id}")]
        public Task<IActionResult> SetPalletDestination([FromBody] SetPalletDestinationRequest request) =>  Handle<SetPalletDestinationRequest, SetPalletDestinationResponse>(request);
    }
}
