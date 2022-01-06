using DataAccess.Entities;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class PalletPropertiesSetter : IPalletPropertiesSetter
    {
        public void SetPalletProperties(Pallet pallet, Pallet Parameter)
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

        public void SetPalletStatus(Pallet pallet)
        {
            if (PalletIsDuringOrderPicking(pallet))
                pallet.PalletStatus = Status.DURING_ORDER_PICKING;
            else if (PalletWasSent(pallet))
                pallet.PalletStatus = Status.SENT;
            else if (PalletIsReadyForDeparture(pallet))
                pallet.PalletStatus = Status.READY_FOR_DEPARTURE;
            else if (PalletIsReadyToBeUnfolded(pallet))
                pallet.PalletStatus = Status.READY_TO_BE_UNFOLDED;
            else
                pallet.PalletStatus = Status.OPEN;
        }

        private bool PalletIsDuringOrderPicking(Pallet pallet) => pallet.OrderId != null && pallet.UserId != null && pallet.Order.OrderState == State.IN_PROGRESS;

        private bool PalletWasSent(Pallet pallet) => pallet.DepartureId != null && pallet.Departure.State == StateType.CLOSED;

        private bool PalletIsReadyForDeparture(Pallet pallet) => pallet.OrderId != null && pallet.Order.OrderState == State.READY_FOR_DEPARTURE;

        private bool PalletIsReadyToBeUnfolded(Pallet pallet) => pallet.InvoiceId != null;

    }
}
