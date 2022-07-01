using System.Security.Claims;

namespace warehouse_management_system.Controllers.BaseController
{
    public static class ApiControllerBaseExtension
    {
        private const string Privileges = "Privileges";
        private const string Request = "Request";

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