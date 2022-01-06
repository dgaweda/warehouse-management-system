using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Enums
{
    public static class RoleEnum
    {
        public enum Roles
        {
            [Description("Kierownik")]
            MANAGER = 4,

            [Description("Zbieracz")]
            COLLECTOR = 5,

            [Description("Magazynier")]
            WAREHOUSEMAN = 11,

            [Description("Admin")]
            GENERAL_ADMIN = 9
        }
    }
}
