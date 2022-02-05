using System.Security.Claims;

namespace warehouse_management_system.Authentication
{
    public interface IPrivilegesService
    {
        void SetUserPrivileges(ClaimsPrincipal claimsPrincipal);
    }
}