using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Pallet;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("/api/pallet/")]
    [ApiController]
    public class PalletController : ApiControllerBase
    {
        public PalletController(IMediator mediator, IPrivilegesService privileges) 
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("get/")]
        public Task<IActionResult> Get([FromQuery] GetPalletsRequest request) => Handle<GetPalletsRequest, GetPalletsResponse>(request);
        
        [HttpGet]
        [Route("status/")]
        public Task<IActionResult> GetByStatus([FromQuery] GetPalletsByStatusRequest request) => Handle<GetPalletsByStatusRequest, GetPalletsByStatusResponse>(request);

        [HttpDelete]
        [Route("remove/")]
        public Task<IActionResult> Remove([FromQuery] RemovePalletRequest request) => Handle<RemovePalletRequest, RemovePalletResponse>(request);

        [HttpPost]
        [Route("add/")]
        public Task<IActionResult> Add([FromBody] AddPalletRequest request) => Handle<AddPalletRequest, AddPalletResponse>(request);

        [HttpPatch]
        [Route("edit/")]
        public Task<IActionResult> SetPalletDestination([FromBody] SetPalletDestinationRequest request) =>  Handle<SetPalletDestinationRequest, SetPalletDestinationResponse>(request);
    }
}
