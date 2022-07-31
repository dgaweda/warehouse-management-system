using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.PalletRepository
{
    public class PalletRepository : Repository<Pallet>, IPalletRepository
    {
        public PalletRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Pallet>> GetPalletsByStatus(PalletStatus palletStatus)
        {
            return await GetAll()
                .Where(x => x.PalletStatus == palletStatus)
                .ToListAsync();
        }

        public override IQueryable<Pallet> GetAll()
        {
            return Entity
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