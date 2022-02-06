using System;
using System.Net;
using System.Security.Claims;
using DataAccess.Migrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;
using WarehouseManagementSystem.ApplicationServices.API.ErrorHandling;

namespace warehouse_management_system.Controllers.BaseController
{
    public static class Helper
    {
        private const string Privileges = "Privileges";
        private const string Request = "Request";
        
        public static HttpStatusCode GetHttpStatusCode(this string errorType)
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

        public static bool IsPermitted<TRequest>(this ClaimsPrincipal user, TRequest request)
        {
            var requestName = typeof(TRequest).Name;
            var privilegeName = TrimRequestName(requestName);
            return user.HasClaim(x => x.Type.Equals(Privileges) && x.Value.Equals(privilegeName));
        }

        private static string TrimRequestName(string requestName)
        {
            var privilegeName = requestName.Replace(Request, "");
            return privilegeName;
        }
    }
}