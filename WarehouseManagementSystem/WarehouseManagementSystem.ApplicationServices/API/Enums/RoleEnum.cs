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
            [Description("Zbieracz")]
            COLLECTOR = 1,

            [Description("Magazynier")]
            WAREHOUSEMAN = 2,
            
            [Description("Kierownik")]
            MANAGER = 3,

            [Description("Admin")]
            GENERAL_ADMIN = 4
        }
    }
}
