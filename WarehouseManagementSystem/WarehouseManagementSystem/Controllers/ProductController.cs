using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.DeliveryProduct;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase<ProductController>
    {

        public ProductController(IMediator mediator, ILogger<ProductController> logger, IPrivilegesService privileges) 
            : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("Get")]
        public Task<IActionResult> Get([FromQuery] GetProductsRequest request) =>Handle<GetProductsRequest, GetProductsResponse>(request);

        [HttpPost]
        [Route("Add")]
        public Task<IActionResult> Add([FromBody] AddProductRequest request) => Handle<AddProductRequest, AddProductResponse>(request);

        [HttpPatch]
        [Route("Edit")]
        public Task<IActionResult> Edit([FromBody] EditProductRequest request) => Handle<EditProductRequest, EditProductResponse>(request);

        [HttpDelete]
        [Route("Remove")]
        public Task<IActionResult> Remove([FromQuery] RemoveProductRequest request) => Handle<RemoveProductRequest, RemoveProductResponse>(request);
    }
}
