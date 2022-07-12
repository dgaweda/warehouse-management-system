using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication.Privileges;
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
        public PalletController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPalletsRequest request) => await Handle<GetPalletsRequest, GetPalletsResponse>(request);
        
        [HttpGet]
        [Route("by-status")]
        public async Task<IActionResult> GetByStatus([FromQuery] GetPalletsByStatusRequest request) => await Handle<GetPalletsByStatusRequest, GetPalletsByStatusResponse>(request);

        [HttpDelete]
        [Route("{palletId}")]
        public async Task<IActionResult> Remove([FromRoute] int palletId)
        {
            var request = new RemovePalletRequest()
            {
                PalletId = palletId
            };
            return await Handle<RemovePalletRequest, RemovePalletResponse>(request);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] AddPalletRequest request) => await Handle<AddPalletRequest, AddPalletResponse>(request);

        [HttpPatch]
        [Route("edit")]
        public async Task<IActionResult> SetPalletDestination([FromBody] SetPalletDestinationRequest request) => await Handle<SetPalletDestinationRequest, SetPalletDestinationResponse>(request);
    }
}
