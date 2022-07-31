using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Seed
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
    }
}