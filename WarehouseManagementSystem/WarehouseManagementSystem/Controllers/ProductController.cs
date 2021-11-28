using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.DeliveryProduct;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {

        public ProductController(IMediator mediator) : base(mediator)
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
