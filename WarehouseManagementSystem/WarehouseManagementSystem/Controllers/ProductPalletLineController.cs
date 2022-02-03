using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPalletLineController : ApiControllerBase<ProductPalletLineController>
    {
        public ProductPalletLineController(IMediator mediator, ILogger<ProductPalletLineController> logger, IPrivilegesService privileges) : base(mediator, logger, privileges)
        {
        }

        [HttpGet]
        [Route("Get/Products/PalletID")]
        public Task<IActionResult> GetProductsByPalletId([FromQuery] GetProductsByPalletIdRequest request) => Handle<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>(request);
    
        [HttpPatch]
        [Route("Set/ProductAmount")]
        public Task<IActionResult> DecreaseProductAmount([FromQuery] DecreaseProductAmountRequest request) => Handle<DecreaseProductAmountRequest, DecreaseProductAmountResponse>(request);
    }
}
