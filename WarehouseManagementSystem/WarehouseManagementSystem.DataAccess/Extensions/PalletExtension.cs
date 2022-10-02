using System;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Enums;

namespace DataAccess.Extensions
{
    public static class PalletExtension
    {
        public static void SetProperties(this Pallet pallet, Pallet parameter)
        {
            if (parameter.OrderId != null)
                pallet.OrderId = parameter.OrderId;

            if (parameter.DepartureId != null)
                pallet.DepartureId = parameter.DepartureId;

            if (parameter.InvoiceId != null)
                pallet.InvoiceId = parameter.InvoiceId;

            if (parameter.UserId != null)
                pallet.UserId = parameter.UserId;
        }

        public static void SetStatus(this Pallet pallet)
        {
            if (pallet.IsDuringOrderPicking())
                pallet.PalletStatus = PalletStatus.DURING_ORDER_PICKING;
            else if (pallet.WasSent())
                pallet.PalletStatus = PalletStatus.SENT;
            else if (pallet.IsReadyForDeparture())
                pallet.PalletStatus = PalletStatus.READY_FOR_DEPARTURE;
            else if (pallet.IsReadyToBeUnfolded())
                pallet.PalletStatus = PalletStatus.READY_TO_BE_UNFOLDED;
            else
                pallet.PalletStatus = PalletStatus.OPEN;
        }

        private static bool IsDuringOrderPicking(this Pallet pallet)
        {
            return pallet.OrderId != null && pallet.UserId != null && pallet.Order.OrderState == OrderState.IN_PROGRESS;
        }

        private static bool WasSent(this Pallet pallet)
        {
            return pallet.DepartureId != null && pallet.Departure.State == StateType.CLOSED;
        }

        private static bool IsReadyForDeparture(this Pallet pallet) {
            return pallet.OrderId != null && pallet.Order.OrderState == OrderState.READY_FOR_DEPARTURE;
        }

        private static bool IsReadyToBeUnfolded(this Pallet pallet) {
            return pallet.InvoiceId != null;
        }

        // FILTERING
        public static IQueryable<Pallet> FilterByPickingEnd(this IQueryable<Pallet> pallets, DateTime pickingEnd)
        {
            if (pickingEnd == default)
                return pallets;

            return pallets.Where(x => x.Order.PickingEnd == pickingEnd);
        }

        public static IQueryable<Pallet> FilterByProvider(this IQueryable<Pallet> pallets, string provider)
        {
            if (string.IsNullOrEmpty(provider))
                return pallets;

            return pallets.Where(x => x.Invoice.Provider == provider);
        }

        public static IQueryable<Pallet> FilterByDeliveryName(this IQueryable<Pallet> pallets, string deliveryName)
        {
            if (string.IsNullOrEmpty(deliveryName))
                return pallets;

            return pallets.Where(x => x.Invoice.Delivery.Name == deliveryName);
        }

        public static IQueryable<Pallet> FilterByUserFirstName(this IQueryable<Pallet> pallets, string userFirstName)
        {
            if (string.IsNullOrEmpty(userFirstName))
                return pallets;

            return pallets.Where(x => x.User.Name == userFirstName);
        }

        public static IQueryable<Pallet> FilterByUserLastName(this IQueryable<Pallet> pallets, string userLastName)
        {
            if (string.IsNullOrEmpty(userLastName))
                return pallets;

            return pallets.Where(x => x.User.Lastname == userLastName);
        }

        public static IQueryable<Pallet> FilterByDepartureName(this IQueryable<Pallet> pallets, string departureName)
        {
            if (string.IsNullOrEmpty(departureName))
                return pallets;

            return pallets.Where(x => x.Departure.Name == departureName);
        }

        public static IQueryable<Pallet> FilterByDepartureCloseTime(this IQueryable<Pallet> pallets, DateTime departureCloseTime)
        {
            if (departureCloseTime == default)
                return pallets;

            return pallets.Where(x => x.Departure.CloseTime == departureCloseTime);
        }
    }
}
