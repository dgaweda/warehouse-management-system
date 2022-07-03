using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Repository.PalletRepository
{
    public class PalletRepository : Repository<Pallet>, IPalletRepository
    {
        public PalletRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Pallet>> GetAllAsync()
        {
            return await GetPallets().ToListAsync();
        }

        public async Task<List<Pallet>> GetPalletsByStatus(PalletStatus palletStatus)
        {
            return await GetPallets()
                .Where(x => x.PalletStatus == palletStatus)
                .ToListAsync();
        }

        private IQueryable<Pallet> GetPallets()
        {
            return DbContext.Pallets
                .Include(x => x.Departure)
                .Include(x => x.Order)
                .Include(x => x.Invoice)
                .ThenInclude(invoice => invoice.Delivery)
                .Include(x => x.User)
                .ThenInclude(user => user.Role)
                .Include(x => x.User)
                .ThenInclude(user => user.Seniority)
                .AsQueryable();
        }
    }
}