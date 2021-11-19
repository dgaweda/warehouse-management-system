using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.DeliveryProduct;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryProductController : ControllerHandler
    {

        public DeliveryProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] GetDeliveryProductsRequest request) => await Handle(request);

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] AddDeliveryProductRequest request) => await Handle(request);

        [HttpPatch]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditDeliveryProductRequest request) => await Handle(request);

        [HttpPatch]
        [Route("Edit/Amount")]
        public async Task<IActionResult> EditAmount([FromBody] EditDeliveryProductAmountRequest request) => await Handle(request);

        [HttpDelete]
        [Route("Remove")]
        public async Task<IActionResult> Remove([FromQuery] RemoveDeliveryProductRequest request) => await Handle(request);
    }
}
