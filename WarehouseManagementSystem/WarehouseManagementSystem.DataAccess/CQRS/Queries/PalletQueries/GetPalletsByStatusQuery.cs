using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsByStatusQuery : QueryBase<List<Pallet>>
    {
        public PalletEnum.Status PalletStatus { get; set; }

        public override async Task<List<Pallet>> Execute(WMSDatabaseContext context)
        {
            var pallets = await context.GetPallets();
            
            return pallets
                .Where(x => x.PalletStatus == PalletStatus)
                .ToList();
        }
    }
}
