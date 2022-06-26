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
    [Route("[controller]")]
    [ApiController]
    public class ProductPalletLineController : ApiControllerBase
    {
        public ProductPalletLineController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("Products/")]
        public Task<IActionResult> GetProductsByPalletId([FromQuery] GetProductsByPalletIdRequest request) => Handle<GetProductsByPalletIdRequest, GetProductsByPalletIdResponse>(request);
    
        [HttpPatch]
        [Route("Set/ProductAmount/")]
        public Task<IActionResult> DecreaseProductAmount([FromQuery] DecreaseProductAmountRequest request) => Handle<DecreaseProductAmountRequest, DecreaseProductAmountResponse>(request);
    }
}
