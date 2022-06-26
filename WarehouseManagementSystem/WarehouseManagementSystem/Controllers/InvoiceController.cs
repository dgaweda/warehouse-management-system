﻿using MediatR;
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
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ApiControllerBase
    {
        public InvoiceController(IMediator mediator) 
            : base(mediator)
        {

        }

        [HttpGet]
        [Route("Get/")]
        public Task<IActionResult> GetInvoices([FromQuery] GetInvoicesRequest request) => Handle<GetInvoicesRequest, GetInvoicesResponse>(request);

        [HttpPost]
        [Route("Add/")]
        public Task<IActionResult> AddInvoice([FromBody] AddInvoiceRequest request) => Handle<AddInvoiceRequest, AddInvoiceResponse>(request);

        [HttpDelete]
        [Route("Remove/")]
        public Task<IActionResult> RemoveInvoice([FromQuery] RemoveInvoiceRequest request) => Handle<RemoveInvoiceRequest, RemoveInvoiceResponse>(request);

        [HttpPut]
        [Route("Edit/")]
        public Task<IActionResult> EditInvoice([FromBody] EditInvoiceRequest request) => Handle<EditInvoiceRequest, EditInvoiceResponse>(request);
    }
}
