using System.ComponentModel;

namespace WarehouseManagementSystem.ApplicationServices.API.Enums
{
    public enum PalletStatus
    {
        [Description("Otwarta")]
        OPEN,                   // After pallet add (default), when pallet is unfolded (no products on pallet), when no Ids are filled

        [Description("W czasie realizacji zamówienia")]
        DURING_ORDER_PICKING,   // when only OrderId and EmployeeId is filled and Order.State = In_Progress

        [Description("Gotowa do wyjazdu")]
        READY_FOR_DEPARTURE,    // when OrderID, EmployeeID and DepartureID is filled and order.State = Ready_for_departure

        [Description("Wysłana")]
        SENT,                   // when OrderID, EmployeeID and DepartureID is filled + DepartureState = CLOSED

        [Description("Gotowa do rozłożenia")]
        READY_TO_BE_UNFOLDED,   // when only InvoiceId is filled

        [Description("Rozłożona")]
        UNFOLDED                // when there is nor product on the pallet
    }
}