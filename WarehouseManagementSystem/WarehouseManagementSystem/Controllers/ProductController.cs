using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Authentication;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Product;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Product;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {

        public ProductController(IMediator mediator, IPrivilegesService privileges) 
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get/")]
        public Task<IActionResult> Get([FromQuery] GetProductsRequest request) =>Handle<GetProductsRequest, GetProductsResponse>(request);

        [HttpPost]
        [Route("Add/")]
        public Task<IActionResult> Add([FromBody] AddProductRequest request) => Handle<AddProductRequest, AddProductResponse>(request);

        [HttpPatch]
        [Route("Edit/")]
        public Task<IActionResult> Edit([FromBody] EditProductRequest request) => Handle<EditProductRequest, EditProductResponse>(request);

        [HttpDelete]
        [Route("Remove/")]
        public Task<IActionResult> Remove([FromQuery] RemoveProductRequest request) => Handle<RemoveProductRequest, RemoveProductResponse>(request);
    }
}
