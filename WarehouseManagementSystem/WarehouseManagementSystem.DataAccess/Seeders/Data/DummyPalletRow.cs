using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Seeders.Data
{
    public class DummyPalletRow
    {
        public static List<PalletRow> GetDummyPalletRows()
        {
            return new List<PalletRow>()
            {
                new PalletRow()
                {
                    Id = Guid.NewGuid(),
                    ProductAmount = 15
                },
                new PalletRow()
                {
                    Id = Guid.NewGuid(),
                    ProductAmount = 50
                },
                new PalletRow()
                {
                    Id = Guid.NewGuid(),
                    ProductAmount = 30
                },
                new PalletRow()
                {
                    Id = Guid.NewGuid(),
                    ProductAmount = 20
                }
            };
        }

        public static void SetDummyPalletRows(WMSDatabaseContext context)
        {
            var product1 = context.Products.First();
            var product2 = context.Products.Skip(1).First();

            var pallet1 = context.Pallets.First();
            var pallet2 = context.Pallets.Skip(1).First();

            var palletRow1 = context.PalletRows.First();
            var palletRow2 = context.PalletRows.Skip(1).First();
            var palletRow3 = context.PalletRows.Skip(2).First();
            var palletRow4 = context.PalletRows.Skip(3).First();

            palletRow1.ProductId = product1.Id;
            palletRow1.PalletId = pallet1.Id;
            
            palletRow2.ProductId = product2.Id;
            palletRow2.PalletId = pallet1.Id;
            
            palletRow3.ProductId = product1.Id;
            palletRow3.PalletId = pallet2.Id;
            
            palletRow4.ProductId = product2.Id;
            palletRow4.PalletId = pallet2.Id;
        }
    }
}