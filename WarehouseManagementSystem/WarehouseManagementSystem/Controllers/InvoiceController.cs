using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetInvoices([FromQuery] GetInvoicesRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
