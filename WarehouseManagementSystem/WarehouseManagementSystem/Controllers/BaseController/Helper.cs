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
                ErrorType.Forbidden => HttpStatusCode.Forbidden,
                ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
                ErrorType.UnsupportedMediaType => HttpStatusCode.UnsupportedMediaType,
                ErrorType.MethodNotAllowed => HttpStatusCode.MethodNotAllowed,
                ErrorType.TooManyRequests => HttpStatusCode.TooManyRequests,
                ErrorType.NotAuthenticated => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.BadRequest,
            };
        }

        public static bool IsAuthenticating<TRequest>(this ClaimsPrincipal user, TRequest request)
        {
            var requestName = typeof(TRequest).Name;
            var isAuthenticating = requestName.Equals("AuthenticateUserRequest");
            return isAuthenticating;
        }

        public static bool IsPermitted<TRequest>(this ClaimsPrincipal user, TRequest request)
        {
            var requestName = typeof(TRequest).Name;
            var privilegeName = requestName.TrimRequestName();
            return user.HasClaim(x => x.Type.Equals(Privileges) && x.Value.Equals(privilegeName));
        }

        private static string TrimRequestName(this string requestName)
        {
            var privilegeName = requestName.Replace(Request, "");
            return privilegeName;
        }
    }
}