using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using warehouse_management_system.Authentication.Privileges;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("/api/product/")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {

        public ProductController(IMediator mediator) 
            : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductsRequest request) => await Handle<GetProductsRequest, GetProductsResponse>(request);

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductRequest request) => await Handle<AddProductRequest, AddProductResponse>(request);

        [HttpPatch]
        public async Task<IActionResult> Edit([FromBody] EditProductRequest request) => await Handle<EditProductRequest, EditProductResponse>(request);

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveProductRequest request) => await Handle<RemoveProductRequest, RemoveProductResponse>(request);
    }
}
