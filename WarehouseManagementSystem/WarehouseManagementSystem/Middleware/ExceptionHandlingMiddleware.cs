using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling.Exceptions;

namespace warehouse_management_system.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionHandlingMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                await HandleValidationException(exception, context);
            }
            catch (NotFoundException exception)
            {
                await SetHttpContextResponse((int)HttpStatusCode.NotFound, exception.Message, context);
            }
            catch (NotAuthenticatedException exception)
            {
                await SetHttpContextResponse((int)HttpStatusCode.Unauthorized, exception.Message, context);
            }
            catch (Exception exception)
            {
                await SetHttpContextResponse(500, exception.Message, context);
            }
            finally
            {
                _logger.LogInformation("-- {HttpProtocol} -- {Method} -- {Host}{Url} => HTTP Response: {StatusCode} --",
                    context.Request.Method,
                    context.Request.Protocol,
                    context.Request.Host,
                    context.Request.Path.Value,
                    context.Response.StatusCode);
            }
        }

        private async Task SetHttpContextResponse(int statusCode, string message, HttpContext context)
        {
            _logger.LogError("-- {Message} --", message);
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json; charset=UTF-8";
            await context.Response.WriteAsJsonAsync(new ErrorModel(message));
        }

        private async Task HandleValidationException(ValidationException exception, HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json; charset=UTF-8";
            _logger.LogError("-- Validation Failed --");
            foreach (var failure in exception.Errors)
            {
                _logger.LogError($"-- {failure.PropertyName}: {failure.AttemptedValue} -- {failure.ErrorMessage} --");
                await context.Response.WriteAsJsonAsync(new ErrorModel(failure.PropertyName, failure.AttemptedValue, failure.ErrorMessage));
            }
        }
    }
}