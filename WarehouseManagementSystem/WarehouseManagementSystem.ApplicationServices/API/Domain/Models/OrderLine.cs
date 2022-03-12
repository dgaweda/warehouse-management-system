namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class OrderLine
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}