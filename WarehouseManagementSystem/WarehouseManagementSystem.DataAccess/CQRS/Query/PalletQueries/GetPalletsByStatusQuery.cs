using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess.Repository.PalletRepository;

namespace DataAccess.CQRS.Query.PalletQueries
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
