using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WarehouseManagementSystem.ApplicationServices.API.Enums;
using static System.Int32;


namespace warehouse_management_system.Authentication
{
    public class PrivilegesService : IPrivilegesService
    {
        public void SetUserPrivileges(ClaimsPrincipal claimsPrincipal)
        {
            var role = ParseUserRoleToEnum(claimsPrincipal);
            var claims = role switch
            {
                
                RoleKey.GENERAL_ADMIN => SetGeneralAdminPrivileges(),
                RoleKey.MANAGER => SetManagerPrivileges(),
                RoleKey.WAREHOUSEMAN => SetWarehouseManPrivileges(),
                RoleKey.COLLECTOR => SetCollectorPrivileges(),
                _ => throw new ArgumentOutOfRangeException()
            };
            AddUserClaims(claims, claimsPrincipal);
        }
        
        private static RoleKey ParseUserRoleToEnum(ClaimsPrincipal user)
        {
            var roleIdString = user.FindFirstValue(ClaimTypes.Role);

            if (TryParse(roleIdString, out var roleId))
            {
                return (RoleKey)roleId;
            }
            throw new InvalidOperationException("Parse Error");
        }

        private void AddUserClaims(IEnumerable<Claim> claims, ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal.Identities.First().AddClaims(claims);
        }
        
        private static List<Claim> SetWarehouseManPrivileges()
        {
            return new List<Claim>
            {
                AddClaim(Privilege.ADD_PALLET),
                AddClaim(Privilege.ADD_INVOICE),
                AddClaim(Privilege.ADD_PRODUCT),
                AddClaim(Privilege.GET_PALLETS),
                AddClaim(Privilege.ADD_DELIVERY),
                AddClaim(Privilege.ADD_LOCATION),
                AddClaim(Privilege.EDIT_INVOICE),
                AddClaim(Privilege.EDIT_PRODUCT),
                AddClaim(Privilege.GET_INVOICES),
                AddClaim(Privilege.GET_LOCATIONS),
                AddClaim(Privilege.GET_PRODUCTS),
                AddClaim(Privilege.ADD_DEPARTURE),
                AddClaim(Privilege.EDIT_DELIVERY),
                AddClaim(Privilege.EDIT_LOCATION),
                AddClaim(Privilege.GET_DEPARTURES),
                AddClaim(Privilege.REMOVE_PALLET),
                AddClaim(Privilege.EDIT_DEPARTURE),
                AddClaim(Privilege.GET_DELIVERIES),
                AddClaim(Privilege.REMOVE_PRODUCT),
                AddClaim(Privilege.REMOVE_DELIVERY),
                AddClaim(Privilege.REMOVE_LOCATION),
                AddClaim(Privilege.REMOVE_DEPARTURE),
                AddClaim(Privilege.GET_PALLETS_BY_STATUS),
                AddClaim(Privilege.SET_PRODUCT_LOCATION),
                AddClaim(Privilege.SET_PALLET_DESTINATION),
                AddClaim(Privilege.DECREASE_PRODUCT_AMOUNT),
                AddClaim(Privilege.GET_PRODUCTS_BY_PALLET_ID),
                AddClaim(Privilege.EDIT_LOCATION_CURRENT_AMOUNT),
                AddClaim(Privilege.GET_ORDERS)
            };
        }

        private List<Claim> SetManagerPrivileges()
        {
            var claims = SetWarehouseManPrivileges();
            claims.Add(AddClaim(Privilege.REMOVE_INVOICE));
            claims.Add(AddClaim(Privilege.GET_ROLES));
            claims.Add(AddClaim(Privilege.REMOVE_INVOICE));
            claims.Add(AddClaim(Privilege.ADD_SENIORITY));
            claims.Add(AddClaim(Privilege.EDIT_SENIORITY));
            claims.Add(AddClaim(Privilege.GET_SENIORITIES));
            claims.Add(AddClaim(Privilege.GET_USERS));
            claims.Add(AddClaim(Privilege.EDIT_USER));
            claims.Add(AddClaim(Privilege.ADD_USER));
            claims.Add(AddClaim(Privilege.REMOVE_INVOICE));
            claims.Add(AddClaim(Privilege.ADD_ORDER));
            claims.Add(AddClaim(Privilege.ADD_ORDERLINE));
            claims.Add(AddClaim(Privilege.EDIT_ORDER));
            claims.Add(AddClaim(Privilege.REMOVE_ORDER));
            return claims;
        }
        
        private List<Claim> SetGeneralAdminPrivileges()
        {
            var claims = SetManagerPrivileges();
            claims.Add(AddClaim(Privilege.ADD_ROLE));
            claims.Add(AddClaim(Privilege.EDIT_ROLE));
            claims.Add(AddClaim(Privilege.REMOVE_ROLE));
            claims.Add(AddClaim(Privilege.REMOVE_USER));
            return claims;
        }

        private static List<Claim> SetCollectorPrivileges()
        {
            return new List<Claim>()
            {
                AddClaim(Privilege.GET_ORDERS),
                AddClaim(Privilege.GET_PRODUCTS),
                AddClaim(Privilege.ADD_PALLET),
                AddClaim(Privilege.GET_PALLETS)
            };
        }

        private static Claim AddClaim(Privilege claimName)
        {
            return new Claim("Privileges", Privileges.Get(claimName));
        }
    }
}