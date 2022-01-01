using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace warehouse_management_system.Controllers
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
            where TResponse : ErrorResponseBase
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            var response = await _mediator.Send(request);
            if(response.Error != null)
            {
                return ErrorResponse(response.Error);
            }
            return Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            return errorType switch
            {
                ErrorType.NotFound => HttpStatusCode.NotFound,
                ErrorType.InternalServerError => HttpStatusCode.InternalServerError,
                ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
                ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
                ErrorType.UnsupportedMediaType => HttpStatusCode.UnsupportedMediaType,
                ErrorType.MethodNotAllowed => HttpStatusCode.MethodNotAllowed,
                ErrorType.TooManyRequests => HttpStatusCode.TooManyRequests,
                _ => HttpStatusCode.BadRequest,
            };
        }
    }
}
