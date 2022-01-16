using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.CQRS.Helpers
{
    public static class RolesHelper
    {
        public static List<Role> FilterById(this List<Role> roles, int roleId)
        {
            if (roleId == default)
                return roles;

            return roles.Where(role => role.Id == roleId).ToList();
        }

        public static List<Role> FilterByRoleName(this List<Role> roles, string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return roles;

            return roles.Where(role => role.Name.Contains(roleName)).ToList();
        }
    }
}
