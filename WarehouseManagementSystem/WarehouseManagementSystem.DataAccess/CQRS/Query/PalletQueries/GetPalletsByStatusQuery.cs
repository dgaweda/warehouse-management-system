using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Repository.PalletRepository;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsByStatusQuery : QueryBase<List<Pallet>, IPalletRepository>
    {
        public PalletStatus PalletStatus { get; set; }

        public override async Task<List<Pallet>> Execute(IPalletRepository palletRepository)
        {
            return await palletRepository.GetPalletsByStatus(PalletStatus);
        }
    }
}
