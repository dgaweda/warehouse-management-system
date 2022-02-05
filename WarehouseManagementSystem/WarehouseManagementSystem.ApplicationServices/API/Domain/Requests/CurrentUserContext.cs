using System.Security.Claims;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public abstract class CurrentUserContext
    {
        private const string Privileges = "Privileges";
        private const string Request = "Request";
        
        public string CurrentUserID { get; set; }

        public bool UserIsPermitted(string requestName, IHttpContextAccessor httpContextAccessor)
        {
            var privilegeName = TrimRequestName(requestName);
            return httpContextAccessor.HttpContext.User.HasClaim(x => x.Type.Equals(Privileges) && x.Value.Equals(privilegeName));
        }

        private string TrimRequestName(string requestName)
        {
            var privilegeName = requestName.Replace(Request, "");
            return privilegeName;
        }
    }
}