using System.Security.Claims;

namespace warehouse_management_system.Authentication
{
    public interface IPrivilegesService
    {
        ClaimsIdentity SetUserPrivileges(ClaimsPrincipal user);
    }
}