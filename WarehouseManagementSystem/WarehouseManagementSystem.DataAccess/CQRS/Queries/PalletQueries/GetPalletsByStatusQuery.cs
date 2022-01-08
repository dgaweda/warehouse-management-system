using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsByStatusQuery : QueryBase<List<Pallet>>
    {
        public PalletEnum.Status PalletStatus { get; set; }
        public override async Task<List<Pallet>> Execute(WMSDatabaseContext context)
        {
            return await context.Pallets
                .Include(x => x.Departure)
                .Include(x => x.Order)
                .Include(x => x.Invoice.Delivery)
                .Include(x => x.User)
                .Where(pallet => pallet.PalletStatus == PalletStatus).ToListAsync();
        }
    }
}
