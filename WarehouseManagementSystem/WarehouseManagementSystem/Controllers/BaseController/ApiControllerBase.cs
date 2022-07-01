using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace warehouse_management_system.Controllers.BaseController
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        protected ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> Handle<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
        {
            if (User.IsPermitted(request))
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }

            throw new ForbidException();
        }
    }
}
