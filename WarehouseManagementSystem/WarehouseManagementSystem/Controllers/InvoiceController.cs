using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using warehouse_management_system.Controllers.BaseController;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Invoice;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Invoice;

namespace warehouse_management_system.Controllers
{
    [Authorize]
    [Route("/api/invoice/")]
    [ApiController]
    public class InvoiceController : ApiControllerBase
    {
        public InvoiceController(IMediator mediator) 
            : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices([FromQuery] GetInvoicesRequest request) => await Handle<GetInvoicesRequest, GetInvoicesResponse>(request);

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody] AddInvoiceRequest request) => await Handle<AddInvoiceRequest, AddInvoiceResponse>(request);

        [HttpDelete]
        [Route("{InvoiceId}")]
        public async Task<IActionResult> RemoveInvoice([FromRoute] RemoveInvoiceRequest request) => await Handle<RemoveInvoiceRequest, RemoveInvoiceResponse>(request);

        [HttpPut]
        public async Task<IActionResult> EditInvoice([FromBody] EditInvoiceRequest request) => await Handle<EditInvoiceRequest, EditInvoiceResponse>(request);
    }
}
