using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Repository.PalletRepository;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsByStatusQuery : QueryBase<List<Pallet>>
    {
        public PalletStatus PalletStatus { get; set; }
        private readonly IPalletRepository _palletRepository;

        public GetPalletsByStatusQuery(IPalletRepository palletRepository)
        {
            _palletRepository = palletRepository;
        }

        public override async Task<List<Pallet>> Execute()
        {
            return await _palletRepository.GetPalletsByStatus(PalletStatus);
        }
    }
}
