using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Helpers
{
    public static class PalletHelper
    {
        public static async Task<Pallet> GetPalletBy(this WMSDatabaseContext context, int PalletId)
        {
            return await context.Pallets
                .Include(x => x.Departure)
                .Include(x => x.Order)
                .Include(x => x.Invoice.Delivery)
                .Include(x => x.User)
                .Include(x => x.User.Role)
                .Include(x => x.User.Seniority)
                .FirstOrDefaultAsync(x => x.Id == PalletId);
        }

        public static void SetProperties(this Pallet pallet, Pallet Parameter)
        {
            if (Parameter.OrderId != null && Parameter.OrderId != 0)
                pallet.OrderId = Parameter.OrderId;

            if (Parameter.DepartureId != null && Parameter.DepartureId != 0)
                pallet.DepartureId = Parameter.DepartureId;

            if (Parameter.InvoiceId != null && Parameter.InvoiceId != 0)
                pallet.InvoiceId = Parameter.InvoiceId;

            if (Parameter.UserId != null && Parameter.UserId != 0)
                pallet.UserId = Parameter.UserId;
        }

        public static void SetStatus(this Pallet pallet)
        {
            if (PalletIsDuringOrderPicking(pallet))
                pallet.PalletStatus = PalletEnum.Status.DURING_ORDER_PICKING;
            else if (PalletWasSent(pallet))
                pallet.PalletStatus = PalletEnum.Status.SENT;
            else if (PalletIsReadyForDeparture(pallet))
                pallet.PalletStatus = PalletEnum.Status.READY_FOR_DEPARTURE;
            else if (PalletIsReadyToBeUnfolded(pallet))
                pallet.PalletStatus = PalletEnum.Status.READY_TO_BE_UNFOLDED;
            else
                pallet.PalletStatus = PalletEnum.Status.OPEN;
        }

        private static bool PalletIsDuringOrderPicking(Pallet pallet) => pallet.OrderId != null && pallet.UserId != null && pallet.Order.OrderState == State.IN_PROGRESS;

        private static bool PalletWasSent(Pallet pallet) => pallet.DepartureId != null && pallet.Departure.State == StateType.CLOSED;

        private static bool PalletIsReadyForDeparture(Pallet pallet) => pallet.OrderId != null && pallet.Order.OrderState == State.READY_FOR_DEPARTURE;

        private static bool PalletIsReadyToBeUnfolded(Pallet pallet) => pallet.InvoiceId != null;
    }
}
