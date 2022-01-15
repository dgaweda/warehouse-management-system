using System;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NLog.LayoutRenderers;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace warehouse_management_system.Authentication
{
    public class Permission
    {
        public Claim[] SetClaims(string roleIdString)
        {
            var roleId = ParseStringToInt(roleIdString);
            var role = (Keys.Role) roleId;
            switch (role)
            {
                case Keys.Role.GENERAL_ADMIN:
                    break;
                case Keys.Role.MANAGER:
                    break;
                case Keys.Role.WAREHOUSEMAN:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Claim[] ()
        {
            return new Claim[]
            {
                new Claim("AddDelivery","Delivery"),
                new Claim("EditDelivery", "Delivery"),
                new Claim("GetDeliveries", "Delivery"),

                new Claim("AddDeparture", "Departure"),
                new Claim("EditDeparture", "Departure"),
                new Claim("GetDeparture", "Departure"),
                
                new Claim("GetInvoices", value: "Invoice"),
                new Claim("AddInvoice", "Invoice"),
                new Claim("EditInvoice", "Invoice")
            };
        }

        private int ParseStringToInt(string id)
        {
            var success = int.TryParse(id, out var roleId);
            return roleId;
        }

        private string ParseEnumToString(Keys.Role role)
        {
            return Enum.GetName(role);
        }
    }
}