using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Enums;

namespace DataAccess.Seeders.Data
{
    public class DummyPallet
    {
        public static List<Pallet> GetDummyPallets()
        {
            return new List<Pallet>()
            {
                new Pallet()
                {
                    Barcode = "1000",
                    PalletStatus = PalletStatus.UNFOLDED,
                },
                new Pallet()
                {
                    Barcode = "1001",
                    PalletStatus = PalletStatus.SENT,
                }
            };
        }

        public static void SetDummyPallets(WMSDatabaseContext context)
        {
            var pallet1 = context.Pallets.First();
            var pallet2 = context.Pallets.Skip(1).First();

            var order = context.Orders.First();

            var user = context.Users.First();

            var invoice = context.Invoices.First();

            var departure = context.Departures.First();

            pallet1.UserId = user.Id;
            pallet1.InvoiceId = invoice.Id;

            pallet2.DepartureId = departure.Id;
            pallet2.OrderId = order.Id;
        }
    }
}