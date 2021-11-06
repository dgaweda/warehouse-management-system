using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerHandler
    {
        public InvoiceController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetInvoices([FromQuery] GetInvoicesRequest request) => await Handle<GetInvoicesRequest>(request);

        //[HttpPost]
       // [Route("Add")]
        //public async Task<IActionResult> AddInvoice([FromBody] AddInvoiceRequest request) => await Handle<AddInvoiceRequest>(request);
    }
}
