using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DataAccess.Entities.EntityBases;
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

        private static void AddUserClaims(IEnumerable<Claim> claims, ClaimsPrincipal claimsPrincipal)
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

        private List<Claim> SetCollectorPrivileges()
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

        public static string GetClaimName(Privilege claimName)
        {
            return Privileges.Get(claimName);
        }

        public static List<string> GetWarehouseManPrivileges()
        {
            return new()
            {
                GetClaimName(Privilege.ADD_PALLET),
                GetClaimName(Privilege.ADD_INVOICE),
                GetClaimName(Privilege.ADD_PRODUCT),
                GetClaimName(Privilege.GET_PALLETS),
                GetClaimName(Privilege.ADD_DELIVERY),
                GetClaimName(Privilege.ADD_LOCATION),
                GetClaimName(Privilege.EDIT_INVOICE),
                GetClaimName(Privilege.EDIT_PRODUCT),
                GetClaimName(Privilege.GET_INVOICES),
                GetClaimName(Privilege.GET_LOCATIONS),
                GetClaimName(Privilege.GET_PRODUCTS),
                GetClaimName(Privilege.ADD_DEPARTURE),
                GetClaimName(Privilege.EDIT_DELIVERY),
                GetClaimName(Privilege.EDIT_LOCATION),
                GetClaimName(Privilege.GET_DEPARTURES),
                GetClaimName(Privilege.REMOVE_PALLET),
                GetClaimName(Privilege.EDIT_DEPARTURE),
                GetClaimName(Privilege.GET_DELIVERIES),
                GetClaimName(Privilege.REMOVE_PRODUCT),
                GetClaimName(Privilege.REMOVE_DELIVERY),
                GetClaimName(Privilege.REMOVE_LOCATION),
                GetClaimName(Privilege.REMOVE_DEPARTURE),
                GetClaimName(Privilege.GET_PALLETS_BY_STATUS),
                GetClaimName(Privilege.SET_PRODUCT_LOCATION),
                GetClaimName(Privilege.SET_PALLET_DESTINATION),
                GetClaimName(Privilege.DECREASE_PRODUCT_AMOUNT),
                GetClaimName(Privilege.GET_PRODUCTS_BY_PALLET_ID),
                GetClaimName(Privilege.EDIT_LOCATION_CURRENT_AMOUNT),
                GetClaimName(Privilege.GET_ORDERS)
            };
        }
        
        public static List<string> GetManagerPrivileges()
        {
            var claims = GetWarehouseManPrivileges();
            claims.Add(GetClaimName(Privilege.REMOVE_INVOICE));
            claims.Add(GetClaimName(Privilege.GET_ROLES));
            claims.Add(GetClaimName(Privilege.REMOVE_INVOICE));
            claims.Add(GetClaimName(Privilege.ADD_SENIORITY));
            claims.Add(GetClaimName(Privilege.EDIT_SENIORITY)); 
            claims.Add(GetClaimName(Privilege.GET_SENIORITIES));
            claims.Add(GetClaimName(Privilege.GET_USERS));
            claims.Add(GetClaimName(Privilege.EDIT_USER));
            claims.Add(GetClaimName(Privilege.ADD_USER));
            claims.Add(GetClaimName(Privilege.REMOVE_INVOICE));
            return claims;
        }
        
        public static List<string> GetGeneralAdminPrivileges()
        {
            var claims = GetManagerPrivileges();
            claims.Add(GetClaimName(Privilege.ADD_ROLE));
            claims.Add(GetClaimName(Privilege.EDIT_ROLE));
            claims.Add(GetClaimName(Privilege.REMOVE_ROLE));
            claims.Add(GetClaimName(Privilege.REMOVE_USER));
            return claims;
        }
    }
}