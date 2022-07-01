using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Extensions;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsByStatusQuery : QueryBase<List<Pallet>>
    {
        public PalletStatus PalletStatus { get; set; }

        public override async Task<List<Pallet>> Execute(WMSDatabaseContext context)
        {
            var pallets = await context.GetPallets();
            
            return pallets
                .Where(x => x.PalletStatus == PalletStatus)
                .ToList();
        }
    }
}
