using System.Collections.Generic;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Models
{
    public class Pallet
    {
        public string PalletStatus { get; set; }
        public string Barcode { get; set; }
        public string OrderBarcode{ get; set; }
        public string DepartureName { get; set; }
        public string DeliveryName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public List<object> Products { get; set; }
    }
}
