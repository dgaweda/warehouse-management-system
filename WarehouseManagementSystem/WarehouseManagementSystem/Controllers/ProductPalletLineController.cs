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
    [Route("/api/pallet/{palletId}/products/")]
    [ApiController]
    public class ProductPalletLineController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public ProductPalletLineController(IMediator mediator) 
            : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProductsByPalletId([FromRoute] int palletId)
        {
            return await Handle<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>
                (new GetProductsByPalletIdRequest() { PalletId = palletId });
        }
    
        [HttpPatch]
        [Route("{productId}/amount")]
        public async Task<IActionResult> DecreaseProductAmount([FromRoute] int palletId, [FromRoute] int productId,  [FromBody] int amount)
        {
            var request = new DecreaseProductAmountRequest()
            {
                PalletId = palletId,
                ProductAmount = amount,
                ProductId = productId
            };
            return await Handle<DecreaseProductAmountRequest, DecreaseProductAmountResponse>(request);
        }
    }
}
