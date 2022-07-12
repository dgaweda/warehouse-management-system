using System.Security.Claims;

namespace warehouse_management_system.Authentication.Privileges
{
    public interface IPrivilegesService
    {
        void SetUserPrivileges(ClaimsPrincipal claimsPrincipal);
    }
}