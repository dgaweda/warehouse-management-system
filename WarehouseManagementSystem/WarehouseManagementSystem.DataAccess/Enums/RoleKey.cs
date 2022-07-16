using System.ComponentModel;

namespace DataAccess.Enums
{
    public enum RoleKey
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