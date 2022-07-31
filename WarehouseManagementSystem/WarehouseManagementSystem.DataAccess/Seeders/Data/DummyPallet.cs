using System;
using System.Collections.Generic;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Seed
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