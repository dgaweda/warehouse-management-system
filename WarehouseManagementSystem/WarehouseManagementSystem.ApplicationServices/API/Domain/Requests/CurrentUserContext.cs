using System.Security.Claims;
using DataAccess.CQRS.Queries.UsersQueries;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.VisualBasic;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public abstract class CurrentUserContext
    {
        private const string Privileges = "Privileges";
        private const string Request = "Request";
        public ClaimsIdentity CurrentUser { get; set; }

        public bool UserIsPermitted(string requestName)
        {
            var privilegeName = TrimRequestName(requestName);
            return CurrentUser.HasClaim(x => x.Type == Privileges && x.Value == privilegeName);
        }

        private static string TrimRequestName(string requestName)
        {
            var privilegeName = requestName.Replace(Request, "");
            return privilegeName;
        }
    }
}