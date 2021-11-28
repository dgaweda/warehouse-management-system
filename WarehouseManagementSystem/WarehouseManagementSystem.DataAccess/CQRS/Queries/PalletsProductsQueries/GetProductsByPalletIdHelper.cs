using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.PalletLineQueries
{
    public class GetProductsByPalletIdHelper : IGetEntityHelper<ProductPalletLine>
    {
        public int PalletId { get; set; }
        public async Task<List<ProductPalletLine>> GetFilteredData(WMSDatabaseContext context)
        {
            var palletLines = await GetPalletLines(context);

            if (PropertiesAreEmpty())
                return palletLines;
            else
                palletLines = SearchByPallet(palletLines);

            return palletLines;
        }

        private async Task<List<ProductPalletLine>> GetPalletLines(WMSDatabaseContext context)
        {
            return await context.PalletLines
                .Include(x => x.Product)
                .Include(x => x.Pallet)
                    .ThenInclude(order => order.Order)
                .Include(x => x.Pallet)
                    .ThenInclude(departure => departure.Departure)
                .Include(x => x.Pallet)
                    .ThenInclude(invoice => invoice.Invoice)
                .Include(x => x.Pallet)
                    .ThenInclude(employee => employee.Employee)
                .ToListAsync();
        }

        public bool PropertiesAreEmpty() => PalletId == 0;

        private List<ProductPalletLine> SearchByPallet(List<ProductPalletLine> palletLines) => palletLines.Where(x => x.PalletId == PalletId).ToList();
        
    }
}
