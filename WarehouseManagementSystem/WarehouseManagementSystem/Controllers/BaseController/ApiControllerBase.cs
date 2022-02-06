﻿using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Requests;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace warehouse_management_system.Controllers.BaseController
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
            
            if (User.IsPermitted(request))
            {
                var response = await _mediator.Send(request);
                return response.Error is null ? Ok(response) : ErrorResponse(response.Error);
            }

            return ErrorResponse(new ErrorModel(ErrorType.Unauthorized));
        }
        
        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = errorModel.Error.GetHttpStatusCode();
            return StatusCode((int)httpCode, errorModel);
        }
    }
}
