using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace warehouse_management_system.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogMiddleware> _logger;

        public LogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LogMiddleware>();
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
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
    }
}