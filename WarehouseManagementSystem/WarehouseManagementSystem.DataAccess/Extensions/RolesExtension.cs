﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class RolesExtension
    {
        public static List<Role> FilterById(this List<Role> roles, Guid roleId)
        {
            if (roleId == default)
                return roles;

            return roles.Where(x => x.Id.Equals(roleId)).ToList();
        }

        public static List<Role> FilterByRoleName(this List<Role> roles, string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return roles;

            return roles.Where(role => role.Name.Contains(roleName)).ToList();
        }
    }
}
