using System.ComponentModel;

namespace WarehouseManagementSystem.ApplicationServices.API.Enums
{
    public enum RoleKey
    {
        [Description("Zbieracz")]
        COLLECTOR = 5,

        [Description("Magazynier")]
        WAREHOUSEMAN = 11,
            
        [Description("Kierownik")]
        MANAGER = 4,

        [Description("Admin")]
        GENERAL_ADMIN = 9
    }
}