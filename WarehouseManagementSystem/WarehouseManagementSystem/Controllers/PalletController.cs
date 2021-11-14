using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Pallet;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PalletController : ControllerHandler
    {
        public PalletController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetPallets([FromQuery] GetPalletsRequest request) => await Handle(request);

        [HttpDelete]
        [Route("Edit")]
        public async Task<IActionResult> RemovePallet([FromQuery] RemovePalletRequest request) => await Handle(request);
    }
}
