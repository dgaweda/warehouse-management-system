using System.Net;
using System.Security.Claims;
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

        public static bool IsAuthenticateUserRequest<TRequest>(this TRequest request)
        {
            return request.GetRequestName().Equals("AuthenticateUser");
        }

        public static bool IsPermitted<TRequest>(this ClaimsPrincipal user, TRequest request)
        {
            var privilege = request.GetRequestName();
            return user.HasClaim(x => x.Type.Equals(Privileges) && x.Value.Equals(privilege));
        }
        
        private static string GetRequestName<TRequest>(this TRequest request)
        {
            return typeof(TRequest).Name.Replace(Request, "");
        }
    }
}