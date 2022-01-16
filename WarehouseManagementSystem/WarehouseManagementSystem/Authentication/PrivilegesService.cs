using System;
using System.Collections.Generic;
using System.Security.Claims;
using WarehouseManagementSystem.ApplicationServices.API.Enums;


namespace warehouse_management_system.Authentication
{
    public class PrivilegesService : Privileges, IPrivilegesService
    {
        public ClaimsPrincipal SetUserPrivileges(ClaimsPrincipal user)
        {
            var role = ParseUserRoleToEnum(user);
            var claims = new List<Claim>();
            
            switch (role)
            {
                case Keys.Role.GENERAL_ADMIN:
                    claims = SetGeneralAdminPrivileges();
                    break;
                case Keys.Role.MANAGER:
                    claims = SetManagerPrivileges();
                    break;
                case Keys.Role.WAREHOUSEMAN:
                    claims = SetWarehouseManPrivileges();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            AddUserClaims(claims, user);
            
            return user;
        }
        
        private static Keys.Role ParseUserRoleToEnum(ClaimsPrincipal user)
        {
            var roleIdString = user.FindFirstValue(ClaimTypes.Role);
            
            var success = int.TryParse(roleIdString, out var roleId);
            var role = (Keys.Role)roleId;
            
            return role;
        }

        private static void AddUserClaims(List<Claim> claims, ClaimsPrincipal user)
        {
            var identity = new ClaimsIdentity(claims);
            user.AddIdentity(identity);
        }
        
        private List<Claim> SetWarehouseManPrivileges()
        {
            return new()
            {
                AddClaim(Claims.ADD_PALLET),
                AddClaim(Claims.ADD_INVOICE),
                AddClaim(Claims.ADD_PRODUCT),
                AddClaim(Claims.GET_PALLETS),
                AddClaim(Claims.ADD_DELIVERY),
                AddClaim(Claims.ADD_LOCATION),
                AddClaim(Claims.EDIT_INVOICE),
                AddClaim(Claims.EDIT_PRODUCT),
                AddClaim(Claims.GET_INVOICES),
                AddClaim(Claims.GET_LOCATION),
                AddClaim(Claims.GET_PRODUCTS),
                AddClaim(Claims.ADD_DEPARTURE),
                AddClaim(Claims.EDIT_DELIVERY),
                AddClaim(Claims.EDIT_LOCATION),
                AddClaim(Claims.GET_DEPARTURE),
                AddClaim(Claims.REMOVE_PALLET),
                AddClaim(Claims.EDIT_DEPARTURE),
                AddClaim(Claims.GET_DELIVERIES),
                AddClaim(Claims.REMOVE_PRODUCT),
                AddClaim(Claims.REMOVE_DELIVERY),
                AddClaim(Claims.REMOVE_LOCATION),
                AddClaim(Claims.REMOVE_DEPARTURE),
                AddClaim(Claims.GET_PALLETS_BY_STATUS),
                AddClaim(Claims.SET_PRODUCT_LOCATION),
                AddClaim(Claims.SET_PALLET_DESTINATION),
                AddClaim(Claims.DECREASE_PRODUCT_AMOUNT),
                AddClaim(Claims.GET_PRODUCTS_BY_PALLET_ID),
                AddClaim(Claims.EDIT_LOCATION_CURRENT_AMOUNT)
            };
        }

        private List<Claim> SetManagerPrivileges()
        {
            var claims = SetWarehouseManPrivileges();
            claims.Add(AddClaim(Claims.REMOVE_INVOICE));
            claims.Add(AddClaim(Claims.GET_ROLES));
            claims.Add(AddClaim(Claims.REMOVE_INVOICE));
            claims.Add(AddClaim(Claims.ADD_SENIORITY));
            claims.Add(AddClaim(Claims.EDIT_SENIORITY));
            claims.Add(AddClaim(Claims.GET_SENIORITY));
            claims.Add(AddClaim(Claims.GET_USERS));
            claims.Add(AddClaim(Claims.EDIT_USER));
            claims.Add(AddClaim(Claims.ADD_USER));
            claims.Add(AddClaim(Claims.REMOVE_INVOICE));
            return claims;
        }
        
        private List<Claim> SetGeneralAdminPrivileges()
        {
            var claims = SetManagerPrivileges();
            claims.Add(AddClaim(Claims.ADD_ROLE));
            claims.Add(AddClaim(Claims.EDIT_ROLE));
            claims.Add(AddClaim(Claims.REMOVE_ROLE));
            claims.Add(AddClaim(Claims.REMOVE_USER));
            return claims;
        }

        private static Claim AddClaim(Claims claim)
        {
            var claimName = Enum.GetName(claim);
            return new Claim("privileges", claimName);
        }
    }
}