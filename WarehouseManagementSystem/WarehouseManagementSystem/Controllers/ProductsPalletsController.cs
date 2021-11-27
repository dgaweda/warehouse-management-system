using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace warehouse_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsPalletsController : ControllerHandler
    {
        public ProductsPalletsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get/Products/PalletID")]
        public async Task<IActionResult> GetProductsByPalletId([FromQuery] GetProductsByPalletIdRequest request) => await Handle(request);
    
        [HttpPatch]
        [Route("Set/ProductAmount")]
        public async Task<IActionResult> SetProductAmount([FromQuery] SetProductAmountRequest request) => await Handle(request);
    }
}
