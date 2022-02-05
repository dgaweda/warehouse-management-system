using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductPalletLineController : ApiControllerBase<ProductPalletLineController>
    {
        public ProductPalletLineController(IMediator mediator, ILogger<ProductPalletLineController> logger) 
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("products/{request.PalletId}")]
        public Task<IActionResult> GetProductsByPalletId([FromQuery] GetProductsByPalletIdRequest request) => Handle<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>(request);
    
        [HttpPatch]
        [Route("set/productAmount")]
        public Task<IActionResult> DecreaseProductAmount([FromQuery] DecreaseProductAmountRequest request) => Handle<DecreaseProductAmountRequest, DecreaseProductAmountResponse>(request);
    }
}
