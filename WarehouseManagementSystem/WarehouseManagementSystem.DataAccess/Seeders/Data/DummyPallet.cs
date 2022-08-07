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
    }
}