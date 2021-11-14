using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsQuery : QueryBase<List<Pallet>>
    {
        private readonly IGetEntityHelper<Pallet> _pallets;
        public GetPalletsQuery(IGetEntityHelper<Pallet> pallets)
        {
            _pallets = pallets;
        }

        public override async Task<List<Pallet>> Execute(WMSDatabaseContext context) => await _pallets.GetFilteredData(context);
    }
}
