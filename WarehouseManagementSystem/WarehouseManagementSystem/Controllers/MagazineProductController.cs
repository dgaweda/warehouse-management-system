using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;

namespace warehouse_management_system.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MagazineProductController : ControllerBase
    {
        private IMediator mediator;
        public MagazineProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllMagazineProducts([FromQuery] GetMagazineProductsRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
