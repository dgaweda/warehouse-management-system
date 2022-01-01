using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ApiControllerBase<InvoiceController>
    {
        public InvoiceController(IMediator mediator, ILogger<InvoiceController> logger) : base(mediator, logger)
        {

        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetInvoices([FromQuery] GetInvoicesRequest request) => Handle<GetInvoicesRequest, GetInvoicesResponse>(request);

        [HttpPost]
        [Route("Add")]
        public Task<IActionResult> AddInvoice([FromBody] AddInvoiceRequest request) => Handle<AddInvoiceRequest, AddInvoiceResponse>(request);

        [HttpDelete]
        [Route("Remove")]
        public Task<IActionResult> RemoveInvoice([FromQuery] RemoveInvoiceRequest request) => Handle<RemoveInvoiceRequest, RemoveInvoiceResponse>(request);

        [HttpPut]
        [Route("Edit")]
        public Task<IActionResult> EditInvoice([FromBody] EditInvoiceRequest request) => Handle<EditInvoiceRequest, EditInvoiceResponse>(request);
    }
}
