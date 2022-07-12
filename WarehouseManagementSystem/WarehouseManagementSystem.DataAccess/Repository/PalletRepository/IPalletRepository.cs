using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.Repository.PalletRepository
{
    public interface IPalletRepository : IRepository<Pallet>
    {
        Task<List<Pallet>> GetPalletsByStatus(PalletStatus palletStatus);
    }
}