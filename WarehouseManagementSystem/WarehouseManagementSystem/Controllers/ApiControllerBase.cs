using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace warehouse_management_system.Controllers
{
    public abstract class ApiControllerBase<TController> : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TController> _logger;
        protected ApiControllerBase(IMediator mediator, ILogger<TController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into: \n" + typeof(TController).Name);
        }

        protected async Task<IActionResult> Handle<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            _logger.LogInformation("Handling Request: \n" + typeof(TRequest).Name);
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    ModelState.Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            var userName = User.FindFirstValue(ClaimTypes.Name);

            var response = await _mediator.Send(request);
            _logger.LogInformation("Response Errors: \n" + response.Error);

            return response.Error == null ? Ok(response) : ErrorResponse(response.Error);
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
