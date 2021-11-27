using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.ProductsPallets;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerHandler
    {

        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] GetProductsRequest request) => await Handle(request);

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddProductRequest request) => await Handle(request);

        [HttpPatch]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditProductRequest request) => await Handle(request);

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromQuery] RemoveProductRequest request) => await Handle(request);
    }
}
