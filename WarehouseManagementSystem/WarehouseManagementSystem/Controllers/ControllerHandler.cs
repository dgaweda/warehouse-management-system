using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace warehouse_management_system.Controllers
{
    public class ControllerHandler : ControllerBase
    {
        private readonly IMediator _mediator;
        public ControllerHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Handle<TRequest>(TRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
