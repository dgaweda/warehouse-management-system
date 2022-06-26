namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class ProductPalletLineDto 
    {
        public string PalletBarcode { get; set; }
        public string ProductName { get; set; }
        public int ProductAmount { get; set; }
        public string OrderBarcode { get; set; }
        public string DepartureName { get; set; }
        public string InvoiceNumber { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
