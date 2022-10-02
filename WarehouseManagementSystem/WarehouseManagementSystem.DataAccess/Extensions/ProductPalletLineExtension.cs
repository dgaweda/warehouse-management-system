using System;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess.Exceptions;

namespace DataAccess.Extensions
{
    public static class ProductPalletLineExtension
    {
        public static void DecreaseProductAmount(this PalletRow palletRow, PalletRow requestPalletRow)
        {
            palletRow.ProductAmount -= requestPalletRow.ProductAmount;
            if (palletRow.ProductAmount < 0)
                throw new OutOfRangeException("Amount can't be less than 0.");
        }

        public static void SetPalletStatus(this Pallet pallet)
        {
            pallet.PalletStatus = PalletStatus.UNFOLDED;
        }

        public static IQueryable<PalletRow> FilterByPalletId(this IQueryable<PalletRow> palletLines, Guid palletId)
        {
            if (palletId == Guid.Empty)
                return palletLines;

            return palletLines.Where(x => x.PalletId == palletId);
        }
    }
}
