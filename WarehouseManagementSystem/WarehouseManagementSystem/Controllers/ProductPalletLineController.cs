using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace warehouse_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPalletLineController : ApiControllerBase
    {
        public ProductPalletLineController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get/Products/PalletID")]
        public Task<IActionResult> GetProductsByPalletId([FromQuery] GetProductsByPalletIdRequest request) => Handle<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>(request);
    
        [HttpPatch]
        [Route("Set/ProductAmount")]
        public Task<IActionResult> SetProductAmount([FromQuery] SetProductAmountRequest request) => Handle<SetProductAmountRequest, SetProductAmountResponse>(request);
    }
}
