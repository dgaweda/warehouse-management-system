using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using DataAccess.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

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
                _logger.LogInformation("-- {HttpProtocol} -- {Method} -- {Host}{Url} => HTTP Response: {StatusCode} --",
                    context.Request.Method,
                    context.Request.Protocol,
                    context.Request.Host,
                    context.Request.Path.Value,
                    context.Response.StatusCode);
                await _next(context);
            }
            catch (ValidationException exception)
            {
                await HandleValidationException(exception, context);
            }
            catch (NotFoundException exception)
            {
                await SetHttpContextResponse((int)HttpStatusCode.NotFound, exception, context);
            }
            catch (AuthenticationException exception)
            {
                await SetHttpContextResponse((int)HttpStatusCode.Unauthorized, exception, context);
            }
            catch (ForbidException exception)
            {
                await SetHttpContextResponse((int)HttpStatusCode.Forbidden, exception, context);
            }
            catch (Exception exception)
            {
                await SetHttpContextResponse(500, exception, context);
            }
        }

        private async Task SetHttpContextResponse(int statusCode, Exception exception, HttpContext context)
        {
            _logger.LogError("-- {msg} --", exception.Message);
            _logger.LogError(exception.StackTrace);
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json; charset=UTF-8";
            await context.Response.WriteAsJsonAsync(new { errorMessage = exception.Message});
        }

        private async Task HandleValidationException(ValidationException exception, HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json; charset=UTF-8";
            _logger.LogError("-- Validation Failed --");
            foreach (var failure in exception.Errors)
            {
                _logger.LogError($"-- {failure.PropertyName}: {failure.AttemptedValue} -- {failure.ErrorMessage} --");
                await context.Response.WriteAsJsonAsync(new {
                        property = failure.PropertyName, 
                        value = failure.AttemptedValue, 
                        message = failure.ErrorMessage
                    });
            }
        }
    }
}