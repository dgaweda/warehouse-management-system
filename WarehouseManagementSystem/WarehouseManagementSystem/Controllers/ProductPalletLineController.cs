using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.ProductsPallets;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("/api/pallet/")]
    [ApiController]
    public class ProductPalletLineController : ApiControllerBase
    {
        public ProductPalletLineController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("{palletId}/products")]
        public async Task<IActionResult> GetProductsByPalletId([FromRoute] GetProductsByPalletIdRequest request) => await Handle<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>(request);

        [HttpPatch]
        [Route("decrease-product-amount")]
        public async Task<IActionResult> DecreaseProductAmount([FromBody] DecreaseProductAmountRequest request) => await Handle<DecreaseProductAmountRequest, DecreaseProductAmountResponse>(request);
    }
}
