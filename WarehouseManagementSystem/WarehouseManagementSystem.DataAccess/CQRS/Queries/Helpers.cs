using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.CQRS.Queries
{
    public static class Helpers
    {
        public static List<User> FilterByRoleName(this List<User> users, string RoleName)
        {
            if (!string.IsNullOrEmpty(RoleName))
            {
                return users.Where(x => x.Employee.Role.Name == RoleName).ToList();
            }
            return users;
        }

        public static List<User> FilterById(this List<User> users, int Id)
        {
            if (Id != 0)
            {
                return users.Where(x => x.Id == Id).ToList();
            }
            return users;
        }

        public static List<User> FilterByName(this List<User> users, string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return users.Where(x => x.Employee.Name == Name).ToList();
            }
            return users;
        }

        public static bool PropertiesAreEmpty(this object request)
        {
            var properties = request.GetType().GetProperties();
            var IsEmpty = true;

            foreach (var property in properties)
            {
                var propValue = property.GetValue(request);
                var success = int.TryParse(propValue.ToString(), out int result);

                IsEmpty = success ? result == 0 : string.IsNullOrEmpty(propValue.ToString());
            }

            return IsEmpty;
        }

    }
}
