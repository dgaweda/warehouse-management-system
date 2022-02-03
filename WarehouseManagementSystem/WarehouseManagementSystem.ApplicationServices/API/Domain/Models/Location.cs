namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Location
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int CurrentAmount { get; set; }
        public int MaxAmount { get; set; }
        public string ProductName { get; set; }
        public int? PalletId { get; set; }
    }
}
